using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade_In_Out : MonoBehaviour
{

    public Image whiteFade;
    
    void Start()
    {
        whiteFade.canvasRenderer.SetAlpha(1.0f);
        fadeIn();
    }

    
    void fadeIn ()
    {
        whiteFade.CrossFadeAlpha(0, 2, false);
    }
}
