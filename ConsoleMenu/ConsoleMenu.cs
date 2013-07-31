using System;

class ConsoleMenu
{
    static void Main()
    {
        string[] menuOptions = { "Option1", "Option2", "Option3", "Option4" };      // the options in the menu

        int currentOption = 0;      // currently selected option

        PrintMenu(menuOptions, currentOption);      // print the menu for the first time

        while (true)
        {
            if (Console.KeyAvailable)           // if the user presses a key
            {
                var key = Console.ReadKey();    // read the key
                if (key.Key == ConsoleKey.UpArrow && currentOption > 0)     // check if its upArrow and change the selected option
                {
                    currentOption--;
                }
                else if (key.Key == ConsoleKey.DownArrow && currentOption < menuOptions.Length - 1)      // check if its downArrow and change the selected option
                {
                    currentOption++;
                }
                else if (key.Key == ConsoleKey.Enter)       // check if its enter exit from the loop to print the current selection
                {
                    break;
                }
                PrintMenu(menuOptions, currentOption);      // print the menu again to update the selection
            }
        }

        Console.WriteLine("You have selected: {0}", menuOptions[currentOption]);

    }

    /// <summary>
    /// This method prints the menu on the console
    /// </summary>
    static void PrintMenu(string[] options, int selectedOption)
    {
        Console.Clear();  // first clear the console from all previous version of the menu
        for (int i = 0; i < options.Length; i++)
        {
            if (i == selectedOption)        // print the selected option with inverted colors
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine(options[i]);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }


}

