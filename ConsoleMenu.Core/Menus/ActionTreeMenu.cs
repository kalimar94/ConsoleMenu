using ConsoleMenu.Core.Factories;
using ConsoleMenu.Core.Input;
using ConsoleMenu.Core.Items;
using ConsoleMenu.Core.Print;
using System;
using System.Collections.Generic;

namespace ConsoleMenu.Core.Menus
{
    /// <summary>
    /// A menu that contains either <see cref="ActionMenuItem"/> or <see cref="SubmenuItem"/>.
    /// Thus each item is either a submenu or an action that gets executed on selection
    /// </summary>
    public class ActionTreeMenu : Menu
    {
        private IInputManagerFactory inputFactory;

        public ActionTreeMenu(IReadOnlyList<MenuItem> menuItems, IMenuPrinter printer, IInputManagerFactory inputFactory)
            : base(menuItems, printer, inputFactory.Create(menuItems))
        {
            this.inputFactory = inputFactory;
        }

        public void RunActionMenu()
        {
            var selection = base.RunToSelection();

            if (selection is SubmenuItem subMenu)
            {
                this.MenuItems = subMenu.SubMenu;
                this.input = inputFactory.Create(this.MenuItems);
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
