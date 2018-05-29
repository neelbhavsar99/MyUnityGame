using UnityEngine;
using System.Collections;

public class TwoPlayer
{
	private bool ballPossesion=false;
	private int strength;

	public bool hasBall 
	{
		get{ return ballPossesion; }
		set{ ballPossesion = value; }
	}
	public float charge(float num, ref bool held)
	{
		if (ballPossesion == true && num < 5) 
		{
			num += 0.25f;
		}
		held = true;
		return num;
	}
	public void PickUp()
	{
        xa.audioManager.PlayPickup();
        ballPossesion = true;
		GameObject.Find ("Basketball").GetComponent<CircleCollider2D>().isTrigger = true;
	}
	public void Drop()
	{
		ballPossesion = false;
		GameObject.Find ("Basketball").GetComponent<CircleCollider2D>().isTrigger = false;
	}
	public int score
	{
		get;
		set;
	}
}