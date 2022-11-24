using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// Include the name space for TextMesh Pro
using TMPro;

public class UIManager : MonoBehaviour
{
    // [SerializeField]
    public TMP_Text scoreTextPlayerLeft;
    // [SerializeField]    
    public TMP_Text scoreTextPlayerRight;

    GameObject[] pauseObjects;

    // Start is called before the first frame update
    void Start()
    {
        scoreTextPlayerLeft.text = "Player 1: " + 0;
        scoreTextPlayerRight.text = "Player 2: " + 0;

        Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        //uses the p button to pause and unpause the game
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

    public void updateScorePlayerLeft (int playerScore)
    {
        scoreTextPlayerLeft.text = "Player 1: " + playerScore.ToString();
    }

    public void updateScorePlayerRight (int playerScore)
    {
        scoreTextPlayerRight.text = "Player 2: " + playerScore.ToString();
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
}
