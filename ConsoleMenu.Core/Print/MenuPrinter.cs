using ConsoleMenu.Core.Items;
using System;
using System.Collections.Generic;

namespace ConsoleMenu.Core.Print
{
    public class MenuPrinter : IMenuPrinter
    {
        private ConsoleColor backgroundColor;

        private ConsoleColor foregroundColor;

        public int LeftOffset { get; private set; }

        public int TopOffset { get; private set; }

        public int Padding { get; private set; }

        public MenuPrinter(int leftOffset = 0, int topOffset = 0, int padding = 0)
        {
            this.backgroundColor = ConsoleColor.Black;
            this.foregroundColor = ConsoleColor.White;

            this.LeftOffset = leftOffset;
            this.TopOffset = topOffset;
            this.Padding = padding;
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

                PrintItemText(menuItems[i]);
                this.ResetColor();
            }
        }


        protected void PrintItemText(MenuItem item)
        {
            if (item.IsSelected)
                this.InverseColor();

            var padText = new string(' ', this.Padding);
            var hotKey = item.HotKey.ToString();

            var printText = item.Text;

            if (item.HotKey != default(char))
            {
                printText = item.Text.Contains(hotKey) ?
                       item.Text.Replace(hotKey, $"[{item.HotKey}]")
                     : item.Text + $"  ({item.HotKey})";
            }

            Console.WriteLine($"{padText}{printText}{padText}");
        }

        protected void InverseColor()
        {
            Console.ForegroundColor = backgroundColor;
            Console.BackgroundColor = foregroundColor;
        }

        protected void ResetColor()
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
        }
    }
}
