using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderAdjustment : MonoBehaviour
{
    //[2/1/22] [Tuesday, 11:58 PM]

    //This basic shader script, which can pretty much be nested anywhere, is specifically used to adjust
    //the Fade amount in the Custom "AllInOne" Shader. If the boolean inGas is true (determined by another
    //script), then the associated material will begin fading in. If the inGas bool is false, then the 
    //material will begin fading out, reversing the effect. Because of the structure of this script, being
    //originally intended for simply getting a GasEffect overlay to fade in and out, it would be difficult 
    //to get this to apply to other areas of the project. However, it will be determined in the future
    //if I need to reuse this code for anything else!


    public Material material;
    public float speed;
    public float value;
    public float maxValue;
    public float minValue;
    public bool inGas;

    private void Start()
    {
        material.SetFloat("_FadeAmount", 1);
    }

    void Update()
    {
        if (inGas == true)
        {
            float fade = Mathf.Lerp(maxValue, minValue, value / speed);
            value += Time.deltaTime;
            material.SetFloat("_FadeAmount", fade);
        }

        if (inGas == false && value >= 0)
        {
            float fade = Mathf.Lerp(maxValue, minValue, value / speed);
            value -= Time.deltaTime;
            material.SetFloat("_FadeAmount", fade);
            StartCoroutine("Coroutine");
        }
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(3f);

        //value = 0;
    }
}
