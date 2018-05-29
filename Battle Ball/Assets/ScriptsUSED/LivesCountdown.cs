using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesCountdown : MonoBehaviour {
    [SerializeField]
    private Text livesText;

	// Use this for initialization
	void Awake() {
        livesText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        livesText.text = "LIVES: " + GameMaster._NOofLives.ToString(); 
	}
}
