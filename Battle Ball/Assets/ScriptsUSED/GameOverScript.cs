using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {
    // Use this for initialization
    public void Quit()
    {
        //To quit the game
        Debug.Log("QUIT GAME");
        SceneManager.LoadScene("Menu");
    }

    public void TryAgain()
    {
       
        //Method used to try again (pre determined method from unity)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
        

}
