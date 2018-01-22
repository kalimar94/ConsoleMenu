using System;

namespace ConsoleMenu.Core.Items
{
    /// <summary>
    /// A single item in the menu, that can be selected
    /// </summary>
    public class MenuItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Text { get; set; }

        public char HotKey { get; set; }

        public bool IsSelected { get; set; }

        public override string ToString()
         => $"Item: {Text}  Id : {Id}";

        public override bool Equals(object obj)
        {
            if (obj is MenuItem other)
                return this.Id.Equals(other.Id);
            else return false;
        }

        public override int GetHashCode()
            => this.Id.GetHashCode();

    }
}
