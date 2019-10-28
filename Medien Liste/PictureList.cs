/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Philipp
 * Datum: 23.08.2013
 * Zeit: 17:33
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.IO;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MedienListe
{
	public class PictureList : Panel
	{
		private List<PictureListItem> content;
		private Config config;
		private Order displayOrder;
		private bool changed;
		private int displayMode;
		private bool displayModeChanged;
		private int objectInCollumn;
		private int innerPadding;
		private string filter;
		
		public int ObjectInCollumn 
		{
			get
			{
				return objectInCollumn;
			}
		}
		
		public new Padding Padding;
		
		public PictureList() : this(100, 100) {}
		
		public PictureList(int width, int height)
		{
			displayOrder = new Order();
			content = new List<PictureListItem>();
			config = Config.getInstance();
			Padding = new Padding(5);
			
			changed = true;
			displayMode = DisplayMode.PlainText;
			displayModeChanged = false;
			objectInCollumn = 3;
			innerPadding = 5;
			filter = "";
			
			Clear();
			setHeight(width);
			setWidth(height);
			
			BackColor = Color.LightGray;
			Visible = true;
		}
		
		public void setHeight(int height)
		{
			Height = height;
		}
		
		public void setWidth(int width)
		{
			Width = width;
		}
		
		public void Clear()
		{
			content.Clear();
			changed = true;
			this.Refresh();
		}
		
		public void replaceItem(PictureListItem item)
		{
			throw new NotImplementedException("Diese Funktion existiert noch nicht.");
		}
		
		public void addRange(List<PictureListItem> items)
		{
			if(items == null || items.Count < 1)
				return;
			
			this.SuspendLayout();
			foreach(PictureListItem item in items)
			{
				item.setDisplayMode(this.displayMode);
				content.Add(item);
			}
			changed = true;
			sortList();
			this.ResumeLayout();
			Refresh();
		}
		
		public void addItem(PictureListItem item)
		{
			if(item == null)
				return;
			
			item.setDisplayMode(this.displayMode);
			content.Add(item);
			changed = true;
			sortList();
			Refresh();
		}
		
		public void remove(PictureListItem item)
		{
			if(item == null)
				return;
			
			content.Remove(item);
			changed = true;
			//sortList();
			Refresh();
		}
		
		public PictureListItem getItemByMedia(Media media)
		{
			foreach(PictureListItem item in content)
			{
				if(item.Content.ID == media.ID)
					return item;
			}
			
			return null;
		}
		
		public void setDisplayMode(int mode)
		{
			if(mode != displayMode)
			{
				displayMode = mode;
				displayModeChanged = true;
				changed = true;
			}
		}
		
		public void setDisplayOrder(Order.OrderBy order)
		{
			displayOrder.order = order;
			sortList();
		}
		
		public void sortList()
		{
			content.Sort(displayOrder);
			changed = true;
		}
		
		public void setFilter(string filter)
		{
			if(filter != null)
			{
				this.filter = filter;
				changed = true;
			}
		}
		
		protected override void OnPaint(PaintEventArgs e)
		{
			if(changed)
			{
				SuspendLayout();
				this.Controls.Clear();
				
				if(content.Count > 0)
				{
					char aktStartChar = content[0].Name.ToLower()[0];
					int aktRating = content[0].Rating;
					Point aktItemPos = new Point(Padding.Left, Padding.Top);
					int countx = 0;
					
					foreach(PictureListItem item in content)
					{
						if(displayModeChanged)
							item.setDisplayMode(displayMode);
						
						bool newRow = false;
						
						if(countx >= objectInCollumn)
							newRow = true;
						/*
						switch(displayOrder.order)
						{
							case Order.OrderBy.NameAsc: 
							case Order.OrderBy.NameDesc:
								if(item.Name.ToLower()[0] != aktStartChar)
									newRow = true;
								break;
							case Order.OrderBy.RatingAsc:
							case Order.OrderBy.RatingDesc:
								if(item.Rating != aktRating)
									newRow = true;
								break;
						}*/
						
						if(newRow)
						{
							countx = 0;
							aktItemPos.X = Padding.Left;
							aktItemPos.Y = aktItemPos.Y + item.Height + Padding.All;
						}
						
						if(checkFilter(item)) //Nur anzeigen wenn der Filter(Textfeld) passt
						{
							aktStartChar = item.Name.ToLower()[0];
						
							item.Location = aktItemPos;
							this.Controls.Add(item);
							
							aktItemPos.X = aktItemPos.X + item.Width + innerPadding;
							
							countx++;
						}
					}
				}
				displayModeChanged = false;
				changed = false;
				
				ResumeLayout();
			}
			
			base.OnPaint(e);
		}
		
		bool checkFilter(PictureListItem item) {
			if(item.Name.ToLower().Contains(filter.ToLower()))
				return true;
			
			return false;
		}
		
		protected override void OnSizeChanged(EventArgs e)
		{		
			int totalwidth = this.Width;
			int newObjectInCollumn = (totalwidth - Padding.Horizontal-20)/(170+innerPadding);
			
			if(objectInCollumn != newObjectInCollumn)
			{
				objectInCollumn = newObjectInCollumn;
				changed = true;
				OnPaint(null);
			}
			
			base.OnSizeChanged(e);
		}
		
		public class Order : IComparer<PictureListItem>
		{
			public OrderBy order{ get; set; }
			
			public enum OrderBy
			{
				NameAsc,
				NameDesc,
				RatingAsc,
				RatingDesc
			}
			
		    public int Compare(PictureListItem x, PictureListItem y)
	 		{
		    	switch(order)
		    	{
		    		case OrderBy.NameDesc:
		    			return y.Name.CompareTo(x.Name);
		    		case OrderBy.RatingAsc:
		    			return x.Rating.CompareTo(y.Rating);
		    		case OrderBy.RatingDesc:
		    			return y.Rating.CompareTo(x.Rating);
	    			default:
		    			return x.Name.CompareTo(y.Name);
		    	}
		    }
		}
		
		public static class DisplayMode
		{
			public static readonly int PlainText = 0;
			public static readonly int Pictures = 1;			
		}
	}
}
