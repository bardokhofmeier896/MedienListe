/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Phil
 * Datum: 07.05.2014
 * Zeit: 22:30
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;

namespace MedienListe
{
	/// <summary>
	/// Description of NamePuffer.
	/// </summary>
	public class NamePuffer
	{
		public int ID{ get; set; }
		public string Name{ get; set; }
		
		public override string ToString()
		{
			return Name;
		}

	}
}
