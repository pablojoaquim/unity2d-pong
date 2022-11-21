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

    // Start is called before the first frame update
    void Start()
    {
        scoreTextPlayerLeft.text = "Player 1: " + 0;
        scoreTextPlayerRight.text = "Player 2: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScorePlayerLeft (int playerScore)
    {
        scoreTextPlayerLeft.text = "Player 1: " + playerScore.ToString();
    }

    public void updateScorePlayerRight (int playerScore)
    {
        scoreTextPlayerRight.text = "Player 2: " + playerScore.ToString();
    }
}
