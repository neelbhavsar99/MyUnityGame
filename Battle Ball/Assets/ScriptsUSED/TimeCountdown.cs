using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//For the countdown of the game
public class TimeCountdown : MonoBehaviour
{
    public float timeStart = 100;
    private Text theText;
    public float timeFinished;
    public GameObject GameOverScreen;
    public PlayerController player;
    private PauseMenu pauseMenu;

    // Use this for initialization
    void Start()
    {
        theText = GetComponent<Text>();

    }
    void Update()
    {

        timeStart -= Time.deltaTime;
		GameMaster.timeLeft = timeStart;
        theText.text = "TIME: " + timeStart.ToString("00");

        if (timeStart <= 0)
        {
            GameOverScreen.SetActive(true);
            player.gameObject.SetActive(false);
        }
        
    }
    /*public float time()
    {
        return timeFinished = timeStart;
    }*/
}

        
