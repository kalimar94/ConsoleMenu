using ConsoleMenu.Core.Items;
using System.Collections.Generic;

namespace ConsoleMenu.Core.Print
{
    public interface IMenuPrinter
    {
        void PrintMenuItems(IReadOnlyList<MenuItem> menuItems, string header = null, string foolter = null);
    }
}