using System;

namespace ConsoleMenu.Core.Input
{
    public class ChangeSelectionEventArgs : EventArgs
    {
        public int NewIndex { get; set; }

        public ChangeSelectionEventArgs(int newIndex)
        {
            this.NewIndex = newIndex;
        }
    }


    public delegate void SelectionChangedEvent(object sender, ChangeSelectionEventArgs e);
}
