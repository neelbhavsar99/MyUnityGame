using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using System.IO;

public class HighScores : MonoBehaviour {

    public static string username = "";
    private StreamWriter highscore;

    public void SetName(string input)
    {
        username = input;
    }

    public void Highscore()
    {
        highscore = new StreamWriter("last winner.txt");
        if (File.Exists("last winner.txt"))
        {
            Debug.Log("last winner.txt" + " already exists.");
            
            Debug.Log(username + " " + (100 - GameMaster.timeLeft));
            highscore.WriteLine(username + "," + (100 - GameMaster.timeLeft));
            Debug.Log("Text written to file");
        }
        else
        {
            Debug.Log("File doesnt exist");
            File.CreateText("last winner.txt");
            Debug.Log("FILE WAS CREATED");
            
            highscore.WriteLine(username + "," + (100 - GameMaster.timeLeft));
            Debug.Log("Text written to file");
        }    
        highscore.Close();
    }
}
