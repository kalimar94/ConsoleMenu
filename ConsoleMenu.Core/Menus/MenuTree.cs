using ConsoleMenu.Core.Input;
using ConsoleMenu.Core.Items;
using ConsoleMenu.Core.Print;
using System.Collections.Generic;

namespace ConsoleMenu.Core.Menus
{
    /// <summary>
    /// A menu that can have sub-menus
    /// </summary>
    public class MenuTree : Menu
    {
        new public event SelectionChangedEvent OnSelectionChange;
        new public event SelectionChosenEvent OnItemChosen;

        public MenuTree(IReadOnlyList<MenuItem> menuItems, IMenuPrinter printer, IMenuInputManager input)
            : base(menuItems, printer, input)
        {

        }

        public override MenuItem RunToSelection()
        {
            var selection = base.RunToSelection();

            if (selection is SubmenuItem subMenu)
            {
                this.MenuItems = subMenu.SubMenu;
                this.input.HotKeyManager.ReInitialize(this.MenuItems);

                return this.RunToSelection();
            }
            else
            {
                return selection;
            }
        }
    }
}
