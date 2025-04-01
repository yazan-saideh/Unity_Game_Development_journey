using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    public void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1 ;
    }
}
