using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHealUpdate : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Health playerHealth;
    void Reset()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        //Inscription au start (si jamais la vie de départ n'est pas la même que la max)
        //Inscription également lorsque la vie change (pour actualiser le slider)
        playerHealth.OnSpawn += AcualiseSlider;
        playerHealth.OnChangeHealth += AcualiseSlider;
    }

    void OnDestroy()
    {
        //Desinscription des évênements
        playerHealth.OnSpawn -= AcualiseSlider;
        playerHealth.OnChangeHealth -= AcualiseSlider;
    }
    void AcualiseSlider()
    {
        //Pourcentage pour avoir la valeur du slider comprise entre 0 et 1
        float percentValue = (float)playerHealth.CurrentHealth / (float)playerHealth.MaxHealth;
        slider.value = percentValue;
    }
}
