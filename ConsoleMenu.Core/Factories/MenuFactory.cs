using ConsoleMenu.Core.Items;
using ConsoleMenu.Core.Menus;
using ConsoleMenu.Core.Print;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenu.Core.Factories
{
    public static class MenuFactory
    {
        public static Menu CreateMenu(IReadOnlyList<MenuItem> items, string header = null, string footer = null, bool cycleSelection = false, int padding = 0)
        {
            var defaultInputManagerFactory = new InputManagerFactory(startIndex: 0, cycleSelection: true);
            var defaultPrinter = new MenuPrinter { Header = header, Footer = footer, Padding = padding };
            return new MenuTree(items, defaultPrinter, defaultInputManagerFactory);
        }

        public static ActionMenu CreateActionMenu(IReadOnlyList<MenuItem> items, string header = "", string footer = "", bool cycleSelection = false, int padding = 0)
        {
            var defaultInputManagerFactory = new InputManagerFactory(startIndex: 0, cycleSelection: true);
            var defaultPrinter = new MenuPrinter { Header = header, Footer = footer, Padding = padding };
            return new ActionTreeMenu(items, defaultPrinter, defaultInputManagerFactory);
        }
    }
}
