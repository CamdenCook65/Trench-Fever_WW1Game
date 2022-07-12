/// <summary>
/// Health.cs
/// Author: MutantGopher
/// This is a sample health script.  If you use a different script for health,
/// make sure that it is called "Health".  If it is not, you may need to edit code
/// referencing the Health component from other scripts
/// </summary>

using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	public bool canDie = true;                  // Whether or not this health can die

	public bool isFinale = false;
	
	public int startingHealth = 1;				// The amount of health to start with
	public int maxHealth = 1;					// The maximum amount of health
	public int currentHealth;					// The current ammount of health
	public int healthBonusA;

	public bool healthFull = false;						//CUSTOM: determines wheather the player's currentHealth = maxHealth

	public bool replaceWhenDead = false;		// Whether or not a dead replacement should be instantiated.  (Useful for breaking/shattering/exploding effects)
	public GameObject deadReplacement;			// The prefab to instantiate when this GameObject dies
	public bool makeExplosion = false;			// Whether or not an explosion prefab should be instantiated
	public GameObject explosion;                // The explosion prefab to be instantiated

	public GameObject gasDeath;
	public GameObject bleedDeath;
	public GameObject shootDeath;
	public GameObject drownDeath;
	public GameObject burnDeath;

	public bool isPlayer = false;				// Whether or not this health is the player
	public GameObject deathCam;                 // The camera to activate when the player dies

	public GameObject music;

	public bool dead = false;                  // Used to make sure the Die() function isn't called twice

	// Use this for initialization
	void Start()
	{
		// Initialize the currentHealth variable to the value specified by the user in startingHealth
		currentHealth = startingHealth;
	}

	private void Update()
	{
		if (currentHealth == maxHealth)
		{
			healthFull = true;
		}
		else
		{
			healthFull = false;
		}
	}

	void OnGUI()
	{
		if (isPlayer == true)
		{
			//GUI.Label(new Rect(10, Screen.height - 50, 100, 20), "Health: " + currentHealth);
		}
	}

	//Detects if the player has collided with a health kit
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "HealthKitA")
		{
			currentHealth += healthBonusA;
			if (currentHealth > maxHealth)
			{
				currentHealth = maxHealth;
			}
		}

		if (other.tag == "FlameResidue")
		{
			StartCoroutine("Coroutine");
		}

	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "FlameResidue")
		{
			StopCoroutine("Coroutine");
		}
	}

	IEnumerator Coroutine()
	{
		yield return new WaitForSeconds(0.2f);

		Burn();
	}

	public void ChangeHealth(int amount)
	{
		// Change the health by the amount specified in the amount variable
		currentHealth += amount;

		// If the health runs out, then Die.
		if (currentHealth <= 0 && !dead && canDie)
			Die();

		// Make sure that the health never exceeds the maximum health
		else if (currentHealth > maxHealth)
			currentHealth = maxHealth;
	}

	public void Die()
	{
		// This GameObject is officially dead.  This is used to make sure the Die() function isn't called again
		dead = true;

		// Make death effects
		if (replaceWhenDead)
			Instantiate(deadReplacement, transform.position, transform.rotation);
		if (makeExplosion)
			Instantiate(explosion, transform.position, transform.rotation);

		if (isPlayer && deathCam != null)
		{
			deathCam.SetActive(true);
		}

		if(isFinale == false && isPlayer == true)
        {
			GameObject music = GameObject.FindGameObjectWithTag("LevelMusic");
			GameObject.Destroy(music);
		}

		// Remove this GameObject from the scene
		Destroy(gameObject);
	}

	public void Gassed()
	{
		dead = true;

		Instantiate(gasDeath, transform.position, transform.rotation);

		if (isPlayer && deathCam != null)
		{
			deathCam.SetActive(true);
		}

		if (isFinale == false && isPlayer == true)
		{
			GameObject music = GameObject.FindGameObjectWithTag("LevelMusic");
			GameObject.Destroy(music);
		}

		Destroy(gameObject);
	}

	public void BleedToDeath()
	{
		dead = true;

		Instantiate(bleedDeath, transform.position, transform.rotation);

		if (isPlayer && deathCam != null)
		{
			deathCam.SetActive(true);
		}

		if (isFinale == false && isPlayer == true)
		{
			GameObject music = GameObject.FindGameObjectWithTag("LevelMusic");
			GameObject.Destroy(music);
		}

		Destroy(gameObject);
	}

	public void Drown()
	{
		dead = true;

		Instantiate(drownDeath, transform.position, transform.rotation);

		if (isPlayer && deathCam != null)
		{
			deathCam.SetActive(true);
		}

		if (isFinale == false && isPlayer == true)
		{
			GameObject music = GameObject.FindGameObjectWithTag("LevelMusic");
			GameObject.Destroy(music);
		}

		Destroy(gameObject);
	}

	public void Burn()
	{
		dead = true;

		Instantiate(burnDeath, transform.position, transform.rotation);

		if (isPlayer && deathCam != null)
		{
			deathCam.SetActive(true);
		}

		if (isFinale == false && isPlayer == true)
		{
			GameObject music = GameObject.FindGameObjectWithTag("LevelMusic");
			GameObject.Destroy(music);
		}

		Destroy(gameObject);
	}
}
