using System;
using System.Collections.Generic;
using System.Text;

namespace C_sharp_text_parsing
{
    class GameEnvironment
    {
        Area[] areas;
        int CurrentArea = 0;
        delegate void Action(string[] input);
        Dictionary<string, Action> actions;
        public GameEnvironment(Area[] areas)
        {
            actions = new Dictionary<string, Action>()
            {
                {"help", Help},
                {"look", LookAround },
                {"go", Go }
            };

            this.areas = areas;
        }


        ConsoleKey AwaitKeyPress()
        {
            return Console.ReadKey(true).Key;
        }

        public void Play()
        {

            Console.Clear();
            Console.WriteLine(constants.Settings.intro);
            Console.WriteLine("Press any key to continue");
            AwaitKeyPress();
     
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"You are currently in {areas[CurrentArea].name}{areas[CurrentArea].description}\nWhat do you want to do?\nUse the command help for help");
                string input = Console.ReadLine();
                string[] parameters;
                string command = utilities.Splice(input.Split(" "), out parameters).ToLower();
                string[] split = input.Split(" ");

                if (actions.TryGetValue(command, out Action action))
                {
                    action(parameters);
                } else
                {
                    Console.WriteLine("That command doesn't exist!");
                    Console.WriteLine("Press any key to continue");
                    AwaitKeyPress();
                }
            }
        }

        void Help(string[] input)
        {
            Console.Clear();
            Console.WriteLine("All commands:");
            foreach (KeyValuePair<string , Action> set in actions)
            {
                Console.WriteLine(set.Key);
            }

            KeyWait();
        }

        void LookAround(string[] input)
        {
            Console.Clear();
            Console.WriteLine(areas[CurrentArea].ListPaths());
            KeyWait();
        }

        void KeyWait()
        {
            Console.WriteLine("Press any key to continue");
            AwaitKeyPress();
        }

        void Finish(string[] _)
        {
            Console.Clear();
            int x = Console.WindowWidth / 2;
            int y = Console.WindowHeight / 2;
            x -= constants.Settings.lastMessage.Length / 2;
            Console.SetCursorPosition(x, y);
            Console.Write(constants.Settings.lastMessage);
            while (true)
            {

            }
        }

        void Go(string[] input)
        {
            string area = utilities.Join(input, " ");
            if (!CanGoTo(area))
            {
                Console.WriteLine("You can't seem to see that area anywhere");
                KeyWait();
                return;
            }

            for (int i = 0; i < areas.Length; i++)
            {
                if (areas[i].name == area)
                {
                    CurrentArea = i;
                    Console.WriteLine($"You walk to {areas[i].name}");
                    KeyWait();
            
                    if (areas[CurrentArea].name == constants.Settings.lastId)
                    {
                        actions.Clear();
                        actions.Add(constants.Settings.lastCommand, Finish);
                        actions.Add("help", Help);
                    }

                    return;
                }
            }
        }

        bool CanGoTo(string name)
        {
            Area area = areas[CurrentArea];
            foreach (string st in area.areasToGo)
            {
                if (name == st)
                    return true;
            }
            return false;
        }
    }
}
