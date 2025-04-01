using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour
{
    public Joystick joystick;
    float movehoriznatol = 0;
    float moveVertical = 0;
    public float speed;
    public float jump;
    Rigidbody2D Rigidbody2D;
    public Animator ani;
    bool Jump = false;
   public bool isgrounded;
    public LayerMask whatisGround;
    public GameObject feet;
    public GameObject cam;
    public Text Health;
    public float health;
    public float maxhealth;
    public Slider healthSlider;
    public GameManager gameManager;
    public float points;
    public float coins;
    public float coinsBouns;
    public float death;
    // Start is called before the first frame update
    void Start()
    {
        death = PlayerPrefs.GetFloat("death");
        coins = PlayerPrefs.GetFloat("coins");
        maxhealth=PlayerPrefs.GetFloat("Health");
        Time.timeScale = 1;
        coinsBouns = 1;
      //coins = PlayerPrefs.GetFloat("coin");
        health = maxhealth;
        Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        healthSlider.value = health;
        healthSlider.maxValue = maxhealth;
        Health.text = health.ToString() + "/" + maxhealth.ToString();
       movehoriznatol = Mathf.Clamp(movehoriznatol, -18, 18);
        if (joystick.Horizontal > .2f)
        {
            movehoriznatol = speed * Time.deltaTime;
            gameObject.transform.localScale = new Vector3(3, 3, 3);

            if (cam.transform.position.x >= 6)
            {
                if (transform.position.x >= 6)
                {
                    cam.transform.position = new Vector3(6, cam.transform.position.y, cam.transform.position.z);
                }
            }
            else if (transform.position.x <= -6)
            {
                cam.transform.position = new Vector3(-6, cam.transform.position.y, cam.transform.position.z);
            }
            else
            {
                cam.transform.position = new Vector3(transform.position.x, cam.transform.position.y, cam.transform.position.z);
            }
        }
        else if(joystick.Horizontal < -.2f)
        {
            movehoriznatol = -speed * Time.deltaTime;
            gameObject.transform.localScale = new Vector3(-3, 3, 3);
            if (cam.transform.position.x <= -6)
            {
                if (transform.position.x <= -6)
                {
                    cam.transform.position = new Vector3(-6, cam.transform.position.y, cam.transform.position.z);
                }
            }
            else if (transform.position.x >= 6)
            {
                cam.transform.position = new Vector3(6, cam.transform.position.y, cam.transform.position.z);
            }
            else
            {
                cam.transform.position = new Vector3(transform.position.x, cam.transform.position.y, cam.transform.position.z);
            }
        }
        else
        {
            movehoriznatol = 0;
            cam.transform.position = cam.transform.position;
        }
        isgrounded = Physics2D.OverlapCircle(feet.transform.position, 0.05f, whatisGround);
        ani.SetFloat("speed", Mathf.Abs(movehoriznatol));
        
        if(joystick.Vertical > .2f && isgrounded == true)
        {
            Rigidbody2D.velocity = Vector2.up * jump * Time.deltaTime;
            Jump = true;
            FindObjectOfType<AudioManager>().Play("Jump");
        }
        if(isgrounded == false)
        {
            ani.SetBool("jump", true);
        }
        else
        {
            ani.SetBool("jump", false);
        }
        Rigidbody2D.velocity = new Vector2(movehoriznatol,Rigidbody2D.velocity.y);
        if (transform.position.y <= -5)
        {
            gameManager.lose();
        }
    }
    public void TakeDamge(int Damage)
    {
        Enemy enemy = FindObjectOfType<Enemy>();
        Damage = enemy.damage;
        if (health > 0)
        {
            health -= Damage;
        }
        else
        {
            death++;
            PlayerPrefs.SetFloat("death", death);
            PlayerPrefs.SetFloat("coins", coins);
            gameManager.lose();
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }
   
}
