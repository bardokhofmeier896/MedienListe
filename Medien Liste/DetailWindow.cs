/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Phil
 * Datum: 09.03.2014
 * Zeit: 18:54
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MedienListe
{
	/// <summary>
	/// Description of Details.
	/// </summary>
	public partial class DetailWindow : Form
	{
		private readonly Database database;
		private Media content;
		private Config config;

		private bool imageEdited = false;
		private bool nameEdited = false;
		
		/*
		public bool NameEdited
		{
			get
			{
				return nameEdited;
			}
		}
		public bool DetailEdited
		{
			get
			{
				return detailEdited;
			}
		}
		public bool RepDetailEdited
		{
			get
			{
				return repDetailEdited;
			}
		}
		public bool ImageEdited
		{
			get
			{
				return imageEdited;
			}
		}*/
		
		public DetailWindow()
		{
			config = Config.getInstance();
			
			InitializeComponent();
/*
			comboBoxLanguage.DataSource = Enum.GetValues(typeof(Detail.Language));
			comboBoxAktivStatus.DataSource = Enum.GetValues(typeof(Detail.Status));
			comboBoxKA.DataSource = Enum.GetValues(typeof(Media.KaEnum));
			
			comboBoxLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxAktivStatus.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxKA.DropDownStyle = ComboBoxStyle.DropDownList;
			
			comboBoxRepLanguage.DataSource = Enum.GetValues(typeof(Detail.Language));
			comboBoxRepAktivStatus.DataSource = Enum.GetValues(typeof(Detail.Status));*/
			
			database = Database.getInstance();
			
			Visible = false;
		}
		
		private void setContent(Media paraContent)
		{
			content = paraContent;
			pictureBoxImage.Image = content.Cover ?? Images.Default;
			labelHeaderContent.Text = content.Name;

			for(int i = 0; i < paraContent.Details.Count; i++)
				tabControlDetails.Controls.Add(new TapPageDetail(paraContent.Details[i], paraContent));	
		}		
		
		public Media ShowDialog(Media content)
		{
			try
			{
				setContent(content);
				
				if(this.ShowDialog() == DialogResult.Yes)
				{
					//MessageBox.Show("DetailWindows.ShowDialog: TODO Result=Yes");
					if(nameEdited)
					{
						content.Name = labelHeaderContent.Text;
						database.updateMedia(content);
					}
					if(imageEdited)
					{
						
						content.Cover = pictureBoxImage.Image;
						database.updateImage(content);
					}
			
					foreach(TapPageDetail page in tabControlDetails.Controls)
					{
						if(page.Edited)
						{
							Detail oldDetail = page.Content;
							Detail newDetail = new Detail(oldDetail.MediaID);
							
							newDetail.MediaSequenzID = oldDetail.MediaSequenzID;
							newDetail.Name = oldDetail.Name;
							newDetail.isRepeat = oldDetail.isRepeat;
							
							newDetail.ViewLanguage = (Detail.Language) page.comboBoxLanguage.SelectedItem;
							newDetail.LastSeenEpisode = Int32.Parse(page.textBoxEpisode.Text);
							newDetail.LastSeenSeason = Int32.Parse(page.textBoxSeason.Text);
							newDetail.LastSeenSeasonFinished = page.checkBoxFinished.Checked;
							newDetail.AktivStatus = (Detail.Status) page.comboBoxStatus.SelectedItem;
							
							content.replaceDetail(oldDetail, newDetail);
							
							if(page.IsMainDetail)
							{
								content.KA = (Media.KaEnum) page.comboBoxKA.SelectedItem;
								content.Rating = Int32.Parse(page.textBoxRating.Text);
								
								database.updateMedia(content);
							}
							
							database.updateDetails(newDetail);
						}
					}

					return content;
				}
			}catch(Exception ex)
			{
				MessageBox.Show("DetailWindows.ShowDialog: " + ex);
			}
			
			return null;
		}
		
		void ButtonExitClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.No;
			this.Close();
		}
		
		void ButtonCommitClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Yes;
			this.Close();
		}
		
		void PictureBoxImageDoubleClick(object sender, EventArgs e)
		{
			if(content.Cover != null)
				if(MessageBox.Show("Wollen sie das vorhandene Bild ersetzen?", "Bild ersetzen", MessageBoxButtons.YesNo) == DialogResult.No)
					return;
			
			try
			{
				OpenFileDialog open = new OpenFileDialog();
				open.Title = "Neues Bild aussuchen";
				open.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.png; *.bmp";
				
				if(open.ShowDialog() == DialogResult.OK)
		        {
					Image neu = Image.FromFile(open.FileName);
					imageEdited = true;
					pictureBoxImage.Image = neu;
		        }
			} 
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		
		void DetailWindowLoad(object sender, EventArgs e)
		{
	   		this.Location = config.LastMainWindowLocation;
		}
		
		void LabelHeaderContentMouseDoubleClick(object sender, MouseEventArgs e)
		{
			MessageBoxOwn temp = new MessageBoxOwn(content.Name);
			
			while(true)
			{
				if(temp.ShowDialog() == DialogResult.OK)
				{
					if(database.getMediaByName(temp.newName) != null)
					{
						MessageBox.Show("Ein Eintrag mit diesen Namen existiert bereits.");
						continue;
					}
					
					labelHeaderContent.Text = temp.newName;
					nameEdited = true;
					break;
				}
			}
		}
		void Label1Click(object sender, EventArgs e)
		{
	
		}
	}
}
