using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PortalMove : MonoBehaviour
{
    [Header("portals")]
    public GameObject OrangePortal;
    public GameObject BluePortal;
    Vector2 target;
    public bool portalcreated = false;
    public bool touchedUI = true;
    public GameObject portalgun;
    Vector2 gunpos;
    public Transform tip;
    bool Blueportalinstansiate = true;
   public bool blueportalinstansiate = false;
   public bool Orangeportalinstansiate = true;
    GameObject orange;
    GameObject blue;
    
    // Start is called before the first frame update
    void Start()
    {
        Input.multiTouchEnabled = true;
        gameObject.GetComponent<PlayerMove>().portaluse = PlayerPrefs.GetFloat("portal");
    }

    // Update is called once per frame
    void Update()
    {
        
        gunpos = new Vector2(portalgun.transform.position.x, portalgun.transform.position.y);
        if (Input.GetMouseButtonDown(0))
        {
            // Check if finger is over a UI element
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                touchedUI = true;
                Debug.Log("UI");
            }
            else
            {
                touchedUI = false;
                if (Input.GetMouseButtonDown(0) && touchedUI == false)
                {
                    if (Input.GetMouseButtonDown(0) && portalcreated == false)
                    {

                        //Touch t = Input.GetTouch(0);
                        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        Vector2 dirction = (target - gunpos);
                        portalgun.transform.right = dirction;
                        if (GameObject.FindGameObjectWithTag("OrangePortal") && Orangeportalinstansiate == true)
                        {
                            //orange.SetActive(false);
                            Orangeportalinstansiate = false;
                            portalcreated = true;
                        }
                        
                        if (Orangeportalinstansiate == false)
                        {
                            
                            OrangePortal.SetActive(true);
                            if(Vector2.Distance(transform.position , target) < 10)
                            {
                                OrangePortal.transform.position = new Vector2(target.x, target.y);
                            }
                            Orangeportalinstansiate = true;
                            portalcreated = true;
                        }
                        else
                        {
                            OrangePortal.SetActive(false);
                            Orangeportalinstansiate = false;
                        }
                        
                    }
                    else if (Input.GetMouseButtonDown(0) && portalcreated == true)
                    {
                        //Touch t = Input.GetTouch(0);
                        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        Vector2 dirction = target - gunpos;
                        portalgun.transform.right = dirction;
                        if(GameObject.FindGameObjectWithTag("BluePortal") && Blueportalinstansiate == true)
                        {
                            
                            //blue.SetActive(false);
                            Blueportalinstansiate = false;
                            blueportalinstansiate = false;
                            portalcreated = false;
                        }
                        
                        Blueportalinstansiate = false;
                        if (Blueportalinstansiate == false)
                        {
                            
                            BluePortal.SetActive(true);
                            if (Vector2.Distance(transform.position, target) < 10)
                            {
                                BluePortal.transform.position = new Vector2(target.x, target.y);
                            }
                            
                            Blueportalinstansiate = true;
                            blueportalinstansiate = true;
                            portalcreated = false;
                            gameObject.GetComponent<PlayerMove>().portaluse -= 1;
                            PlayerPrefs.SetFloat("portal", gameObject.GetComponent<PlayerMove>().portaluse);

                        }
                        else
                        {
                            BluePortal.SetActive(false);
                            Blueportalinstansiate = false;
                            blueportalinstansiate = false;
                        }
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            gameObject.transform.parent = collision.gameObject.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            gameObject.transform.parent = null;
        }
    }
}
