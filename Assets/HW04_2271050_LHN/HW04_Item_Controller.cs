using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW04_Item_Controller : MonoBehaviour
{
    public GameObject Pick_Controller;
    void OnMouseDown()
    {
        print( $"{gameObject.name} clicked");
        Pick_Controller.GetComponent<HW04_Pick_Controller>().Increase_PickCount();
        Destroy(gameObject);
    }
}
