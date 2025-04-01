using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumppad : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private Rigidbody2D rb;
    public float jumphight;
    [SerializeField]
    bool jumpplayer = false;
   
    float jumptime;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(jumpplayer == true)
        {
            rb.velocity = new Vector2(0, jumphight * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            jumpplayer = true;
            Debug.Log("weeeee");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jumpplayer = false;
        }
    }
}
