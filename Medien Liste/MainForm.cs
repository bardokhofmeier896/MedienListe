/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Philipp
 * Datum: 20.08.2013
 * Zeit: 17:27
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace MedienListe
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private Database database;
		private Config config;
		
		public MainForm()
		{
			InitializeComponent();
			
			textBoxFilter.MouseWheel += (s, e) =>
			{
				// disable once ConvertToLambdaExpression
				pictureListContent.Focus();
			};
			/*pictureListContent.PreviewKeyDown += (s, e) =>
			{
				string key = e.KeyCode.ToString().ToLower();
				if(key.Length == 1 && Char.IsLetterOrDigit(key, 0))
					textBoxFilter.Text +=  key; //Überprüfen ob Taste ein Buchstabe war
				
				textBoxFilter.Focus();
				textBoxFilter.SelectionStart = textBoxFilter.Text.Length;
			};*/
			
			config = Config.getInstance();
			database = Database.getInstance();
			
			buttonClearFilter.Image = Images.Delete;
			
			aktivToolStripMenuItem.Checked = true;
			DisplayContentChanged(aktivToolStripMenuItem, null);
		}
		
		void DisplayContentChanged(object sender, EventArgs e)
		{
			allSeriesToolStripMenuItem.Checked = false;
			DisplayContentChanged(sender);
		}
		
		private void DisplayContentChanged(object sender)
		{
			pictureListContent.Clear();
			
			var ret = new List<int>(6);
			
			var isAll = (ToolStripMenuItem) sender == allSeriesToolStripMenuItem;
			
			foreach(ToolStripMenuItem item in anzeigeToolStripMenuItem.DropDownItems)
			{
				if(item != allSeriesToolStripMenuItem && (item.Checked || isAll))
				{
					var temp = Regex.Split(item.Name, "ToolStripMenuItem")[0];
					var temp2 = (Detail.Status) Enum.Parse(typeof(Detail.Status), temp);
					ret.Add((int) temp2);
				}
			}
			
			pictureListContent.addRange(database.getData("Serie", ret));
			pictureListContent.Focus();
		}	
		
		void TextBoxFilterTextChanged(object sender, EventArgs e)
		{
			pictureListContent.setFilter(textBoxFilter.Text);
			pictureListContent.Refresh();
		}	
		
		void ButtonClearFilterClick(object sender, EventArgs e)
		{
			textBoxFilter.Text = "";
			pictureListContent.Focus();
		}
		
		void BeendenToolStripMenuItemClick(object sender, EventArgs e)
		{
			Program.Exit();
		}
		
		void NurTextToolStripMenuItemClick(object sender, EventArgs e)
		{
			mitCoverToolStripMenuItem.Checked = false;
			
			pictureListContent.setDisplayMode(PictureList.DisplayMode.PlainText);
			pictureListContent.Refresh();
		}
		
		void MitCoverToolStripMenuItemClick(object sender, EventArgs e)
		{
			nurTextToolStripMenuItem.Checked = false;
			
			pictureListContent.setDisplayMode(PictureList.DisplayMode.Pictures);
			pictureListContent.Refresh();
		}
		
		void NeuerEintragToolStripMenuItemClick(object sender, EventArgs e)
		{
			var add = new AddContent();
			while(true)
			{
				if(add.ShowDialog(AddContent.Purpose.addNewMovie) == DialogResult.OK)
				{
					var dbRet = database.getMediaByName(add.RetMedia.Name);
					if(dbRet != null)
					{
						MessageBox.Show("Es gibt bereits einen Eintrag mit diesem Namen:" + Environment.NewLine +
						              	"Name: " + add.RetMedia.Name + Environment.NewLine +
						              	"Typ: " + add.RetMedia.Type + Environment.NewLine +
										"Genre: " + add.RetMedia.Genre + Environment.NewLine +
										"KA: " + add.RetMedia.KA + Environment.NewLine +
										"Bewertung: " + add.RetMedia.Rating + Environment.NewLine);
						continue;
					}
					else
					{
						database.addNewEntry(add.RetMedia);
						DisplayContentChanged(sender, e);
					}
				}
				
				break;
			}
			add.Dispose();
		}
		
		void AddReptoolStripMenuItemClick(object sender, EventArgs e)
		{
			var add =  new AddContent();
			
			if(add.ShowDialog(AddContent.Purpose.addRepDetails) == DialogResult.OK)
			{
				database.addDetail(add.RetMedia.ID, add.RetMedia.RepeatDetail);
				
				DisplayContentChanged(sender, e);
			}
			
			add.Dispose();
		}
		
		void AllSeriesToolStripMenuItemClick(object sender, EventArgs e)
		{
			unseenToolStripMenuItem.Checked = false;
			aktivToolStripMenuItem.Checked = false;
			pausedToolStripMenuItem.Checked = false;
			stoppedToolStripMenuItem.Checked = false;
			finishedToolStripMenuItem.Checked = false;
			badToolStripMenuItem.Checked = false;
			
			DisplayContentChanged(sender, e);
		}
		
		void EintragLöschenToolStripMenuItemClick(object sender, EventArgs e)
		{
			var add =  new AddContent();
			
			if(add.ShowDialog(AddContent.Purpose.deleteMovie) == DialogResult.OK)
			{
				if(MessageBox.Show("Sicher das sie \"" + add.RetMedia.Name + "\" löschen möchten?", "Einträg löschen", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					database.deleteMedia(add.RetMedia);	
					PictureListItem temp = pictureListContent.getItemByMedia(add.RetMedia);
					pictureListContent.remove(temp);
				}
			}
			
			add.Dispose();
			DisplayContentChanged(sender);
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			config.LastMainWindowSize = this.Size;
			config.LastMainWindowLocation = this.Location;
			
			config.writeConfig();
			
			this.Dispose();
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			config.readConfig();
			
			this.Size = config.LastMainWindowSize;
			this.Location = config.LastMainWindowLocation;
		}
		
		void MainFormShown(object sender, EventArgs e)
		{
			pictureListContent.Focus();
		}
	}
}
