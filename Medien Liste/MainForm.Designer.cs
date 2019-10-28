/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Philipp
 * Datum: 20.08.2013
 * Zeit: 17:27
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
namespace MedienListe
{
	partial class MainForm
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.buttonClearFilter = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxFilter = new System.Windows.Forms.TextBox();
			this.pictureListContent = new MedienListe.PictureList();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addReptoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.eintragLöschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.anzeigeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.unseenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aktivToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pausedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stoppedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.finishedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.badToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.allSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nurTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mitCoverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel2.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.buttonClearFilter);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.textBoxFilter);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 24);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(680, 37);
			this.panel2.TabIndex = 1;
			// 
			// buttonClearFilter
			// 
			this.buttonClearFilter.Location = new System.Drawing.Point(187, 11);
			this.buttonClearFilter.Name = "buttonClearFilter";
			this.buttonClearFilter.Size = new System.Drawing.Size(20, 20);
			this.buttonClearFilter.TabIndex = 2;
			this.buttonClearFilter.TabStop = false;
			this.buttonClearFilter.UseVisualStyleBackColor = true;
			this.buttonClearFilter.Click += new System.EventHandler(this.ButtonClearFilterClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 14);
			this.label1.TabIndex = 1;
			this.label1.Text = "Filter :";
			// 
			// textBoxFilter
			// 
			this.textBoxFilter.Location = new System.Drawing.Point(54, 11);
			this.textBoxFilter.Name = "textBoxFilter";
			this.textBoxFilter.Size = new System.Drawing.Size(130, 20);
			this.textBoxFilter.TabIndex = 0;
			this.textBoxFilter.TextChanged += new System.EventHandler(this.TextBoxFilterTextChanged);
			// 
			// pictureListContent
			// 
			this.pictureListContent.AutoScroll = true;
			this.pictureListContent.BackColor = System.Drawing.Color.LightGray;
			this.pictureListContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureListContent.Location = new System.Drawing.Point(0, 61);
			this.pictureListContent.Name = "pictureListContent";
			this.pictureListContent.Size = new System.Drawing.Size(680, 395);
			this.pictureListContent.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.dateiToolStripMenuItem,
			this.anzeigeToolStripMenuItem,
			this.ansichtToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(680, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// dateiToolStripMenuItem
			// 
			this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.newEntryToolStripMenuItem,
			this.addReptoolStripMenuItem,
			this.eintragLöschenToolStripMenuItem,
			this.infoToolStripMenuItem,
			this.exitToolStripMenuItem});
			this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
			this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.dateiToolStripMenuItem.Text = "Datei";
			// 
			// newEntryToolStripMenuItem
			// 
			this.newEntryToolStripMenuItem.Name = "newEntryToolStripMenuItem";
			this.newEntryToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.newEntryToolStripMenuItem.Text = "Neuer Eintrag";
			this.newEntryToolStripMenuItem.Click += new System.EventHandler(this.NeuerEintragToolStripMenuItemClick);
			// 
			// addReptoolStripMenuItem
			// 
			this.addReptoolStripMenuItem.Name = "addReptoolStripMenuItem";
			this.addReptoolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.addReptoolStripMenuItem.Text = "Wiederholung hinzufügen";
			this.addReptoolStripMenuItem.Click += new System.EventHandler(this.AddReptoolStripMenuItemClick);
			// 
			// eintragLöschenToolStripMenuItem
			// 
			this.eintragLöschenToolStripMenuItem.Name = "eintragLöschenToolStripMenuItem";
			this.eintragLöschenToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.eintragLöschenToolStripMenuItem.Text = "Eintrag löschen";
			this.eintragLöschenToolStripMenuItem.Click += new System.EventHandler(this.EintragLöschenToolStripMenuItemClick);
			// 
			// infoToolStripMenuItem
			// 
			this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
			this.infoToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.infoToolStripMenuItem.Text = "Info";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.exitToolStripMenuItem.Text = "Beenden";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.BeendenToolStripMenuItemClick);
			// 
			// anzeigeToolStripMenuItem
			// 
			this.anzeigeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.unseenToolStripMenuItem,
			this.aktivToolStripMenuItem,
			this.pausedToolStripMenuItem,
			this.stoppedToolStripMenuItem,
			this.finishedToolStripMenuItem,
			this.badToolStripMenuItem,
			this.allSeriesToolStripMenuItem});
			this.anzeigeToolStripMenuItem.Name = "anzeigeToolStripMenuItem";
			this.anzeigeToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
			this.anzeigeToolStripMenuItem.Text = "Filter";
			// 
			// unseenToolStripMenuItem
			// 
			this.unseenToolStripMenuItem.CheckOnClick = true;
			this.unseenToolStripMenuItem.Name = "unseenToolStripMenuItem";
			this.unseenToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.unseenToolStripMenuItem.Tag = "Serie";
			this.unseenToolStripMenuItem.Text = "Ungesehen";
			this.unseenToolStripMenuItem.Click += new System.EventHandler(this.DisplayContentChanged);
			// 
			// aktivToolStripMenuItem
			// 
			this.aktivToolStripMenuItem.CheckOnClick = true;
			this.aktivToolStripMenuItem.Name = "aktivToolStripMenuItem";
			this.aktivToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.aktivToolStripMenuItem.Tag = "Serie";
			this.aktivToolStripMenuItem.Text = "Aktive";
			this.aktivToolStripMenuItem.Click += new System.EventHandler(this.DisplayContentChanged);
			// 
			// pausedToolStripMenuItem
			// 
			this.pausedToolStripMenuItem.CheckOnClick = true;
			this.pausedToolStripMenuItem.Name = "pausedToolStripMenuItem";
			this.pausedToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.pausedToolStripMenuItem.Tag = "Serie";
			this.pausedToolStripMenuItem.Text = "Pausierte";
			this.pausedToolStripMenuItem.Click += new System.EventHandler(this.DisplayContentChanged);
			// 
			// stoppedToolStripMenuItem
			// 
			this.stoppedToolStripMenuItem.CheckOnClick = true;
			this.stoppedToolStripMenuItem.Name = "stoppedToolStripMenuItem";
			this.stoppedToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.stoppedToolStripMenuItem.Tag = "Serie";
			this.stoppedToolStripMenuItem.Text = "Gestoppte";
			this.stoppedToolStripMenuItem.Click += new System.EventHandler(this.DisplayContentChanged);
			// 
			// finishedToolStripMenuItem
			// 
			this.finishedToolStripMenuItem.CheckOnClick = true;
			this.finishedToolStripMenuItem.Name = "finishedToolStripMenuItem";
			this.finishedToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.finishedToolStripMenuItem.Tag = "Serie";
			this.finishedToolStripMenuItem.Text = "Beendete";
			this.finishedToolStripMenuItem.Click += new System.EventHandler(this.DisplayContentChanged);
			// 
			// badToolStripMenuItem
			// 
			this.badToolStripMenuItem.CheckOnClick = true;
			this.badToolStripMenuItem.Name = "badToolStripMenuItem";
			this.badToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.badToolStripMenuItem.Tag = "Serie";
			this.badToolStripMenuItem.Text = "Schlechte";
			this.badToolStripMenuItem.Click += new System.EventHandler(this.DisplayContentChanged);
			// 
			// allSeriesToolStripMenuItem
			// 
			this.allSeriesToolStripMenuItem.CheckOnClick = true;
			this.allSeriesToolStripMenuItem.Name = "allSeriesToolStripMenuItem";
			this.allSeriesToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.allSeriesToolStripMenuItem.Tag = "Serie";
			this.allSeriesToolStripMenuItem.Text = "Alle anzeigen";
			this.allSeriesToolStripMenuItem.Click += new System.EventHandler(this.AllSeriesToolStripMenuItemClick);
			// 
			// ansichtToolStripMenuItem
			// 
			this.ansichtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.nurTextToolStripMenuItem,
			this.mitCoverToolStripMenuItem});
			this.ansichtToolStripMenuItem.Name = "ansichtToolStripMenuItem";
			this.ansichtToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.ansichtToolStripMenuItem.Text = "Ansicht";
			// 
			// nurTextToolStripMenuItem
			// 
			this.nurTextToolStripMenuItem.CheckOnClick = true;
			this.nurTextToolStripMenuItem.Name = "nurTextToolStripMenuItem";
			this.nurTextToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.nurTextToolStripMenuItem.Text = "Nur Text";
			this.nurTextToolStripMenuItem.Click += new System.EventHandler(this.NurTextToolStripMenuItemClick);
			// 
			// mitCoverToolStripMenuItem
			// 
			this.mitCoverToolStripMenuItem.CheckOnClick = true;
			this.mitCoverToolStripMenuItem.Name = "mitCoverToolStripMenuItem";
			this.mitCoverToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.mitCoverToolStripMenuItem.Text = "Mit Cover";
			this.mitCoverToolStripMenuItem.Click += new System.EventHandler(this.MitCoverToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(680, 456);
			this.Controls.Add(this.pictureListContent);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.menuStrip1);
			this.MinimumSize = new System.Drawing.Size(250, 250);
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.Shown += new System.EventHandler(this.MainFormShown);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripMenuItem addReptoolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem unseenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newEntryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mitCoverToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nurTextToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ansichtToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem badToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem finishedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stoppedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pausedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aktivToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem allSeriesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem anzeigeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private MedienListe.PictureList pictureListContent;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ToolStripMenuItem eintragLöschenToolStripMenuItem;
		private System.Windows.Forms.Button buttonClearFilter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxFilter;
	}
}
