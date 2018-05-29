using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
	public static Vector2 ballSpawn;
    private float strength = 0f;
    private bool held;
    private int num = 0;
    private Rigidbody2D ballPhys;
    Text txt1;
    Text txt2;
    void Start()
    {
		xa.player[0] = new TwoPlayer();
		xa.player[1] = new TwoPlayer();
        txt1 = GameObject.Find("lblScore1").GetComponent<Text>();
        txt2 = GameObject.Find("lblScore2").GetComponent<Text>();
        ballPhys = gameObject.GetComponent<Rigidbody2D>();
		ballSpawn = gameObject.transform.position;
    }
    void Update()
    {
		if (xa.player[num].hasBall == true)
			FollowPlayer();
		if (Input.GetKey("down") && xa.player[1].hasBall == true|| xa.player[0].hasBall == true && Input.GetKey("s"))
			strength = xa.player[num].charge(strength,ref held);
            else
            {
                if (held == true)
                {
                    held = false;
                    ballPhys.velocity = Vector2.zero;
                    Shoot();
                }
            }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player1")
        {
            num = 0;
			xa.player[0].PickUp();
			xa.player[1].Drop();
            held = false;
        }
        else if (col.gameObject.tag == "Player2")
        {
            num = 1;
			xa.player[1].PickUp();
			xa.player[0].Drop();
            held = false;
        }
        if (xa.player[0].hasBall == false && xa.player[1].hasBall == false)
        {
            if (col.gameObject.tag == "Net1")
            {
                xa.audioManager.PlayScore();
                xa.player[0].score++;
                txt1.text = xa.player[0].score.ToString();
				BallRespawn();             
            }
            else if (col.gameObject.tag == "Net2")
            {
                xa.audioManager.PlayScore();
                xa.player[1].score++;
                txt2.text = xa.player[1].score.ToString();                 
				BallRespawn();
            }
            else if (col.gameObject.tag == "Hazards")
				BallRespawn();
        }

    }
    void FollowPlayer()
    {
        Vector2 ballPos;
        if (num == 0)
            ballPos = target1.transform.position;
        else
            ballPos = target2.transform.position;
        ballPos.y += 0.5f;
        transform.position = ballPos;
        ballPhys.angularVelocity = 0;
    }
    void Shoot()
    {
        xa.audioManager.PlayPass();
        xa.player[num].Drop();
        ballPhys.AddForce(Vector2.up  * strength);
        if (xa.ballRight[num] == true)
            ballPhys.AddForce(Vector2.right * strength * 0.7f);
        else
            ballPhys.AddForce(Vector2.left * strength * 0.7f);
		strength = 0;
    }
	public static void BallRespawn()
	{
		GameObject.Find("Basketball").GetComponent<Transform>().position = ballSpawn;
		GameObject.Find ("Basketball").GetComponent<Rigidbody2D> ().isKinematic = true;
		GameObject.Find ("Basketball").GetComponent<Rigidbody2D> ().isKinematic = false;
	}
}