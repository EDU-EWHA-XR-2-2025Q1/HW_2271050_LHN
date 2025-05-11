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
            DontDestroyOnLoad(gameObject); // �� �̵��ص� ������� ����
        }
        else
        {
            Destroy(gameObject); // �ߺ� ����
        }
    }
}
