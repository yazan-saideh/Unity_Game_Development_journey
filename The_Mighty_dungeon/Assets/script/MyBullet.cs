using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MyBullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public EnemyAI EnemyAI;
    public BossAI BossAI;
    private GameManager GameManager;
    public GameObject bloodParticle;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb.velocity = player.transform.up * (speed * Time.deltaTime);
    }
    // Update is called once per frame
    
   
}
