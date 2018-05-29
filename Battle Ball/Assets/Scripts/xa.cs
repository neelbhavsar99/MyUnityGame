using UnityEngine;
using System.Collections;

public class xa : MonoBehaviour 
{
	// this script creates a bunch of static public variables that can be seen by all the other scripts in the game

	public static AudioManager audioManager;
    public static bool[] ballRight = new bool[2];
	public static TwoPlayer[] player = new TwoPlayer[2];
    // layers

	public enum TeamWithBall
	{
		None,
		Team1,
		Team2
	}

	public static TeamWithBall teamWithBall = TeamWithBall.None;

	void Start()
	{
		// cache these so they can be accessed by other scripts
		audioManager = gameObject.GetComponent<AudioManager>();
	}
}