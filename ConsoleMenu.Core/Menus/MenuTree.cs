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

        Stack<IReadOnlyList<MenuItem>> previousMenus;

        public MenuTree(IReadOnlyList<MenuItem> menuItems, IMenuPrinter printer, IMenuInputManager input)
            : base(menuItems, printer, input)
        {
            previousMenus = new Stack<IReadOnlyList<MenuItem>>();
        }

        private static IReadOnlyList<MenuItem> AddBackItem(IReadOnlyList<MenuItem> menuItems)
        {
            var list = new List<MenuItem>(menuItems);
            list.Add(new MenuItem { Text = "Back", Id = BACK_BTN_ID });

            return list;
        }

        private void UpdateCurrentMenu(IReadOnlyList<MenuItem> menuItems)
        {
            this.MenuItems = menuItems;
            this.input.OptionsCount = this.MenuItems.Count;
            this.input.HotKeyManager.ReInitialize(this.MenuItems);
            this.input.ResetSelection();
        }

        public override MenuItem RunToSelection()
        {
            var selection = base.RunToSelection();

            if (selection is SubmenuItem subMenu)
            {
                this.previousMenus.Push(this.MenuItems);
                this.UpdateCurrentMenu(AddBackItem(subMenu.SubMenu));

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
