using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text result;
        result = GameObject.Find("PlayerScore").GetComponent<Text>();
		result.text = "You finished in " + (100 - GameMaster.timer).ToString("00") + " seconds"; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
