using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSensitiveSetting : MonoBehaviour
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

        slider.value = 0.5f;
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
        value.moveSens = lastvalue;

    }
}
