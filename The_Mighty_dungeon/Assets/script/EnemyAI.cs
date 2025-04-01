using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    public float stoppingdistance;
    public float speed;
    public float startdistance;
    public float timebtwshoot;
    public float shoottime;
    public GameObject bullet;
    public float health;
    private GameManager GameManager;
    public MyBullet myBullet;
    public GameObject money;
    bool shoot;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector2.Distance(transform.position , player.position) > stoppingdistance && Vector2.Distance(transform.position, player.position) < startdistance)
        {
           transform.position = Vector2.MoveTowards(transform.position, player.position, speed* Time.deltaTime);
            if (timebtwshoot <= 0)
            {
                shoot = true;
                if(shoot == true)
                {
                    Instantiate(bullet, transform.position, Quaternion.identity);
                    timebtwshoot = shoottime;
                }
            }
            else
            {
                timebtwshoot -= Time.deltaTime;
            }
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingdistance && Vector2.Distance(transform.position, player.position) > 1)
        {
            transform.position = this.transform.position;
            if (timebtwshoot <= 0)
            {
                shoot = true;
                if (shoot == true)
                {
                    Instantiate(bullet, transform.position, Quaternion.identity);
                    timebtwshoot = shoottime;
                }
            }
            else
            {
                timebtwshoot -= Time.deltaTime;
            }
        }
        else if (player.GetComponent<playerMove>().health <= 0)
        {
            shoot = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            FindObjectOfType<AudioManager>().Play("Hit");
            health -= GameObject.FindGameObjectWithTag("Player").GetComponent<playerMove>().damage;
            if (health <= 0)
            {
                GameManager.i-=1;
                Instantiate(money, transform.position, Quaternion.identity);
                Instantiate(myBullet.bloodParticle, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);

            }
            Destroy(GameObject.FindGameObjectWithTag("Bullet"));
        }
    }
}
