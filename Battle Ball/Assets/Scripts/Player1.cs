using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player1 : Character 
{
    // Use this for initialization
    public Transform spawn;

    public override void Start () 
	{
		base.Start();
		// grab the players position at startup and use it for the spawn position when starting new rounds
		myTeam = MyTeam.Team1;
		spawnPos = _transform.position;
	}
	
	public void Update () 
	{
		// reload the scene to reset scores etc
		if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.T))
		{
            SceneManager.LoadScene(0);
		}
		UpdateMovement();
	}

	public void FixedUpdate()
	{
		// inputstate is none unless one of the movement keys are pressed
		currentInputState = inputState.None;
		
		// move left
		if(Input.GetKey(KeyCode.A)) 
		{ 
			currentInputState = inputState.WalkLeft;
			facingDir = facing.Left;
            xa.ballRight[0] = false;
        }

		// move right
		if (Input.GetKey(KeyCode.D) && currentInputState != inputState.WalkLeft) 
		{ 
			currentInputState = inputState.WalkRight;
			facingDir = facing.Right;
            xa.ballRight[0] = true;
        }

		// jump
		if (Input.GetKeyDown(KeyCode.W)) 
		{ 
			currentInputState = inputState.Jump;
		}

		// pass the ball
		if(Input.GetKeyDown(KeyCode.S))
		{
			currentInputState = inputState.Pass;
		}

		UpdatePhysics();
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Hazards")
		{
			if (xa.player[0].hasBall == true) 
			{
				xa.player[0].Drop();
				Ball.BallRespawn();
			}
			gameObject.SetActive (false);
			gameObject.SetActive (true);
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