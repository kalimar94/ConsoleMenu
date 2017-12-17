using System.Collections.Generic;

namespace ConsoleMenu.Core.Items
{
    /// <summary>
    /// A menu item that is holds a reference to a sub-menu
    /// </summary>
    public class SubmenuItem : MenuItem
    {
        public IReadOnlyList<MenuItem> SubMenu { get; set; }
    }
}
