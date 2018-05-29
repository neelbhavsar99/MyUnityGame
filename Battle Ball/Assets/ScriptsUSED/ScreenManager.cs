using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("Menu");
    }
	
    public void EndGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }
}
