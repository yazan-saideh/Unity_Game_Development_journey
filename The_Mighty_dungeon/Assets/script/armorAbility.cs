using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armorAbility : MonoBehaviour
{
    playerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMove>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("PowerUp");
            playerMove.armor += 20;
            Destroy(gameObject);
        }
    }
}
