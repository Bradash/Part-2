using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("savedhealth");
    }
    public void TakeDamage(float damage)
    {
        slider.value -= damage;
    }
}
