using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW04_Instantiate_Gameobject : MonoBehaviour
{
    public GameObject Target;       // Step02 (������ ����) 
    public int cloneCount = 10;     // Step02 (������ ����) 

    void Start()
    {
        Instantiate_GameObject();   // Step02 (������ ����) 
    }

    // Step02: ���� ������Ʈ(������)�� �����ϴ� �Լ� 
    void Instantiate_GameObject()
    {
        int picked = HW04_GameManager.Instance != null ? HW04_GameManager.Instance.PickCount : 0;
        int remaining = Mathf.Max(0, cloneCount - picked);
        for (int i = 0; i < remaining; i++)
        {
            // ������ Ŭ���� ������ position 
            Vector3 randomSphere = Random.insideUnitSphere * 0.1f;
            randomSphere.y = 0.03f;
            Vector3 randomPos = randomSphere;

            // ������ Ŭ���� ������ rotation 
            float randomAngle = Random.value * 360f;
            Quaternion randomRot = Quaternion.Euler(0, randomAngle, 0);

            // Ŭ������ ���� 
            GameObject Clone = Instantiate(Target, randomPos, randomRot);

            // Ŭ�� Ȱ��ȭ 
            Clone.SetActive(true);

            // Ŭ���� �̸� ���� 
            Clone.gameObject.name = "Clone-" + string.Format("{0:D4}", i);

            // Ŭ���� �θ� ���� 
            Clone.transform.SetParent(transform);

        }

    }
}
