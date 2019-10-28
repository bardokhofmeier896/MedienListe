/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Phil
 * Datum: 07.05.2014
 * Zeit: 14:11
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.Windows.Forms;

namespace MedienListe
{
	/// <summary>
	/// Description of MessageBoxOwn.
	/// </summary>
	public class MessageBoxOwn : Form
	{
		private TextBox textbox = new TextBox();
		private Button ok = new Button();
		private Button cancel = new Button();
		
		public string newName = "";
		
		public MessageBoxOwn(string seriesName)
		{
			StartPosition = FormStartPosition.Manual;
			Location = Cursor.Position;
			
			this.Width = 240;
			this.Height = 90;
			this.Text = "Serie umbennen";
			
			Controls.Add(textbox);
			Controls.Add(ok);
			Controls.Add(cancel);
			
			textbox.Text = seriesName;
			ok.Text = "Speichern";
			cancel.Text = "Abbruch";
			
			textbox.SetBounds(5, 5, 210, 20);
			ok.SetBounds(25, 30, 80, 20);
			cancel.SetBounds(115, 30, 80, 20);

			cancel.Click += this.ButtonCancelClick;
			ok.Click += this.ButtonOKClick;
			
			Visible = false;
		}
		
		void ButtonCancelClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			textbox.Dispose();
			ok.Dispose();
			cancel.Dispose();
			this.Dispose();
		}
		
		void ButtonOKClick(object sender, EventArgs e)
		{
			newName = textbox.Text;
			DialogResult = DialogResult.OK;
			this.Dispose();
		}
	}
}
