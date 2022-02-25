using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIBehavior
{
    public class SpriteManager : MonoBehaviour
    {
        //[12/27/21] [Monday, 11:27 PM]

        //This is the Sprite Manager script, which is in charge of setting different sprites active depending
        //on which Enemy AI Behaviors Animation is currenlty active. When a particular animation is active,
        //then a gameObject with the corresponding Sprite Animation will be setActive. This gameObject will
        //be set back to Inactive when another animation begins playing. There really isn't much to this, so
        //I'll just leave with it, it's just another if/else script that gets things done.


        public AIBehaviors Enemy;

        public GameObject idleAnim;
        public GameObject walkAnim;
        public GameObject fleeAnim;
        public GameObject backAnim;
        public GameObject hurtAnim;
        public GameObject fireAnim;
        public GameObject deadAnim;
        public GameObject gassedDeath;
        public GameObject bleedDeath;
        public GameObject fireDeath;
        public Collider playerCollider;
        public Transform enemyPosition;
        public bool GasKillable;
        public bool FlameResistant;

        private void Start()
        {
            idleAnim.SetActive(true);
            walkAnim.SetActive(false);
            fleeAnim.SetActive(false);
            backAnim.SetActive(false);
            hurtAnim.SetActive(false);
            fireAnim.SetActive(false);
            deadAnim.SetActive(false);

            playerCollider = GetComponent<Collider>();
        }


        void Update()
        {

            if (Enemy.currentState.name == "Idle")
            {
                idleAnim.SetActive(true);
            }
            else
            {
                idleAnim.SetActive(false);
                //Destroy(idleAnim);
            }





            if (Enemy.currentState.name == "Seek")
            {
                walkAnim.SetActive(true);
            }
            else
            {
                walkAnim.SetActive(false);
                //Destroy(walkAnim);
            }





            if (Enemy.currentState.name == "Fleeing")
            {
                fleeAnim.SetActive(true);
            }
            else
            {
                fleeAnim.SetActive(false);
                //Destroy(walkAnim);
            }





            if (Enemy.currentState.name == "Step Back")
            {
                backAnim.SetActive(true);
            }
            else
            {
                backAnim.SetActive(false);
                //Destroy(backAnim);
            }





            if (Enemy.currentState.name == "Got Hit")
            {
                hurtAnim.SetActive(true);
            }
            else
            {
                hurtAnim.SetActive(false);
                //Destroy(hurtAnim);
            }





            if (Enemy.currentState.name == "Attack")
            {
                fireAnim.SetActive(true);
            }
            else
            {
                fireAnim.SetActive(false);
                //Destroy(fireAnim);
            }





            if (Enemy.currentState.name == "Dead")
            {
                deadAnim.SetActive(true);
                StartCoroutine("Coroutine");
            }
            else
            {
                deadAnim.SetActive(false);
                //Destroy(deadAnim);
            }
        }



        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(4);

            Destroy(gameObject);
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

            if (other.tag == "BarbedWire")
            {
                StartCoroutine("WireTimer");
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

        IEnumerator WireTimer()
        {
            yield return new WaitForSeconds(0.5f);

            Instantiate(bleedDeath, enemyPosition.position, enemyPosition.rotation);
            Destroy(gameObject);
        }

        IEnumerator FireTimer()
        {
            yield return new WaitForSeconds(0.1f);

            Instantiate(fireDeath, enemyPosition.position, enemyPosition.rotation);
            Destroy(gameObject);
        }
    }
}
