using System;
using System.IO;
using System.Collections.Generic;

namespace C_sharp_text_parsing
{
    class Program
    {
        public static Parse parsingManager = new Parse();

        static Area currentArea;

        static string GetFilePath(string name)
        {
            return Path.Join(Directory.GetCurrentDirectory(), name);
        }

        static void Main()
        {
            Console.Title = "Game";
            bool Recompile = false;

            bool f = File.Exists(GetFilePath("compiled.dat"));

            if (f)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Compile?\nyes or no");
                    string a = Console.ReadLine().ToLower();

                    if (a == "yes")
                    {
                        Recompile = true;
                        break;
                    }
                    else if (a == "no")
                        break;
                }
            }

            if (!Recompile && f)
            {
                using (FileStream stream = File.OpenRead(GetFilePath("compiled.dat")))
                {
                    byte[] bruh = new byte[stream.Length];

                    stream.Read(bruh, 0, (int)stream.Length);
                    stream.Close();
                    foreach (byte b in bruh)
                    {
                        Console.Write($"{(char)b} ");
                    }
                    Compiler compiler = new Compiler();
                    compiler.SetData(bruh);
                    new GameEnvironment(compiler.Decompile()).Play();
                }
                return;
            }

            checkfiles();



            Area[] areas = parsingManager._Parse();

            parsingManager.listAreas(areas);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i} {constants.Settings.ToStrings()[i]}");
            }

            new Compiler().Compile(areas);

            Console.WriteLine("\n\n\nGame compiled");
        }

        static bool checkfiles()
        {
            string pathA = Path.Join(Directory.GetCurrentDirectory(), "instructions.txt");
            string pathB = Path.Join(Directory.GetCurrentDirectory(), "data.txt");
            string pathC = Path.Join(Directory.GetCurrentDirectory(), "settings.txt");
            
            if (!File.Exists(pathA))
            {
                using (StreamWriter m = File.CreateText(pathA))
                {

                    m.Write(constants.instructions);
                }

                Console.WriteLine("Created instructions...");
            }

            if (!File.Exists(pathC))
            {
                using (StreamWriter m = File.CreateText(pathC))
                {


                    m.Write(utilities.Join(constants.SettingsDefault, "\n"));
                    m.Close();
                }
            }

            if (!File.Exists(pathB))
            {
                using (StreamWriter m = File.CreateText(pathB))
                {
                    

                    m.Write(utilities.Join(constants.ExampleCode, "\n"));
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
