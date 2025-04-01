using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public float look = 10f;
    Transform target;
    public float health = 400;
    public int sworddamage = 1000;
    public float timebtwshoots;
    public float starttimebtwshoot;
    public GameObject Enemybullet;
    public Transform guntip;
    public Transform randomspawn;
    public int minX;
    public int maxX;
    public int maxZ;
    public int minZ;
    public float waittime;
    public float startwaittime;
    public float speed;
    NavMeshAgent agent;
    public float ninjastardamage = 100;
    public GameObject ninjastar;
    // Start is called before the first frame update
    void Start()
    {
        randomspawn.position = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));
        waittime = startwaittime;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        timebtwshoots = starttimebtwshoot;
        agent = gameObject.GetComponent<NavMeshAgent>();
        
    }
    private void Update()
    {
        
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= look)
        {
           
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                facetarget();
            }
           
            if(timebtwshoots <= 0)
            {
                Instantiate(Enemybullet, guntip.position, transform.rotation);
                timebtwshoots = starttimebtwshoot;
            }
            else
            {
                timebtwshoots -= Time.deltaTime;
            }
        }
        else {
            agent.SetDestination(randomspawn.position);
            if (Vector3.Distance(transform.position, randomspawn.position) <= .2f)
            {
                if (waittime <= 0)
                {
                    randomspawn.position = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));
                    waittime = startwaittime;
                }
                else
                {
                    waittime -= Time.deltaTime;
                }
            }
        }

    }
    // Update is called once per frame
    public void damageEnemy(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, look);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            damageEnemy(sworddamage);
        }
        if (other.CompareTag("Bullet"))
        {
            damageEnemy(ninjastardamage);
            Destroy(ninjastar);
        }
    }
    
    void facetarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation , lookrotation , Time.deltaTime * 5f);
    }
}
