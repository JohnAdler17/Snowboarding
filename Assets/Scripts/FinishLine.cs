using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float reloadTime = 2f;
    [SerializeField] ParticleSystem finishEffect;
    bool hasCrossed = false;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && !hasCrossed) {
            hasCrossed = true;
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", reloadTime);
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
