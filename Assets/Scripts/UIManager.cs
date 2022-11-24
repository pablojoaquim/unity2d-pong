using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// Include the name space for TextMesh Pro
using TMPro;

public class UIManager : MonoBehaviour
{
    // [SerializeField]
    public TMP_Text scoreTextPlayerLeft;
    // [SerializeField]    
    public TMP_Text scoreTextPlayerRight;

    GameObject[] pauseObjects;
    GameObject[] finishObjects;

    bool finishShowed;

    // Start is called before the first frame update
    void Start()
    {
        finishShowed = false;

        scoreTextPlayerLeft.text = "Player 1: " + 0;
        scoreTextPlayerRight.text = "Player 2: " + 0;

        Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        finishObjects = GameObject.FindGameObjectsWithTag("ShowOnFinish");

        hidePaused();
        hideFinished();
    }

    // Update is called once per frame
    void Update()
    {
        if (finishShowed == false)
        {
            // uses the spacebar button to pause and unpause the game
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                    showPaused();
                } else if (Time.timeScale == 0){
                    Time.timeScale = 1;
                    hidePaused();
                }
            }
        }

        //uses the F5 button to restart
        if(Input.GetKeyDown(KeyCode.F5))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void updateScorePlayerLeft (int playerScore)
    {
        scoreTextPlayerLeft.text = "Player 1: " + playerScore.ToString();
    }

    public void updateScorePlayerRight (int playerScore)
    {
        scoreTextPlayerRight.text = "Player 2: " + playerScore.ToString();
    }

    public void updateGameOver ()
    {
        finishShowed = true;
        Time.timeScale = 0;
        showFinished();
    }
    

    // hides objects with ShowOnPause tag
	public void hidePaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}
	}

    // shows objects with ShowOnPause tag
	public void showPaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(true);
		}
	}

    //shows objects with ShowOnFinish tag
	public void showFinished(){
		foreach(GameObject g in finishObjects){
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnFinish tag
	public void hideFinished(){
		foreach(GameObject g in finishObjects){
			g.SetActive(false);
		}
	}
}
