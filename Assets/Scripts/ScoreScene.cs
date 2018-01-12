using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScoreScene : MonoBehaviour {

	// Use this for initialization
    
	
	// Update is called once per frame
	void Update () {
        sceneChange();
       
	}
    void sceneChange()
    {
        if (PlayerMove.isdead == true)
        {
            if (PlayerPrefs.GetInt("YourScore") > PlayerPrefs.GetInt("last"))          // This script chooses which scene to run upon death
            {
               
                SceneManager.LoadScene("InitialInput");
            }
            else
                SceneManager.LoadScene("HighScores");
        }
    }
}
