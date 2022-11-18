using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace drcjobs.Core.Utilities
{
	public class SerializableSingletonHelper<TSingleton> where TSingleton : class
	{

		/// <summary>
		/// Instantiates this helper. Assign to a private static readonly field in your singleton.
		/// </summary>
		/// <param name="creator">Function that creates an instance of the singleton. If not specified, the singleton must have a public default constructor (not good).</param>
		/// <param name="cacheFileName">Name of the cache file. Defaults to the instance class name, with .bin extension</param>
		/// <param name="intervalBeforeExpiry">Interval before access will cause this helper to try creating a new instance in the background</param>
		/// <param name="maximumInstanceAge">Interval before the instance becomes unretrievable and must be recreated in the foreground (should normally not happen, since background creation should have kicked in).</param>
		/// <param name="disableSerialization">If set to true, this helper will just handle lazy instantiation and expiry, and will not do any serialization or deserialization.</param>
		public SerializableSingletonHelper(Func<TSingleton> creator = null, string cacheFileName = null, TimeSpan? intervalBeforeExpiry = null, TimeSpan? maximumInstanceAge = null, bool disableSerialization = false)
		{
			this.creator = creator ?? (() => Activator.CreateInstance(typeof(TSingleton)) as TSingleton); //assume public default constructor if not specified (though it's better for a singleton to have a private constructor).
			this.cacheFileName = cacheFileName ?? (typeof(TSingleton).Name + ".bin");
			this.intervalBeforeExpiry = intervalBeforeExpiry ?? TimeSpan.FromMinutes(120); //assume two hours if not specified.
			this.maximumInstanceAge = maximumInstanceAge ?? TimeSpan.FromHours(48); //2 days if not specified.
			this.disableSerialization = disableSerialization;
		}

		private Func<TSingleton> creator;
		private InstanceContainer container;
		private readonly TimeSpan intervalBeforeExpiry;
		private readonly TimeSpan maximumInstanceAge;
		private readonly string cacheFileName;
		private SemaphoreSlim instanceMakerLockObject = new SemaphoreSlim(1); //has to be a semaphore, since we need to be able to lock/unlock on different threads.
		private bool disableSerialization;

		public TSingleton Instance
		{
			get
			{
				//if there is no instance, then try to load from serialized image - even if it's going to be a very old copy...
				if (!disableSerialization)
				{
					if (container == null) //only try to get lock if we have to...
					{
						try
						{
							instanceMakerLockObject.Wait();
							if (container == null) //see if instance is still null, now that we got the lock...
							{
								//load from serialized image...
								try
								{
									IFormatter formatter = new BinaryFormatter();
									using (Stream stream = new FileStream(Path.Combine(HttpRuntime.AppDomainAppPath, cacheFileName), FileMode.Open, FileAccess.Read))
									{
										container = (InstanceContainer)formatter.Deserialize(stream);
									}
								}
								catch (Exception e)
								{
									DeserializationError = e.ToString();
									//ignore, since this can fail if the file does not exist yet etc.
								}
							}
						}
						finally
						{
							instanceMakerLockObject.Release();
						}
					}
				}

				if (MaximumAgeExceeded) //deserialize failed, or maximum age exceeded... make a new one...
				{
					try
					{
						instanceMakerLockObject.Wait();
						if (MaximumAgeExceeded) //check that it wasn't recreated by someone else while we were waiting for the lock...
						{
							container = MakeNewInstance();
						}
					}
					finally
					{
						instanceMakerLockObject.Release();
					}
				}

				//if the current instance is old (but not neccesarily exceeding maximum age), and no one is currently creating a new copy...
				if (Expired && instanceMakerLockObject.Wait(0))
				{
					//make a new copy in a background task....
					Task.Run(() => {
						try
						{
							container = MakeNewInstance();
						}
						finally { instanceMakerLockObject.Release(); }
					});
				}

				var c = container; //not locked. atomic. container can not be null here.
				return c.instance;
			}
		}

		public string DeserializationError { get; private set; }

		private InstanceContainer MakeNewInstance()
		{
			var newInstanceContainer = new InstanceContainer(creator());

			if (!disableSerialization)
			{
				IFormatter formatter = new BinaryFormatter();
				using (Stream stream = new FileStream(Path.Combine(HttpRuntime.AppDomainAppPath, cacheFileName), FileMode.OpenOrCreate, FileAccess.Write))
				{
					formatter.Serialize(stream, newInstanceContainer);
				}
			}

			return newInstanceContainer;
		}

		//copy ref for atomocity.
		private bool Expired { get { var c = container; return c == null || (DateTime.Now - c.createTime > intervalBeforeExpiry || c.invalidated); } }

		//this is "extra expired" :). copy ref for atomocity.
		private bool MaximumAgeExceeded { get { var c = container; return c == null || (DateTime.Now - c.createTime > maximumInstanceAge || c.invalidated); } }

		public void Invalidate() { var c = container; if (c != null) { c.invalidated = true; } }

		[Serializable]
		class InstanceContainer
		{
			public InstanceContainer(TSingleton ins) { createTime = DateTime.Now; instance = ins; }
			public readonly DateTime createTime;
			public readonly TSingleton instance;
			public bool invalidated;
		}
	}
}
