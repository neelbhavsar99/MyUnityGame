using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Victory : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Text winner;
		winner = GameObject.Find("lblWinner").GetComponent<Text>();
        if (xa.player[0].score > xa.player[1].score)
        {
            winner.text = "Player 1 wins!!";
        }
        else if (xa.player[1].score > xa.player[0].score)
        {
            winner.text = "Player 2 wins!!";
        }
        else
            winner.text = "It's a tie!!";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}