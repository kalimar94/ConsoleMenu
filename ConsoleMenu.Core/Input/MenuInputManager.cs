using System;
using System.Threading;

namespace ConsoleMenu.Core.Input
{
    public class MenuInputManager : IMenuInputManager
    {
        private int selectedIndex;

        public int OptionsCount { get; set; }

        public bool CycleSelection { get; set; }

        public IHotkeyManger HotKeyManager { get; private set; }


        public MenuInputManager(int optionsCount, IHotkeyManger hotkeyManger = null, int startIndex = 0, bool cycleSelection = false)
        {
            this.OptionsCount = optionsCount;
            this.selectedIndex = startIndex;
            this.HotKeyManager = hotkeyManger;
            this.CycleSelection = cycleSelection;
        }

        /// <summary>
        /// Blocks execution until the next event occurs - which can be either change of selection 
        /// or confirming/chosing the selected item
        /// </summary>
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
                        else if (CycleSelection) this.selectedIndex = OptionsCount - 1;

                        return new ChangeSelectionEventArgs(this.selectedIndex);
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (this.selectedIndex < OptionsCount - 1) this.selectedIndex++;
                        else if (CycleSelection) this.selectedIndex = 0;

                        return new ChangeSelectionEventArgs(this.selectedIndex);
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        return new SelectionChosenEventArgs(this.selectedIndex);
                    }
                    else if (hotkeyChar.HasValue)
                    {
                        return new SelectionChosenEventArgs(hotkeyChar.Value);
                    }
                }
                Thread.Sleep(10);  // This should greatly reduce CPU usage
            }
        }


    }
}
