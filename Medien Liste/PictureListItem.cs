/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Philipp
 * Datum: 23.08.2013
 * Zeit: 17:37
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.Drawing;
using System.Windows.Forms;


namespace MedienListe
{
	/// <summary>
	/// Description of PicuterListItem.
	/// </summary>
	public class PictureListItem : Panel
	{	
		private PictureBox pictureBoxImage = new PictureBox();
		private Label labelTitel = new Label();
		
		private Panel panelButtons = new Panel();
		private Button buttonRaiseEpisode = new Button();
		private Button buttonRaiseSeason = new Button();
		private Button buttonEdit = new Button();
		private Label labelStatus = new Label();
		
		private Media content;
		private readonly Database database;

		public Media Content
		{
			get
			{
				return content;
			}
		}
		public new string Name{ get; private set; }
		public Detail.Status AktivStatus
		{
			get
			{
				return content.LatestDetail.AktivStatus;
			}
		}
		
		public int Rating
		{
			get
			{
				return content.Rating;
			}
		}
		
		public PictureListItem(Media content)
		{
			database = Database.getInstance();

			this.content = content;
			setDisplayMode(0);
			
			labelTitel.Text = content.ID + ":" + content.Name;
			if(content.LatestDetail.Name != null)
			{
				labelTitel.Text = content.LatestDetail.Name;
				Name = content.LatestDetail.Name;
			}
			else
			{
				labelTitel.Text = content.Name;
				Name = content.Name;
			}
			
			if(content.Cover != null)
				pictureBoxImage.Image = content.Cover;
			else
				pictureBoxImage.Image = Images.Default;
			
			setLabelStatus();
			
			pictureBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;
			BorderStyle = BorderStyle.FixedSingle;
				
			labelTitel.TextAlign = ContentAlignment.MiddleCenter;		
			buttonRaiseEpisode.Dock = DockStyle.Right;
			buttonEdit.Dock = DockStyle.Right;
			buttonRaiseSeason.Dock = DockStyle.Right;
			labelStatus.Dock = DockStyle.Fill;
			
			buttonRaiseEpisode.Image = Images.RaiseEpisode;
			buttonRaiseSeason.Image = Images.RaiseSeason;
			buttonEdit.Image = Images.Edit;
			
			buttonRaiseEpisode.Size = new Size(20, 20);
			buttonRaiseSeason.Size = new Size(20, 20);
			buttonEdit.Size = new Size(20, 20);
			
			panelButtons.Controls.Add(buttonRaiseEpisode);
			panelButtons.Controls.Add(buttonRaiseSeason);
			panelButtons.Controls.Add(buttonEdit);
			panelButtons.Controls.Add(labelStatus);
			
			Controls.Add(pictureBoxImage);
			Controls.Add(labelTitel);
			Controls.Add(panelButtons);
			
			labelTitel.BringToFront();
			panelButtons.BringToFront();
			
			buttonRaiseEpisode.Click += new EventHandler(this.raiseEpisode);
			buttonRaiseSeason.Click += new EventHandler(this.raiseSeason);
			buttonEdit.Click += new EventHandler(this.openDetails);
			
			this.pictureBoxImage.Visible = true;
			Visible = true;
		}
		
		private void setLabelStatus()
		{
			int tempSeason = content.LatestDetail.LastSeenSeason;
			int tempEpisode = content.LatestDetail.LastSeenEpisode;
			
			string season = tempSeason < 10 && tempSeason > -1? "0" + tempSeason : "" + tempSeason;
			string episode = tempEpisode < 10 && tempEpisode > -1 ? "0" + tempEpisode : "" + tempEpisode;
			string info = content.hasRepeat ? "w" : "";
			info += content.LatestDetail.LastSeenSeasonFinished ? " f" : "";
			
			labelTitel.Text = content.Name;
			labelStatus.Text = string.Format("S{0} E{1} {2}", season, episode, info);	
		}
		
		public void setDisplayMode(int mode)
		{
			pictureBoxImage.Dock = DockStyle.Top;
			
			switch(mode)
			{
				case 0:
					labelTitel.Dock = DockStyle.Top;
					panelButtons.Dock = DockStyle.Fill;
					
					this.BorderStyle = BorderStyle.FixedSingle;
					pictureBoxImage.Visible = false;
					this.Width = 170;
					this.Height = 45; //30
					break;
				case 1:
					labelTitel.Dock = DockStyle.Top;
					panelButtons.Dock = DockStyle.Fill;
					this.BorderStyle = BorderStyle.FixedSingle;
					
					pictureBoxImage.Visible = true;
					this.Width = 170;
					this.Height = 165; //150
					pictureBoxImage.Width = 80;
					pictureBoxImage.Height = 120;
					break;
			}
		}
		
		private void openDetails(System.Object sender, EventArgs e)
		{
			DetailWindow det = new DetailWindow();
			
			if(det.ShowDialog(content) != null)
			{
				
				setLabelStatus();
				this.Refresh();
			}
			
			det.Dispose();
		}
		
		private void raiseEpisode(System.Object sender, EventArgs e)
		{
			if(content.LatestDetail.LastSeenEpisode != -1 && content.LatestDetail.LastSeenSeasonFinished)
			{
				MessageBox.Show("Staffel wurde beendet. Folge kann nicht erhöht werden.");
				return;
			}
			
			if(content.LatestDetail.isRepeat)
			{
				
			}
			content.LatestDetail.LastSeenEpisode = content.LatestDetail.LastSeenEpisode + 1;
			content.LatestDetail.LastSeenSeasonFinished = false;
			database.updateDetails(content.LatestDetail);
			setLabelStatus();
			this.Refresh();
		}
		
		private void raiseSeason(System.Object sender, EventArgs e)
		{
			int epi = content.LatestDetail.LastSeenSeason;
			if(epi != -1)
			{
				DialogResult res = MessageBox.Show("Gibt es schon eine neue Staffel?", "Staffelende", MessageBoxButtons.YesNoCancel);
				switch(res)
				{
					case DialogResult.Yes:
						content.LatestDetail.LastSeenEpisode = -1;
						content.LatestDetail.LastSeenSeason = content.LatestDetail.LastSeenSeason + 1;
						content.LatestDetail.AktivStatus = Detail.Status.aktiv;
						database.updateDetails(content.LatestDetail);
						break;
						
					case DialogResult.No:
						if(content.LatestDetail.isRepeat)
						{
							database.deleteRepDetail(content.LatestDetail);
							content.clearRepeatDetail();
							MessageBox.Show("Wiederholung wird gelöscht.");
						}
						else
						{
							content.LatestDetail.AktivStatus = Detail.Status.paused;
							content.LatestDetail.LastSeenSeasonFinished = true;
							database.updateDetails(content.LatestDetail);
						}
						break;
						
					case DialogResult.Abort:
						break;
				}
				setLabelStatus();
				this.Refresh();
			}
			else
			{
				MessageBox.Show("Die Staffel ist unbestimmt und kann somit nicht erhöht werden.");
			}
		}
	}
}
