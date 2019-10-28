/*
 * Created by SharpDevelop.
 * User: Philipp
 * Date: 20.08.2013
 * Time: 16:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MedienListe
{
	/// <summary>
	/// Description of Media.
	/// </summary>
	public class Media
	{		
		public List<Detail> Details {get; private set; }
		private Image image;
		
		public int ID{ get; private set; }
		public string Type{ get; set; } //Serie oder Film
		public string Name{ get; set; }
		public string Genre{ get; set; } //Ungenutzt
		public KaEnum KA{ get; set; } //Ist es ein Anime oder mit echten Schauspielern
		public int Rating{ get; set; }
		public bool hasRepeat{ get; private set; }
		public Image Cover
		{ 
			get
			{
				return image;
			}
			set
			{
				if(value == null)
					return;
				
				SetSizedImage(value);
			}
		}
		
		public Detail LatestDetail
		{	
			get
			{
				return Details.Last();
			}
		}
		
		public Detail RepeatDetail
		{
			get
			{
				return hasRepeat ? Details.First(e => e.isRepeat) : null;				
			}
		}
				
		public Media(int id)
		{
			ID = id;
			hasRepeat = false;
			Details = new List<Detail>();
		}
		
		public void addDetail(Detail param)
		{
			if(Details.Contains(param))
				throw new Exception("Media.addDetail: Detail bereits in Media enthalten.");
			
			if(param.isRepeat && hasRepeat)
				throw new Exception("Media.addDetail: Media enthält bereits ein Wiederholungs-Detail.");

			hasRepeat = param.isRepeat;
			Details.Add(param);
			Details.Sort();
		}
		
		public void clearDetails()
		{
			Details = new List<Detail>();
		}
		
		public void clearRepeatDetail()
		{
			bool deleted = false;
			
			if(hasRepeat)
			{
				foreach(Detail detail in Details)
				{
					if(detail.isRepeat)
					{
						Details.Remove(detail);
						deleted = true;
						break;
					}
				}
			}
			
			if(!deleted)
				MessageBox.Show("Media.clearRepeatDetail: Keine Wiederholung vorhanden.");
		}
		
		public void replaceDetail(Detail old, Detail akt)
		{
			if(akt == null || old == null)
			{
				MessageBox.Show("Media.replaceDetail: Parameter Null");
				return;
			}
			
			if(Details.Remove(old))
			{
				Details.Add(akt);
				Details.Sort();
			}
			else
			{
				MessageBox.Show("Media.replaceDetail: Kein Detail zum ersetzen gefunden");
			}
		}
		
		public enum KaEnum
		{
			anime, 
			real
		}
		
		private void SetSizedImage(Image value)
		{
			double newWidth = 0;
			double newHeigth = 0;
			double sizeFactor = 0;
			
			if(value.Width > 450)
			{
				newWidth = 450;
				sizeFactor = newWidth/value.Width;
			    newHeigth = sizeFactor*value.Height;
			}
			else if(value.Height > 250)
			{
				newHeigth = 250;
				sizeFactor = newHeigth/value.Height;
			    newWidth = sizeFactor*value.Width;
			}
			else
			{
				image = value;
				return;
			}
			
			var newImage = new Bitmap((int) newWidth, (int) newHeigth);
		    using (Graphics g = Graphics.FromImage(newImage))
		    {
		        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
		        g.DrawImage(value, new Rectangle(0, 0, (int) newWidth, (int) newHeigth));
		    }
		    
		    image = newImage;
		}
	}
}