using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float speed;
    public float speedjump;
    public float jumpcount = 1;
    public float moveHorizontol;
    public float moveVertical;
    public Rigidbody2D rb;
    public bool IsRight = false;
    public bool IsLeft = false;
    public Animator ani;
    public LayerMask layer;
    public LayerMask layer2;
   public bool isjump = false;
   public bool isground = true;
   public bool isoneplayer = true;
    public GameObject groundcheck;
    public GameObject playercheck;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsLeft)
        {
            rb.velocity = new Vector2(-speed * Time.deltaTime, -60* Time.deltaTime);
                transform.localScale = new Vector2(-1, 1);
            ani.SetBool("run", true);
        }
        if (IsRight)
        {
            rb.velocity = new Vector2(speed * Time.deltaTime, -60 * Time.deltaTime);
                transform.localScale = new Vector2(1, 1);
            ani.SetBool("run", true);
        }
        isground  = Physics2D.OverlapCircle(groundcheck.transform.position,  0.2f, layer);
        isoneplayer  = Physics2D.OverlapCircle(playercheck.transform.position,  0.2f, layer2);
        if (isoneplayer)
        {
            jumpcount = 2;
        }
        else
        {
            jumpcount = 1;
        }
        if (isjump && jumpcount > 0 && isground )
        {
            isjump = false;
            rb.velocity = (Vector2.up * speedjump * Time.deltaTime);
        }
    } 
    public void moveRight()
    {
        IsRight = true;
    }
        
    public void moveLeft()
    {
        IsLeft = true;
    }
    public void jump()
    {
        jumpcount -= 1;
        isjump = true;
    }
    public void Stop()
    {
        ani.SetBool("run", false);
        IsLeft = false;
        IsRight = false;
        isjump = false;
    }
}
