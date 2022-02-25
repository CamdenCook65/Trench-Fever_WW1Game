using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCloud : MonoBehaviour
{
    //[11/12/21] [Friday, 4:05 PM]

    //The GasCloud script will, of course, be located on the gasCloud gameObjects present in the world. 
    //This script wil control when the gasEffect and gasDamaged effect overlays nested in the HUD will be 
    //setActive and will be incharge of killing the player if they are exposed to the gas without a GasMask.
    //The gasCloud will check whether a gameObject with the tag "Player" has entered the cloud. If it has,
    //then the script will check if the Player is wearing a gasMask. If so, then the gasEffect is setActive
    //and they will not be damaged. If not, then the gasDamaged effect is SetActive and a Coroutine is 
    //started. If the player is inside of the gasCloud for longer than the designated killTime (with lengths
    //varying depending on the gasType), then they will die from suffication. The GasDeath is referenced 
    //from the Player's Health script.


    public bool inGas;
    public GameObject gasEffect;
    public GameObject gasDamaged;
    public Material effect;
    public Material damaged;
    public GasMask reference;
    public Health playerHealth;
    public float killTime = 3f;
    public AudioSource choking;
    public AudioSource playerGassed;
    public AudioClip chokingSFX;

    private void Start()
    {
        gasEffect.SetActive(false);
        //gasDamaged.SetActive(false);
        inGas = false;
    }

    private void Update()
    {
        if (GetComponent<AudioSource>() == null)
        {
            gameObject.AddComponent(typeof(AudioSource));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (reference.masked == true)
            {
                gasEffect.SetActive(true);
                //gasDamaged.SetActive(false);

                StopCoroutine("ExampleCoroutine");
                choking.Pause();
            }

            if (reference.masked == false)
            {
                gasEffect.SetActive(false);
                //gasDamaged.SetActive(true);

                StartCoroutine("ExampleCoroutine");
                //GetComponent<AudioSource>().PlayOneShot(chokingSFX);
                choking.Play();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (reference.masked == true)
            {
                gasEffect.SetActive(true);
                //gasDamaged.SetActive(false);

                StopCoroutine("ExampleCoroutine");
                choking.Pause();
            }

            if (reference.masked == false)
            {
                gasEffect.SetActive(false);
                //gasDamaged.SetActive(true);

                StartCoroutine( "ExampleCoroutine" );
                choking.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gasEffect.SetActive(false);
            //gasDamaged.SetActive(false);

            StopCoroutine( "ExampleCoroutine" );
            choking.Pause();
        }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(killTime);
        while (true)
        {
            Gassed();
        }
    }

    void Gassed()
    {
        playerHealth.Gassed();
        playerGassed.Play();
        choking.Pause();
    }
}
