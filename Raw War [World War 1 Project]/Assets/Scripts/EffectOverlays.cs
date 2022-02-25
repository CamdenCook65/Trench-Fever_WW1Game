using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOverlays : MonoBehaviour
{
    //[11/12/21] [Friday, 3:56 PM]

    //This scripted is nested in the Character gameObject and houses all of the screenEffects that can
    //occur in the game. These effects will be referenced by other scripts, setting them active when
    //need be. The health effect, unlike the others listed, is activated by this script itself rather than
    //referenced by another script.


    public Health playerHealth;
    //public AmmoManager pistol;
    //public AmmoManager revolver;
    //public AmmoManager rifle;
    //public AmmoManager shotgun;
    //public AmmoManager SMG;
    //public AmmoManager LMG;
    //public AmmoManager Launcher;
    //public AmmoManager RocketGun;
    //public AmmoManager Flamethrower;

    public GameObject damagedEffect;
    public GameObject healedEffect;
    public GameObject pickupEffect;

    public AudioClip injured;
    public AudioClip ammoPickup;
    public AudioClip healthPickup;

    void Start()
    {
        damagedEffect.SetActive(false);
        healedEffect.SetActive(false);
        pickupEffect.SetActive(false);
    }

    private void Update()
    {
        if (GetComponent<AudioSource>() == null)
        {
            gameObject.AddComponent(typeof(AudioSource));
        }

        if (playerHealth.currentHealth == 4)
        {
            StartCoroutine("coroutine4");
            Debug.Log("Current Health: 4");
        }

        if (playerHealth.currentHealth == 3)
        {
            StartCoroutine("coroutine3");
            Debug.Log("Current Health: 3");
        }

        if (playerHealth.currentHealth == 2)
        {
            StartCoroutine("coroutine2");
            Debug.Log("Current Health: 2");
        }

        if (playerHealth.currentHealth == 1)
        {
            StartCoroutine("coroutine1");
            Debug.Log("Current Health: 1");
        }
    }

    IEnumerator coroutine4()
    {
        yield return new WaitForSeconds(0);

        if (playerHealth.currentHealth < 4)
        {
            Damaged();
        }
    }

    IEnumerator coroutine3()
    {
        yield return new WaitForSeconds(0);

        if (playerHealth.currentHealth < 3)
        {
            Damaged();
        }
    }

    IEnumerator coroutine2()
    {
        yield return new WaitForSeconds(0);

        if (playerHealth.currentHealth < 2)
        {
            Damaged();
        }
    }

    IEnumerator coroutine1()
    {
        yield return new WaitForSeconds(0);

        if (playerHealth.currentHealth < 1)
        {
            Damaged();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HealthKitA")
        {
            if (playerHealth.healthFull == false)
            {
                Healed();
            }
        }
    }

    public void Damaged()
    {
        damagedEffect.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(injured);

        Debug.Log("Damaged!");
    }

    public void Healed()
    {
        healedEffect.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(healthPickup);

        Debug.Log("Healed");
    }

    public void PickedUp()
    {
        pickupEffect.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(ammoPickup);

        Debug.Log("Ammo Acquired");
    }
}
