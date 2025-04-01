
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.RenderGraphModule;
using UnityEngine.Rendering.HighDefinition;
public class TimeManager : MonoBehaviour
   
{

    public Animator ani;
    public float slowmition = .2f;
    public bool isslowed = false;
    public float slowmotiontime;
    
    bool slowed;
    public Volume Volume;
    Vignette Vignette;
    public void Start()
    {
        Volume.profile.TryGet(out Vignette);
    }
    private void Update()
    {
        if(slowed == true)
        {
            Vignette.intensity.value += .007f;
            slowmotiontime += Time.deltaTime;
        }
        slowmotiontime = Mathf.Clamp(slowmotiontime, 0, 2);
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            if (Time.timeScale == 1)
            {
                Time.timeScale = .5f;
                slowed = true;

            }
            else if(Time.timeScale == .5f)
            {
                Time.timeScale = 1f;
            }
            
        }
            if(slowmotiontime >= 2)
            {
            slowed = false;
            if (slowed == false)
            {
                if(Vignette.intensity.value == 0)
                {
                    slowmotiontime = 0;
                }
                Time.timeScale = 1f;
                Vignette.intensity.value -= .01f;
            }
        }
        
    }
}


