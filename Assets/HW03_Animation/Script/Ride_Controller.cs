using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ride_Controller : MonoBehaviour
{
    public Animator animator;
    public AudioSource vehicleSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Vehicle")
        {
            transform.SetParent(other.transform);
            transform.position = other.transform.position + Vector3.up * 2f;

            animator.speed = 1f;

            if (animator.GetInteger("room")==1)
            {
                animator.SetInteger("vehicle_status", 1);
            }
            else
            {
                animator.SetInteger("vehicle_status", 2);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Vehicle")
        {
            transform.SetParent(null);
            animator.speed = 0f;
        }
    }

}
