namespace Project_1___MP3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CenterText("--------------------------------------");
            CenterText("Project: MP3 Tracker");
            CenterText("Project 1");
            CenterText("------");
            CenterText("Created By: Daniel Lynch");
            CenterText("--------------------------------------");

            string name;
            CenterText("Please Enter Your Name:");
            name = Console.ReadLine();
            CenterText("--------------------------------------");

            do
            {
                int userInput;
                CenterText("Menu");
                CenterText("--------------------------------------");
                CenterText("1. Create a New MP3 File");
                CenterText("2. Display an MP3 File");
                CenterText("3. Exit");
                Console.Write("Type The Number Of Your Choice:");
                userInput = int.Parse(Console.ReadLine());

                if(userInput == 1)
                {
                    CenterText("Create an MP3");
                }
                else if(userInput == 2)
                {

                }
                else if(userInput == 3)
                {
                    CenterText("Goodbye, Thank you for choosing MP3 Tracker,");
                    CenterText(name);
                    Environment.Exit(0);
                }
                else if(userInput < 1 || userInput > 3)
                {
                    Console.WriteLine("Please Try Agian");
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