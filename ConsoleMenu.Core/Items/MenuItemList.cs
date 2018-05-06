using System;
using System.Collections.Generic;

namespace ConsoleMenu.Core.Items
{

    /// <summary> This wrapper class is merely used for initialization syntax sugar through collection initializers </summary> 
    public class MenuItemList : List<MenuItem>
    {
        // Regular menu item
        public void Add(string text)
        {
            this.Add(new MenuItem { Text = text });
        }

        public void Add(char hotkey, string text)
        {
            this.Add(new MenuItem { HotKey = hotkey, Text = text });
        }

        public void Add(string id, char hotkey, string text)
        {
            this.Add(new MenuItem { Id = id, HotKey = hotkey, Text = text });
        }


        // Sub Menu Item
        public void Add(string id, char hotkey, string text, IReadOnlyList<MenuItem> subMenu)
        {
            this.Add(new SubmenuItem { Id = id, HotKey = hotkey, Text = text, SubMenu = subMenu });
        }

        public void Add(string text, IReadOnlyList<MenuItem> subMenu)
        {
            this.Add(new SubmenuItem { Text = text, SubMenu = subMenu });
        }

        public void Add(char hotkey, string text, IReadOnlyList<MenuItem> subMenu)
        {
            this.Add(new SubmenuItem { HotKey = hotkey, Text = text, SubMenu = subMenu });
        }


        // Action Menu Item
        public void Add(string id, char hotkey, string text, Action action)
        {
            this.Add(new ActionMenuItem { Id = id, HotKey = hotkey, Text = text, Action = action });
        }

        public void Add(char hotkey, string text, Action action)
        {
            this.Add(new ActionMenuItem { HotKey = hotkey, Text = text, Action = action });
        }

        public void Add(string text, Action action)
        {
            this.Add(new ActionMenuItem { Text = text, Action = action });
        }
    }
}
