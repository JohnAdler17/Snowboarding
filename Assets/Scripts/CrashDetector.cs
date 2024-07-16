using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadTime = 1f;
    [SerializeField] ParticleSystem deadEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground" && !hasCrashed) {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            deadEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", reloadTime);
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
