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
        const string BACK_BTN_ID = "BACK_BTN";

        public string BackButtonText { get; set; } = "Back";

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
            return menuItems.Concat(new[] { new MenuItem { Text = BackButtonText , Id = BACK_BTN_ID } }).ToList();
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
            else if (selection.Id == BACK_BTN_ID)
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
