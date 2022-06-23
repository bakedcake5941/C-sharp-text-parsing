using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace C_sharp_text_parsing
{
    class Parse //This class is entirely to organise the parsing systems.
    {
        private string intro;
        public string lastId;
        public string lastCommand;
        public string lastMessage;

        public Area[] _Parse(string fileName = "data.txt")
        {
            Console.WriteLine(Directory.GetCurrentDirectory().ToString());
            List<string[]> toParse = new List<string[]>(); //Debug
            try
            {
                string path = System.IO.Path.Join(Directory.GetCurrentDirectory(), fileName);
                string text = System.IO.File.ReadAllText(path);
                List<string> block = new List<string>();

                string[] data = text.Split("\n");
                bool searching = false;

                for (int i = 0; i < data.Length; i++)
                {
                    Console.WriteLine(data[i]);


                    if (data[i].ToLower().StartsWith("start"))//This annotates the beginning of a new Area
                    {
                        searching = true;
                    }
                    if (data[i].ToLower().StartsWith("end") && searching)
                    {
                        searching = false;
                        Console.WriteLine("\n\nAdding area\n\n");
                        toParse.Add(block.ToArray());
                        block.Clear();
                    }
                    else if (searching)
                    {
                        block.Add(data[i]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an issue parsing data: " + e.Message);
                Console.WriteLine(e.StackTrace);
                toParse = null;
            }
            Area[] bruh = new Area[toParse.Count];


            for (int i = 0; i < bruh.Length; i++)
            {
                bruh[i] = ParseArray(toParse[i]);
                Console.WriteLine($"Parsed area {i} ({bruh[i].name})");
            }

            Verify(bruh);

            parseSettings();

            return bruh;
        }

        private void parseSettings()
        {
            string text = File.ReadAllText(System.IO.Path.Join(Directory.GetCurrentDirectory(), "settings.txt"));

            string[] information = text.Split("\n");

            for (int i = 0; i < information.Length; i++)
            {
                if (information[i].Length <= 0)
                    continue;

                string[] input = information[i].Split(":");
                string command = input[0].ToLower();
                string data = input[1];
                switch (command)
                {
                    case "console":
                        Console.Title = data;
                        break;

                    case "intro":
                        intro = data;
                        break;

                    case "final command":
                        lastCommand = data;
                        break;

                    case "final message":
                        lastMessage = data;
                        break;

                    case "final area":
                        lastId = data;
                        break;
                }
            }
        }

        private Area ParseArray(string[] input)
        {
            Area toReturn = new Area("");

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(input[i]);
                string[] parameters = input[i].Split(":");
                if (parameters.Length < 2)
                    continue;
                string command, data;

                try
                {
                    command = parameters[0];
                    data = parameters[1];
                } catch
                {
                    Console.WriteLine("Bruh");
                    return null;
                }

                switch (command)
                {
                    case "name":
                        toReturn.name = data;
                        break;

                    case "id":
                        toReturn.identifier = data;
                        break;

                    case "description":
                        toReturn.description = data;
                        break;

                    case "areas":
                        toReturn.areasToGo = data.Split(",");
                        break;
                }
            }

            toReturn.description = toReturn.description.Replace("\\n", "\n");


            return toReturn;
        }

        public void listAreas(Area[] m)
        {
            Console.Clear();
            for (int i = 0; i < m.Length; i++)
            {
                Console.WriteLine("\n\n");

                Console.WriteLine(m[i].name);
                Console.WriteLine(m[i].description);
                Console.WriteLine(new utilities().Join(m[i].areasToGo, ", "));
            }
        }

        public void readIntro()
        {
            Console.Clear();
            Console.WriteLine(intro);
            Console.ReadKey();
        }

        void Verify(Area[] areas)
        {
            foreach (Area area in areas)
            {
                if (area == null)
                {
                    Console.WriteLine("An area is null... skipping");
                    continue;
                }

                if (area.identifier == null)
                {
                    throw new Exception($"The area {area.name} does not have an ID");
                }

                foreach (Area area2 in areas)
                {
                    if (area == area2)
                        continue;

                    if (area.identifier == area2.identifier)
                    {
                        Console.Clear();
                        throw new Exception("You can not assign the same id to two areas");
                    }
                }
            }
        }

    }
}
