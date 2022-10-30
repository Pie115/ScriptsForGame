using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSphere : MonoBehaviour
{
    public AudioClip KillPlayer;

    private AudioSource rakeAudio;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Guy"))
        {

            rakeAudio.PlayOneShot(KillPlayer, 2.0f);
            Application.LoadLevel(Application.loadedLevel);

        }
    }
}
