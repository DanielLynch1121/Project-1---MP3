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
namespace Project_1___MP3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // variables for MP3 object
            string songTitle;
            string artist;
            string songReleaseDate;
            double playbackTimeInMinutes;
            string genre;
            Genre getParse;
            decimal downloadCost;
            double fileSizeInMBs;
            string albumCoverPhoto;
            // variables for Playlist object
            string playlistName;
            string creatorName;
            string creationDate;
            
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
                        Console.Write("2. Please Enter the Creators Name: ");
                        creatorName = Console.ReadLine();
                        Console.Write("3. Please enter the Creation Date MM/DD/YYYY: ");
                        creationDate = Console.ReadLine();
                        
                        userPlaylist = new Playlist(playlistName, creatorName, creationDate);
                        break;
                    
                    // Case 2 Creates a new MP3 Object and Stores it in the playlist
                    case 2:
                        Console.Clear();

                        if (userPlaylist != null)
                        {
                            try
                            {
                                CenterText("Create an MP3");
                                CenterText("-----------------------------");
                                Console.Write(" 1. Please Enter The Songs Title:");
                                songTitle = Console.ReadLine();
                                Console.Write(" 2. Please Enter The Artit's Name:");
                                artist = Console.ReadLine();
                                Console.Write(" 3. Please Enter The Release Date (MM/DD/YYYY): ");
                                songReleaseDate = Console.ReadLine();
                                Console.Write(" 4. Please Enter The Playback Time (Minutes): ");
                                playbackTimeInMinutes = Convert.ToDouble(Console.ReadLine());
                                Console.Write(" 5. Please Enter The Song's Genre (Rock, Pop, Jazz, Country, Classical, Lofi, Funk, Rap, Other): ");
                                genre = Console.ReadLine();
                                Enum.TryParse(genre, out getParse);
                                Console.Write(" 6. Please Enter The Download Cost: $");
                                downloadCost = Convert.ToDecimal(Console.ReadLine());
                                Console.Write(" 7. Please Enter The File Size (MB): ");
                                fileSizeInMBs = Convert.ToDouble(Console.ReadLine());
                                Console.Write(" 8. Please Enter the Path Of The Album Cover Photo: ");
                                albumCoverPhoto = Console.ReadLine();

                                userMP3 = new MP3(songTitle, artist, songReleaseDate, playbackTimeInMinutes, getParse, downloadCost, fileSizeInMBs, albumCoverPhoto);

                                userPlaylist.AddMP3(userMP3);
                            }
                            catch
                            {
                                CenterText("please be sure to enter correct data... MB(100), $(2.00), Minutes(1)");
                            }
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
                                int mp3Attribute = int.Parse(Console.ReadLine());

                                userPlaylist.EditMP3(searchTitle, mp3Attribute);
                                istrue = true;
                            }
                            catch
                            {
                                Console.WriteLine("Please enter the title and a number 1-3.");
                            }
                               CenterText("Press <Enter> to continue");
                                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        }
                        
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Enter the title of the song you would like to remove: ");
                        string titleToRemove = Console.ReadLine();
                        userPlaylist.DeleteMP3ByTitle(titleToRemove);
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
                                string titleEdit = Console.ReadLine();
                                List<MP3> results = userPlaylist.SearchByTitle(titleEdit);
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
                            try
                            {
                                Console.WriteLine("Enter the genre of the songs you would like to search for: ");
                                Genre searchGenre = (Genre)Enum.Parse(typeof(Genre), Console.ReadLine(), true);
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
                            catch
                            {
                                Console.WriteLine("Invalid genre entered.");
                                CenterText("Press <Enter> to continue");
                                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                            }
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
                        Console.Write("Enter the file path of the MP3s you would like to import:");
                        string filePath = Console.ReadLine();
                        Playlist.FillFromFile(filePath);
                        break; 
                    case 12:
                        break;
                    case 13:
                        Console.Clear();
                        CenterText("Goodbye, Thank you for choosing MP3 Tracker,");
                        CenterText(name);
                        Environment.Exit(0);
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