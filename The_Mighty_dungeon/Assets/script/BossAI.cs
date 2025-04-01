using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossAI : MonoBehaviour
{
    private Transform player;
    public float stoppingdistance;
    public float speed;
    public float startdistance;
    public float timebtwshoot;
    public float shoottime;
    public GameObject bullet;
    public float health;
    public float damage;
    public float score;
     public GameManager GameManager;
    public GameObject bossblood;
    public MyBullet myBullet;
    void Start()
    {
        //GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingdistance && Vector2.Distance(transform.position, player.position) < startdistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            if (timebtwshoot <= 0)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                timebtwshoot = shoottime;
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
                Instantiate(bullet, transform.position, Quaternion.identity);
                timebtwshoot = shoottime;
            }
            else
            {
                timebtwshoot -= Time.deltaTime;
            }
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
                speed = 0;
                FindObjectOfType<AudioManager>().Play("Boss");
                if (GameObject.FindGameObjectsWithTag("EnemyReal").Length == 0)
                {
                    GameManager.score++;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                // GameObject.FindGameObjectWithTag("Boss").active = (false);
                Instantiate(bossblood, transform.position, Quaternion.identity);
                Invoke("destroy", 2f);
            }
            
        }
    }
    void destroy()
    {
        Destroy(gameObject);
    }
}
