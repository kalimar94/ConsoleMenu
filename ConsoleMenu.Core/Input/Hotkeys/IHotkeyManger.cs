using ConsoleMenu.Core.Items;
using System.Collections.Generic;

namespace ConsoleMenu.Core
{
    public interface IHotkeyManger
    {
        int? GetItemIndexForKey(char key);

        void ReInitialize(IReadOnlyList<MenuItem> items);
    }
}