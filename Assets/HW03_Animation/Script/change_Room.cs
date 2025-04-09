using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_Room : MonoBehaviour
{
    public Animator animator;
    public void SetRoomToRoom1()
    {
        animator.SetInteger("room", 1);
        Debug.Log("room1");
    }

    public void SetRoomToRoom2()
    {
        animator.SetInteger("room", 2);
        Debug.Log("room2");
    }
}
