using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW04_Put_Repo_Controller : MonoBehaviour
{
    public Transform imageTarget;  // ���� Ÿ�� ������Ʈ
    public float radius;    // �ʹ� ũ�� ī�޶� ������ ����
    public GameObject UI_Controller;

    void Start()
    {
        StartCoroutine(MoveWithinTargetArea());
    }
    IEnumerator MoveWithinTargetArea()
    {
        while (true)
        {
            float waitTime = Random.Range(0.5f, 1.0f);
            yield return new WaitForSeconds(waitTime);

            // Ÿ�� ���� local ��ǥ�� �������� �����̰� ����
            Vector3 localOffset = new Vector3(0f,0f, Random.Range(-radius, radius));

            // Ÿ�� �������� �����̰�,ī�޶� �þ߿��� �־����� �ʰ�
            transform.position = imageTarget.TransformPoint(localOffset);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item")
        {
            print("touch");
            UI_Controller.GetComponent<HW04_UI_Controller>().Display_PutCounts();
            Destroy(other.gameObject);
        }
    }
}
