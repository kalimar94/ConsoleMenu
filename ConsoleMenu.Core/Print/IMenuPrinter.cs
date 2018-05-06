using ConsoleMenu.Core.Items;
using System.Collections.Generic;

namespace ConsoleMenu.Core.Print
{
    public interface IMenuPrinter
    {
        string Header { get; set; }

        string Footer { get; set; }

        void PrintMenuItems(IReadOnlyList<MenuItem> menuItems);
    }
}