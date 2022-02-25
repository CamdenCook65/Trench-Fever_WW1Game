using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UI;
using UnityEngine;

public class GasMask : MonoBehaviour
{
    //[11/12/21] [Friday, 4:10 PM]

    //Nested on the Character gameObject, the GasMask script controls what happens when the player activates
    //their gasMask. When the Player presses G on their keyboard, their gasMask will be setActive. When the
    //gasMask is active, they will move at a slower pace and won't be able to die from gasClouds. A sprite
    //known as the maskOverlay will be setActive, obscurring most of the player's view. When inside of a 
    //gasCloud, the gasEffect overlay will be setActive while the gasDamaged overlay isn't. Custom sound
    //effects will play when the mask is activated, in use and deactivated. The boolean "masked" is
    //referenced by other scripts to determine if the player is using the gasMask.
    

    public Health playerHealth;
    public FirstPersonCharacter character;
    public bool puttingMaskOn;
    public bool pullingMaskOff;
    public bool masked;
    public bool InsideCloud_Chl;
    public bool InsideCloud_Mus;
    public bool InsideCloud_Phs;
    public GameObject maskOverlay;
    //public float equipTime;
    public ShaderAdjustment Chl_shaderScript;
    public ShaderAdjustment Mus_shaderScript;
    public ShaderAdjustment Phs_shaderScript;
    public AudioClip maskOn;
    public AudioClip maskOff;
    public AudioClip choking;
    public AudioClip takingOn;
    public AudioClip takingOff;
    public AudioSource sufficating;
    public AudioSource deepBreath;

    private void Start()
    {
        //maskOverlay.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Chl_GasCloud")
        {
            InsideCloud_Chl = true;

            if (masked == false)
            {
                sufficating.Play();
            }
        }

        if (other.tag == "Mus_GasCloud")
        {
            InsideCloud_Mus = true;

            if (masked == false)
            {
                sufficating.Play();
            }
        }

        if (other.tag == "Phs_GasCloud")
        {
            InsideCloud_Phs = true;

            if (masked == false)
            {
                sufficating.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Chl_GasCloud")
        {
            InsideCloud_Chl = false;
        }

        if (other.tag == "Mus_GasCloud")
        {
            InsideCloud_Mus = false;
        }

        if (other.tag == "Phs_GasCloud")
        {
            InsideCloud_Phs = false;
        }
    }

    void Update()
    {
        if (InsideCloud_Chl == true && masked == false)
        {
            Chl_shaderScript.inGas = true;
        }

        if (InsideCloud_Mus == true && masked == false)
        {
            Mus_shaderScript.inGas = true;
        }

        if (InsideCloud_Phs == true && masked == false)
        {
            Phs_shaderScript.inGas = true;
        }

        if (InsideCloud_Chl == false)
        {
            Chl_shaderScript.inGas = false;
        }

        if (InsideCloud_Mus == false)
        {
            Mus_shaderScript.inGas = false;
        }

        if (InsideCloud_Phs == false)
        {
            Phs_shaderScript.inGas = false;
        }



        if (GetComponent<AudioSource>() == null)
        {
            gameObject.AddComponent(typeof(AudioSource));
        }



        if (Input.GetKeyDown(KeyCode.G) && masked == false && pullingMaskOff == false && puttingMaskOn == false)
        {
            puttingMaskOn = true;
            StartCoroutine("MaskingUp");
            GetComponent<AudioSource>().PlayOneShot(takingOn);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.G) && puttingMaskOn == false && pullingMaskOff == false)
            {
                pullingMaskOff = true;
                StartCoroutine("MaskingOff");
                GetComponent<AudioSource>().PlayOneShot(takingOff);
            }
        }




        if (masked == true)
        {
            maskOverlay.SetActive(true);
            character.maskedMovement = true;
            puttingMaskOn = false;
            //pullingMaskOff = false;
            sufficating.Stop();
        }
        else
        {
            maskOverlay.SetActive(false);
            character.maskedMovement = false;
        }

        if (playerHealth.dead == true)
        {
            //Do Something
        }
    }

    IEnumerator MaskingUp()
    {
        yield return new WaitForSeconds(2f);

        MaskOn();
    }

    IEnumerator MaskingOff()
    {
        yield return new WaitForSeconds(1f);

        MaskOff();
    }


    void MaskOn()
    {
        masked = true;
        puttingMaskOn = false;
        GetComponent<AudioSource>().PlayOneShot(maskOn);
    }


    void MaskOff()
    {
        masked = false;
        puttingMaskOn = false;
        pullingMaskOff = false;
        GetComponent<AudioSource>().PlayOneShot(maskOff);
        if (InsideCloud_Chl == false)
        {
            deepBreath.Play();
        }

        if (InsideCloud_Mus == false)
        {
            deepBreath.Play();
        }

        if (InsideCloud_Phs == false)
        {
            deepBreath.Play();
        }



        if (InsideCloud_Chl == true)
        {
            sufficating.Play();
        }

        if (InsideCloud_Mus == true)
        {
            sufficating.Play();
        }

        if (InsideCloud_Phs == true)
        {
            sufficating.Play();
        }
    }
}
