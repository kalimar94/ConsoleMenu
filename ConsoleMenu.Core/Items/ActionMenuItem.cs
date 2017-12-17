using System;

namespace ConsoleMenu.Core.Items
{
    /// <summary>
    /// A menu item whoose action should be invoked when selected
    /// </summary>
    public class ActionMenuItem : MenuItem
    {
        public Action Action { get; set; }
    }
}
