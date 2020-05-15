using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    Renderer render;
    private float dissolveProgress = 1;
    public float dissolveVelocityMultiplier = 1;
    void Start()
    {
        //render = GetComponent<Renderer>();
        //render.material.SetFloat("_DissolveScale", 1f);
        //dissolveProgress = 1;
    }

    private void OnEnable()
    {
        render = GetComponent<Renderer>();
        render.material.SetFloat("_DissolveScale", 1f);
        dissolveProgress = 1;
    }

    void Update()
    {
        if (render.material.GetFloat("_DissolveScale") > 0)
        {
            dissolveProgress -= Time.deltaTime * dissolveVelocityMultiplier;
            render.material.SetFloat("_DissolveScale", dissolveProgress);
        }
    }
}
