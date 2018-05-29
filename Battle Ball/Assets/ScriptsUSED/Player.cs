using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [System.Serializable]
    [SerializeField]
    //This script is when the player falls off the ground and respawns
    public class PlayerStats {
        public int Health = 100;
    }
    private GameObject CompleteGame;
    public float cameraShakeAmt = 0.1f;
    Camera camShake;
    public PlayerStats playerStats = new PlayerStats();
    public int fallBoundary = -20;
    public PlayerController player;
    public Transform spawnPrefab;


    [SerializeField]
    Sound[] sounds;

    public void MakeActive()
    {
        CompleteGame.SetActive(true);
    }

    void Start()
    {
       
    }

    void Update()
    {
        if (transform.position.y <= fallBoundary)
        {
            PlaySound("Background");
            DamagePlayer(9999999);
        }
    }

    void OnCollisionEnter2D(Collision2D x)
    {
        if (x.gameObject.tag == "Obstacle")
        {
            GameObject duplicate = Instantiate(spawnPrefab, player.transform.position, player.transform.rotation) as GameObject;
            Destroy(duplicate, 3f);
            DamagePlayer(99999999);
        }

        if (x.gameObject.tag == "EndPoint")
        {
            
            Debug.Log("Game Ended");
            GameMaster.timer = GameMaster.timeLeft;
            SceneManager.LoadScene("FinishGame");
        }

    }

    public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
        if (playerStats.Health <= 0) {
            GameMaster.KillPlayer(this);
        }
    }

    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }
    }
}
