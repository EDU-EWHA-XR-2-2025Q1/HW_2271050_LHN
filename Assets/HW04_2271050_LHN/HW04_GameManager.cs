using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW04_GameManager : MonoBehaviour
{
    public static HW04_GameManager Instance;

    public int PickCount = 0;
    public int PutCount = 0;

    public List<string> RemainingItemNames = new List<string>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 이동해도 사라지지 않음
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }
}
