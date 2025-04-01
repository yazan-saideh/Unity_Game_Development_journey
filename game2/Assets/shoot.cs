using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    GameObject player;
    public float speed;
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = new Vector3(player.transform.position.x, player.transform.position.y , player.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position == target )
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;
            GameManager game;
            game = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            game.lose();
            Destroy(gameObject);
        }
        
    }
}
