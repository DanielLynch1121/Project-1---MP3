/**
*--------------------------------------------------------------------
* File name: {Program.cs}
* Project name: {Project 1 - MP3}
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
            bool playlistCreated = false;
            
            MP3 userMP3 = null;
            Playlist userPlaylist = null;

            // Welcome Page with my center text Method
            CenterText("Project: MP3 Tracker");
            CenterText("-----------------");
            CenterText("Demonstrates the functionality of the MP3 class.");
            CenterText("-------------------");
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
                Console.WriteLine("11. Exit");
                Console.Write("Type The Number Of Your Choice: ");
                
                // Validation for the number typed into the Main Menu
                if (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 1 || userInput > 11)
                {
                    CenterText("Invalid choice. Please enter a number from 1 to 11.");
                }

                switch (userInput)
                {
                    // Case 1 Creates A New Playlist object
                    case 1:
                        Console.Clear();
                        Console.WriteLine("1. Please Enter the Playlist Name: ");
                        playlistName = Console.ReadLine();
                        Console.WriteLine("2. Please Enter the Creators Name: ");
                        creatorName = Console.ReadLine();
                        Console.WriteLine("3. Please enter the Creation Date MM/DD/YYYY: ");
                        creationDate = Console.ReadLine();
                        
                        userPlaylist = new Playlist(playlistName, creatorName, creationDate);
                        playlistCreated = true;
                        break;
                    
                    // Case 2 Creates a new MP3 Object and Stores it in the playlist
                    case 2:
                        Console.Clear();

                        if (playlistCreated = true)
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
                                Console.Write(" 4. Please Enter The Playback Time (Minutes):");
                                playbackTimeInMinutes = Convert.ToDouble(Console.ReadLine());
                                Console.Write(" 5. Please Enter The Song's Genre (Rock, Pop, Jazz, Country, Classical, Lofi, Funk, Rap, Other):");
                                genre = Console.ReadLine();
                                Enum.TryParse(genre, out getParse);
                                Console.Write(" 6. Please Enter The Download Cost: $");
                                downloadCost = Convert.ToDecimal(Console.ReadLine());
                                Console.Write(" 7. Please Enter The File Size (MB):");
                                fileSizeInMBs = Convert.ToDouble(Console.ReadLine());
                                Console.Write(" 8. Please Enter the Path Of The Album Cover Photo:");
                                albumCoverPhoto = Console.ReadLine();

                                userMP3 = new MP3(songTitle, artist, songReleaseDate, playbackTimeInMinutes, getParse, downloadCost, fileSizeInMBs, albumCoverPhoto);

                                userPlaylist.AddMP3(userMP3);
                            }
                            catch
                            {
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            CenterText("Please Create a Playlist Before adding MP3s to it.");
                            CenterText("Press <Enter> to continue");
                            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        }
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
                            finally
                            {
                                CenterText("Press <Enter> to continue");
                                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                            }
                        
                        }
                        
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Enter the title of the song you would like to remove: ");
                        string titleToRemove = Console.ReadLine();
                        userPlaylist.DeleteMP3ByTitle(titleToRemove);
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
                        if(userPlaylist != null && userMP3 != null)
                        {
                            try
                            {
                                Console.WriteLine("Enter the title of the song you would like to search for: ");
                                string titleEdit = Console.ReadLine();
                                userPlaylist.SearchByTitle(titleEdit);
                                CenterText("Press <Enter> to continue");
                                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                            }
                            catch
                            {
                                Console.WriteLine("The song you are looking for hasent been created yet.");
                                CenterText("Press <Enter> to continue");
                                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                            }
                        }
                        break;
                    case 7:
                        Console.Clear();
                        userPlaylist.DisplayAllMP3s();
                        Console.WriteLine("Press <Enter> to continue");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        break;
                    case 8: 
                        Console.Clear();
                        Console.Write("What is the name of the artist you want to search for? ");
                        string artistSearch = Console.ReadLine();
                        userPlaylist.SearchByArtist(artistSearch);
                        break;
                    case 9:
                        Console.Clear();
                        Console.Write("What is the title of the song you want to search for? ");
                        string titleSearch = Console.ReadLine();
                        userPlaylist.SearchByTitle(titleSearch);
                        Console.WriteLine("Press <Enter> to continue");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        break;
                    case 10:
                        Console.Clear();
                        userPlaylist.SortByDate();
                        Console.WriteLine("Press <Enter> to continue");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        break;
                    case 11:
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