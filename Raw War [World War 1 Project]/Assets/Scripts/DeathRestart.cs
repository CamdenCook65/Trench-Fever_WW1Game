using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathRestart : MonoBehaviour
{
    public bool Finale = false;
    public int time = 3;

    void Start()
    {
        StartCoroutine("Coroutine");
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(time);

        if (Finale == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Finale == true)
        {
            SceneManager.LoadScene(27);
        }
    }
}
