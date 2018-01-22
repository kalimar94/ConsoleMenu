using System;

namespace ConsoleMenu.Core.Input
{
    public interface IMenuInputManager
    {
        int OptionsCount { get; set; }

        bool CycleSelection { get; set; }

        /// <summary>
        /// Blocks execution until the next event occurs - which can be either change of selection 
        /// or confirming/chosing the hovered item
        /// </summary>
        EventArgs WaitForNextEvent();

    }
}