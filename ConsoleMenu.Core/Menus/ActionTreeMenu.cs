using ConsoleMenu.Core.Factories;
using ConsoleMenu.Core.Input;
using ConsoleMenu.Core.Items;
using ConsoleMenu.Core.Print;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleMenu.Core.Menus
{
    /// <summary>
    /// A menu that contains either <see cref="ActionMenuItem"/> or <see cref="SubmenuItem"/>.
    /// Thus each item is either a submenu or an action that gets executed on selection
    /// </summary>
    public class ActionTreeMenu : ActionMenu
    {
        private IInputManagerFactory inputFactory;

        private Stack<IReadOnlyList<MenuItem>> previousMenus;

        public ActionTreeMenu(IReadOnlyList<MenuItem> menuItems, IMenuPrinter printer, IInputManagerFactory inputFactory)
            : base(menuItems, printer, inputFactory.Create(menuItems))
        {
            previousMenus = new Stack<IReadOnlyList<MenuItem>>();
            this.inputFactory = inputFactory;
        }

        private void UpdateCurrentMenu(IReadOnlyList<MenuItem> menuItems)
        {
            this.MenuItems = menuItems;
            this.input = this.inputFactory.Create(MenuItems);
        }

        private IReadOnlyList<MenuItem> AddBackOption(IReadOnlyList<MenuItem> menuItems)
        {
            return MenuItem.DefaultBackitem != null ? menuItems.Concat(new[] { MenuItem.DefaultBackitem }).ToList() : menuItems;
        }

        override public void RunActionMenu()
        {
            var selection = base.RunToSelection();


            if (selection is SubmenuItem menuItem)
            {
                this.previousMenus.Push(this.MenuItems); // Save current context in stack, so that we can go back
                this.UpdateCurrentMenu(AddBackOption(menuItem.SubMenu));

                this.RunActionMenu();
                return;
            }
            else if (selection.Id == MenuItem.DefaultBackitem?.Id)
            {
                this.UpdateCurrentMenu(this.previousMenus.Pop()); // Restore the last saved state
                this.RunActionMenu();
                return;
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
