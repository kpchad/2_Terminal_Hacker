using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    string[] level1Passwords = { "heart", "brain", "bone", "spine", "blood" };
    string[] level2Passwords = { "muscle", "appendix", "pancreas", "injection", "anesthetic" };

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu("Hello Kyle");
    }

    void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("");
        Terminal.WriteLine("How well can you decode medical terms?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for med school level");
        Terminal.WriteLine("Press 2 for residency level");
        Terminal.WriteLine("Press 3 for fellowship level");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("Let's try again");
            currentScreen = Screen.MainMenu;
        }
        else if (currentScreen == Screen.MainMenu){
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password){
            CheckPassword(input);
        }
        else if (currentScreen == Screen.Win){
            
        }
        else {
            
        }
    }



    void RunMainMenu(string input) {
        if (input == "1"){
            level = 1;
            password = level1Passwords[2]; // to do: make random
            StartGame();
        }
        else if (input == "2"){
            level = 2;
            password = level2Passwords[1]; // to do: make random
            StartGame();
        }
        else if (input == "bandaid"){
            Terminal.WriteLine("bandaids won't fix everything, kid.");
            Terminal.WriteLine("Go to med school.");
        }
        else{
            Terminal.WriteLine("invalid response");
        }
    }

    void StartGame() {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have selected level " + level);
        if (level == 1) {
            Terminal.WriteLine("enter password:");
        }
        else if (level == 2){
            Terminal.WriteLine("enter password:");
        }
        else {
            
        }
    }

    void CheckPassword(string input) {
        if (input == password) {
            Terminal.WriteLine("You Win!");
        }
        else {
            Terminal.WriteLine("Try again...");
        }
    }

}