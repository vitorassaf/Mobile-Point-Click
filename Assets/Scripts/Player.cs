using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2d;
    public float horizontalInput = 0f;
    public bool grounded;
    public Animator anima;
    public static bool move;
    public bool dir = true;
    public Vector2 touchPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(horizontalInput, rb2d.velocity.y);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 t = Camera.main.ScreenToViewportPoint(touch.position);
            if (t.y > 0.2)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        move = false;
                        touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 25f));
                        if (touchPosition.x > transform.position.x)
                            dir = true;
                        else
                            dir = false;
                        break;
                    case TouchPhase.Ended:
                        if (move)
                            Movimento(dir);
                        move = false;
                        break;
                }
            }
        }
        if (dir)
        {
            if (touchPosition.x <= transform.position.x)
            {
                horizontalInput = 0;
            }
        }
        else
        {
            {
                if (touchPosition.x >= transform.position.x)
                {
                    horizontalInput = 0;
                }
            }
        }
        if (horizontalInput > 0.2f)
        {
            anima.SetBool("isRun", true);
            gameObject.transform.localScale = new Vector3(1,1);
        }
        else if (horizontalInput < -0.2f)
        {
            anima.SetBool("isRun", true);
            gameObject.transform.localScale = new Vector3(-1, 1);
        }
        else
        {
            horizontalInput = 0;
            anima.SetBool("isRun", false);
        }
    }

    public void MoveButton()
    {
        move = !move;
    }

    public void Movimento(bool dir)
    {
        if (dir)
        {
            horizontalInput = speed;
        }
        else
        {
            horizontalInput = -speed;
        }
    }
}
