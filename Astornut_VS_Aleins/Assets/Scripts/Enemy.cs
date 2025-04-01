using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    GameObject player;
    public float speed;
    public float health;
    public Slider healthslider;
    public float MaxHealth;
    public Text healthtext;
    public GameManager gameManager;
    public int damage;
    public GameObject partical;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        health = MaxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        healthslider.value = health;
        healthslider.maxValue = MaxHealth;
        healthtext.text = health.ToString() + "/" + MaxHealth.ToString();
        if (Vector2.Distance(transform.position, player.transform.position) > 0.8f)
        {
             transform.position =Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if(health <= 0)
        {
            FindObjectOfType<AudioManager>().Play("Kill");
            player.GetComponent<player>().points = player.GetComponent<player>().coinsBouns;
            partical.SetActive(true);
            player.GetComponent<player>().coins = player.GetComponent<player>().coins + player.GetComponent<player>().points;
            if (gameManager.started == false)
            {
                gameManager.enemynum -= 1f;
            }
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<player>().TakeDamge(damage);
            Destroy(gameObject);
        }
        
    }
    public void TakeDamge(int Damage)
    {
        if(health > 0)
        {
            health -= Damage;
        }
        else
        { 
            FindObjectOfType<AudioManager>().Play("Kill");
            player.GetComponent<player>().points = player.GetComponent<player>().coinsBouns;
            partical.SetActive(true); 
            player.GetComponent<player>().coins = player.GetComponent<player>().coins + player.GetComponent<player>().points;
            if (gameManager.started == false)
            {
                gameManager.enemynum -= 1f;
            }
            Destroy(gameObject);
        }
    }
}
