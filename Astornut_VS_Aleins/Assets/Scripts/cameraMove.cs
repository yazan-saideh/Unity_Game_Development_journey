using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class cameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + 5 * Time.deltaTime, transform.position.y, transform.position.z);
    }
    public void playscene()
    {
        SceneManager.LoadScene("New Scene");
    }
}
