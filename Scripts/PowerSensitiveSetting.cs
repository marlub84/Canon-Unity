using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PowerSensitiveSetting : MonoBehaviour
{
    public Slider slider;

    [SerializeField] private GameObject canon;
    private CanonMove value;

    private float sensitive;
    private float lastvalue;

    // Start is called before the first frame update
    void Start()
    {
        value = canon.GetComponent<CanonMove>();

        slider.value = 0.3f;
        lastvalue = slider.value;
        SetValue();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastvalue != slider.value)
        {
            lastvalue = slider.value;
            SetValue();
        }
        
    }

    private void SetValue()
    {
        value.powerSens = lastvalue;
    }
}
