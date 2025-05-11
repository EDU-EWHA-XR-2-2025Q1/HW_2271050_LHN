using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.UI;
using TMPro;

public class HW04_Put_Controller : MonoBehaviour
{
    public GameObject TargetObjectToThrow;
    public Transform ARCamera;                     // Vuforia AR ī�޶�
    public Button FireButton;                      // �߻� ��ư
    public GameObject UI;


    void Start()
    {
        // GameManager���� PickCount ������
        UI.GetComponent<HW04_UI_Controller>().Display_PickCounts(HW04_GameManager.Instance.PickCount);

        FireButton.onClick.AddListener(TryThrow);
        UpdateFireButtonState();
    }

    void Update()
    {
        // �� �����Ӹ��� ��ư Ȱ��ȭ ���� ����
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
        // �߻� ��ġ = AR ī�޶� ����
        Vector3 pos = ARCamera.position + ARCamera.forward * 0.1f;

        // ���� ȸ��
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

        // 3�� �� ����
        Destroy(Clone, 3f);
    }


    void UpdateFireButtonState()
    {
        int pickCount = UI.GetComponent<HW04_UI_Controller>().GetPickCounts();
        FireButton.interactable = (pickCount > 0);
    }
}
