using System;
using System.Collections.Generic;
using ConsoleMenu.Core.Items;

namespace ConsoleMenu.Core
{
    public interface IHotkeyManger
    {
        /// <summary> The key used for movin the selection up in the menu  </summary>
        ConsoleKey UpKey { get; set; }

        /// <summary> The key used for moving the selection down in the menu  </summary>
        ConsoleKey DownKey { get; set; }

        /// <summary> The key used for confirming selection </summary>
        ConsoleKey SelectKey { get; set; }

        /// <summary> A reference to the original menu items selection  </summary>
        IReadOnlyList<MenuItem> MenuItems { get; }

        /// <summary> Searches if any item matches the given hotkey and returns it's index </summary> 
        int? GetItemIndexForKey(char key);

        /// <summary> Searches if any item matches the given hotkey and returns it's Id  </summary> 
        string GetItemIdForKey(char key);

    }
}