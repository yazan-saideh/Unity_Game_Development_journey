using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerMove : MonoBehaviour
{
    public Joystick joystick;
    Rigidbody2D rb;
    public float Speed = 600;
    public float SpeedR = 200;
    float Horitontal = 0;
    float HoritontalR = 0;
    float y = 0;
    public Joystick joystickR;
    public float health;
    public float Maxhealth;
    public float armor;
    public float Maxarmor;
    public Slider healthslider;
    public Slider armorslider;
    public Button FireButton;
    public GameObject projecttiles;
    RaycastHit2D hit;
    public int die;
    public float damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        die = PlayerPrefs.GetInt("die", 0);
        damage = PlayerPrefs.GetFloat("damage", 10);
        rb = GetComponent<Rigidbody2D>();
       Maxhealth = PlayerPrefs.GetFloat("MaxHealth", 100);
       Maxarmor = PlayerPrefs.GetFloat("ArmorHelath", 100);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hit = Physics2D.BoxCast(transform.position, new Vector2( 5 , 5), 0, new Vector2(-1 , 1) , 3);
        healthslider.value = health;
        armorslider.value = armor;
        healthslider.maxValue = Maxhealth;
        armorslider.maxValue = Maxarmor;
        rb.velocity = new Vector2(Horitontal, y);
            Horitontal = (joystick.Horizontal * Speed * Time.deltaTime) ;
        y = (joystick.Vertical * Speed * Time.deltaTime);
        if(joystickR.Horizontal > .02f)
        {
            rb.freezeRotation = false;
            transform.rotation = Quaternion.EulerAngles(0, 0, HoritontalR);
            HoritontalR = joystickR.Horizontal * -SpeedR;
        }
       else if (joystickR.Horizontal < -.02f)
        {
            rb.freezeRotation = false;
            transform.rotation = Quaternion.EulerAngles(0, 0, -HoritontalR);
            HoritontalR = joystickR.Horizontal * SpeedR;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.freezeRotation = true;
        }
       
    }
    
   public void firebutton()
    {
        Instantiate(projecttiles, transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("Shoot");
    }
   
}
