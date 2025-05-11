using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW04_Pick_Controller : MonoBehaviour
{
    int pickCount = 0;
    public GameObject UI;

    public void Increase_PickCount()
    {
        // GameManager에서 기존 값 가져와 +1
        HW04_GameManager.Instance.PickCount++;
        int pickCount = HW04_GameManager.Instance.PickCount;

        print($"pick count: {pickCount}");

        UI.GetComponent<HW04_UI_Controller>().Display_PickCounts(pickCount);
    }
}
 