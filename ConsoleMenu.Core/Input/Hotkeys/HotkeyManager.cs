using ConsoleMenu.Core.Items;
using System.Collections.Generic;

namespace ConsoleMenu.Core.Input.Hotkeys
{
    public class HotkeyManager : IHotkeyManger
    {
        Dictionary<char, int> hotkeyIndexes;

        public HotkeyManager(IReadOnlyList<MenuItem> menuItems)
        {
            ReInitialize(menuItems);
        }

        public int? GetItemIndexForKey(char key)
        {
            return hotkeyIndexes.ContainsKey(key) ? hotkeyIndexes[key] as int? : null;
        }

        public void ReInitialize(IReadOnlyList<MenuItem> menuItems)
        {
            hotkeyIndexes = new Dictionary<char, int>(menuItems.Count);

            for (int i = 0; i < menuItems.Count; i++)
            {
                hotkeyIndexes.Add(menuItems[i].HotKey, i);
            }
        }
    }
}
