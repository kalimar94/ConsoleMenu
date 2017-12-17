using System;

namespace ConsoleMenu.Core.Input
{
    public class MenuInputManager : IMenuInputManager
    {
        private int selectedIndex;
        private int optionsCount;

        public bool CycleSelection { get; set; }

        public IHotkeyManger HotKeyManager { get; private set; }

        public MenuInputManager(int optionsCount, IHotkeyManger hotkeyManger = null, int startIndex = 0, bool cycleSelection = false)
        {
            this.optionsCount = optionsCount;
            this.selectedIndex = startIndex;
            this.HotKeyManager = hotkeyManger;
            this.CycleSelection = cycleSelection;
        }

        public EventArgs WaitForNextEvent()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    var hotkeyChar = HotKeyManager?.GetItemIndexForKey(key.KeyChar);

                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        if (this.selectedIndex > 0) this.selectedIndex--;
                        else if (CycleSelection) this.selectedIndex = optionsCount - 1;

                        return new ChangeSelectionEventArgs(this.selectedIndex);
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (this.selectedIndex < optionsCount - 1) this.selectedIndex++;
                        else if (CycleSelection) this.selectedIndex = 0;

                        return new ChangeSelectionEventArgs(this.selectedIndex);
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        return new SelectionChosenEventArgs(this.selectedIndex);
                    }
                    else if (hotkeyChar.HasValue)
                    {
                        return new SelectionChosenEventArgs(this.selectedIndex);
                    }
                }
            }
        }
    }
}
