using ConsoleMenu.Core.Factories;
using ConsoleMenu.Core.Input;
using ConsoleMenu.Core.Items;
using ConsoleMenu.Core.Print;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleMenu.Core.Menus
{
    /// <summary>
    /// A menu that can have sub-menus
    /// </summary>
    public class MenuTree : Menu
    {

        public MenuItem DefaultBackitem { get; set; } = new MenuItem { Text = "Back", Id = "BACK_BTN" };

        private Stack<IReadOnlyList<MenuItem>> previousMenus;

        private IInputManagerFactory inputFactory;

        public MenuTree(IReadOnlyList<MenuItem> menuItems, IMenuPrinter printer, IInputManagerFactory inputFactory)
            : base(menuItems, printer, inputFactory.Create(menuItems))
        {
            previousMenus = new Stack<IReadOnlyList<MenuItem>>();
            this.inputFactory = inputFactory;
        }

        private IReadOnlyList<MenuItem> AddBackOption(IReadOnlyList<MenuItem> menuItems)
        {
            return DefaultBackitem != null ? menuItems.Concat(new[] { DefaultBackitem }).ToList() : menuItems;
        }

        private void UpdateCurrentMenu(IReadOnlyList<MenuItem> menuItems)
        {
            this.MenuItems = menuItems;
            this.input = this.inputFactory.Create(MenuItems);
        }

        public override MenuItem RunToSelection()
        {
            var selection = base.RunToSelection();

            if (selection is SubmenuItem menuItem)
            {
                this.previousMenus.Push(this.MenuItems); // Save current context in stack
                this.UpdateCurrentMenu(AddBackOption(menuItem.SubMenu));

                return this.RunToSelection();
            }
            else if (selection.Id == DefaultBackitem?.Id)
            {
                this.UpdateCurrentMenu(this.previousMenus.Pop());
                return this.RunToSelection();
            }
            else
            {
                return selection;
            }
        }
    }
}
