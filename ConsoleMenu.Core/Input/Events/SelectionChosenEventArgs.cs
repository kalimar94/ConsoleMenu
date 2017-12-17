using System;

namespace ConsoleMenu.Core.Input
{
    public class SelectionChosenEventArgs : EventArgs
    {
        public int ChosenIndex { get; set; }

        public SelectionChosenEventArgs(int chosenIndex)
        {
            this.ChosenIndex = chosenIndex;
        }
    }

    public delegate void SelectionChosenEvent(object sender, SelectionChosenEventArgs e);
}
