/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Phil
 * Datum: 09.03.2014
 * Zeit: 18:54
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
namespace MedienListe
{
	partial class DetailWindow
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
			this.labelHeader = new System.Windows.Forms.Label();
			this.labelHeaderContent = new System.Windows.Forms.Label();
			this.panelSeries = new System.Windows.Forms.Panel();
			this.buttonExit = new System.Windows.Forms.Button();
			this.buttonCommit = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.pictureBoxImage = new System.Windows.Forms.PictureBox();
			this.tabControlDetails = new System.Windows.Forms.TabControl();
			this.panelSeries.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
			this.SuspendLayout();
			// 
			// labelHeader
			// 
			this.labelHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelHeader.Location = new System.Drawing.Point(0, 0);
			this.labelHeader.Name = "labelHeader";
			this.labelHeader.Size = new System.Drawing.Size(912, 54);
			this.labelHeader.TabIndex = 2;
			this.labelHeader.Text = "Details zu ";
			this.labelHeader.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// labelHeaderContent
			// 
			this.labelHeaderContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelHeaderContent.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelHeaderContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Underline);
			this.labelHeaderContent.Location = new System.Drawing.Point(0, 54);
			this.labelHeaderContent.Name = "labelHeaderContent";
			this.labelHeaderContent.Size = new System.Drawing.Size(912, 50);
			this.labelHeaderContent.TabIndex = 24;
			this.labelHeaderContent.Text = "---";
			this.labelHeaderContent.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.labelHeaderContent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LabelHeaderContentMouseDoubleClick);
			// 
			// panelSeries
			// 
			this.panelSeries.Controls.Add(this.buttonExit);
			this.panelSeries.Controls.Add(this.buttonCommit);
			this.panelSeries.Controls.Add(this.panel3);
			this.panelSeries.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelSeries.Location = new System.Drawing.Point(0, 104);
			this.panelSeries.Name = "panelSeries";
			this.panelSeries.Size = new System.Drawing.Size(912, 319);
			this.panelSeries.TabIndex = 27;
			// 
			// buttonExit
			// 
			this.buttonExit.Location = new System.Drawing.Point(465, 282);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(75, 23);
			this.buttonExit.TabIndex = 32;
			this.buttonExit.Text = "Schließen";
			this.buttonExit.UseVisualStyleBackColor = true;
			this.buttonExit.Click += new System.EventHandler(this.ButtonExitClick);
			// 
			// buttonCommit
			// 
			this.buttonCommit.Location = new System.Drawing.Point(340, 282);
			this.buttonCommit.Name = "buttonCommit";
			this.buttonCommit.Size = new System.Drawing.Size(75, 23);
			this.buttonCommit.TabIndex = 31;
			this.buttonCommit.Text = "Speichern";
			this.buttonCommit.UseVisualStyleBackColor = true;
			this.buttonCommit.Click += new System.EventHandler(this.ButtonCommitClick);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.pictureBoxImage);
			this.panel3.Controls.Add(this.tabControlDetails);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(912, 262);
			this.panel3.TabIndex = 30;
			// 
			// pictureBoxImage
			// 
			this.pictureBoxImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBoxImage.Location = new System.Drawing.Point(440, 0);
			this.pictureBoxImage.Name = "pictureBoxImage";
			this.pictureBoxImage.Size = new System.Drawing.Size(472, 262);
			this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxImage.TabIndex = 27;
			this.pictureBoxImage.TabStop = false;
			this.pictureBoxImage.DoubleClick += new System.EventHandler(this.PictureBoxImageDoubleClick);
			// 
			// tabControlDetails
			// 
			this.tabControlDetails.Dock = System.Windows.Forms.DockStyle.Left;
			this.tabControlDetails.Location = new System.Drawing.Point(0, 0);
			this.tabControlDetails.Name = "tabControlDetails";
			this.tabControlDetails.SelectedIndex = 0;
			this.tabControlDetails.Size = new System.Drawing.Size(440, 262);
			this.tabControlDetails.TabIndex = 33;
			// 
			// DetailWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.ClientSize = new System.Drawing.Size(912, 423);
			this.Controls.Add(this.panelSeries);
			this.Controls.Add(this.labelHeaderContent);
			this.Controls.Add(this.labelHeader);
			this.MaximizeBox = false;
			this.Name = "DetailWindow";
			this.ShowInTaskbar = false;
			this.Text = "Details";
			this.Load += new System.EventHandler(this.DetailWindowLoad);
			this.panelSeries.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.TabControl tabControlDetails;
		private System.Windows.Forms.Button buttonCommit;
		private System.Windows.Forms.Button buttonExit;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.PictureBox pictureBoxImage;
		private System.Windows.Forms.Panel panelSeries;
		private System.Windows.Forms.Label labelHeaderContent;
		private System.Windows.Forms.Label labelHeader;
	}
}
