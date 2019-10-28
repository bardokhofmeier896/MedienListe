/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Phil
 * Datum: 13.03.2014
 * Zeit: 15:53
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;

namespace MedienListe
{
	/// <summary>
	/// Description of Detail.
	/// </summary>
	public class Detail : IComparable<Detail>
	{
		public int MediaID{ get; private set; }
		public int MediaSequenzID{ get; set; }
		public string Name{ get; set; }
		public Language ViewLanguage{ get; set; }
		public Status AktivStatus{ get; set; }
		public bool isRepeat{ get; set; }
		public int LastSeenEpisode{ get; set; }
		public int LastSeenSeason{ get; set; }
		public bool LastSeenSeasonFinished{ get; set; }
		
		public Detail(int mediaID)
		{
			MediaID = mediaID;
		}	

		public int CompareTo(Detail other)
		{
			return MediaSequenzID.CompareTo(other.MediaSequenzID);
		}
		
		public enum Language
		{
			english, 
			german, 
			englishESub, //Englisch mit englischen Untertiteln
			englishDSub, //Englisch mit deutschen Untertiteln
			japESub, //Japanisch mit englischen Untertiteln
			japDSub //Japanisch mit deutschen Untertiteln
		}
		
		public enum Status
		{
			unseen = 1, //Bisher nur gefunden
			aktiv = 2, //Wird aktiv geguckt
			paused = 3, //Keine neuen Folgen verfügbar aber Serie nicht beendet
			stopped = 4, //Wurde aufgehört zu gucken (Grund egal)
			finished = 5, //Serie beendet
			bad = 6, //Einfach nur schlecht
		}
	}
}
