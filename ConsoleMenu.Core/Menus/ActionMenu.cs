using ConsoleMenu.Core.Input;
using ConsoleMenu.Core.Items;
using ConsoleMenu.Core.Print;
using System.Collections.Generic;

namespace ConsoleMenu.Core.Menus
{
    public class ActionMenu : Menu
    {
        public ActionMenu(IReadOnlyList<ActionMenuItem> menuItems, IMenuPrinter printer, IMenuInputManager input)
            : base(menuItems, printer, input)
        {
        }

        public void RunActionMenu()
        {
            var selection = base.RunToSelection() as ActionMenuItem;
            selection.Action?.Invoke();
        }
    }
}
