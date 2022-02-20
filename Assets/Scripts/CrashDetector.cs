using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField]
    float loadDelay = 1f;

    [SerializeField]
    ParticleSystem crashEffect;

    [SerializeField]
    AudioClip crashSFX;

    bool isCrashAlreadyRaised = false;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            FindObjectOfType<PlayerController>().DisableControl();
            crashEffect.Play();
            if (!isCrashAlreadyRaised)
            {
                GetComponent<AudioSource>().PlayOneShot(crashSFX);
                isCrashAlreadyRaised = true;
            }
            Invoke("ReloadScene", loadDelay);
        }

    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
