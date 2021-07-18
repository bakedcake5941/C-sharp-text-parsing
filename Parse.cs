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
            List<Area> toReturn = new List<Area>();
            try
            {
                string path = System.IO.Path.Join(Directory.GetCurrentDirectory(), fileName);
                string text = System.IO.File.ReadAllText(path);
                List<string> block = new List<string>();

                string[] data = text.Split("\n");
                bool hunt = false;

                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].ToLower().Contains("start"))//This annotates the beginning of a new Area
                    {
                        hunt = true;
                    }

  

                    if (!data[i].ToLower().StartsWith("end") && hunt)
                    {
                        block.Add(data[i]);
                    }
                    else if (data[i].ToLower().StartsWith("end") && hunt)
                    {
                        hunt = false;

                        string[] array = block.ToArray();


                        Area toAdd = this.ParseArray(array);

                        block.Clear();
                        toReturn.Add(toAdd);

                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine("There was an issue parsing data: " + e.Message);
                Console.WriteLine(e.StackTrace);
                toReturn = new List<Area> { new Area("...") };
            } finally
            {
                Console.WriteLine("Finished parsing the data");
            }

            this.Verify(toReturn.ToArray());

            parseSettings();

            return toReturn.ToArray();
        }

        private void parseSettings()
        {
            string text = System.IO.File.ReadAllText(System.IO.Path.Join(Directory.GetCurrentDirectory(), "settings.txt"));

            string[] data = text.Split("\n");

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].ToLower().StartsWith("console:"))
                {
                    Console.Title = data[i].Replace("console:", "");
                }

                if (data[i].ToLower().StartsWith("intro:"))
                {
                    intro = data[i].Replace("intro:", "");
                    intro = intro.Replace("Intro:", "");
                    intro = intro.Replace("//", "\n");
                }

                if (data[i].ToLower().StartsWith("final:"))
                {
                    lastId = data[i].Replace("final:", "");
                }

                if (data[i].ToLower().StartsWith("finalcommand:"))
                {
                    lastCommand = data[i].Replace("finalCommand:", "");
                    lastCommand = lastCommand.Replace("finalcommand:", "");
                    lastCommand = lastCommand.Replace("FinalCommand:", "");
                    lastCommand = lastCommand.Replace("Finalcommand:", "");
                }

                if (data[i].ToLower().StartsWith("finalmessage:"))
                {
                    lastMessage = data[i].Replace("finalMessage:", "");
                    lastMessage = lastMessage.Replace("finalmessage:", "");
                    lastMessage = lastMessage.Replace("FinalMessage:", "");
                    lastMessage = lastMessage.Replace("Finalmessage:", "");
                }

            }
        }

        private Area ParseArray(string[] input)
        {
            Area toReturn = new Area("");

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].ToLower().Contains("name:"))
                {

                    toReturn.name = input[i].Replace("name:", "");

                } else if (input[i].ToLower().Contains("id:"))
                {

                    toReturn.identifier = input[i].Replace("id:", "");

                } else if (input[i].ToLower().Contains("desc:"))
                {
                    toReturn.description = input[i].Replace("desc:", "");

                } else if (input[i].ToLower().Contains("areas:"))
                {
                    toReturn.areasToGo = input[i].Replace("areas:", "").Split(",");
                }
            }

            toReturn.description = toReturn.description.Replace("//", "\n");


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

        private void Verify(Area[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i].identifier == arr[j].identifier && arr[i] != arr[j])
                    {
                        Console.Clear();
                        Console.WriteLine("You can't assign the same id to 2 areas");
                        while (true)
                            Console.ReadLine();
                    }
                }

                if (arr[i].identifier == null)
                {
                    Console.Clear();
                    Console.WriteLine("One of your areas doesn't have an ID!");
                    while (true)
                        Console.ReadLine();
                }

   //
            }
        }
    }
}
