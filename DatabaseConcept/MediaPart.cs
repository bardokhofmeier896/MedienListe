/*
 * Created by SharpDevelop.
 * User: Phil
 * Date: 05.05.2018
 * Time: 10:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace DatabaseConcept
{
	/// <summary>
	/// Description of MediaPart.
	/// </summary>
	public class MediaPart
	{
		public Media Parent { get; set; }
		public string NameExtension { get; set; }
		public MediaType MediaType { get; set; }
		public string Language { get; set; }
		public Image Image { get; set; }
	}
}
