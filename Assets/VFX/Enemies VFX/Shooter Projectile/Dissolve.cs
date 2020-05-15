using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    Renderer render;
    private float dissolveValue = 1;
    public float dissolveVelocityMultiplier = 1;
    public float dissolveLimit = 0.6f;
    void Start()
    {
        //render = GetComponent<Renderer>();
        //render.material.SetFloat("_DissolveScale", 1f);
        //dissolveValue = 1;
    }

    private void OnEnable()
    {
        render = GetComponent<Renderer>();
        render.material.SetFloat("_DissolveScale", 1f);
        dissolveValue = 1;
    }

    void Update()
    {
        if (render.material.GetFloat("_DissolveScale") > dissolveLimit)
        {
            dissolveValue -= Time.deltaTime * dissolveVelocityMultiplier;
            render.material.SetFloat("_DissolveScale", dissolveValue);
        }
    }
}
