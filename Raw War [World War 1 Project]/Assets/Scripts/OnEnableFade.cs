using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableFade : MonoBehaviour
{
    public Material material;
    public float speed;
    public float value;
    public float maxValue;
    public float minValue;

    private void Start()
    {
        //material.SetFloat("_FadeAmount", 1);
    }

    private void OnEnable()
    {
        material.SetFloat("_FadeAmount", 1);
        value = 0f;
    }

    void Update()
    {
        if (gameObject != null)
        {
            float fade = Mathf.Lerp(maxValue, minValue, value / speed);
            value += Time.deltaTime;
            material.SetFloat("_FadeAmount", fade);
        }
    }
}
