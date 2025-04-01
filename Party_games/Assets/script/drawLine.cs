using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawLine : MonoBehaviour
{
    public GameObject linerender;
    public GameObject currentlinerrender;
    public LineRenderer line;
    public EdgeCollider2D EdgeCollider2D;
    public List<Vector2> fingerpos;
    bool istantiated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            finger();
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 tempo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector2.Distance(tempo , fingerpos[fingerpos.Count - 1] ) > .1f)
            {
                updateline(tempo);
            }
        }
    }
    void finger()
    {
        if(istantiated == true)
        {

        }
        else
        {
            currentlinerrender = Instantiate(linerender, Vector3.zero, Quaternion.identity);
            istantiated = true;
            line = currentlinerrender.GetComponent<LineRenderer>();
            EdgeCollider2D = currentlinerrender.GetComponent<EdgeCollider2D>();
            fingerpos.Clear();
            fingerpos.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            fingerpos.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            line.SetPosition(0, fingerpos[0]);
            line.SetPosition(1, fingerpos[1]);
            EdgeCollider2D.points = fingerpos.ToArray();
        }
    }
    void updateline(Vector2 lineupdae)
    {
        fingerpos.Add(lineupdae);
        line.positionCount++;
        line.SetPosition(line.positionCount - 1, lineupdae);
        EdgeCollider2D.points = fingerpos.ToArray();
    }
}
