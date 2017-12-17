using System;

namespace ConsoleMenu.Core.Input
{
    public interface IMenuInputManager
    {
        bool CycleSelection { get; set; }

        IHotkeyManger HotKeyManager { get; }

        EventArgs WaitForNextEvent();
    }
}