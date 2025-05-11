using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HW04_SceneManager : MonoBehaviour
{
    public void LoadScene01()
    {
        SceneManager.LoadScene("HW04_scene1");
    }

    public void LoadScene02()
    {
        SceneManager.LoadScene("HW04_scene2");
    }
}
