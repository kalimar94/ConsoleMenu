using ConsoleMenu.Core.Input;
using ConsoleMenu.Core.Input.Hotkeys;
using ConsoleMenu.Core.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenu.Core.Factories
{
    public class InputManagerFactory : IInputManagerFactory
    {
        private int startIndex;
        private bool cycleSelection;

        public InputManagerFactory(int startIndex = 0, bool cycleSelection = false)
        {
            this.startIndex = startIndex;
            this.cycleSelection = cycleSelection;
        }

        public IMenuInputManager Create(IReadOnlyList<MenuItem> menuItems)
        {
            var hotkeyManager = new HotkeyManager(menuItems);
            var inputManager = new MenuInputManager(menuItems.Count, hotkeyManager, startIndex, cycleSelection);

            return inputManager;
        }
    }
}
