using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIBehavior
{
    public class RatManager : MonoBehaviour
    {
        //[1/6/22] [Thursday, 4:18 PM]

        //This is the Rat Manager script, which is in charge of setting different Trench Rat sprites active 
        //depending on which Enemy AI Behaviors Animation is currenlty active. This script is esentially 
        //a watered down version fo the SpriteManager script that is suited just for the Rat enemies. 
        //Attempts to use the normal Sprite Manager were unsuccessful, so this custom one is used in place
        //and everything is currently working as intended. As with the last script, this is basically an
        //ellaborate if/and statement. You can check out the Sprite Manager to gain a more in-depth 
        //understanding as to how this system functions.


        public AIBehaviors Enemy;

        public GameObject walkAnim;
        public GameObject fireAnim;
        public GameObject deadAnim;
        public bool GasKillable;
        public bool FlameResistant;
        public Transform enemyPosition;
        public GameObject gassedDeath;
        public GameObject fireDeath;


        private void Start()
        {
            walkAnim.SetActive(true);
            fireAnim.SetActive(false);
            deadAnim.SetActive(false);
        }


        void Update()
        {
            if (Enemy.currentState.name == "Seek")
            {
                walkAnim.SetActive(true);
            }
            else
            {
                walkAnim.SetActive(false);
            }





            if (Enemy.currentState.name == "Attack")
            {
                fireAnim.SetActive(true);
            }
            else
            {
                fireAnim.SetActive(false);
            }





            if (Enemy.currentState.name == "Dead")
            {
                deadAnim.SetActive(true);
            }
            else
            {
                deadAnim.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Chl_GasCloud" && GasKillable == true)
            {
                StartCoroutine("KillTimer");
            }

            if (other.tag == "Mus_GasCloud" && GasKillable == true)
            {
                StartCoroutine("KillTimer");
            }

            if (other.tag == "Phs_GasCloud" && GasKillable == true)
            {
                StartCoroutine("KillTimer");
            }

            if (other.tag == "FlameResidue" && FlameResistant == false)
            {
                StartCoroutine("FireTimer");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "GasCloud")
            {
                StopCoroutine("KillTimer");
            }
        }

        IEnumerator KillTimer()
        {
            yield return new WaitForSeconds(1f);

            Instantiate(gassedDeath, enemyPosition.position, enemyPosition.rotation);
            Destroy(gameObject);

            //Debug.Log("Gassed too Death!");
        }

        IEnumerator FireTimer()
        {
            yield return new WaitForSeconds(0.1f);

            Instantiate(fireDeath, enemyPosition.position, enemyPosition.rotation);
            Destroy(gameObject);
        }
    }
}
