using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class shoot : MonoBehaviour
{
    
    public LineRenderer line;
    public GameObject flash;
    public float firerate;
    [Range(0, 1)]
    public float firerate2;
    public Sprite assult;
    [Range(0, 10)]
    public int damage;
    public bool touchedUI = true;
    public float int1;
    //public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        firerate = firerate2;
        Input.multiTouchEnabled = true;
        //transform.parent.GetComponent<SpriteRenderer>().sprite = assult;
        if (transform.parent.GetComponent<SpriteRenderer>().sprite.name == "AstronautSpriteAtlas_11")
        {
            transform.position = new Vector3(4.615919f, -0.0004129047f, 0);
            firerate2 = .5f;
            damage = 10;
        }
        else if (transform.parent.GetComponent<SpriteRenderer>().sprite = assult)
        {
            transform.position = new Vector3(4.901481f, 0.03237902f, 0);
            firerate2 = .1f;
            damage = 50;
        }
    }

    // Update is called once per frame
    private bool isoverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (isoverUI())
               {
                touchedUI = true;
                Debug.Log("UI");
                if (Input.touchCount > 1)
                {
                    Touch t = Input.GetTouch(1);
                    if (t.phase == TouchPhase.Began)
                    {
                        if (firerate <= 0)
                        {
                            firerate = firerate2;
                            StartCoroutine(Shoot());
                        }
                    }
                    else if (t.phase == TouchPhase.Moved)
                    {
                        if (firerate <= 0)
                        {
                            firerate = firerate2;
                            StartCoroutine(Shoot());
                        }
                    }
                    else if (t.phase == TouchPhase.Ended)
                    {
                        if (firerate <= 0)
                        {
                            firerate = firerate2;
                            StartCoroutine(Shoot());
                        }
                    }


                    //touchedUI = false;

                }
            }
            else
            {
                touchedUI = false;
                if (Input.GetMouseButton(0) && touchedUI == false || Input.GetMouseButton(1) && touchedUI == false)
                if (firerate <= 0)
                {
                    firerate = firerate2;
                    StartCoroutine(Shoot());
                }
            }
        }
        firerate -= Time.deltaTime;
    }
   
   
    IEnumerator Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
        Debug.DrawRay(transform.position, transform.forward, Color.yellow);
        if (hit)
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamge(damage);
            }
            //damage enemy
            line.SetPosition(0, transform.position);
            line.SetPosition(1, hit.point);
        }
        else
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1,  transform.position+transform.right * 100);
        }
        FindObjectOfType<AudioManager>().Play("Shoot");
        line.enabled = true;
        flash.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        flash.SetActive(false);
        line.enabled = false;
    }
   
}
