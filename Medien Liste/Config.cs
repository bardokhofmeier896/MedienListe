/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Phil
 * Datum: 15.04.2014
 * Zeit: 19:37
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MedienListe
{
	/// <summary>
	/// Description of Config.
	/// </summary>
	public class Config
	{
		private static Config config;
		private string configPath;
		
		public Size LastMainWindowSize{ get; set; }
		public Point LastMainWindowLocation{ get; set; }
		public string DatabaseLocation{ get; set; }

		private bool breakOnCharChange;
		
		private Config()
		{
			configPath = "config.ini";
			breakOnCharChange = true;
			
			LastMainWindowSize = new Size(200, 200);
			LastMainWindowLocation = new Point(0, 0);
		}
		
		public static Config getInstance()
		{
			if(config == null)
			{
				config = new Config();
				config.readConfig();
			}
			return config;
		}
		
		public bool breakOnCharChangeByMode(int displaymode)
		{
			
			MessageBox.Show("Config.breakOnCharChangeByMode: Unfertig");
			
			return breakOnCharChange;
		}
		
		public void readConfig()
		{
			StreamReader myFile = null;
			try
			{
				if(File.Exists(configPath))
			   	{
					myFile = new StreamReader(configPath);
					//StreamReader myFile = new StreamReader(configPath);
					
					string line;
					while((line = myFile.ReadLine()) != null)
					{
						if(line.Length < 1 || line.StartsWith("//"))
							continue;
						
						string[] sline = line.Split('=');
						string[] values = sline[1].Split(';');
						
						switch(sline[0])
						{
							case "size":
								int width = Int32.Parse(values[0]);
								int heigth = Int32.Parse(values[1]);
								if(width >= 0 && heigth >= 0)
									LastMainWindowSize = new Size(width, heigth);
								break;
							case "location":
								int x = Int32.Parse(values[0]);
								int y = Int32.Parse(values[1]);
								if(x >= 0 && y >= 0)
									LastMainWindowLocation = new Point(x, y);
								break;
							case "breakOnCharChange":
								breakOnCharChange = Boolean.Parse(values[0]);
								break;
							case "databaseLocation":
								DatabaseLocation = values[0];
								break;
							default:
								throw new NotImplementedException();
						}
					}
			   	}
				else
				{	
					LastMainWindowSize = new Size(0, 0);
					LastMainWindowLocation = new Point(100, 100);	
					breakOnCharChange = true;
					
					MessageBox.Show("Configurationsdatei konnte nicht gefunden werden oder ist defekt. Es werden Standartwerte genutzt.");
				}
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				myFile.Close();
			}
		}
		
		public void writeConfig()
		{
			StreamWriter file = null;
			try
			{
				if(File.Exists(configPath))
					File.Delete(configPath);
				
				file = new StreamWriter(configPath);
				//StreamWriter file = new StreamWriter(configPath);
				
				writeConfigHeader(file);
				file.WriteLine(string.Format("size={0};{1}", LastMainWindowSize.Width, LastMainWindowSize.Height));
				file.WriteLine(string.Format("location={0};{1}", LastMainWindowLocation.X, LastMainWindowLocation.Y));
				file.WriteLine(string.Format("breakOnCharChange={0}", breakOnCharChange.ToString()));
				file.WriteLine(string.Format("databaseLocation={0}", DatabaseLocation));
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				file.Close();
			}
		}
		
		private void writeConfigHeader(StreamWriter file)
		{
			file.WriteLine("// Die Zeilen müssen immer nach folgendem Schema aufgebaut sein:");
			file.WriteLine("// var=val;val...");
			file.WriteLine("// '//' leiten Kommentarzeilen ein, Leerzeilen sind erlaubt.");
			file.WriteLine("");
		}
	}
}
