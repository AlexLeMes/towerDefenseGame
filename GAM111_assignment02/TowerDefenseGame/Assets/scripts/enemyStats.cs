using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enemyStats : MonoBehaviour {

    //public endTown townScript;

    public bool isTarget = false;

    public playerShoot projectileInfo;

    public followWaypoints enemyWaypoint;

    public waveSpawner waveSystem;

    float moveSpeed;
    public float minSpeed = 0.5f;
    public float maxSpeed = 2f;

    public Slider healthBar;
    const float maxHealth = 1f;
    float currentHealth;

    float damageTaken;

    public GameObject deathParticles;
    public GameObject coin;

    float fireballDamage = 100f;

    public void Awake()
    {
        enemyWaypoint = gameObject.GetComponent<followWaypoints>();
        projectileInfo = GameObject.Find("_fireingPoint").GetComponent<playerShoot>();
        waveSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<waveSpawner>();
    }

    void Start ()
    {
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        Debug.Log("moveSpeed = " + moveSpeed);
        enemyWaypoint.speed = moveSpeed;
        //healthBar = gameObject.GetComponent<Slider>();
        healthBar.value = maxHealth;
        currentHealth = maxHealth;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "projectile")
        {
            damageTaken = projectileInfo.projectileDamage;
            healthBar.value = currentHealth - damageTaken;
            currentHealth = healthBar.value;
            updateHealth();
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "fireball")
        {
            damageTaken = fireballDamage;
            healthBar.value = currentHealth - damageTaken;
            currentHealth = healthBar.value;
            updateHealth();
        }
    }

    void updateHealth()
    {
        healthBar.value = currentHealth;

        if(currentHealth <= 0)
        {
            waveSystem.enemiesKilled += 1;
            waveSystem.ememiesDeadThisWave += 1;
            waveSystem.UpdateWaveStatus();
            die();
        }
    }

    void die()
    {
        Instantiate(deathParticles, gameObject.transform.position, Quaternion.identity);
        Instantiate(coin, gameObject.transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }
}
