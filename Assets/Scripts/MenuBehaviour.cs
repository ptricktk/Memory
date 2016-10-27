using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class MenuBehaviour : MonoBehaviour {

    public Slider DifficultSlider;

    public void TriggerMenubehaviour()
    {
        switch (int.Parse(DifficultSlider.value.ToString()))
        {
            default:
            case (1):
                SceneManager.LoadScene("level_1");
                break;
            case (2):
                SceneManager.LoadScene("level_2");
                break;
            case (3):
                SceneManager.LoadScene("level_3");
                break;
            
        }
    }

}
