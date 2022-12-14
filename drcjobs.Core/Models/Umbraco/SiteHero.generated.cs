//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v8.18.5
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder.Embedded;

namespace Umbraco.Web.PublishedModels
{
	// Mixin Content Type with alias "siteHero"
	/// <summary>Site Hero</summary>
	public partial interface ISiteHero : IPublishedElement
	{
		/// <summary>Button</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		global::Umbraco.Web.Models.Link Button { get; }

		/// <summary>Text Align</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		string HeroAlign { get; }

		/// <summary>Overlay Intensity</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		decimal HeroAlpha { get; }

		/// <summary>Overlay Color</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		string HeroLook { get; }

		/// <summary>Background Image</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		global::Umbraco.Core.Models.MediaWithCrops Image { get; }

		/// <summary>Label</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		string Label { get; }

		/// <summary>Title</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		string Title { get; }

		/// <summary>Vimeo Video Loop</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		string Video { get; }
	}

	/// <summary>Site Hero</summary>
	[PublishedModel("siteHero")]
	public partial class SiteHero : PublishedElementModel, ISiteHero
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public new const string ModelTypeAlias = "siteHero";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<SiteHero, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public SiteHero(IPublishedElement content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Button
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		[ImplementPropertyType("button")]
		public virtual global::Umbraco.Web.Models.Link Button => GetButton(this);

		/// <summary>Static getter for Button</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public static global::Umbraco.Web.Models.Link GetButton(ISiteHero that) => that.Value<global::Umbraco.Web.Models.Link>("button");

		///<summary>
		/// Text Align
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		[ImplementPropertyType("heroAlign")]
		public virtual string HeroAlign => GetHeroAlign(this);

		/// <summary>Static getter for Text Align</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public static string GetHeroAlign(ISiteHero that) => that.Value<string>("heroAlign");

		///<summary>
		/// Overlay Intensity
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		[ImplementPropertyType("heroAlpha")]
		public virtual decimal HeroAlpha => GetHeroAlpha(this);

		/// <summary>Static getter for Overlay Intensity</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public static decimal GetHeroAlpha(ISiteHero that) => that.Value<decimal>("heroAlpha");

		///<summary>
		/// Overlay Color
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		[ImplementPropertyType("heroLook")]
		public virtual string HeroLook => GetHeroLook(this);

		/// <summary>Static getter for Overlay Color</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public static string GetHeroLook(ISiteHero that) => that.Value<string>("heroLook");

		///<summary>
		/// Background Image
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		[ImplementPropertyType("image")]
		public virtual global::Umbraco.Core.Models.MediaWithCrops Image => GetImage(this);

		/// <summary>Static getter for Background Image</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public static global::Umbraco.Core.Models.MediaWithCrops GetImage(ISiteHero that) => that.Value<global::Umbraco.Core.Models.MediaWithCrops>("image");

		///<summary>
		/// Label
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		[ImplementPropertyType("label")]
		public virtual string Label => GetLabel(this);

		/// <summary>Static getter for Label</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public static string GetLabel(ISiteHero that) => that.Value<string>("label");

		///<summary>
		/// Title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		[ImplementPropertyType("title")]
		public virtual string Title => GetTitle(this);

		/// <summary>Static getter for Title</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public static string GetTitle(ISiteHero that) => that.Value<string>("title");

		///<summary>
		/// Vimeo Video Loop: Only the number - not entire URL. Note: Video uses image as fallback/preloader.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		[ImplementPropertyType("video")]
		public virtual string Video => GetVideo(this);

		/// <summary>Static getter for Vimeo Video Loop</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.18.5")]
		public static string GetVideo(ISiteHero that) => that.Value<string>("video");
	}
}
