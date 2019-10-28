/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Phil
 * Datum: 11.04.2014
 * Zeit: 14:44
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace MedienListe
{
	/// <summary>
	/// Description of AddContent.
	/// </summary>
	public partial class AddContent : Form
	{
		private Config config;
		private Database database;
		private Image defaultImage;
		
		private Media aktMedia;
		
		private bool imageChanged = false;
		private Purpose purpose;
		
		public Media RetMedia
		{
			get
			{
				return aktMedia;
			}
		}
		
		public AddContent()
		{
			this.Visible = false;
			config = Config.getInstance();
			database = Database.getInstance();
			
			InitializeComponent();
			
			comboBoxLanguage.DataSource = Enum.GetValues(typeof(Detail.Language));
			comboBoxAktivStatus.DataSource = Enum.GetValues(typeof(Detail.Status));
			comboBoxKA.DataSource = Enum.GetValues(typeof(Media.KaEnum));
			comboBoxSelectName.DataSource = database.getAllNames();
			
			comboBoxLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxAktivStatus.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxKA.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxSelectName.DropDownStyle = ComboBoxStyle.DropDownList;
			
			System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
			Stream myStream = myAssembly.GetManifestResourceStream("default");
	   		defaultImage = Image.FromStream(myStream);
	   		pictureBoxImage.Image = defaultImage;
		}
		
		public DialogResult ShowDialog(Purpose pur)
		{
			purpose = pur;
			switch(purpose)
			{
				case Purpose.addRepDetails:
					this.Text = "Wiederholungsdetails hinzufügen";
				
					comboBoxKA.Enabled = false;
					textBoxRating.Enabled = false;
					comboBoxAktivStatus.Enabled = false;
					
					textBoxName.Visible = false;
					comboBoxSelectName.Visible = true;
					
					comboBoxAktivStatus.SelectedItem = Detail.Status.aktiv;
					
					buttonCommit.Text = "Speichern";
					break;
					
				case Purpose.addNewMovie:
					this.Text = "Neuen Eintrag erstellen";
				
					comboBoxKA.Enabled = true;
					textBoxRating.Enabled = true;
					
					textBoxName.Visible = true;
					comboBoxSelectName.Visible = false;
					
					buttonCommit.Text = "Speichern";
					break;
				case Purpose.deleteMovie:
					this.Text = "Eintrag löschen";
					
					comboBoxLanguage.Enabled = false;
					textBoxLastSeenEpisode.Enabled = false;
					textBoxLastSeenSeason.Enabled = false;
					checkBoxSeasonFinished.Enabled = false;
					comboBoxKA.Enabled = false;
					textBoxRating.Enabled = false;
					comboBoxAktivStatus.Enabled = false;
					textBoxRating.Enabled = false;
					
					buttonCommit.Text = "Löschen";
					break;
				default:
					throw new NotImplementedException();
			}
			
			this.DialogResult = DialogResult.Cancel;
			comboBoxAktivStatus.SelectedIndex = 1; //Auswahl std. auf aktiv setzen
			
			return base.ShowDialog();
		}
		
		void PictureBoxImageDoubleClick(object sender, EventArgs e)
		{
			if(purpose == Purpose.addRepDetails)
				return;
			
			try
			{
				OpenFileDialog open = new OpenFileDialog();
				open.Title = "Neues Bild aussuchen";
				open.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.png; *.bmp";
				if(open.ShowDialog() == DialogResult.OK)
		        {
					Image neu = Image.FromFile(open.FileName);
					imageChanged = true;
					pictureBoxImage.Image = neu;
		        }
			} 
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		
		void ButtonCommitClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			
			if(purpose == Purpose.addNewMovie)
			{
				string name = textBoxName.Text.Trim();
				if(name.Length < 1)
				{
					MessageBox.Show("Sie müssen einem Namen angeben.");
					textBoxName.BackColor = Color.Red;
					return;
				}
				
				if(name.Length < 1)
				{
					MessageBox.Show("Sie müssen einen Rating angeben.");
					textBoxRating.BackColor = Color.Red;
					return;
				}
			}
			
			if(textBoxLastSeenEpisode.Text.Length < 1)
			{
				MessageBox.Show("Sie müssen eine letzte Episode angeben.");
				textBoxLastSeenEpisode.BackColor = Color.Red;
				return;
			}
			
			if(textBoxLastSeenSeason.Text.Length < 1)
			{
				MessageBox.Show("Sie müssen eine letzte Staffel angeben.");
				textBoxLastSeenSeason.BackColor = Color.Red;
				return;
			}
			
			textBoxName.BackColor = Color.White;
			textBoxLastSeenEpisode.BackColor = Color.White;
			textBoxLastSeenSeason.BackColor = Color.White;
			textBoxRating.BackColor = Color.White;
			
			Media media;
			
			if(purpose == Purpose.addRepDetails)
				media = new Media(((NamePuffer)comboBoxSelectName.SelectedItem).ID);
			else
				media = new Media(-1);
			
			media.Name = textBoxName.Text;
			media.Type = "Serie";
			media.Genre = null;
			media.KA = (Media.KaEnum) comboBoxKA.SelectedItem;
			if(imageChanged)
				media.Cover = pictureBoxImage.Image;
			
			try
			{
				media.Rating = Int32.Parse(textBoxRating.Text);
			}
			catch(Exception) 
			{
				MessageBox.Show("Sie müssen eine Ganzzahl eingeben.");
				textBoxLastSeenEpisode.BackColor = Color.Red;
				return;
			}
			
			Detail detail = new Detail(-1);
			
			detail.ViewLanguage = (Detail.Language) comboBoxLanguage.SelectedItem;
			try
			{
				detail.LastSeenEpisode = Int32.Parse(textBoxLastSeenEpisode.Text);
			}
			catch(Exception) 
			{
				MessageBox.Show("Sie müssen eine Ganzzahl eingeben.");
				textBoxLastSeenEpisode.BackColor = Color.Red;
				return;
			}
			
			try
			{
				detail.LastSeenSeason = Int32.Parse(textBoxLastSeenSeason.Text);
			}
			catch(Exception) 
			{
				MessageBox.Show("Sie müssen eine Ganzzahl eingeben.");
				textBoxLastSeenSeason.BackColor = Color.Red;
				return;
			}
			
			detail.AktivStatus = (Detail.Status) comboBoxAktivStatus.SelectedItem;
			detail.LastSeenSeasonFinished = checkBoxSeasonFinished.Checked;
			
			if(purpose == Purpose.addRepDetails)
			{
				detail.isRepeat = true;
				media.addDetail(new Detail(-2));
				media.addDetail(detail);
				//database.addRepDetail(((NamePuffer)comboBoxSelectName.SelectedItem).ID, detail);
				this.aktMedia = media;
			}
			else if(purpose == Purpose.addNewMovie)
			{	
				media.addDetail(detail);
				this.aktMedia = media;
			}	

			this.DialogResult = DialogResult.OK;
		}
		
		void ButtonExitClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Visible = false;
		}
		
		void AddContentLoad(object sender, EventArgs e)
		{
	   		this.Location = config.LastMainWindowLocation;
		}
		
		void ComboBoxSelectNameSelectedIndexChanged(object sender, EventArgs e)
		{
			NamePuffer puf = (NamePuffer) comboBoxSelectName.SelectedItem;
			
			Media tmp = database.getMediaById(puf.ID);
			
			if(tmp.Cover == null)
				pictureBoxImage.Image = defaultImage;
			else
				pictureBoxImage.Image = tmp.Cover;
			
			comboBoxKA.SelectedItem = tmp.KA;
			textBoxRating.Text = tmp.Rating + "";
			
			if(purpose == Purpose.deleteMovie)
			{
				Detail last = tmp.LatestDetail;
				
				comboBoxLanguage.SelectedItem = last.ViewLanguage;
				textBoxLastSeenEpisode.Text = last.LastSeenEpisode + "";
				textBoxLastSeenSeason.Text = last.LastSeenSeason + "";
				checkBoxSeasonFinished.Checked = last.LastSeenSeasonFinished;
				comboBoxAktivStatus.SelectedItem = last.AktivStatus;
			}
			
			aktMedia = tmp;
		}
		
		public enum Purpose
		{
			addNewMovie, 
			addRepDetails,
			deleteMovie
		}
	}
}
