using ConsoleMenu.Core.Items;
using System.Collections.Generic;
using System;

namespace ConsoleMenu.Core.Input.Hotkeys
{
    public class HotkeyManager : IHotkeyManger
    {
        Dictionary<char, int> hotkeyIndexes;
        Dictionary<char, string> hotkeyIds;

        public ConsoleKey UpKey { get; set; } = ConsoleKey.UpArrow;

        public ConsoleKey DownKey { get; set; } = ConsoleKey.DownArrow;

        public ConsoleKey SelectKey { get; set; } = ConsoleKey.Enter;

        public IReadOnlyList<MenuItem> MenuItems { get; private set; }

        public HotkeyManager(IReadOnlyList<MenuItem> menuItems)
        {
            this.MenuItems = menuItems;
            hotkeyIndexes = new Dictionary<char, int>(menuItems.Count);
            hotkeyIds = new Dictionary<char, string>(menuItems.Count);

            for (int i = 0; i < menuItems.Count; i++)
            {
                if (menuItems[i].HotKey != default(char))
                {
                    hotkeyIndexes.Add(Char.ToLower(menuItems[i].HotKey), i);
                    hotkeyIds.Add(Char.ToLower(menuItems[i].HotKey), menuItems[i].Id);
                }
            }
        }

        public int? GetItemIndexForKey(char key)
        {
            return hotkeyIndexes.ContainsKey(Char.ToLower(key)) ? hotkeyIndexes[key] as int? : null;
        }

        public string GetItemIdForKey(char key)
        {
            return hotkeyIds.ContainsKey(Char.ToLower(key)) ? hotkeyIds[key] : null;
        }
    }
}
