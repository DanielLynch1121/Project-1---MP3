/**
*--------------------------------------------------------------------
* File name: {Program.cs}
* Project name: {Project 3 - MP3}
*--------------------------------------------------------------------
* Author’s name and email: {Daniel Lynch ynchda@etsu.edu}
* Course-Section: {002}
* Creation Date: {02/02/2023}
* -------------------------------------------------------------------
*/
using System;
using System.Globalization;

namespace Project_1___MP3
{
    public class Program
    {
        static void Main(string[] args)
        {
            // variables for MP3 object
            string songTitle;
            string artist;
            DateTime songReleaseDate;
            double playbackTimeInMinutes;
            string genre;
            Genre getParse;
            decimal downloadCost;
            double fileSizeInMBs;
            string albumCoverPhoto = "";
            // variables for Playlist object
            string playlistName;
            string titleToRemove;
            string creatorName;
            bool saveNeeded;
            DateTime creationDate;
            MP3 userMP3 = null;
            Playlist userPlaylist = null;
            
            // Welcome Page with my center text Method
            CenterText("Project: MP3 Tracker");
            CenterText("-------------------------------");
            CenterText("Demonstrates the functionality of the MP3 class.");
            CenterText("-------------------------------");
            CenterText("Created By: Daniel Lynch");

            string name;
            Console.Write("Please Enter Your Name: ");
            name = Console.ReadLine();
           
            do
            {
                Console.Clear();
                int userInput = 0;
                
                // Main Menu
                CenterText("Menu");
                CenterText("--------------------------------");
                Console.WriteLine("1. Create a new Playlist for the MP3 Tracker"); 
                Console.WriteLine("2. Create a new MP3 object and add it to the playlist");
                Console.WriteLine("3. Edit an existing MP3 from the playlist");
                Console.WriteLine("4. Drop an MP3 from the playlist");
                Console.WriteLine("5. Display all MP3s in the playlist");
                Console.WriteLine("6. Find and display an MP3 by song title");
                Console.WriteLine("7. Display all MP3s on the tracker of a given genre");
                Console.WriteLine("8. Display all MP3s on the tracker with a given artist");
                Console.WriteLine("9. Sort the MP3s by song title");
                Console.WriteLine("10. Sort the MP3s by song release date");
                Console.WriteLine("11. Import MP3's from file");
                Console.WriteLine("12. Save Playlist to a file");
                Console.WriteLine("13. Exit");
                Console.Write("Type The Number Of Your Choice: ");
                
                // Validation for the number typed into the Main Menu
                if (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 1 || userInput > 11)
                {
                    CenterText("Invalid choice. Please enter a number from 1 to 11.");
                    CenterText("Press <Enter> to continue");
                    while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                }

                switch (userInput)
                {
                    // Case 1 Creates A New Playlist object
                    case 1:
                        Console.Clear();
                        Console.Write("1. Please Enter the Playlist Name: ");
                        playlistName = Console.ReadLine();
                        while (string.IsNullOrEmpty(playlistName))
                        {
                            Console.Write("Playlist Name cannot be empty. Please enter the Playlist Name again: ");
                            playlistName = Console.ReadLine();
                        }
                        Console.Write("2. Please Enter the Creators Name: ");
                        creatorName = Console.ReadLine();
                        while (string.IsNullOrEmpty(creatorName))
                        {
                            Console.Write("Creator Name cannot be empty. Please enter the Creator Name again: ");
                            creatorName = Console.ReadLine();
                        }
                        Console.Write("3. Please enter the Creation Date MM/DD/YYYY: ");
                        string creationDateStr = Console.ReadLine();
                        while (!DateTime.TryParseExact(creationDateStr, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out creationDate))
                        {
                            Console.Write("Invalid date format. Please enter the date in MM/DD/YYYY format: ");
                            creationDateStr = Console.ReadLine();
                        }
                        userPlaylist = new Playlist(playlistName, creatorName, creationDate);
                        userPlaylist.SaveNeeded = true;
                        break;

                    // Case 2 Creates a new MP3 Object and Stores it in the playlist
                    case 2:
                        Console.Clear();

                        if (userPlaylist != null)
                        {
                            CenterText("Create an MP3");
                            CenterText("-----------------------------");
                            Console.Write(" 1. Please Enter The Songs Title:");
                            songTitle = Console.ReadLine();
                            while (string.IsNullOrEmpty(songTitle))
                            {
                                Console.Write("Song Title cannot be empty. Please enter the title again: ");
                                songTitle = Console.ReadLine();
                            }
                            Console.Write(" 2. Please Enter The Artit's Name:");
                            artist = Console.ReadLine();
                            while (string.IsNullOrEmpty(artist))
                            {
                                Console.Write("Artist Name cannot be empty. Please enter the artist's name again: ");
                                songTitle = Console.ReadLine();
                            }
                            Console.Write(" 3. Please Enter The Release Date (MM/DD/YYYY): ");
                            string releaseDate = Console.ReadLine();
                            while (!DateTime.TryParseExact(releaseDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out songReleaseDate))
                            {
                                Console.Write("Invalid date format. Please enter the date in MM/DD/YYYY format: ");
                                releaseDate = Console.ReadLine();
                            }
                            Console.Write("4. Please Enter The Playback Time (Minutes): ");
                            while (!double.TryParse(Console.ReadLine(), out playbackTimeInMinutes) || playbackTimeInMinutes <= 0)
                            {
                                Console.Write("Invalid input. Please enter a positive number for the playback time in minutes: ");
                            }
                            Console.Write(" 5. Please Enter The Song's Genre (Rock, Pop, Jazz, Country, Classical, Lofi, Funk, Rap, Other): ");
                            genre = Console.ReadLine();
                            if (!Enum.IsDefined(typeof(Genre), genre))
                            {
                                Console.WriteLine("Invalid genre. Please enter a valid genre.");
                                continue;
                            }
                            Enum.TryParse(genre, out getParse);
                            Console.Write(" 6. Please Enter The Download Cost: $");
                            while (!decimal.TryParse(Console.ReadLine(), out downloadCost) || downloadCost <= 0)
                            {
                                Console.Write("Invalid input. Please enter a positive number for the download cost: ");
                            }
                            Console.Write(" 7. Please Enter The File Size (MB): ");
                            while (!double.TryParse(Console.ReadLine(), out fileSizeInMBs) || fileSizeInMBs <= 0)
                            {
                                Console.Write("Invalid input. Please enter a positive number for the file size: ");
                            }
                            fileSizeInMBs = Convert.ToDouble(Console.ReadLine());
                            Console.Write(" 8. Please Enter the Path Of The Album Cover Photo: ");
                            while (string.IsNullOrEmpty(albumCoverPhoto))
                            {
                                Console.Write("The album Cover photo path cannot be empty. Please enter the path again: ");
                                songTitle = Console.ReadLine();
                            }
                            userMP3 = new MP3(songTitle, artist, songReleaseDate, playbackTimeInMinutes, getParse, downloadCost, fileSizeInMBs, albumCoverPhoto);

                            userPlaylist.AddMP3(userMP3);
                            userPlaylist.SaveNeeded = true;
                        }
                        else 
                        {
                            Console.Clear();
                            CenterText("Please Create a Playlist Before adding MP3s to it.");
                        }
                        CenterText("Press <Enter> to continue");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        break;
                    case 3:
                        Console.Clear();
                        bool istrue = false;
                        while(!istrue)
                        {
                            try
                            {
                                Console.Write("Please Enter the song title of the MP3 you would like to edit: ");
                                string searchTitle = Console.ReadLine();
                                Console.WriteLine("Which attribute do you want to edit?");
                                Console.WriteLine("1. Song Title");
                                Console.WriteLine("2. Artist Name");
                                Console.WriteLine("3. Genre");

                                int mp3Attribute;
                                while (!int.TryParse(Console.ReadLine(), out mp3Attribute) || mp3Attribute < 1 || mp3Attribute > 3)
                                {
                                    Console.WriteLine("Please enter a number between 1 and 3.");
                                }

                                userPlaylist.EditMP3(searchTitle, mp3Attribute);
                                userPlaylist.SaveNeeded = true;
                                istrue = true;
                            }
                            catch
                            {
                                Console.WriteLine("An error occured. Please try agian");
                            }
                            CenterText("Press <Enter> to continue");
                            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Enter the title of the song you would like to remove: ");
                        titleToRemove = Console.ReadLine();
                        while (string.IsNullOrEmpty(titleToRemove))
                        {
                            Console.Write("Song Title cannot be empty. Please enter the title again: ");
                            titleToRemove = Console.ReadLine();
                        }
                        userPlaylist.DeleteMP3ByTitle(titleToRemove);
                        userPlaylist.SaveNeeded = true;
                        CenterText("Press <Enter> to continue");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        break;
                    case 5:
                        Console.Clear();
                        if (userMP3 != null)
                        {
                            userPlaylist.DisplayAllMP3s();
                        }
                        else
                        {
                            Console.WriteLine("There are no MP3s to Display.");
                        }
                        CenterText("Press <Enter> to continue");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        break;
                    case 6:
                        Console.Clear();
                        Console.Clear();
                        if (userPlaylist != null && userMP3 != null)
                        {
                            try
                            {
                                Console.WriteLine("Enter the title of the song you would like to search for: ");
                                string titleSearch = Console.ReadLine();
                                while (string.IsNullOrEmpty(titleSearch))
                                {
                                    Console.Write("Song Title cannot be empty. Please enter the title again: ");
                                    titleToRemove = Console.ReadLine();
                                }
                                List<MP3> results = userPlaylist.SearchByTitle(titleSearch);
                                if (results.Count > 0)
                                {
                                    Console.WriteLine("Matching MP3s found:");
                                    foreach (MP3 mp3 in results)
                                    {
                                        Console.WriteLine(mp3);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No matching MP3s found.");
                                }
                                CenterText("Press <Enter> to continue");
                                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                            }
                            catch
                            {
                                Console.WriteLine("The song you are looking for hasn't been created yet.");
                                CenterText("Press <Enter> to continue");
                                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                            }
                        }

                        break;
                    case 7:
                        Console.Clear();
                        if (userPlaylist != null && userMP3 != null)
                        {
                            Console.WriteLine("Enter the genre of the songs you would like to search for: ");
                            Genre searchGenre;
                            if (!Enum.TryParse(Console.ReadLine(), true, out searchGenre))
                            {
                                Console.WriteLine("Invalid genre. Please enter a valid genre.");
                                CenterText("Press <Enter> to continue");
                                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                                return;
                            }

                            List<MP3> results = userPlaylist.SearchByGenre(searchGenre);
                            if (results.Count > 0)
                            {
                                Console.WriteLine($"Found {results.Count} MP3(s) with genre {searchGenre}:");
                                foreach (MP3 mp3 in results)
                                {
                                    Console.WriteLine($"{mp3.GetSongTitle()} by {mp3.GetArtist()}");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"No MP3s found with genre {searchGenre}.");
                            }
                            CenterText("Press <Enter> to continue");
                            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        }

                        break;
                    case 8:
                        Console.Clear();
                        if (userPlaylist != null && userMP3 != null)
                        {
                            try
                            {
                                Console.WriteLine("Enter the name of the artist you would like to search for: ");
                                string artistName = Console.ReadLine();
                                while (string.IsNullOrEmpty(artistName))
                                {
                                    Console.Write("Artis's Name cannot be empty. Please enter the name again: ");
                                    artistName = Console.ReadLine();
                                }
                                List<MP3> results = userPlaylist.SearchByArtist(artistName);
                                Console.WriteLine($"Here are all the MP3s in the playlist by {artistName}:");
                                foreach (MP3 mp3 in results)
                                {
                                    Console.WriteLine(mp3.ToString());
                                }
                                CenterText("Press <Enter> to continue");
                                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                            }
                            catch
                            {
                                Console.WriteLine("No MP3s by that artist found in the playlist.");
                                CenterText("Press <Enter> to continue");
                                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                            }
                        }
                        break;
                    case 9:
                        Console.Clear();
                        userPlaylist.SortByTitle();
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        break;
                    case 10:
                        Console.Clear();
                        userPlaylist.SortByDate();
                        CenterText("Press <Enter> to continue");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        break;
                    case 11:
                        Console.Clear();
                        if (saveNeeded = true)
                        {
                            Console.WriteLine("The current playlist has unsaved changes. Do you want to save the changes? (Y/N)");
                            ConsoleKey response = Console.ReadKey(true).Key;
                            if (response == ConsoleKey.Y)
                            {
                                Console.WriteLine("Enter the file name:");
                                string savefileName = Console.ReadLine();
                                while (string.IsNullOrEmpty(savefileName))
                                {
                                    Console.Write("File name cannot be empty. Please enter the file name again: ");
                                    savefileName = Console.ReadLine();
                                }

                                Console.WriteLine("Enter the file path to save the playlist:");
                                string saveFilePath = Console.ReadLine();
                                while (string.IsNullOrEmpty(saveFilePath))
                                {
                                    Console.Write("File path cannot be empty. Please enter the file path again: ");
                                    saveFilePath = Console.ReadLine();
                                }
                                userPlaylist.SaveToFile(savefileName, saveFilePath);
                            }
                        }
                        Console.Write("Enter the file path of the MP3s you would like to import:");
                        string filePath = Console.ReadLine();
                        while (string.IsNullOrEmpty(filePath))
                        {
                            Console.Write("File path cannot be empty. Please enter the file path again: ");
                            filePath = Console.ReadLine();
                        }
                        List<MP3> mp3List = Playlist.FillFromFile(filePath);
                        foreach (MP3 mp3 in mp3List)
                        {
                            userPlaylist.AddMP3(mp3);
                        }
                        saveNeeded = true;
                        CenterText("Press <Enter> to continue");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }

                        break; 
                    case 12:
                        Console.Clear();
                        Console.Write("Please enter the file name: ");
                        string fileName = Console.ReadLine();
                        while (string.IsNullOrEmpty(fileName))
                        {
                            Console.Write("Song Title cannot be empty. Please enter the title again: ");
                            fileName = Console.ReadLine();
                        }
                        Console.Write("Please Enter the file path: ");
                        string Path = Console.ReadLine();
                        while (string.IsNullOrEmpty(Path))
                        {
                            Console.Write("Song Title cannot be empty. Please enter the title again: ");
                            Path = Console.ReadLine();
                        }
                        userPlaylist.SaveToFile(fileName, Path);
                        userPlaylist.SaveNeeded = false;
                        CenterText("Press <Enter> to continue");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        break;
                    case 13:
                        Console.Clear();
                        if (userPlaylist != null && userPlaylist.SaveNeeded )
                        {
                            Console.WriteLine("Changes have been made to the playlist. Do you want to save before exiting? (Y/N)");
                            string response = Console.ReadLine();

                            if (response.ToLower() == "y")
                            {
                                Console.Write("Please enter the file name: ");
                                string nameOfFile = Console.ReadLine();
                                while (string.IsNullOrEmpty(nameOfFile))
                                {
                                    Console.Write("Song Title cannot be empty. Please enter the title again: ");
                                    nameOfFile = Console.ReadLine();
                                }
                                Console.Write("Please Enter the file path: ");
                                string pathOfFile = Console.ReadLine();
                                while (string.IsNullOrEmpty(pathOfFile))
                                {
                                    Console.Write("Song Title cannot be empty. Please enter the title again: ");
                                    pathOfFile = Console.ReadLine();
                                }
                                userPlaylist.SaveToFile(nameOfFile, pathOfFile);                                
                            }
                        }
                        else
                        {
                            CenterText("Goodbye, Thank you for choosing MP3 Tracker,");
                            CenterText(name);
                            Environment.Exit(0);
                        }
                        break;
                }
            }
            while(true);
        }
        // Method to center text
        private static void CenterText(string text)
        {
            int screenWidth = Console.WindowWidth;
            int textWidth = text.Length;
            int space = (screenWidth - textWidth) / 2;
            Console.WriteLine("{0," + space + "}{1}", "", text);
        }
    }
}