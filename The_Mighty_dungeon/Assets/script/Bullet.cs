using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform player;
    private Vector2 target;
    public float speed;
    public float damage;
    private playerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMove>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime );
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(playerMove.armor > 0)
            {
                playerMove.armor -= damage;
            }
            else if (playerMove.armor <= 0 && playerMove.health > 0)
            {
                playerMove.health -= damage;
            }
            else if (playerMove.health <= 0 && playerMove.armor <= 0)
            {
                playerMove.die++;
                Time.timeScale = 0;
            }
            FindObjectOfType<AudioManager>().Play("Hit1");
        }
    }
}
