using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.UI;
using TMPro;

public class HW04_Put_Controller : MonoBehaviour
{
    public GameObject TargetObjectToThrow;
    public Transform ARCamera;                     // Vuforia AR 카메라
    public Button FireButton;                      // 발사 버튼
    public GameObject UI;


    void Start()
    {
        // GameManager에서 PickCount 가져옴
        UI.GetComponent<HW04_UI_Controller>().Display_PickCounts(HW04_GameManager.Instance.PickCount);

        FireButton.onClick.AddListener(TryThrow);
        UpdateFireButtonState();
    }

    void Update()
    {
        // 매 프레임마다 버튼 활성화 상태 갱신
        UpdateFireButtonState();
    }


    void TryThrow()
    {
        int pickCount = HW04_GameManager.Instance.PickCount;
        if (pickCount > 0)
        {
            Throw();
            HW04_GameManager.Instance.PickCount--;
            UI.GetComponent<HW04_UI_Controller>().Display_PickCounts(HW04_GameManager.Instance.PickCount);
        }
    }

    void Throw()
    {
        // 발사 위치 = AR 카메라 앞쪽
        Vector3 pos = ARCamera.position + ARCamera.forward * 0.1f;

        // 랜덤 회전
        Quaternion rot = Quaternion.Euler(
            Random.Range(0f, 360f),
            Random.Range(0f, 360f),
            Random.Range(0f, 360f)
        );

        GameObject Clone = Instantiate(TargetObjectToThrow, pos, rot);
        Clone.SetActive(true);


        Clone.GetComponent<Collider>().isTrigger = false;
        Clone.GetComponent<Rigidbody>().useGravity = true;

        Clone.GetComponent<Rigidbody>().AddForce(ARCamera.forward * 400f);

        // 3초 후 제거
        Destroy(Clone, 3f);
    }


    void UpdateFireButtonState()
    {
        int pickCount = UI.GetComponent<HW04_UI_Controller>().GetPickCounts();
        FireButton.interactable = (pickCount > 0);
    }
}
