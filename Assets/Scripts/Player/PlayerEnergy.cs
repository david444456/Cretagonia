using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] int maxEnergyValue = 150;
    [SerializeField] Slider sliderEnergy;
    [SerializeField] UnityEvent eventDie = new UnityEvent();
    // Start is called before the first frame update

    float valueWater = 0;
    void Start()
    {
        valueWater = maxEnergyValue;
        sliderEnergy.maxValue = maxEnergyValue;
    }

    private void Update()
    {
        valueWater -= Time.deltaTime;
 

        if (valueWater <= 0) {
            print("You are dead");
            eventDie.Invoke();
        }
        else sliderEnergy.value = valueWater;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "BackGround") {
            print("water");
        }
    }

    public void AugmentWaterValue(float valueToAugment) {
        valueWater += valueToAugment;
        valueWater = Mathf.Min(maxEnergyValue, valueWater);
        print(valueWater);
        sliderEnergy.value = valueWater;
    }
}
