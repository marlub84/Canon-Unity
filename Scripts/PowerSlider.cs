using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSlider : MonoBehaviour
{

    public Slider slider;

    public void SetPower(float value)
    {
        slider.value = value;
    }

    public void ResetSlider()
    {
        slider.value = 0;
    }
}
