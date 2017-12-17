using ConsoleMenu.Core.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenu.Core.Print
{
    public class MenuPrinter : IMenuPrinter
    {
        public int LeftOffset { get; private set; }

        public int TopOffset { get; private set; }

        public MenuPrinter(int leftOffset = 0, int topOffset = 0)
        {

        }


        public void PrintMenuItems(IReadOnlyList<MenuItem> menuItems, string header = null, string foolter = null)
        {
            Console.Clear();
            int extraLines = 0;           // if there are any extra lines because of the header that could interfere in the positioning

            if (header != null)
            {
                extraLines = 2;
                Console.SetCursorPosition(LeftOffset, TopOffset);         // print the menu on the user-defined position
                Console.WriteLine("{0}:", header);                                      // print header
                Console.WriteLine(new string('-', Console.WindowWidth));                // print a line of '-' chars
            }

            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.SetCursorPosition(LeftOffset, TopOffset + i + extraLines);      // print the menu on the user-defined position

                if (menuItems[i].IsSelected)                                            // the selected option is printed with inverted colors
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }

                Console.WriteLine(menuItems[i].Text);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
            }


        }
    }
}
