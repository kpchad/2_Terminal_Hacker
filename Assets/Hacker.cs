using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game state
    int level; 

    // Use this for initialization
    void Start()
    {
        ShowMainMenu("Hello Kyle");
    }

    void ShowMainMenu(string greeting)
    {
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
        }
        else if (input == "1"){
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else if (input == "bandaid"){
            Terminal.WriteLine("bandaids won't fix everything, kid.");
            Terminal.WriteLine("Go to med school.");
        }
        else {
            Terminal.WriteLine("invalid response");
        }
    }

    void StartGame()
    {
        Terminal.WriteLine("You have selected level " + level);
    }
}