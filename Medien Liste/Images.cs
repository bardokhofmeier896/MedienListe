/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Phil
 * Datum: 13.03.2016
 * Zeit: 21:51
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.Drawing;
using System.IO;

namespace MedienListe
{
	/// <summary>
	/// Description of Images.
	/// </summary>
	public static class Images
	{
		private static Image imageDefault;
		private static Image imageRaiseEpisode;
		private static Image imageRaiseSeason;
		private static Image imageEdit;
		private static Image imageDelete;
		
		public static Image Default
		{
			get
			{
				if(imageDefault == null)
					imageDefault = getImage("default");
				
				return imageDefault;
			}
		}
		
		public static Image RaiseEpisode
		{
			get
			{
				if(imageRaiseEpisode == null)
					imageRaiseEpisode = getImage("add");
				
				return imageRaiseEpisode;
			}
		}
		
		public static Image RaiseSeason
		{
			get
			{
				if(imageRaiseSeason == null)
					imageRaiseSeason = getImage("add2");
				
				return imageRaiseSeason;
			}
		}
		
		public static Image Edit
		{
			get
			{
				if(imageEdit == null)
					imageEdit = getImage("edit");
				
				return imageEdit;
			}
		}
		
		public static Image Delete
		{
			get
			{
				if(imageDelete == null)
					imageDelete = getImage("delete");
				
				return imageDelete;
			}
		}
		
		private static Image getImage(string identifier)
		{
			System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
			Stream myStream = myAssembly.GetManifestResourceStream(identifier);
	   		return Image.FromStream(myStream);	 
		}
	}
}
