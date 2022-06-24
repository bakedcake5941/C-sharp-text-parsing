using System;
using System.Collections.Generic;
using System.Text;

namespace C_sharp_text_parsing
{
    class constants
    {
        public static readonly string[] ExampleCode =
                    {
                        "console:Game",

"intro:You find yourself in an example for my game creator",
"final:final",
"finalCommand:end",
"finalMessage:You win!",

"start",
"name:area1",
"description:the first area",
"areas:area2",
"end",

"start",
"name:area2",
"description:the second area",
"areas:area1,area3",
"end",

"start",
"name:invalid",
"description:the fourth secret area",
"areas:nnn,nnn1,nnn2",
"end",

"start",
"name:area3",
"description:the third area",
"areas:area1,area2,final area",
"end",

"start",
"name:final area",
"description:the final area in the game",
"areas:final area",
"end"
                    };

        public static readonly string[] SettingsDefault =
                    {
                        "title:Game",
                        "intro:You find yourself in an example for my game creator",
                        "final area:final",
                        "final Command:end",
                        "final Message:You win!"
                    };

        public const string instructions = "Right now all you can do is look at data.txt as an example";
    
        public static class Settings
        {
            public static string intro;
            public static string lastId;
            public static string lastCommand;
            public static string lastMessage;
            public static string Title;

            public static string[] ToStrings()
            {
                return new string[]
                {
                    intro, lastId, lastCommand, lastMessage, Title
                };
            }

            public static void SetValues(string[] input)
            {
                if (input.Length != 5)
                    return;

                intro = input[0];
                lastId = input[1];
                lastCommand = input[2];
                lastMessage = input[3];
                Title = input[4];
            }
        }
    }
}
