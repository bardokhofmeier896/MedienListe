/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Phil
 * Datum: 04.03.2014
 * Zeit: 19:24
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;

namespace MedienListe
{
	/// <summary>
	/// Controls access to the Database
	/// </summary>
	public class Database
	{	
		private static Database instance;
		private string connectionString;
		
		private Database(string databaseLocation)
		{
			if(databaseLocation == null || databaseLocation.Length < 1)
			{
				throw new Exception("Datenbankdateipfad ist leer.");
			} 
			
			connectionString = "Data Source=" + databaseLocation;
		}
		
		/// <summary>
		/// Provides a filtered list of the content.
		/// </summary>
		public List<PictureListItem> getData(string category, List<int> type)
		{
			if(type.Count < 1)
				return null;
			
			List<PictureListItem> ret = new List<PictureListItem>();
			
			using (SQLiteConnection connection = new SQLiteConnection(connectionString))
			{
				try
				{
					connection.Open();
					
					string typeString = "";
					foreach(int item in type)
						typeString += item + ",";
					typeString = typeString.Substring(0, typeString.Length-1);

					using(SQLiteCommand command = new SQLiteCommand("SELECT * FROM Media WHERE Type = @type AND ID IN (SELECT DISTINCT MediaID FROM Details WHERE AktivStatus IN (" + typeString + "))", connection))
					{
						command.Parameters.AddWithValue("@type", category);
						using(SQLiteDataReader reader = command.ExecuteReader())
						{
							while(reader.Read())
				            {
								try
								{
									Media item = createMediaFromReader(reader);
									
									using(SQLiteCommand detCommand = new SQLiteCommand("SELECT * FROM Details WHERE MediaID=@id", connection))
									{
										detCommand.Parameters.AddWithValue("@id", item.ID);
										using(SQLiteDataReader detailReader = detCommand.ExecuteReader())
										{
											while(detailReader.Read())
											{
												item.addDetail(createDetailFromReader(detailReader));
											}
										}
										
										ret.Add(new PictureListItem(item));
									}
								}
								catch(Exception ex) 
								{
									MessageBox.Show(ex.ToString());
								}
			            	}
						}
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("Database.getData: " + ex);
				}
			}
			
			return ret;
		}
		
		public List<NamePuffer> getAllNames()
		{
			List<NamePuffer> ret = new List<NamePuffer>();
			
			using (SQLiteConnection connection = new SQLiteConnection(connectionString))
			{
				try
				{
					connection.Open();
					
					using(SQLiteCommand command = new SQLiteCommand("SELECT m.id, m.name, d.count FROM Media m, (SELECT mediaid, COUNT(mediaid) as count FROM Details GROUP BY mediaid) d WHERE m.id = d.mediaid AND count < 2 ORDER BY m.name", connection))
					{
						using(SQLiteDataReader reader = command.ExecuteReader())
						{
							while(reader.Read())
				            {
								NamePuffer tmp = new NamePuffer();
								tmp.ID = reader.GetInt32(0);
								tmp.Name = reader.GetString(1);
								ret.Add(tmp);
							}
						}
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("Database.getAllNames: " + ex);
				}
			}
			
			return ret;
		}
		
		public Media getMediaById(int id)
		{
			return getMediaByValue("ID=@var", id.ToString());
		}
		
		public Media getMediaByName(string name)
		{
			return getMediaByValue("Name=@var", name);
		}
		
		private Media getMediaByValue(string where, string value)
		{
			Media ret = null;
			
			using (SQLiteConnection connection = new SQLiteConnection(connectionString))
			{
				try
				{
					connection.Open();
	
					using(SQLiteCommand command = new SQLiteCommand("SELECT * FROM Media WHERE " + where, connection))
					{
						command.Parameters.AddWithValue("@var", value);
						using(SQLiteDataReader reader = command.ExecuteReader())
						{
							reader.Read();
							
							if(reader.HasRows)
							{
								ret = createMediaFromReader(reader);
								
								using(SQLiteCommand command2 = new SQLiteCommand("SELECT * FROM Details WHERE mediaID=@ID", connection))
								{
									command2.Parameters.AddWithValue("@ID", ret.ID);
									using(SQLiteDataReader reader2 = command2.ExecuteReader())
									{
										while(reader2.Read())
										{
											ret.addDetail(createDetailFromReader(reader2));
										}
									}
								}
							}
						}
					}	
				}
				catch(Exception ex)
				{
					MessageBox.Show("Database.getMediaByValue: " + ex);
				}
			}
			
			return ret;
		}
		
		public void addNewEntry(Media neu)
		{
			using (SQLiteConnection connection = new SQLiteConnection(connectionString))
			{
				try
				{
					connection.Open();
					SQLiteTransaction trans =  connection.BeginTransaction();
					
					using(SQLiteCommand command = new SQLiteCommand("INSERT INTO Media VALUES(null, @type, @name, @genre, @image, @ka, @rating)", connection))
					{
						command.Parameters.AddWithValue("@type", neu.Type);
						command.Parameters.AddWithValue("@name", neu.Name);
						command.Parameters.AddWithValue("@genre", neu.Genre);
						command.Parameters.AddWithValue("@image", neu.Cover != null ? imageToByteArray(neu.Cover): null);
						command.Parameters.AddWithValue("@ka", neu.KA);
						command.Parameters.AddWithValue("@rating", neu.Rating);
						command.ExecuteNonQuery();
					}
					
					int id = 0;
					using(SQLiteCommand command = new SQLiteCommand("SELECT last_insert_rowid() FROM MEDIA", connection))
					{
						command.Parameters.AddWithValue("@name", neu.Name);
						SQLiteDataReader ret = command.ExecuteReader();
						ret.Read();
						id = ret.GetInt32(0);
					}
					
					using(SQLiteCommand command = new SQLiteCommand("INSERT INTO Details VALUES(@mID, @sequenz, @name, @language, @status, @isRepeat, @lsEpisode, @lsSeason, @finished)", connection))
					{
						command.Parameters.AddWithValue("@mID", id);
						command.Parameters.AddWithValue("@sequenz", 0);
						command.Parameters.AddWithValue("@name", neu.LatestDetail.Name);
						command.Parameters.AddWithValue("@language", neu.LatestDetail.ViewLanguage);
						command.Parameters.AddWithValue("@lsEpisode", neu.LatestDetail.LastSeenEpisode);
						command.Parameters.AddWithValue("@lsSeason", neu.LatestDetail.LastSeenSeason);
						command.Parameters.AddWithValue("@status", neu.LatestDetail.AktivStatus);
						command.Parameters.AddWithValue("@finished", neu.LatestDetail.LastSeenSeasonFinished);
						command.Parameters.AddWithValue("@isRepeat", false); //Immer falsch da neu
						command.ExecuteNonQuery();
					}

					trans.Commit();
				}
				catch(Exception ex)
				{
					MessageBox.Show("Database.addNewEntry: " + ex);
				}
			}
		}
		
		public void addDetail(int mediaID, Detail insert)
		{
			using (SQLiteConnection connection = new SQLiteConnection(connectionString))
			{
				try
				{
					connection.Open();
					
					using(SQLiteCommand command = new SQLiteCommand("INSERT INTO Details VALUES(@mID, (SELECT max(MediaSequenzID) FROM Details WHERE mediaID = @mID)+1, @name, @language, @status, @isRepeat, @lsEpisode, @lsSeason, @finished)", connection))
					{
						command.Parameters.AddWithValue("@mID", mediaID);
						command.Parameters.AddWithValue("@sequenz", insert.MediaSequenzID);
						command.Parameters.AddWithValue("@name", insert.Name);
						command.Parameters.AddWithValue("@language", insert.ViewLanguage);
						command.Parameters.AddWithValue("@lsEpisode", insert.LastSeenEpisode);
						command.Parameters.AddWithValue("@lsSeason", insert.LastSeenSeason);
						command.Parameters.AddWithValue("@status", insert.AktivStatus);
						command.Parameters.AddWithValue("@finished", insert.LastSeenSeasonFinished);
						command.Parameters.AddWithValue("@isRepeat", insert.isRepeat); //Immer falsch
						command.ExecuteNonQuery();
					}
					
				}
				catch(Exception ex)
				{
					MessageBox.Show("Database.addDetail: " + ex);
				}
			}
		}
		
		public int updateMedia(Media media)
		{
			int ret = -1;
			using (SQLiteConnection connection = new SQLiteConnection(connectionString))
			{
				try
				{
					connection.Open();
					
					using(SQLiteCommand command = new SQLiteCommand("", connection))
					{
						command.CommandText = @"UPDATE Media SET name = @name, genre = @ge, ka = @ka, rating = @ra WHERE ID=@id";
						
						command.Parameters.AddWithValue("@name", media.Name);
						command.Parameters.AddWithValue("@ge", media.Genre);//media.Genre);
						command.Parameters.AddWithValue("@ka", media.KA);
						command.Parameters.AddWithValue("@ra", media.Rating);
						command.Parameters.AddWithValue("@id", media.ID);
						
						ret = command.ExecuteNonQuery();
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("Database.updateMedia: " + ex);
				}
			}
			
			return ret;
		}
		
		public int updateImage(Media media)
		{
			int ret = -1;
			using (SQLiteConnection connection = new SQLiteConnection(connectionString))
			{
				try
				{
					connection.Open();
					
					using(SQLiteCommand command = new SQLiteCommand(@"UPDATE Media SET image = @im WHERE id=@id", connection))
					{
						command.Parameters.AddWithValue("@im", imageToByteArray(media.Cover));
						command.Parameters.AddWithValue("@id", media.ID);
						
						ret = command.ExecuteNonQuery();
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("Database.updateImage: " + ex);
				}
			}
			
			return ret;
		}
		
		public int updateDetails(Detail detail)
		{
			int ret = -1;
			using (SQLiteConnection connection = new SQLiteConnection(connectionString))
			{
				try
				{
					connection.Open();
					
					using(SQLiteCommand command = new SQLiteCommand(@"UPDATE Details SET language=@la, lastSeenEpisode=@ep, lastSeenSeason=@se, AktivStatus=@ak, lastSeenSeasonFinished=@fi WHERE MediaID=@mID AND MediaSequenzID=@sequenz", connection))
					{
						command.Parameters.AddWithValue("@la", detail.ViewLanguage);
						command.Parameters.AddWithValue("@ep", detail.LastSeenEpisode);
						command.Parameters.AddWithValue("@se", detail.LastSeenSeason);
						command.Parameters.AddWithValue("@ak", detail.AktivStatus);
						command.Parameters.AddWithValue("@fi", detail.LastSeenSeasonFinished);
						command.Parameters.AddWithValue("@mID", detail.MediaID);
						command.Parameters.AddWithValue("@sequenz", detail.MediaSequenzID);
						
						ret = command.ExecuteNonQuery();
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("Database.updateDetails: " + ex);
				}
			}
			
			return ret;
		}
		
		public int deleteRepDetail(Detail detail)
		{
			int ret = -1;
			
			if(detail.isRepeat)
			{
				using (SQLiteConnection connection = new SQLiteConnection(connectionString))
				{
					try
					{
						connection.Open();
						
						using(SQLiteCommand command = new SQLiteCommand(@"DELETE FROM Details WHERE MediaID=@mID AND MediaSequenzID=@sequenz AND isRepeat=1", connection))
						{						
							command.Parameters.AddWithValue("@mID", detail.MediaID);
							command.Parameters.AddWithValue("@sequenz", detail.MediaSequenzID);
							
							ret = command.ExecuteNonQuery();
						}
					}
					catch(Exception ex)
					{
						MessageBox.Show("Database.deleteRepDetail: " + ex);
					}
				}
			}
			
			return ret;
		}
		
		public void deleteMedia(Media delete)
		{
			using (SQLiteConnection connection = new SQLiteConnection(connectionString))
				{
					try
					{
						connection.Open();
						SQLiteTransaction trans = connection.BeginTransaction();
						
						using(SQLiteCommand command = new SQLiteCommand("DELETE FROM Details WHERE mediaID=@id", connection))
						{
							command.Parameters.AddWithValue("@id", delete.ID);
							command.ExecuteNonQuery();
						}
						
						using(SQLiteCommand command = new SQLiteCommand("DELETE FROM Media WHERE id=@id", connection))
						{
							command.Parameters.AddWithValue("@id", delete.ID);
							command.ExecuteNonQuery();
						}
						
						trans.Commit();
					}
					catch(Exception ex)
					{
						MessageBox.Show("Database.deleteMedia: " + ex);
					}
				}
		}
		
		public static Database getInstance()
		{
			if(instance == null)
				instance = new Database(Config.getInstance().DatabaseLocation);
			return instance;
		}
		
		private byte[] imageToByteArray(Image img)
		{
			ImageConverter imageConverter = new ImageConverter();
			return (byte[])imageConverter.ConvertTo(img, typeof(byte[]));
		}
						
		public Media createMediaFromReader(SQLiteDataReader reader) {
			Media insert = new Media(reader.GetInt32(0));
			
			insert.Type = reader.GetString(1);
			insert.Name = reader.GetString(2);
			if(!reader.IsDBNull(3))
				insert.Genre = reader.GetString(3);

			if(!reader.IsDBNull(4))
			{
				byte[] image = (byte[])reader.GetValue(4);
				MemoryStream ms = new MemoryStream(image);
				insert.Cover = Image.FromStream(ms);
			}
			
			insert.KA = (Media.KaEnum) Enum.Parse(typeof(Media.KaEnum), reader.GetString(5));
			insert.Rating = reader.GetInt32(6);
			
			return insert;
		}
		
		public Detail createDetailFromReader(SQLiteDataReader reader) {
			Detail insert = new Detail(reader.GetInt32(0));
			
			insert.MediaSequenzID = reader.GetInt32(1);
			if(!reader.IsDBNull(2))
				insert.Name = reader.GetString(2);
			insert.ViewLanguage = (Detail.Language) reader.GetInt32(3);
			insert.AktivStatus = (Detail.Status) reader.GetInt32(4);
			insert.isRepeat = reader.GetBoolean(5);
			insert.LastSeenEpisode = reader.GetInt32(6);
			insert.LastSeenSeason = reader.GetInt32(7);
			insert.LastSeenSeasonFinished = reader.GetBoolean(8);
			
			return insert;
		}
	}
}