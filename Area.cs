using System;
using System.Collections.Generic;
using System.Text;

namespace C_sharp_text_parsing
{
    public class Area
    {
        public string name;
        public string description = null;
        public string[] areasToGo = null;

        public Area(string _name)
        {
            name = _name;
        }

        public string ListPaths()
        {
            string toReturn = "";

            foreach (string st in areasToGo)
            {
                toReturn += st + "\n";
            }

            return toReturn;
        }

        /*public Area findAreas(Area[] areas, string idToFind)
        { 
            for (int i = 0; i < areas.Length; i++)
            {
                if (areas[i].name == idToFind)
                {
                    if (areasToGo == null)
                    {
                        Area broken = new Area("Error");
                        broken.description = "There appears to have been a fatal error!";
                        broken.areasToGo = new string[]
                        {
                            "Nowhere!"
                        };
                        broken.areasToGoNames = new string[] { "Nowhere!" };
                        broken.identifier = null;
                        return broken;
                    }

                    for (int j = 0; j < areasToGo.Length; j++)
                    {
                        try
                        {
                            if (areas[i].identifier == areasToGo[j])
                            {
                                return areas[i];
                            }

                        } catch
                        {
                            Console.WriteLine("You know that location exists but can't find it anywhere!");
                            Console.ReadLine();
                            return this;
                        }
                    }

                }
            }

            Console.WriteLine("You can't see that area anywhere");
            Console.ReadKey();

            return this;
        }



        public string getAreas(Area[] areas)
        {
            List<string> names = new List<string>();

            if (!namesDefined)
            {
                if (areasToGo == null)
                    return "Sorry! There has been an error!";

                    for (int i = 0; i < areas.Length; i++)
                    {
                        for (int k = 0; k < areasToGo.Length; k++)
                        {
                            if (areas[i].identifier == areasToGo[k])
                            {
                                names.Add(areas[i].name);
                            }
                        }
                    }
                areasToGoNames = names.ToArray();
                namesDefined = true;

            } 


            return utilities.Join(areasToGoNames, "\n");
        }*/

        public override string ToString()
        {
            return (name + ",\n" + description + "\n");
        }
    }
}
