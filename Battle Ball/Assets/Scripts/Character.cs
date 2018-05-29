using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{
	public MyTeam myTeam;

	public enum inputState 
	{ 
		None, 
		WalkLeft, 
		WalkRight, 
		Jump, 
		Pass
	}
	[HideInInspector] public inputState currentInputState;
	
	[HideInInspector] public enum facing { Right, Left }
	[HideInInspector] public facing facingDir;

	[HideInInspector] public bool alive = true;
	[HideInInspector] public Vector3 spawnPos;
	
	protected Transform _transform;
	protected Rigidbody2D _rigidbody;

	// edit these to tune character movement	
	private float runVel = 2.5f; 	// run speed when not carrying the ball
	private float walkVel = 2f; 	// walk speed while carrying ball
	private float jumpVel = 4f; 	// jump velocity
	private float jump2Vel = 2f; 	// double jump velocity
	private float fallVel = 1f;		// fall velocity, gravity
    public bool onIce = false;
    public bool onSand = false;
    public float moveVel;
	
	private int jumps = 0;
    private int maxJumps = 2; 		// set to 2 for double jump
	protected string team = "";

	// raycast stuff
	private RaycastHit2D hit;
	private Vector2 physVel = new Vector2();
	[HideInInspector] public bool grounded = false;
	private int groundMask = 1 << 8; // Ground layer mask

	public virtual void Awake()
	{
		_transform = transform;
		_rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Use this for initialization
	public virtual void Start () 
	{
		moveVel = walkVel;
	}
	
	// Update is called once per frame
	public virtual void UpdateMovement() 
	{
		if(myTeam == MyTeam.Team1 && xa.player[0].hasBall == true)
			PickUpBall();
		else if (myTeam == MyTeam.Team2 && xa.player[1].hasBall == true) 
			PickUpBall ();
		else
			RemoveBall ();
	}
	
	// ============================== FIXEDUPDATE ============================== 

	public virtual void UpdatePhysics()
	{
		physVel = Vector2.zero;

        // move left
        if (currentInputState == inputState.WalkLeft && onSand == true)
			physVel.x = -0.5f;
        else if (currentInputState == inputState.WalkLeft)
            physVel.x = -moveVel;	
		// move Right
        else if (currentInputState == inputState.WalkRight && onSand == true)
			physVel.x = 0.5f;
        else if (currentInputState == inputState.WalkRight)
            physVel.x = moveVel;

		// jump
		if(currentInputState == inputState.Jump)
		{
			if(jumps < maxJumps)
			{
				jumps += 1;
				if(jumps == 1)
				{
					_rigidbody.velocity = new Vector2(physVel.x, jumpVel);
				}
				else if(jumps == 2)
				{
					_rigidbody.velocity = new Vector2(physVel.x, jump2Vel);
				}
			}
		}
			

		// use raycasts to determine if the player is standing on the ground or not
		if (Physics2D.Raycast(new Vector2(_transform.position.x-0.1f,_transform.position.y), -Vector2.up, .26f, groundMask) 
		    || Physics2D.Raycast(new Vector2(_transform.position.x+0.1f,_transform.position.y), -Vector2.up, .26f, groundMask))
		{
			grounded = true;
            jumps = 0;
		}
		else
		{
			grounded = false;
			_rigidbody.AddForce(-Vector3.up * fallVel);
		}
			
        // if they're on ice, add force to their character so they "slide"
        if (onIce == true && facingDir == facing.Left)
            _rigidbody.AddForce(Vector2.left * 5);
        else if (onIce == true && facingDir == facing.Right)
            _rigidbody.AddForce(Vector2.right * 5);
        else
            _rigidbody.velocity = new Vector2(physVel.x, _rigidbody.velocity.y);
	}
    // ============================== SPEED HANDLING ==============================

    public virtual void PickUpBall()
	{
		moveVel = walkVel;
	}
	
	void RemoveBall()
	{
		moveVel = runVel;
	}
}
public enum MyTeam 
{
	Team1,
	Team2,
	None
}