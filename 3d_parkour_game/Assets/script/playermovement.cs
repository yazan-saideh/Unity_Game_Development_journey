using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playermovement : MonoBehaviour
{
    public CharacterController controller;
    public float health, armor;
    public float maxhealth, maxarmor;
    public Slider healthslider;
    public Slider armorslider;
        public Animator ani;
    public float turmsmoothtime = 0.1f;
    float turnsmoothvelocity;
    public float speed = 6f;
    public Transform cam;
    Vector3 velocity;
    float gravity = -9.81f;
    public Transform groundcheck;
    public float groundcheckdistance = 0.4f;
    public LayerMask layer;
    bool isgrounded;
    public float heightjump = 3f;
    public void FixedUpdate()
    {
       
        recoverhealth();
        healthslider.value = health;
        healthslider.maxValue = maxhealth;
        armorslider.value = armor;
        armorslider.maxValue = maxarmor;
    }
    private void Update()
    {
        isgrounded = Physics.CheckSphere(groundcheck.position, groundcheckdistance, layer);
        if(isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float X = Input.GetAxis("Horizontal");
        float Y = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(X, 0, Y).normalized;
        if(direction.magnitude >= 0.1)
        {
            float targetangle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnsmoothvelocity, turmsmoothtime);
            transform.rotation = Quaternion.Euler(0, targetangle, 0);
            Vector3 MovDir = Quaternion.Euler(0, targetangle, 0) * Vector3.forward;
            controller.Move(MovDir.normalized * speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                controller.Move(MovDir.normalized * speed * 2 * Time.deltaTime);
            }
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(heightjump * -2f * gravity);
        }
    }
    public void TakeDamage(float damage)
    { if(armor >= 1)
        {
            armor -= damage;
        }
        else if(health >= 1 && armor <= 1)
        {
            health -= damage;
        }
         if(health <= 1)
        {
            die();
        }
    }
    void die()
    {
        //GetComponent<SkinnedMeshRenderer>().material = dissolve;
    }
    void recoverhealth()
    {
        if(health <= 20 && health > 0)
        {
            health += .01f;
        }
    }
}
