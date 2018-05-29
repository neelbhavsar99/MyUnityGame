using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    Text txt;
    float timeLeft = 120f;
    void Update()
    {
        txt = GameObject.Find("lblTime").GetComponent<Text>();
        timeLeft -= Time.deltaTime;
        txt.text = timeLeft.ToString("F2");
		if (timeLeft <= 0) 
			SceneManager.LoadScene("Victory Screen");
    }
}