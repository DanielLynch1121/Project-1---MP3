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
            CenterText("Project: MP3 Tracker");
            CenterText("Demonstrates the functionality of the MP3 class.");
            CenterText("-------------------");
            CenterText("Created By: Daniel Lynch");
            CenterText("---------------------------");

            string name;
            Console.Write("     Please Enter Your Name:");
            name = Console.ReadLine();
            CenterText("Press <Enter> to continue");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            Console.Clear();
            
            MP3 userMP3 = null;

            do
            {
                Console.Clear() ;
                int userInput;
                CenterText("Menu");
                CenterText("--------------------------------");
                CenterText("1. Create a New MP3 File");
                CenterText("2. Display an MP3 File");
                CenterText("3. Exit");
                Console.Write("Type The Number Of Your Choice:");
                userInput = int.Parse(Console.ReadLine());

                string songTitle;
                string artist;
                string songReleaseDate;
                double playbackTimeInMinutes;
                string genre;
                Genre getParse;
                decimal downloadCost;
                double fileSizeInMBs;
                string albumCoverPhoto;

                switch(userInput)
                {
                    case 1:
                    
                        Console.Clear();
                        Console.WriteLine("       Create an MP3");
                        Console.WriteLine("-----------------------------");
                        Console.Write("1. Please Enter The Songs Title:");
                        songTitle = Console.ReadLine();
                        Console.Write("2. Please Enter The Artit's Name:");
                        artist = Console.ReadLine();
                        Console.Write("3. Please Enter The Release Date (MM/DD/YYYY): ");
                        songReleaseDate = Console.ReadLine();
                        Console.Write("4. Please Enter The Playback Time (Minutes):");
                        playbackTimeInMinutes = Convert.ToDouble(Console.ReadLine());
                        Console.Write("5. Please Enter The Song's Genre (Rock, Pop, Jazz, Country, Classical, Lofi, Funk, Rap, Other):");
                        genre = Console.ReadLine();
                        Enum.TryParse(genre, out getParse);
                        Console.Write("6. Please Enter The Download Cost:");
                        downloadCost = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("7. Please Enter The File Size (MB):");
                        fileSizeInMBs = Convert.ToDouble(Console.ReadLine());
                        Console.Write("8. Please Enter the Path Of The Album Cover Photo:");
                        albumCoverPhoto = Console.ReadLine();

                        userMP3 = new MP3(songTitle, artist, songReleaseDate, playbackTimeInMinutes, getParse, downloadCost, fileSizeInMBs, albumCoverPhoto);
                        break;
                    case 2:
                
                        Console.Clear();
                        if (userMP3 != null)
                        {
                            Console.WriteLine(userMP3.ToString());
                            CenterText("Press <Enter> to continue");
                            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        }
                        else
                        {
                            CenterText("No MP3 object exists. Please create one first.");
                            CenterText("Press <Enter> to continue");
                            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        }
                        break;

                    case 3:
                        Console.Clear();
                        CenterText("Goodbye, Thank you for choosing MP3 Tracker,");
                        CenterText(name);
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Please Enter a Number 1-3");
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