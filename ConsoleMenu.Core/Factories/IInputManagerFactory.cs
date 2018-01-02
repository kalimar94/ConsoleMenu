using ConsoleMenu.Core.Input;
using ConsoleMenu.Core.Items;
using System.Collections.Generic;

namespace ConsoleMenu.Core.Factories
{
    public interface IInputManagerFactory
    {
        IMenuInputManager Create(IReadOnlyList<MenuItem> menuItems);
    }
}
