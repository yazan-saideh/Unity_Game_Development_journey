using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
     NavMeshAgent agent;
     Transform player;
    public LayerMask WhatIsGround, WhatIsPlayer;
    public Vector3 walkpoint;
    public bool walkpointset;
    public float walkpointrange;
    public float tbwshoots;
    public bool alreadyshooted;
    public float sightrange, attackrange;
    public bool playerinAttackRange, PlayerInSightrange;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInSightrange = Physics.CheckSphere(transform.position, sightrange, WhatIsPlayer);
        playerinAttackRange = Physics.CheckSphere(transform.position, attackrange, WhatIsPlayer);
        if (!PlayerInSightrange && !playerinAttackRange) patroling();
        if (PlayerInSightrange && !playerinAttackRange) cashing();
        if (PlayerInSightrange && playerinAttackRange) attacking();
    }
    void patroling()
    {
        if (!walkpointset)
            searchwalkpoint();
        if (walkpointset)
            agent.SetDestination(walkpoint);
        Vector3 distance = transform.position - walkpoint;
        if (distance.magnitude < 1)
            walkpointset = false;
       
    }
    void searchwalkpoint()
    {
        float randomZ = Random.Range(-walkpointrange, walkpointrange);
        float randomX = Random.Range(-walkpointrange, walkpointrange);
        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkpoint, -transform.up, 36.58381f, WhatIsGround))
            walkpointset = true;
    }
    void cashing()
    {
        agent.SetDestination(player.position);
    }
    void attacking()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        if (!alreadyshooted)
        {
            alreadyshooted = true;
            Invoke(nameof(ResetAttack), tbwshoots);
        }
    }
    private void ResetAttack()
    {
        alreadyshooted = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, attackrange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, sightrange);
    }
}
