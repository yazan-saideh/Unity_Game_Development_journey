using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    
    bool walkRight;
    bool walkLeft;
    [Header("move")]
    public float movehorizontol = 0;
    public float speed;
    [Header("RigidBody")]
    private Rigidbody2D rb;
    [Header("Animation")]
    public Animator ani;
    [Header("Joystick")]
    public GameObject buttons;
    [Header("numbers")]
    public float portaluse;
    public float portalend;
    GameObject gameManager;
    public Text portaltext;
    // Start is called before the first frame update
    void Start()
    {
        rb =gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        portaluse = portalend;
        PlayerPrefs.SetFloat("portal", portaluse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        portaltext.text = portaluse.ToString();
       
            buttons.SetActive(true);
            if (walkLeft)
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, 0);
            }
            if (walkRight)
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, 0);
            }

            if (walkRight)
            {
                transform.localScale = new Vector2(3, 3);
                ani.SetBool("run", true);

            }
            else if (walkLeft)
            {
                transform.localScale = new Vector2(-3, 3);
                ani.SetBool("run", true);

            }
            else
            {
                ani.SetBool("run", false);

            }
        
        
        if(PlayerPrefs.GetFloat("portal") <= 0)
        {
            gameManager.GetComponent<GameManager>().Restart();
        }
       
    }
    public void MoveLeft()
    {
        walkLeft = true;
    }
    public void moveRight()
    {
        walkRight = true;
    }
    public void Stop()
    {
        walkLeft = false;
        walkRight = false;
        rb.velocity = new Vector2(0, 0);
    }
   
}
