using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class MainMenu
    {
        public void OpenMainMenu()
        {
            ConsoleKeyInfo key;

            int selection = 0;
            List<string> list = new List<string>() 
            {
                "<<Start>>",
                "<<Exit>>"
            };
            while (true)
            {
                Console.Clear();
                DrawLogo();
                for (int i = 0; i < list.Count; i++)
                {
                    if(i == selection)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(list[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                key = Console.ReadKey();

                if(key.Key == ConsoleKey.W ||  key.Key == ConsoleKey.UpArrow) 
                {
                    selection--;
                    if(selection < 0) selection = list.Count - 1;
                }
                if (key.Key == ConsoleKey.S || key.Key == ConsoleKey.DownArrow)
                {
                    selection++;
                    if (selection >= list.Count) selection = 0;
                }
                if(key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar)
                {
                    if(selection == 0)
                    {
                        break;
                    }
                    if (selection == 1)
                    {
                        Environment.Exit(0);
                    }
                }
                
            }
            
        }
        public void DrawGameOver(int score)
        {
            Console.WriteLine($@"
===========================================================================
 ██████╗  █████╗ ███╗   ███╗███████╗     ██████╗ ██╗   ██╗███████╗██████╗ 
██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██╔═══██╗██║   ██║██╔════╝██╔══██╗
██║  ███╗███████║██╔████╔██║█████╗      ██║   ██║██║   ██║█████╗  ██████╔╝
██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗
╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ╚██████╔╝ ╚████╔╝ ███████╗██║  ██║
 ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝     ╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═╝
===========================================================================
                           YOUR SCORE: {score}
                       DO YOU WANT TO TRY AGAIN?
");
        }

        public void DrawLogo()
        {
            Console.WriteLine(@"
================================================================================================
███████╗██╗      ██████╗ ██████╗ ██████╗ ██╗   ██╗    ██████╗ ██╗     ██╗   ██╗██████╗ ██████╗ 
██╔════╝██║     ██╔═══██╗██╔══██╗██╔══██╗╚██╗ ██╔╝    ██╔══██╗██║     ██║   ██║██╔══██╗██╔══██╗
█████╗  ██║     ██║   ██║██████╔╝██████╔╝ ╚████╔╝     ██████╔╝██║     ██║   ██║██████╔╝██║  ██║
██╔══╝  ██║     ██║   ██║██╔══██╗██╔═══╝   ╚██╔╝      ██╔══██╗██║     ██║   ██║██╔══██╗██║  ██║
██║     ███████╗╚██████╔╝██║  ██║██║        ██║       ██████╔╝███████╗╚██████╔╝██║  ██║██████╔╝
╚═╝     ╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝        ╚═╝       ╚═════╝ ╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═════╝ 
================================================================================================
");
        }
        public void GameOver(int score)
        {
            ConsoleKeyInfo key;

            int selection = 0;
            List<string> list = new List<string>()
            {
                "<<YES>>",
                "<<NO>>"
            };
            while (true)
            {
                Console.Clear();
                DrawGameOver(score);
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == selection)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(list[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                key = Console.ReadKey();

                if (key.Key == ConsoleKey.W || key.Key == ConsoleKey.UpArrow)
                {
                    selection--;
                    if (selection < 0) selection = list.Count - 1;
                }
                if (key.Key == ConsoleKey.S || key.Key == ConsoleKey.DownArrow)
                {
                    selection++;
                    if (selection >= list.Count) selection = 0;
                }
                if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar)
                {
                    if (selection == 0)
                    {
                        Process.Start("Random.exe");
                        Environment.Exit(0);
                    }
                    if (selection == 1)
                    {
                        Environment.Exit(0);
                    }
                }

            }
            
        }
    }
    
}
