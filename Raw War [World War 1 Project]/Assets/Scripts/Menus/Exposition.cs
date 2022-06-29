using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exposition : MonoBehaviour
{
    public int timer = 10;
    public bool ending = false;

    void Start()
    {
        StartCoroutine("Coroutine");
        
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            if (ending == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 27);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(timer);

        if(ending == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 27);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
