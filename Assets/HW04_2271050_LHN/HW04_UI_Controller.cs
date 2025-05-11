using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HW04_UI_Controller : MonoBehaviour
{
    public TMP_Text PickCounts;
    public TMP_Text PutCounts;

    void Start()
    {
        int savedPick = HW04_GameManager.Instance != null ? HW04_GameManager.Instance.PickCount : 0;
        int savedPut = HW04_GameManager.Instance != null ? HW04_GameManager.Instance.PutCount : 0;

        Display_PickCounts(savedPick);
        Display_PutCounts(savedPut);
    }


    public void Display_PickCounts(int count)
    {
        PickCounts.text = count.ToString();
    }

    public void Display_PutCounts()
    {
        int lastPutCount = int.Parse(PutCounts.text);
        int currentPutCount = lastPutCount + 1;
        PutCounts.text = currentPutCount.ToString();

        HW04_GameManager.Instance.PutCount = currentPutCount;
    }

    public void Display_PutCounts(int count)
    {
        PutCounts.text = count.ToString();
    }

    public void Decrease_PickCounts()
    {
        int lastPickCount = int.Parse(PickCounts.text);
        int currentPickCount = lastPickCount - 1;
        PickCounts.text = currentPickCount.ToString();
    }

    public int GetPickCounts()
    {
        int pickCounts = int.Parse(PickCounts.text);
        return pickCounts;
    }
}
