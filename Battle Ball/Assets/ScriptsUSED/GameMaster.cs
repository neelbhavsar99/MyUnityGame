using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
   
    public static GameMaster gm;
    private static int noOfLives = 3;
    [SerializeField]
    private GameObject gameOver;
    public static float timer;
	public static float timeLeft;
    public static Player player;
    //There is two variables declared here, one for this class and one for the "LivesCountdown" class. (public and private variables)
    public static int _NOofLives
    {
        get { return noOfLives; }
    }

    //Method EndGame where it resets the player's life to 3 and enables the GameOverScreen.
    public void EndGame()
    {
        noOfLives = 3;
        
        gameOver.SetActive(true);
    }
    //This is for the GM tag 
    void Start ()
    {

     //  player = FindObjectOfType<Player>();
                
        if (gm == null) {
            gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();
        }
    }
    //These variables are declared for where the player respawns.
    public Transform playerPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 2;
    public Transform spawnPrefab;


    public Transform deathParticle;

    
        //Because we are using yield thats why we need IEnumerator
    public IEnumerator RespawnPlayer ()
    {

        //Trying the death particle effect
      // GameObject duplicate2 = Instantiate(deathParticle, playerPrefab.transform.position, playerPrefab.transform.rotation) as GameObject;
         //Destroy(duplicate2, 3f);
        
        //Waits for 2 seconds when player falls down.
        Debug.Log("Waiting for spawn sound");
           
        yield return new WaitForSeconds(spawnDelay);
        //This word instantiate means that the player'a duplicate is created at the position of the spawnpoint child
       Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);

        //This makes the particle effect    
        GameObject duplicate = Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
        //Destroy method is used to get rid of the particles (because they are faded away but still there)
        Destroy(duplicate, 3f);
    }

    //This method kills the object as well as reduces the number of lives and when it is 0 lives, the game ends.
    public static void KillPlayer (Player player)   {
        
        Destroy (player.gameObject);
        noOfLives -= 1;
        if (noOfLives <= 0)
        {
            gm.EndGame(); 
        }
        else
        {
            gm.StartCoroutine(gm.RespawnPlayer());
        }

        }
}
