using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW04_Instantiate_Gameobject : MonoBehaviour
{
    public GameObject Target;       // Step02 (복제할 원본) 
    public int cloneCount = 10;     // Step02 (복제할 수량) 

    void Start()
    {
        Instantiate_GameObject();   // Step02 (아이템 복제) 
    }

    // Step02: 게임 오브젝트(아이템)을 복제하는 함수 
    void Instantiate_GameObject()
    {
        int picked = HW04_GameManager.Instance != null ? HW04_GameManager.Instance.PickCount : 0;
        int remaining = Mathf.Max(0, cloneCount - picked);
        for (int i = 0; i < remaining; i++)
        {
            // 복제한 클론의 랜덤한 position 
            Vector3 randomSphere = Random.insideUnitSphere * 0.1f;
            randomSphere.y = 0.03f;
            Vector3 randomPos = randomSphere;

            // 복제한 클론의 랜덤한 rotation 
            float randomAngle = Random.value * 360f;
            Quaternion randomRot = Quaternion.Euler(0, randomAngle, 0);

            // 클론으로 복제 
            GameObject Clone = Instantiate(Target, randomPos, randomRot);

            // 클론 활성화 
            Clone.SetActive(true);

            // 클론의 이름 설정 
            Clone.gameObject.name = "Clone-" + string.Format("{0:D4}", i);

            // 클론의 부모 설정 
            Clone.transform.SetParent(transform);

        }

    }
}
