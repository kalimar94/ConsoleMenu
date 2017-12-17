using System;

namespace ConsoleMenu.Core.Input
{
    public interface IMenuInputManager
    {
        int OptionsCount { get; set; }

        bool CycleSelection { get; set; }

        IHotkeyManger HotKeyManager { get; }

        EventArgs WaitForNextEvent();

        void ResetSelection();
    }
}