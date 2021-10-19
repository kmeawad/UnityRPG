using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    //public function to set the max health
    public void setMaxHealth(int max) {
        slider.maxValue = max;
        slider.value = max;
    }
    //public function to set the health
    public void setHealth(int health) {
        slider.value = health;
    }
    //public function to get the current health
    public float getHealth() {
        return slider.value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
