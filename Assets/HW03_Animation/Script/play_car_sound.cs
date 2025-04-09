using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_car_sound : MonoBehaviour
{
    public AudioSource engineSound; // ���� ���� (����)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (engineSound != null && !engineSound.isPlaying)
            {
                engineSound.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (engineSound != null && engineSound.isPlaying)
            {
                engineSound.Stop();
            }
        }
    }
}
