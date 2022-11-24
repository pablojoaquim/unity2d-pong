using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float speed = 30;
    public AudioClip bounceAudioEffect;    // Add your Audi Clip Here;

    private float speed_delta;

    private int scorePlayerLeft;
    private int scorePlayerRight;

    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(0,2) == 0? -1 : 1;
        float y = Random.Range(0,2) == 0? -1 : 1;

        speed_delta = 0;

        scorePlayerLeft = 0;
        scorePlayerRight = 0;

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed*x, speed*y);
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider
        
        // Hit the left Racket?
        if (col.gameObject.name == "playerLeft") {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * (speed + speed_delta);
            
            // Play the sound effect
            GetComponent<AudioSource>().Play();

            // Increment the ball speed on every hit
            speed_delta++;
            AddScore_PlayerLeft();
        }

        // Hit the right Racket?
        if (col.gameObject.name == "playerRight") {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * (speed + speed_delta);
            
            // Play the sound effect
            GetComponent<AudioSource>().Play();

            // Increment the ball speed on every hit
            speed_delta++;
            AddScore_PlayerRight();
        }

        // Hit the left wall?
        if (col.gameObject.name == "goalLeft") {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameOver();
        }

        if (col.gameObject.name == "goalRight") {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameOver();
        }

    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight) 
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        float factor = (ballPos.y - racketPos.y) / racketHeight;
        Debug.Log(ballPos);
        Debug.Log(racketPos);
        Debug.Log(racketHeight);
        Debug.Log(factor);

        return factor;
    }

    void AddScore_PlayerLeft()
    {
        scorePlayerLeft++;
        canvas.GetComponent<UIManager>().updateScorePlayerLeft(scorePlayerLeft);
    }

    void AddScore_PlayerRight()
    {
        scorePlayerRight++;
        canvas.GetComponent<UIManager>().updateScorePlayerRight(scorePlayerRight);
    }

    void GameOver()
    {
        canvas.GetComponent<UIManager>().updateGameOver();
    }

}
