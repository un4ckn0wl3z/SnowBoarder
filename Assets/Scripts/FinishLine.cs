using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField]
    float loadDelay = 0.5f;

    [SerializeField]
    ParticleSystem finishLineEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            finishLineEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", loadDelay);

        }

    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
