using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class RotateHand : MonoBehaviour
{
    public float speed;
    public bool touchedUI = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private bool isoverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    void Update()
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
                    Vector2 dis = Camera.main.ScreenToWorldPoint(t.position) - transform.position;
                    float angle = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
                    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
                }
               else if (t.phase == TouchPhase.Moved)
                {
                    Vector2 dis = Camera.main.ScreenToWorldPoint(t.position) - transform.position;
                    float angle = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
                    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
                }
               else if(t.phase == TouchPhase.Ended)
                {
                    Vector2 dis = Camera.main.ScreenToWorldPoint(t.position) - transform.position;
                    float angle = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
                    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
                }
                
            }
        }
        else
        {
            Vector2 dis = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        }
    }
}
