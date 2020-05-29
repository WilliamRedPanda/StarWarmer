using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFadeValueRuntime : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Renderer render;
    [SerializeField] Image blackPanel;

    [SerializeField] float timer;

    Material material;
    float fadeValue;
    float delta;
    float oldAlpha;

    private void Awake()
    {
        if (image)
        {
            material = image.material;
        }
        else if (render)
        {
            material = render.material;
        }
        oldAlpha = blackPanel.color.a;
    }

    private void OnEnable()
    {
        fadeValue = 0;
        material.SetFloat("_Slider", fadeValue);
        StartCoroutine(FadeCorutine());
        blackPanel.color = new Color(0, 0, 0, 0);
    }

    private void OnDisable()
    {
        fadeValue = 0;
        material.SetFloat("_Slider", fadeValue);
        blackPanel.color = new Color(0, 0, 0, 0);
    }

    IEnumerator FadeCorutine()
    {
        delta = (1 / timer) * Time.deltaTime;
        while (fadeValue < 1)
        {
            fadeValue += delta;
            if (fadeValue > 1)
                fadeValue = 1;
            material.SetFloat("_Slider", fadeValue);
            if (fadeValue < oldAlpha)
                blackPanel.color = new Color(0, 0, 0, fadeValue);
            else
                blackPanel.color = new Color(0, 0, 0, oldAlpha);
            yield return null;
        }
        yield return null;
    }
}