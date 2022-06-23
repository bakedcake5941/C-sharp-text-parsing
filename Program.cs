using System;
using System.IO;
using System.Collections.Generic;

namespace C_sharp_text_parsing
{
    class Program
    {
        public static Parse parsingManager = new Parse();

        static Area currentArea;

        static void Main()
        {
            Console.Title = "Game";

            checkfiles();

            Area[] areas = parsingManager._Parse();

            //parsingManager.listAreas(areas);

            currentArea = areas[0];
            parsingManager.readIntro();
            while (true)
            {
                Console.Clear();
                Console.Write("You are currently in ");
                Console.WriteLine(currentArea);

                Console.WriteLine("\nWhat do you want to do?");
                Console.WriteLine("To look at commands type actions\n");

                string e = Console.ReadLine();

                switch (e.Split(" ")[0])
                {
                    case "actions":
                        if (currentArea.identifier == parsingManager.lastId)
                        {
                            Console.Clear();
                            Console.WriteLine("This is the only command:\n" + parsingManager.lastCommand);
                            Console.ReadLine();
                            break;
                        }
                        Console.Clear();
                        Console.WriteLine("These are the current commands:\ngoto [area name]: lets you go to the area\nlook around: see which areas you can go to\n");
                        Console.ReadLine();    
                        break;
                    case "goto":
                        if (currentArea.identifier == parsingManager.lastId) break;
                        ///Console.WriteLine(e + " -> " + e.Replace("goto ", ""));
                        ////Console.ReadKey();
                        ///Console.ReadKey();
                        currentArea = currentArea.findAreas(areas, e.Replace("goto ", ""));
                        break;

                    case "look":
                        if (currentArea.identifier == parsingManager.lastId) break;
                        Console.Clear();
                        Console.WriteLine("You can go to these areas:");
                        Console.WriteLine(currentArea.getAreas(areas));
                        Console.ReadLine();
                        break;
                }

                if (currentArea.identifier == parsingManager.lastId && e == parsingManager.lastCommand)
                {
                    Console.Clear();
                    Console.WriteLine(parsingManager.lastMessage);
                    Console.ReadKey();
                    Console.ReadKey();
                    return;
                }
            }
        }

        static bool checkfiles()
        {
            string pathA = System.IO.Path.Join(Directory.GetCurrentDirectory(), "instructions.txt");
            string pathB = System.IO.Path.Join(Directory.GetCurrentDirectory(), "data.txt");
            string pathC = System.IO.Path.Join(Directory.GetCurrentDirectory(), "settings.txt");
            
            if (!File.Exists(pathA))
            {
                using (StreamWriter m = File.CreateText(pathA))
                {
                    string instructionss = "This is a simple project I am making to test out some things with parsing as well as making console games, this has a simple coding language that you should be able to understand from data.txt";

                    m.Write(instructionss);
                }

                Console.WriteLine("Created instructions...");
            }

            if (!File.Exists(pathC))
            {
                using (StreamWriter m = File.CreateText(pathC))
                {


                    m.Write(new utilities().Join(constants.Settings, "\n"));
                    m.Close();
                }
            }

            if (!File.Exists(pathB))
            {
                using (StreamWriter m = File.CreateText(pathB))
                {
                    

                    m.Write(new utilities().Join(constants.ExampleCode, "\n"));
                }
                Console.WriteLine("Created data...");
                return false;
            }
            else
                return true;
        }

        
        void Initialize()
        {
            Console.Title = "Game creator";
        }
    }
}
