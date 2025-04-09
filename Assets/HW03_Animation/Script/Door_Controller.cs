using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Controller : MonoBehaviour
{
    public Animator Animator;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 toPlayer = other.transform.position - transform.position;
            float dot = Vector3.Dot(transform.forward, toPlayer);

            if (dot >= 0)
            {
                // 바깥쪽에서 접근한 경우 → 실내를 향해 문 열림
                Animator.SetInteger("status", 2);
            }
            else
            {
                // 안쪽에서 접근한 경우 → 실외를 향해 문 열림
                Animator.SetInteger("status", 1);
            }
        }
    }


    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 toPlayer = other.transform.position - transform.position;
            float dot = Vector3.Dot(transform.forward, toPlayer);

            if (dot >= 0)
            {
                // 바깥쪽에서 나간 경우 → 실외 방향으로 문 닫힘
                Animator.SetInteger("status", 3);
            }
            else
            {
                // 안쪽에서 나간 경우 → 실내 방향으로 문 닫힘
                Animator.SetInteger("status", 4);
            }
        }
    }

}
