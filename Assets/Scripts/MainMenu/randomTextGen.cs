using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class randomTextGen : MonoBehaviour
{
    public List<string> Messages = new List<string>();
    [SerializeField] TMP_Text mytext;

    private void Start()
    {
        Messages.Add("surprisingly lacking in phallic imagery");
        Messages.Add("IT’S SHORT FOR DOOM TICKLE, GUYS");
        Messages.Add("Is your dickle bloody, or are you just happy to see me");
        Messages.Add("Our protagonist is a woman, btw. #Feminism");
        Messages.Add("Get ready for some girlboss behavior");
        Messages.Add("Don’t look at the map from a top-down angle");
        Messages.Add("Kate T. Dickle loves you");
        Messages.Add("If you’ve got a bloody dickle, please call a doctor immediately");
        Messages.Add("The NYU mental health hot-line number is (212) 443-9999, btw");
        Messages.Add("He bloody on my dickle till I *Willhelm screams*");
        Messages.Add("Capitalism be damned, that girl can tickle!");
        Messages.Add("This happened to my buddy, Eric");
        Messages.Add("All hail our corporate overlords");
        Messages.Add("NYU Game Design is personally responsible for this");
        Messages.Add("Iiiii’m gonna getcha!");
        Messages.Add("Smash or pass Doom Guy");
        Messages.Add("Doom Guy x Kate T. Dickle: OTP 4ever");
        Messages.Add("Able to be run on your refrigerator!");
        Messages.Add("Hot girls work in Unity");
        Messages.Add("Best internship ever!");
        Messages.Add("Post this shit on your LinkedIn");
        Messages.Add("This one’s going on the resume");
        Messages.Add("Look at how pretty Dade’s hands are");
        Messages.Add("Creating a hostile work environment");
        Messages.Add("This game is porn to somebody");
        Messages.Add("This is the future liberals want");
        Messages.Add("Getting paid in bagels and experience");
        Messages.Add("Just a hop and a skip away from being a fetish game");
        Messages.Add("Don’t read into it...");
        Messages.Add("For the girls, theys, and gays");
        Messages.Add("Arguably a cozy game");
        Messages.Add("Tickle tac toe");
        Messages.Add("Dear Global Game Jam 2024 Judges, We wuv u :3");
        Messages.Add("Go Violets!");
        Messages.Add("Getting corporate!");
        Messages.Add("#GlobalGameJam2024");
        Messages.Add("''RANDOM TEXT''");

        Invoke("ChangeText", 1.0f);
    }

    public void ChangeText()
    {
        mytext.text = Messages[Random.Range(0, Messages.Count)];
    }
}
