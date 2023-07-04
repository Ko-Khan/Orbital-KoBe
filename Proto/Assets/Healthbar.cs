using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour
{

    public Slider slider;
    
    public void setMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = slider.maxValue;
    }

    public void setHealth(int health) {
        slider.value = health;
    }
}
