using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelLoad : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] buttons;
    void Start()
    {
        int levelat = PlayerPrefs.GetInt("LevelAt", 2);
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i + 2 > levelat)
                buttons[i].interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
