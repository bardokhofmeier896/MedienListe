/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Phil
 * Datum: 13.03.2016
 * Zeit: 20:11
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.Windows.Forms;

namespace MedienListe
{
	/// <summary>
	/// Description of TapPage.
	/// </summary>
	public class TapPageDetail : TabPage
	{
		readonly Label labelLanguage = new Label();
		readonly Label labelEpisode = new Label();
		readonly Label labelSeason = new Label();
		readonly Label labelStatus = new Label();
		readonly Label labelKA = new Label();
		readonly Label labelRating = new Label();

		readonly Button buttonEdit = new Button();
		
		public ComboBox comboBoxLanguage = new ComboBox();
		public TextBox textBoxEpisode = new TextBox();
		public TextBox textBoxSeason = new TextBox();
		public CheckBox checkBoxFinished = new CheckBox();
		public ComboBox comboBoxStatus = new ComboBox();
		public ComboBox comboBoxKA = new ComboBox();
		public TextBox textBoxRating = new TextBox();
		
		public bool IsMainDetail { get; private set; }
		public bool Edited { get; private set; }
		public Detail Content {get; private set; }
		
		public TapPageDetail(Detail paraContent, Media media)
		{	
			/*			
			comboBoxLanguage.DataSource = Enum.GetValues(typeof(Detail.Language));
			comboBoxStatus.DataSource = Enum.GetValues(typeof(Detail.Status));
			comboBoxKA.DataSource = Enum.GetValues(typeof(Media.KaEnum));
			*/
			
			foreach(Detail.Language l in Enum.GetValues(typeof(Detail.Language)))
		        comboBoxLanguage.Items.Add(l);
			foreach(Detail.Status l in Enum.GetValues(typeof(Detail.Status)))
		        comboBoxStatus.Items.Add(l);
			foreach(Media.KaEnum l in Enum.GetValues(typeof(Media.KaEnum)))
		        comboBoxKA.Items.Add(l);
			
			Content = paraContent;
			
			comboBoxLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxKA.DropDownStyle = ComboBoxStyle.DropDownList;
			
			labelLanguage.Text = "Sprache";
			labelEpisode.Text = "Zuletzt gesehene Folge";
			labelSeason.Text = "Zuletzt gesehene Staffel";
			labelStatus.Text = "Status";
			labelKA.Text = "KA";
			labelRating.Text = "Bewertung";
			
			checkBoxFinished.Text = "abgeschlossen";
			buttonEdit.Text = "Bearbeiten";
						
			Text = Content.Name ?? "Tab";
			BackColor = System.Drawing.SystemColors.AppWorkspace;
			buttonEdit.UseVisualStyleBackColor = true;
			
			labelLanguage.BorderStyle = BorderStyle.FixedSingle;
			labelEpisode.BorderStyle = BorderStyle.FixedSingle;
			labelSeason.BorderStyle = BorderStyle.FixedSingle;
			labelStatus.BorderStyle = BorderStyle.FixedSingle;
			labelKA.BorderStyle = BorderStyle.FixedSingle;
			labelRating.BorderStyle = BorderStyle.FixedSingle;
			
			labelLanguage.SetBounds(19, 15, 128, 18);
			labelEpisode.SetBounds(19, 48, 128, 18);
			labelSeason.SetBounds(19, 81, 128, 18);
			labelStatus.SetBounds(19, 114, 128, 18);
			labelKA.SetBounds(19, 147, 128, 18);
			labelRating.SetBounds(19, 180, 128, 18);
			
			comboBoxLanguage.SetBounds(157, 14, 105, 18);
			textBoxEpisode.SetBounds(157, 47, 35, 18);
			textBoxSeason.SetBounds(157, 80, 35, 18);
			checkBoxFinished.SetBounds(198, 81, 100, 18);
			comboBoxStatus.SetBounds(157, 113, 105, 18);
			comboBoxKA.SetBounds(157, 146, 115, 18);
			textBoxRating.SetBounds(157, 179, 35, 18);
			
			buttonEdit.SetBounds(175, 210, 86, 23);
			
			Controls.Add(labelLanguage);
			Controls.Add(labelEpisode);
			Controls.Add(labelSeason);
			Controls.Add(labelStatus);
			Controls.Add(labelKA);
			Controls.Add(labelRating);
			
			Controls.Add(comboBoxLanguage);
			Controls.Add(textBoxEpisode);
			Controls.Add(textBoxSeason);
			Controls.Add(checkBoxFinished);
			Controls.Add(comboBoxStatus);
			Controls.Add(comboBoxKA);
			Controls.Add(textBoxRating);
			
			Controls.Add(buttonEdit);
			
			comboBoxLanguage.Enabled = false;
			textBoxEpisode.Enabled = false;
			textBoxSeason.Enabled = false;
			checkBoxFinished.Enabled = false;
			comboBoxStatus.Enabled = false;
			comboBoxKA.Enabled = false;
			textBoxRating.Enabled = false;		
			
			comboBoxLanguage.SelectedItem = Content.ViewLanguage;
			textBoxEpisode.Text = Content.LastSeenEpisode.ToString();
			textBoxSeason.Text = Content.LastSeenSeason.ToString();
			checkBoxFinished.Checked = Content.LastSeenSeasonFinished;			
			comboBoxStatus.SelectedItem = Content.AktivStatus;
			comboBoxKA.SelectedItem = media.KA;
			
			if(media != null)
			{
				labelKA.Visible = true;
				labelRating.Visible = true;
				
				comboBoxKA.Visible = true;
				textBoxRating.Visible = true;

				comboBoxKA.SelectedItem = media.KA;
				textBoxRating.Text = media.Rating.ToString();
				
				IsMainDetail = true;
			}
			else
			{
				labelKA.Visible = false;
				labelRating.Visible = false;

				comboBoxKA.Visible = false;
				textBoxRating.Visible = false;
				
				IsMainDetail = false;
			}
			
			this.buttonEdit.Click += new System.EventHandler(this.ButtonEditClick);
		}
		
		void ButtonEditClick(object sender, EventArgs e)
		{
			comboBoxLanguage.Enabled = true;
			textBoxEpisode.Enabled = true;
			textBoxSeason.Enabled = true;
			checkBoxFinished.Enabled = true;
			if(!Content.isRepeat)
				comboBoxStatus.Enabled = true;
			comboBoxKA.Enabled = true;
			textBoxRating.Enabled = true;
			
			buttonEdit.Enabled = false;
			
			Edited = true;
		}
	}
}
