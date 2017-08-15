using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endTown : MonoBehaviour {

    public Slider townHealthBar;

    public float townHealth = 100f;
    float currentHealth;

    GameObject endTownObj;

    private void Awake()
    {
        endTownObj = GameObject.FindGameObjectWithTag("town");

        townHealthBar.value = townHealth;

        townHealthBar.value = townHealth;
        currentHealth = townHealth;
    }


    private void Update()
    {
        townHealthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            killTown();
        }
    }

    void killTown()
    {

    }
}
