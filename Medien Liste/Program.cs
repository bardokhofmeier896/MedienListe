/*
 * Created by SharpDevelop.
 * User: Philipp
 * Date: 20.08.2013
 * Time: 16:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace MedienListe
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{/*
			Database d = Database.getInstance();
			
			List<Detail> list = d.DebugSelect();
			MessageBox.Show("Die Daten wurde runtergeladen.");
			d.DebugInsert(list);*/
			
			
			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		
		public static void Exit()
		{
			Application.Exit();
		}
	}
}
