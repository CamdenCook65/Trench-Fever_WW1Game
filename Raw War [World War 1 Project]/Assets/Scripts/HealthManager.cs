using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
	//[11/12/21] [Friday, 4:32 PM]

	//The HealthManager script, located in the PlayerManager gameObject, controls the Heart and Shield 
	//sprites located on the player's HUD, ensuring that they accurately represent the player's health
	//value. Referencing the player's Health script, this script sets certain sprites Active or Inactive
	//depending on what the current health value is.


	public Health player;

	public AudioSource gasMask;

    public int heartValue = 1;
    public int shield1Value = 2;
    public int shield2Value = 3;
    public int shield3Value = 4;
	public int deathValue = 0;

    public GameObject heart_Full;                       
    public GameObject heart_Empty;

    public GameObject Shield1_Full;
    public GameObject Shield1_Empty;

    public GameObject Shield2_Full;
    public GameObject Shield2_Empty;

    public GameObject Shield3_Full;
    public GameObject Shield3_Empty;


	private void Start()
	{
		gasMask.GetComponent<AudioSource>();
	}

	void Update()
    {
		//HUD health icons set active/inactive based on currentHealth value
		//Restructure in the future if it causes system and preformance problems
		if (player.currentHealth == heartValue)
		{
			heart_Full.SetActive(true);
			heart_Empty.SetActive(false);

			Shield1_Full.SetActive(false);
			Shield1_Empty.SetActive(true);

			Shield2_Full.SetActive(false);
			Shield2_Empty.SetActive(true);

			Shield3_Full.SetActive(false);
			Shield3_Empty.SetActive(true);
		}

		if (player.currentHealth == shield1Value)
		{
			heart_Full.SetActive(true);
			heart_Empty.SetActive(false);

			Shield1_Full.SetActive(true);
			Shield1_Empty.SetActive(false);

			Shield2_Full.SetActive(false);
			Shield2_Empty.SetActive(true);

			Shield3_Full.SetActive(false);
			Shield3_Empty.SetActive(true);
		}

		if (player.currentHealth == shield2Value)
		{
			heart_Full.SetActive(true);
			heart_Empty.SetActive(false);

			Shield1_Full.SetActive(true);
			Shield1_Empty.SetActive(false);

			Shield2_Full.SetActive(true);
			Shield2_Empty.SetActive(false);

			Shield3_Full.SetActive(false);
			Shield3_Empty.SetActive(true);
		}

		if (player.currentHealth == shield3Value)
		{
			heart_Full.SetActive(true);
			heart_Empty.SetActive(false);

			Shield1_Full.SetActive(true);
			Shield1_Empty.SetActive(false);

			Shield2_Full.SetActive(true);
			Shield2_Empty.SetActive(false);

			Shield3_Full.SetActive(true);
			Shield3_Empty.SetActive(false);
		}

		if (player.currentHealth <= deathValue)
		{
			heart_Full.SetActive(false);
			heart_Empty.SetActive(true);

			Shield1_Full.SetActive(false);
			Shield1_Empty.SetActive(true);

			Shield2_Full.SetActive(false);
			Shield2_Empty.SetActive(true);

			Shield3_Full.SetActive(false);
			Shield3_Empty.SetActive(true);

			gasMask.mute = true;
		}
	}

}
