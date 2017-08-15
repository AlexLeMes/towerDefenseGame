using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class townStats : MonoBehaviour {

    public Slider townHealthBar;

    public waveSpawner waveSystemScript;

    public gameStatus gameStatusScript;

    float townHealth = 1f;
    public float currentHealth;

    float damageToTake = 0.4f;

    void Awake()
    {
        townHealthBar.value = townHealth;
        currentHealth = townHealth;
        //townHealthBar.value = townHealth;
        //currentHealth = townHealth;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("enemyHitTown");

            currentHealth -= damageToTake;

            waveSystemScript.ememiesDeadThisWave += 1;

            updateHealth();

            Destroy(other.gameObject);
        }
    }

    void updateHealth()
    {
        //townHealthBar.value = currentHealth;
        Debug.Log("town health = " + currentHealth);

        townHealthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            gameStatusScript.endGame();
            Debug.Log("Town_died");
        }
    }
}
