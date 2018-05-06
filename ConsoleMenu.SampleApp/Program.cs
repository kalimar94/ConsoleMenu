using ConsoleMenu.Core.Factories;
using ConsoleMenu.Core.Items;
using ConsoleMenu.Core.Menus;
using ConsoleMenu.Core.Print;
using System;

namespace ConsoleMenu.SampleApp
{
    class Program
    {

        static void Main()
        {
            MenuDemo();
            Console.ReadLine();
            
            ActionMenuDemo();
            Console.ReadLine();
        }

        static void MenuDemo()
        {
            var subSubMenu = new[]
            {
                new MenuItem { Text = "Sub Submenu Item 1", HotKey = '1' },
                new MenuItem { Text = "Sub Submenu Item 2", HotKey = '2' },
                new MenuItem { Text = "Sub Submenu Item 3", HotKey = '3' },
            };

            // shorthand initialization:
            var subMenu = new MenuItemList
            {
               { '1',  "Submenu Item 1" },
               { '2', "Submenu Item 2" },
               { 's', "Sub sub menu",subSubMenu },
            };

            var menuItems = new MenuItemList
            {
                { '1', "Item 1" },
                { '2', "Item 2" },
                { '3', "Item 3" },
                { 'T', "Test" },
                { 's', "SubMenu", subMenu }
            };

            var menu = MenuFactory.CreateMenu(menuItems);
            var selectedItem = menu.RunToSelection();

            Console.WriteLine("Selected: " + selectedItem);
        }

        static void ActionMenuDemo()
        {
            var subMenu = new MenuItemList
            {
                { "SubItem1", () => Console.WriteLine("Invoked action of SubItem1") },
                { "SubItem2", () => Console.WriteLine("Invoked action of SubItem2") },
                { "SubItem3", () => Console.WriteLine("Invoked action of SubItem3") },
                { "SubItem4", () => Console.WriteLine("Invoked action of SubItem4") }
            };

            var mainMenu = new MenuItemList
            {
                { "Item1", () => Console.WriteLine("Invoked action of Item1") },
                { "Item2", () => Console.WriteLine("Invoked action of Item2") },
                { "Item3", () => Console.WriteLine("Invoked action of Item3") },
                { "Item4", () => Console.WriteLine("Invoked action of Item4") },
                { "Submenu", subMenu },
            };

            MenuFactory.CreateActionMenu(mainMenu).RunActionMenu();
        }
    }
}
