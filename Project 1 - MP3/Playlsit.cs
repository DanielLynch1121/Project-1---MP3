/**
*--------------------------------------------------------------------
* File name: {Playlist.cs}
* Project name: {Project 3 - MP3 Tracker}
*--------------------------------------------------------------------
* Author’s name and email: {Daniel Lynch ynchda@etsu.edu}
* Course-Section: {002}
* Creation Date: {02/06/2023}
* -------------------------------------------------------------------
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project_1___MP3
{
    internal class Playlist
    { 
        private List<MP3> _playlist { get; set; }
        private string _playlistName { get; set; }
        private string _creatorName { get; set; }
        private string _creationDate { get; set; }
        private bool saveNeeded { get; set; }

        public Playlist(string playlistName, string creatorName, string creationDate)
        {
            _playlistName = playlistName;
            _creatorName = creatorName;
            _creationDate = creationDate;
            _playlist = new List<MP3>();
        }

        public void AddMP3(MP3 mp3)
        {
           _playlist.Add(mp3);
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
            Console.WriteLine("Press <Enter> to continue");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
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
            _playlist.Sort((mp31, mp32) => DateTime.Parse(mp31.GetSongReleaseDate()).CompareTo(DateTime.Parse(mp32.GetSongReleaseDate())));
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
        public static void FillFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                try
                {
                    string[] parts = line.Split('|');
                    string songTitle = parts[0];
                    string artist = parts[1];
                    string songReleaseDate = parts[2];
                    double playbackTimeInMinutes = double.Parse(parts[3]);
                    
                    decimal downloadcost = decimal.Parse(parts[4]);
                    double fileSizeInMBs = double.Parse(parts[5]);
                    string albumCoverPhoto = parts[6];
                }
                catch
                {
                    
                }
            }
        }
        public void SaveToFile(string fileName, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach(MP3 mp3 in _playlist)
                {
                    string line = $"";
                    writer.WriteLine(line);
                }
            }
        }
        public override string ToString()
        {
            return $"{_playlistName} created by {_creatorName} on {_creationDate} with {_playlist.Count} MP3s.";
      
        }  
    }   
}
