using ConsoleMenu.Core.Items;
using System;
using System.Collections.Generic;

namespace ConsoleMenu.Core.Print
{
    public class MenuPrinter : IMenuPrinter
    {
        private ConsoleColor backgroundColor;

        private ConsoleColor foregroundColor;

        public int LeftOffset { get; set; }

        public int TopOffset { get; set; }
 
        public int Padding { get; set; }

        public string Header { get; set; }

        public string Footer { get; set; }

        public MenuPrinter()
        {
            this.backgroundColor = Console.BackgroundColor;
            this.foregroundColor = Console.ForegroundColor;
        }

        public void PrintMenuItems(IReadOnlyList<MenuItem> menuItems)
        {
            Console.Clear();

            PrintHeader();

            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.SetCursorPosition(LeftOffset, Console.CursorTop);      // print the menu on the user-defined position

                PrintItemText(menuItems[i]);
                this.ResetColor();
            }

              PrintFooter();
        }


        /// <summary>  Prints the header and returns the number of lines occupied by the header </summary>
        protected virtual void PrintHeader()
        {
            if (!string.IsNullOrWhiteSpace(Header))
            {
                Console.SetCursorPosition(LeftOffset, TopOffset);         // print the menu on the user-defined position
                Console.WriteLine(Header);                                // print header
                Console.WriteLine();
            }
        }

        protected virtual void PrintFooter()
        {
            if (!string.IsNullOrWhiteSpace(Footer))
            {
                Console.WriteLine();
                Console.SetCursorPosition(LeftOffset, Console.CursorTop); 
                Console.WriteLine(Footer);
            }
        }

        protected virtual void PrintItemText(MenuItem item)
        {
            if (item.IsSelected)
                this.InverseColor();

            var padText = new string(' ', this.Padding);
            var hotKey = item.HotKey.ToString();

            var printText = item.Text;

            // If the hotkey characted is found in the text it will be surrounded in brackets
            if (item.HotKey != default(char))
            {
                printText = item.Text.Contains(hotKey) ?
                       item.Text.Replace(hotKey, $"[{item.HotKey}]")
                     : item.Text + $"  ({item.HotKey})";
            }

            Console.WriteLine($"{padText}{printText}{padText}");
        }

        protected virtual void InverseColor()
        {
            Console.ForegroundColor = backgroundColor;
            Console.BackgroundColor = foregroundColor;
        }

        protected virtual void ResetColor()
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
        }
    }
}
