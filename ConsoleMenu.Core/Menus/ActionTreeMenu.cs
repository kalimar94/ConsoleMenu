using ConsoleMenu.Core.Input;
using ConsoleMenu.Core.Items;
using ConsoleMenu.Core.Print;
using System;
using System.Collections.Generic;

namespace ConsoleMenu.Core.Menus
{
    public class ActionTreeMenu : Menu
    {
        public ActionTreeMenu(IReadOnlyList<MenuItem> menuItems, IMenuPrinter printer, IMenuInputManager input)
            : base(menuItems, printer, input)
        {
        }

        public void RunActionMenu()
        {
            var selection = base.RunToSelection();

            if (selection is SubmenuItem subMenu)
            {
                this.MenuItems = subMenu.SubMenu;
                this.input.HotKeyManager.ReInitialize(this.MenuItems);
            }
            else if (selection is ActionMenuItem actionItem)
            {
                actionItem.Action?.Invoke();
            }
            else
            {
                throw new InvalidOperationException("Running a menu as action menu, requires all items to be either action items or sub menu items");
            }
        }
    }
}
