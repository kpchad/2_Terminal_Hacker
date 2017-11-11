
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    const string menuHint = "You may type menu at any time.";
    string[] level1Passwords = { "heart", "brain", "bone", "spine", "blood" };
    string[] level2Passwords = { "muscle", "appendix", "pancreas", "injection", "anesthetic" };
    string[] level3Passwords = { "influenza", "bronchitis", "cartilage", "endoscope", "epichondyle"};

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
        Terminal.WriteLine("Type 1 for med school level");
        Terminal.WriteLine("Type 2 for residency level");
        Terminal.WriteLine("Type 3 for fellowship level");
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
        else if (input == "quit" || input == "close" || input == "exit"){
            Terminal.WriteLine("If on the web, close the tab");
            Application.Quit();
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
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber){
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "bandaid"){ // easter egg
            Terminal.WriteLine("bandaids won't fix everything, kid.");
            Terminal.WriteLine("Go to med school.");
        }
        else{
            Terminal.WriteLine("invalid response");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword() {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword() {
        switch (level) {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                Terminal.WriteLine(menuHint);
                break;
        }
    }

    void CheckPassword(string input) {
        if (input == password) {
            DisplayWinScreen();
        }
        else {
            AskForPassword();
        }
    }

    void DisplayWinScreen() {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward() {
        switch (level){
            case 1:
                Terminal.WriteLine("You have unlocked the textbook!");
                Terminal.WriteLine(@"
    _____________________
   /                    /
  /____________________/
 (|___________________|__
 (|___________________| /
  \____________________/
"               );
                break;
            case 2:
                Terminal.WriteLine("You have unlocked the white coat!");
                Terminal.WriteLine(@"
  ____   ___
 / \_ \/_/  \
| |  \|/  || |
L_|   |.  ||_|
  |   |.  |
  / U /\ U \
  L___||___|
"               );
                break;
            case 3:
                Terminal.WriteLine("You have unlocked the stethescope!");
                Terminal.WriteLine(@"
   ========
 //        \\
()          \\              _
             O=============(O)
()          //              
 \\        //
   ========
");
                break;
            default:
                Debug.LogError("invalid level reached");
                break;
        }

    }
}