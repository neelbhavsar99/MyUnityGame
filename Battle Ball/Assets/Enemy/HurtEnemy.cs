using UnityEngine;
using System.Collections;

public class HurtEnemy : MonoBehaviour {
    public int damageToGive;
   
    public class PlayerStats
    {
        public int Health = 100;
    }
    public PlayerStats playerStats = new PlayerStats();
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(this);
        }
    }

   /* public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
        if (playerStats.Health <= 0)
        {
            GameMaster.KillPlayer(this);
        }
    } */
}
