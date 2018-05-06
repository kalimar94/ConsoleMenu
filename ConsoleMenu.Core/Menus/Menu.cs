using ConsoleMenu.Core.Input;
using ConsoleMenu.Core.Items;
using ConsoleMenu.Core.Print;
using System.Collections.Generic;

namespace ConsoleMenu.Core.Menus
{
    /// <summary>
    /// A simple menu with multiple items
    /// </summary>
    public class Menu
    {
        protected IMenuPrinter printer;
        protected IMenuInputManager input;

        public IReadOnlyList<MenuItem> MenuItems { get; protected set; }
        public event SelectionChangedEvent OnSelectionChange;
        public event SelectionChosenEvent OnItemChosen;

        public Menu(IReadOnlyList<MenuItem> menuItems, IMenuPrinter printer, IMenuInputManager input)
        {
            this.MenuItems = menuItems;
            this.printer = printer;
            this.input = input;
        }

        /// <summary>
        /// Displays the menu and waits for the user to select an item from the menu.
        /// The selected item is returned
        /// </summary>
        public virtual MenuItem RunToSelection()
        {
            int selectedIndex = 0;
            while (true)
            {
                MenuItems[selectedIndex].IsSelected = true;
                printer.PrintMenuItems(MenuItems);

                var inputData = input.WaitForNextEvent();
                if (inputData is ChangeSelectionEventArgs selectionChange)
                {
                    MenuItems[selectedIndex].IsSelected = false;

                    selectedIndex = selectionChange.NewIndex;
                    OnSelectionChange?.Invoke(this, selectionChange);
                }
                else if (inputData is SelectionChosenEventArgs itemChosen)
                {
                    MenuItems[selectedIndex].IsSelected = false;

                    OnItemChosen?.Invoke(this, itemChosen);
                    return MenuItems[itemChosen.ChosenIndex];
                }
            }
        }

    }
}
