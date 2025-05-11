using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW04_Put_Repo_Controller : MonoBehaviour
{
    public Transform imageTarget;  // 기준 타겟 오브젝트
    public float radius;    // 너무 크면 카메라 밖으로 나감
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

            // 타겟 기준 local 좌표계 내에서만 움직이게 제한
            Vector3 localOffset = new Vector3(0f,0f, Random.Range(-radius, radius));

            // 타겟 기준으로 움직이고,카메라 시야에서 멀어지지 않게
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
