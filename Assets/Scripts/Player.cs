using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 30;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move;
        
        if (gameObject.name == "playerLeft")
        {
            move = Input.GetAxisRaw("Vertical2");
        }
        else
        {
            move = Input.GetAxisRaw("Vertical");
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, move*speed);
    }
}
