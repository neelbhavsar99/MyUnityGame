using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class ReadFile : MonoBehaviour {
    private string inValue;
    private string[] score;
    // Use this for initialization
    void Start()
    {
        Text bestScore;
        bestScore = GameObject.Find("last score").GetComponent<Text>();

        if (File.Exists("last winner.txt"))
        {
            try
            {
                StreamReader highScore = new StreamReader("last winner.txt");
                while ((inValue = highScore.ReadLine()) != null)
                {
                    score = inValue.Split(',');
                }
            }
            catch (IOException exc)
            {
                Debug.Log(exc.Message);
            }
            bestScore.text = "The last player who finished the 1-player mode was: \n" + "'" + score[0] + "' who completed in: \n" + score[1] + " seconds!";
        }       
    }
}
