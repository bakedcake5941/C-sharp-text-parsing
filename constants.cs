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
"id:nnn",
"areas:nnn1,nnn",
"end",

"start",
"name:area2",
"description:the second area",
"id:nnn1",
"areas:nnn,nnn1,nnn3",
"end",

"start",
"name:invalid",
"description:the fourth secret area",
"id:nnn2",
"areas:nnn,nnn1,nnn2",
"end",

"start",
"name:area3",
"description:the third area",
"id:nnn3",
"areas:nnn3,nnn1,nnn,final",
"end",

"start",
"name:final area",
"description:the final area in the game",
"id:final",
"areas:final",
"end"
                    };

        public static readonly string[] Settings =
                    {
                        "title:Game",
                        "intro:You find yourself in an example for my game creator",
                        "final area:final",
                        "final Command:end",
                        "final Message:You win!"
                    };
    }
}
