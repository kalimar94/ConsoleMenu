using System;
using System.Collections.Generic;


namespace ClassyConsoleMenu
{

    public class ConsoleMenu
    {
        public string[] options;
        public string header;
        private int selectedOption;
        public string backKeyword = "\nBack";   // The keyword that indicates that when this option is pressed - return to the previous menu
        public Dictionary<int, ConsoleMenu> subMenus = new Dictionary<int, ConsoleMenu>();    //storing the submenus
        public int positionLeft = 0;            // Position from left Edge where the menu will be printed
        public int positionTop = 0;             // Position from top Edge where the menu will be printed
      


        // Constructors for defining a new Menu:

        /// <summary>
        /// Defines a Console Menu
        /// </summary>
        /// <param name="options">All available options to the user</param>
        /// <param name="MenuHeader">The text above the Menu</param>
        /// <param name="backKeyword">The word that wii be used to indicate return to the previous menu</param>
        /// <param name="positionLeft">The position of the Menu from the left edge</param>
        /// <param name="positionTop">The position of the Menu from the top line</param>
        public ConsoleMenu(string[] options, string MenuHeader = null, string backKeyword = "\nBack", int positionLeft = 0, int positionTop = 0)    // parameters that are set to a value are optional and their default value is set
        {
            this.options = options;
            this.header = MenuHeader;
            this.backKeyword = backKeyword;
            this.positionLeft = positionLeft;
            this.positionTop = positionTop;
        }

        public ConsoleMenu(params string[] options)
        {
            this.options = options;
        }

        private void PrintMenu()
        {
            Console.Clear();
            int extraLines = 0;           // if there are any extra lines because of the header that could interfere in the positioning
            if (this.header != null)
            {
                extraLines = 2;
                Console.SetCursorPosition(this.positionLeft, this.positionTop);         // print the menu on the user-defined position
                Console.WriteLine("{0}:", header);                                      // print header
                Console.WriteLine(new string('-', Console.WindowWidth));                // print a line of '-' chars
            }

            for (int i = 0; i < this.options.Length; i++)
            {
                Console.SetCursorPosition(this.positionLeft, this.positionTop + i + extraLines);      // print the menu on the user-defined position
                if (i == selectedOption)                                                              // the selected option is printed with inverted colors
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine(options[i]);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        /// <summary>
        /// Shows the Menu to the user (all SubMenus will be automaticly called if needed)
        /// </summary>
        public string StartMenu()
        {  
            this.PrintMenu();
                while (true)
                {
                    if (Console.KeyAvailable)           // if a key is pressed -> check for up and down arrows and enter
                    {
                        var key = Console.ReadKey();
                        if (key.Key == ConsoleKey.UpArrow && this.selectedOption > 0)
                        {
                            this.selectedOption--;
                        }
                        else if (key.Key == ConsoleKey.DownArrow && this.selectedOption < options.Length - 1)
                        {
                            this.selectedOption++;
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            if (this.subMenus.ContainsKey(selectedOption))  // if there's a subMenu defined on the selected Option, open it
                            {
                                string subResult = subMenus[selectedOption].StartMenu();
                                if (subResult == backKeyword)       // if the result from the subMenu is back
                                {
                                    return this.StartMenu();   
                                }
                                else
                                {
                                    return subResult;               // otherwise return the result of the subMenu
                                }
                            }
                            return options[this.selectedOption];   // if no subMenu defined return the option
                        }
                        this.PrintMenu();
                    }
                }
            
        }

    }
}
