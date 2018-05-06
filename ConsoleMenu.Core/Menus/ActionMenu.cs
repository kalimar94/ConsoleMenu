using ConsoleMenu.Core.Input;
using ConsoleMenu.Core.Items;
using ConsoleMenu.Core.Print;
using System.Collections.Generic;

namespace ConsoleMenu.Core.Menus
{
    /// <summary>
    /// A menu that contains only <see cref="ActionMenuItem"/>.
    /// Each item has an action defined that will be executed on selection
    /// </summary>
    public class ActionMenu : Menu
    {
        public ActionMenu(IReadOnlyList<MenuItem> menuItems, IMenuPrinter printer, IMenuInputManager input)
            : base(menuItems, printer, input)
        {
        }

        public virtual void RunActionMenu()
        {
            var selection = base.RunToSelection() as ActionMenuItem;
            selection?.Action?.Invoke();
        }
    }
}
