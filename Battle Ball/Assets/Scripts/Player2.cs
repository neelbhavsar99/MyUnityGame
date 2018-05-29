using UnityEngine;
using System.Collections;

public class Player2 : Character 
{	
	// Use this for initialization
	public override void Start () 
	{
		myTeam = MyTeam.Team2;
		base.Start();
		spawnPos = _transform.position;
	}
	
	// Update is called once per frame
	public void Update () 
	{
		UpdateMovement();
	}

	public void FixedUpdate()
	{
		// these are false unless one of keys is pressed
		currentInputState = inputState.None;
		
		// keyboard input
		if(Input.GetKey(KeyCode.LeftArrow)) 
		{ 
			currentInputState = inputState.WalkLeft;
			facingDir = facing.Left;
            xa.ballRight[1] = false;
        }
		if (Input.GetKey(KeyCode.RightArrow) && currentInputState != inputState.WalkLeft) 
		{ 
			currentInputState = inputState.WalkRight;
			facingDir = facing.Right;
            xa.ballRight[1] = true;
        }
		
		if (Input.GetKeyDown(KeyCode.UpArrow)) 
		{ 
			currentInputState = inputState.Jump;
		}
		
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			currentInputState = inputState.Pass;
		}
		
		UpdatePhysics();
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Hazards")
        {
            if (xa.player[1].hasBall == true)
            {
                xa.player[1].Drop();
				Ball.BallRespawn();
            }
            gameObject.SetActive(false);
            gameObject.SetActive(true);
            _transform.position = spawnPos;
        }
        if (other.gameObject.tag == "Sand")
        {
            onSand = true;
        }
        else
            onSand = false;
        if (other.gameObject.tag == "Ice")
        {
            onIce = true;
        }
        else
            onIce = false;
    }
    public void Respawn()
	{
		if(alive == true)
		{
			_transform.position = spawnPos;
		}
	}
}