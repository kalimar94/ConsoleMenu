using System;
using System.Collections.Generic;

namespace ClassyConsoleMenu
{
    class Examples
    {
        static void Main()
        {
            ConsoleMenu mainMenu = new ConsoleMenu("Colors", "Animals", "RandomMenu", "Programming Languages");   // define a menu without header (text above it)

            // if we want a menu with a header we have to define the options using new string[] and the header after them
            ConsoleMenu colorsMenu = new ConsoleMenu(options: new string[] { "Red", "Blue", "Orange", "Black", "Purple", "White", "Green", "Yellow", "\nBack" }, MenuHeader: "SolveTasks Menu");  
            ConsoleMenu animalsMenu = new ConsoleMenu(new string[] { "Reptiles", "Mammals", "Birds", "\nBack" }, "Choose Animal Type or get back to previous menu:");  
            ConsoleMenu randomMenu = new ConsoleMenu(new string[] { "Only RandomStuff here", "\nBack" }, "RandomMenu");   
            ConsoleMenu languagesMenu = new ConsoleMenu(options: new string[] { "C#", "Visual Basic", "Java", "C++", "Pascal", "\nBack" }, MenuHeader: "Programming Languages Menu");

            // This is how we create SubMenus:
            mainMenu.subMenus.Add(0, colorsMenu);     // defining that option 0 ("Colors") is actually a submenu - the menu "colorsMenu" 
            mainMenu.subMenus.Add(1, animalsMenu);    // defining that option 1 ("Animals") is actually a submenu - the menu "colorsMenu"
            mainMenu.subMenus.Add(2, randomMenu);     // defining that option 2 ("RandomMenu") is actually a submenu - the menu "randomMenu" 
            mainMenu.subMenus.Add(3, languagesMenu);  // defining that option 3 ("Programming Languages") is actually a submenu - the menu "languagesMenu"

            //An example of adding SubMenus to the Animals Menu without using subMenus.Add(). And it's not necessary to predefine the menus (we can define them when adding them)
            animalsMenu.subMenus = new Dictionary<int, ConsoleMenu>()
            {
                {0, new ConsoleMenu(options: new string[] { "Snake", "Lizzard", "Crocodile", "Turtle", "\nBack" }, MenuHeader: "Reptiles SubMenu")},        // a submenu on index 0
                {1, new ConsoleMenu(options: new string[] { "Human", "Dog", "Cat", "Bear", "\nBack" }, MenuHeader: "Mammals SubMenu")},                     // a submenu on index 1
                {2, new ConsoleMenu(options: new string[] { "Hawk", "Eagle", "Pigeon", "Owl", "\nBack" }, MenuHeader: "Reptiles SubMenu")}                  // a submenu on index 2
            };

            string result = mainMenu.StartMenu();  // starting the Main Menu, all sub menus will be automaticly started if needed

            Console.WriteLine();
            Console.WriteLine("You have selected: {0}", result);

            // Tip: You can change the position of the Menus using yourMenu.positionLeft and .positionTop, 
            // as well as the Back keyword from \nBack to something else using yourMenu.backKeyword

        }
    }

}