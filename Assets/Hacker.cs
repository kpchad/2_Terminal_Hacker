using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        var greeting = "Hello Kyle";
        ShowMainMenu(greeting);
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
        print("The user typed " + input);
    }

}