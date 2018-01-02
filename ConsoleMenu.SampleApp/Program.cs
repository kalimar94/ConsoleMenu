using ConsoleMenu.Core.Factories;
using ConsoleMenu.Core.Items;
using ConsoleMenu.Core.Menus;
using ConsoleMenu.Core.Print;
using System;

namespace ConsoleMenu.SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var subSubMenu = new[]
            {
                new MenuItem { Text = "Sub Submenu Item 1", HotKey = '1' },
                new MenuItem { Text = "Sub Submenu Item 2", HotKey = '2' },
                new MenuItem { Text = "Sub Submenu Item 3", HotKey = '3' },
            };

            var subMenu = new[]
            {
                new MenuItem { Text = "Submenu Item 1", HotKey = '1' },
                new MenuItem { Text = "Submenu Item 2", HotKey = '2' },
                new SubmenuItem { Text = "Sub sub menu", HotKey = 's', SubMenu = subSubMenu },
            };

            var menuItems = new[]
            {
                new MenuItem { Text = "Item 1", HotKey = '1' },
                new MenuItem { Text = "Item 2", HotKey = '2' },
                new MenuItem { Text = "Item 3", HotKey = '3' },
                new MenuItem { Text = "Item 4", HotKey = '4' },
                new SubmenuItem { Text = "SubMenu", HotKey = 's', SubMenu = subMenu }
            };


            var inputManagerFactory = new InputManagerFactory(startIndex: 0, cycleSelection: true);
            var printer = new MenuPrinter(padding: 20);

            var menu = new MenuTree(menuItems, printer, inputManagerFactory);

            var selectedItem = menu.RunToSelection();

            Console.WriteLine("Selected: " + selectedItem);
            Console.ReadLine();
        }
    }
}
