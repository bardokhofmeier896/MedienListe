/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Phil
 * Datum: 11.04.2014
 * Zeit: 14:44
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
namespace MedienListe
{
	partial class AddContent
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.panelSeries = new System.Windows.Forms.Panel();
			this.comboBoxSelectName = new System.Windows.Forms.ComboBox();
			this.buttonCommit = new System.Windows.Forms.Button();
			this.buttonExit = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.comboBoxAktivStatus = new System.Windows.Forms.ComboBox();
			this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.labelKA = new System.Windows.Forms.Label();
			this.textBoxRating = new System.Windows.Forms.TextBox();
			this.textBoxLastSeenEpisode = new System.Windows.Forms.TextBox();
			this.textBoxLastSeenSeason = new System.Windows.Forms.TextBox();
			this.checkBoxSeasonFinished = new System.Windows.Forms.CheckBox();
			this.comboBoxKA = new System.Windows.Forms.ComboBox();
			this.label15 = new System.Windows.Forms.Label();
			this.labelRating = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.pictureBoxImage = new System.Windows.Forms.PictureBox();
			this.panelSeries.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
			this.SuspendLayout();
			// 
			// panelSeries
			// 
			this.panelSeries.Controls.Add(this.comboBoxSelectName);
			this.panelSeries.Controls.Add(this.buttonCommit);
			this.panelSeries.Controls.Add(this.buttonExit);
			this.panelSeries.Controls.Add(this.label1);
			this.panelSeries.Controls.Add(this.textBoxName);
			this.panelSeries.Controls.Add(this.comboBoxAktivStatus);
			this.panelSeries.Controls.Add(this.comboBoxLanguage);
			this.panelSeries.Controls.Add(this.label16);
			this.panelSeries.Controls.Add(this.label18);
			this.panelSeries.Controls.Add(this.labelKA);
			this.panelSeries.Controls.Add(this.textBoxRating);
			this.panelSeries.Controls.Add(this.textBoxLastSeenEpisode);
			this.panelSeries.Controls.Add(this.textBoxLastSeenSeason);
			this.panelSeries.Controls.Add(this.checkBoxSeasonFinished);
			this.panelSeries.Controls.Add(this.comboBoxKA);
			this.panelSeries.Controls.Add(this.label15);
			this.panelSeries.Controls.Add(this.labelRating);
			this.panelSeries.Controls.Add(this.label17);
			this.panelSeries.Controls.Add(this.pictureBoxImage);
			this.panelSeries.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelSeries.Location = new System.Drawing.Point(0, 0);
			this.panelSeries.Name = "panelSeries";
			this.panelSeries.Size = new System.Drawing.Size(499, 291);
			this.panelSeries.TabIndex = 30;
			// 
			// comboBoxSelectName
			// 
			this.comboBoxSelectName.FormattingEnabled = true;
			this.comboBoxSelectName.Location = new System.Drawing.Point(146, 10);
			this.comboBoxSelectName.Name = "comboBoxSelectName";
			this.comboBoxSelectName.Size = new System.Drawing.Size(166, 21);
			this.comboBoxSelectName.TabIndex = 81;
			this.comboBoxSelectName.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectNameSelectedIndexChanged);
			// 
			// buttonCommit
			// 
			this.buttonCommit.Location = new System.Drawing.Point(146, 252);
			this.buttonCommit.Name = "buttonCommit";
			this.buttonCommit.Size = new System.Drawing.Size(75, 23);
			this.buttonCommit.TabIndex = 64;
			this.buttonCommit.Text = "Speichern";
			this.buttonCommit.UseVisualStyleBackColor = true;
			this.buttonCommit.Click += new System.EventHandler(this.ButtonCommitClick);
			// 
			// buttonExit
			// 
			this.buttonExit.Location = new System.Drawing.Point(249, 252);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(75, 23);
			this.buttonExit.TabIndex = 65;
			this.buttonExit.Text = "Abbrechen";
			this.buttonExit.UseVisualStyleBackColor = true;
			this.buttonExit.Click += new System.EventHandler(this.ButtonExitClick);
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 18);
			this.label1.TabIndex = 80;
			this.label1.Text = "Name";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(146, 10);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(166, 20);
			this.textBoxName.TabIndex = 1;
			// 
			// comboBoxAktivStatus
			// 
			this.comboBoxAktivStatus.FormattingEnabled = true;
			this.comboBoxAktivStatus.Location = new System.Drawing.Point(146, 142);
			this.comboBoxAktivStatus.Name = "comboBoxAktivStatus";
			this.comboBoxAktivStatus.Size = new System.Drawing.Size(104, 21);
			this.comboBoxAktivStatus.TabIndex = 6;
			// 
			// comboBoxLanguage
			// 
			this.comboBoxLanguage.FormattingEnabled = true;
			this.comboBoxLanguage.Location = new System.Drawing.Point(146, 43);
			this.comboBoxLanguage.Name = "comboBoxLanguage";
			this.comboBoxLanguage.Size = new System.Drawing.Size(104, 21);
			this.comboBoxLanguage.TabIndex = 2;
			// 
			// label16
			// 
			this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label16.Location = new System.Drawing.Point(12, 78);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(128, 18);
			this.label16.TabIndex = 76;
			this.label16.Text = "Zuletzt gesehene Folge";
			// 
			// label18
			// 
			this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label18.Location = new System.Drawing.Point(12, 144);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(128, 18);
			this.label18.TabIndex = 68;
			this.label18.Text = "Status";
			// 
			// labelKA
			// 
			this.labelKA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelKA.Location = new System.Drawing.Point(12, 177);
			this.labelKA.Name = "labelKA";
			this.labelKA.Size = new System.Drawing.Size(128, 18);
			this.labelKA.TabIndex = 69;
			this.labelKA.Text = "KA";
			// 
			// textBoxRating
			// 
			this.textBoxRating.Location = new System.Drawing.Point(146, 208);
			this.textBoxRating.Name = "textBoxRating";
			this.textBoxRating.Size = new System.Drawing.Size(43, 20);
			this.textBoxRating.TabIndex = 8;
			this.textBoxRating.Text = "-1";
			// 
			// textBoxLastSeenEpisode
			// 
			this.textBoxLastSeenEpisode.Location = new System.Drawing.Point(146, 77);
			this.textBoxLastSeenEpisode.Name = "textBoxLastSeenEpisode";
			this.textBoxLastSeenEpisode.Size = new System.Drawing.Size(43, 20);
			this.textBoxLastSeenEpisode.TabIndex = 3;
			this.textBoxLastSeenEpisode.Text = "-1";
			// 
			// textBoxLastSeenSeason
			// 
			this.textBoxLastSeenSeason.Location = new System.Drawing.Point(146, 110);
			this.textBoxLastSeenSeason.Name = "textBoxLastSeenSeason";
			this.textBoxLastSeenSeason.Size = new System.Drawing.Size(43, 20);
			this.textBoxLastSeenSeason.TabIndex = 4;
			this.textBoxLastSeenSeason.Text = "-1";
			// 
			// checkBoxSeasonFinished
			// 
			this.checkBoxSeasonFinished.Location = new System.Drawing.Point(195, 111);
			this.checkBoxSeasonFinished.Name = "checkBoxSeasonFinished";
			this.checkBoxSeasonFinished.Size = new System.Drawing.Size(104, 18);
			this.checkBoxSeasonFinished.TabIndex = 5;
			this.checkBoxSeasonFinished.Text = "abgeschlossen";
			this.checkBoxSeasonFinished.UseVisualStyleBackColor = true;
			// 
			// comboBoxKA
			// 
			this.comboBoxKA.FormattingEnabled = true;
			this.comboBoxKA.Location = new System.Drawing.Point(146, 175);
			this.comboBoxKA.Name = "comboBoxKA";
			this.comboBoxKA.Size = new System.Drawing.Size(114, 21);
			this.comboBoxKA.TabIndex = 7;
			// 
			// label15
			// 
			this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label15.Location = new System.Drawing.Point(12, 45);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(128, 18);
			this.label15.TabIndex = 66;
			this.label15.Text = "Sprache";
			// 
			// labelRating
			// 
			this.labelRating.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelRating.Location = new System.Drawing.Point(12, 210);
			this.labelRating.Name = "labelRating";
			this.labelRating.Size = new System.Drawing.Size(128, 18);
			this.labelRating.TabIndex = 70;
			this.labelRating.Text = "Bewertung";
			// 
			// label17
			// 
			this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label17.Location = new System.Drawing.Point(12, 111);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(128, 18);
			this.label17.TabIndex = 67;
			this.label17.Text = "Zuletzt gesehene Staffel";
			// 
			// pictureBoxImage
			// 
			this.pictureBoxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxImage.Location = new System.Drawing.Point(318, 10);
			this.pictureBoxImage.Name = "pictureBoxImage";
			this.pictureBoxImage.Size = new System.Drawing.Size(171, 119);
			this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxImage.TabIndex = 63;
			this.pictureBoxImage.TabStop = false;
			this.pictureBoxImage.DoubleClick += new System.EventHandler(this.PictureBoxImageDoubleClick);
			// 
			// AddContent
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.ClientSize = new System.Drawing.Size(499, 291);
			this.Controls.Add(this.panelSeries);
			this.MaximizeBox = false;
			this.Name = "AddContent";
			this.ShowInTaskbar = false;
			this.Text = "Title";
			this.Load += new System.EventHandler(this.AddContentLoad);
			this.panelSeries.ResumeLayout(false);
			this.panelSeries.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ComboBox comboBoxSelectName;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ComboBox comboBoxKA;
		private System.Windows.Forms.CheckBox checkBoxSeasonFinished;
		private System.Windows.Forms.TextBox textBoxLastSeenSeason;
		private System.Windows.Forms.TextBox textBoxLastSeenEpisode;
		private System.Windows.Forms.TextBox textBoxRating;
		private System.Windows.Forms.Button buttonCommit;
		private System.Windows.Forms.Panel panelSeries;
		private System.Windows.Forms.Button buttonExit;
		private System.Windows.Forms.PictureBox pictureBoxImage;
		private System.Windows.Forms.Label labelRating;
		private System.Windows.Forms.Label labelKA;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.ComboBox comboBoxLanguage;
		private System.Windows.Forms.ComboBox comboBoxAktivStatus;
	}
}
