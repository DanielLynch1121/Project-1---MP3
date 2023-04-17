/**
*--------------------------------------------------------------------
* File name: {Playlist.cs}
* Project name: {Projec 4 - MP3 Tracker with Files}
*--------------------------------------------------------------------
* Author’s name and email: {Daniel Lynch lynchda@etsu.edu}
* Course-Section: {002}
* Creation Date: {02/06/2023}
* -------------------------------------------------------------------
*/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project__4__MP3_Tracker_with_Files
{
    public class Playlist
    { 
        private List<MP3> _playlist { get; set; }
        private string _playlistName { get; set; }
        private string _creatorName { get; set; }
        private DateTime _creationDate { get; set; }
        public bool SaveNeeded { get; set; }

        public Playlist(string playlistName, string creatorName, DateTime creationDate)
        {
            _playlistName = playlistName;
            _creatorName = creatorName;
            _creationDate = creationDate;
            _playlist = new List<MP3>();
        }

        public void AddMP3(MP3 mp3)
        {
           _playlist.Add(mp3);
           SaveNeeded = true;
        }

        public void DeleteMP3ByTitle(string title)
        {
            MP3 mp3ToRemove = _playlist.Find(mp3 => mp3.GetSongTitle() == title);
            if (mp3ToRemove != null)
            {
                _playlist.Remove(mp3ToRemove);
                Console.WriteLine($"MP3 {title} was removed successfully. ");
            }
            else
            {
                Console.WriteLine($"No MP3 found with title '{title}'.");
            }
            SaveNeeded = true;
        }
        public void EditMP3(string songTitle, int attribute)
        {
            MP3 mp3ToEdit = _playlist.Find(mp3 => mp3.GetSongTitle() == songTitle);

            if (mp3ToEdit == null)
            {
                Console.WriteLine($"No MP3 found with album name '{songTitle}'.");
                return;
            }

            switch (attribute)
            {
                case 1:
                    Console.WriteLine("Enter new song title:");
                    string newTitle = Console.ReadLine();
                    mp3ToEdit.SetSongTitle(newTitle);
                    Console.WriteLine("Song title updated.");
                    break;
                case 2:
                    Console.WriteLine("Enter new artist name:");
                    string newArtist = Console.ReadLine();
                    mp3ToEdit.SetArtist(newArtist);
                    Console.WriteLine($"Artist name updated to {newArtist}.");
                    break;
                case 3:
                    Console.WriteLine("Enter new genre:");
                    string newGenreStr = Console.ReadLine();
                    if (Enum.TryParse(newGenreStr, out Genre newGenre))
                    {
                        mp3ToEdit.SetGenre(newGenre);
                        Console.WriteLine("Genre updated.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid genre.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid property choice.");
                    break;

                Console.WriteLine("Press <Enter> to continue");
                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            }
            
        }

        public void SortByTitle()
        {
            _playlist.Sort((mp31, mp32) => mp31.GetSongTitle().CompareTo(mp32.GetSongTitle()));
        }
        public void SortByDate()
        {
            _playlist.Sort((mp1, mp2) => mp1.GetSongReleaseDate().CompareTo(mp2.GetSongReleaseDate()));
        }
        public void DisplayAllMP3s()
        {
            foreach(MP3 mp3 in _playlist)
            {
                Console.WriteLine(mp3);
            }
        }
        public List<MP3> SearchByArtist(string artistName)
        {
            return _playlist.FindAll(mp3 => mp3.GetSongTitle().Contains(artistName));
        }
        public List<MP3> SearchByTitle(string title)
        {
            return _playlist.FindAll(mp3 => mp3.GetSongTitle().Contains(title));
        }
        public List<MP3> SearchByGenre(Genre genre)
        {
            return _playlist.FindAll(mp3 => mp3.GetGenre() == genre);
        }
        public static Playlist FillFromFile(string filePath)
        {
            Playlist playlist = new Playlist("name", "creator", new DateTime(2004, 03, 23));
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist at the given path.");
                return playlist;
            }
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                try
                {
                    string[] parts = line.Split('|');
                    string songTitle = parts[0];
                    string artist = parts[1];
                    DateTime songReleaseDate = DateTime.ParseExact(parts[2], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    double playbackTimeInMinutes = double.Parse(parts[3]);
                    string genre = parts[4];
                    Genre genreEnum = (Genre)Enum.Parse(typeof(Genre), genre);
                    decimal downloadCost = decimal.Parse(parts[5]);
                    double fileSizeInMBs = double.Parse(parts[6]);
                    string albumCoverPhoto = parts[7];

                    MP3 mp3 = new MP3(songTitle, artist, songReleaseDate, playbackTimeInMinutes, genreEnum, downloadCost, fileSizeInMBs, albumCoverPhoto);
                    playlist.AddMP3(mp3);
                    Console.WriteLine("Line parsed successfully: " + line);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error parsing line: " + line);
                }
            }
            return playlist;
        }
        public List<MP3> GetMP3s()
        {
            return _playlist;
        }
        public void SaveToFile(string fileName, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(filePath, fileName)))
                {
                    foreach (MP3 mp3 in _playlist)
                    {
                        string line = $"{mp3.GetSongTitle()}|{mp3.GetArtist()}|{mp3.GetSongReleaseDate()}|{mp3.GetPlayBackTimeInMinutes()}" +
                            $"|{mp3.GetGenre()}|{mp3.GetDownloadCost()}|{mp3.GetFileSizeInMBs()}|{mp3.GetAlbumCoverPhoto()}";
                        writer.WriteLine(line);
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("An Error occured while writing to the file. ");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Please Be sure you have access to the file you are trying to save to.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Please enter a valid file Path.");
            }
            catch
            {
                Console.WriteLine("An Error occured. ");
            }
        }
        public override string ToString()
        {
            return $"{_playlistName} created by {_creatorName} on {_creationDate} with {_playlist.Count} MP3s.";
      
        }  
    }   
}
