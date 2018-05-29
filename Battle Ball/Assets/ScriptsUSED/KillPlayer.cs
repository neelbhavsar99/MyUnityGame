using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {
    
    //Create empty levelmanager of type levelmanager
    public GameMaster GameMaster;
    // Use this for initialization
    void Start () {
        //Find any object in the scene that has a level manager on it .
        GameMaster = FindObjectOfType<GameMaster>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {   
            GameMaster.RespawnPlayer();
        }      
    }
}
