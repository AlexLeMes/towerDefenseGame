using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnTower : MonoBehaviour {

    public GameObject player;

    public noBuildZone noBuildZoneScript;

    float yOffSet = -0.5f;

    public playerCurrency _playerCurrency;

    public GameObject tower01;
    public GameObject tower02;
    public GameObject tower03;

    public int tower01_cost = 0;
    public int tower02_cost = 0;
    public int tower03_cost = 0;

    int playerCoins = 0;

    float buildCooldown = 0f;
    float cooldown = 6f;

    public Text cooldownText;


    GameObject spawnedTower;

    public bool canSpawnHere = false;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _playerCurrency = gameObject.GetComponent<playerCurrency>();

        playerCoins = _playerCurrency.currentAmount;
        Debug.Log("playerCoins: " + playerCoins);
        //canSpawnHere = true;
    }

    void Update()
    {
        buildCooldown -= Time.deltaTime;

        if (buildCooldown <= 0)
        {
            buildCooldown = 0;
        }

        cooldownText.text = "Cooldown: " + Mathf.RoundToInt(buildCooldown).ToString();
    }

    public void spawnTowerOne()
    {
        playerCoins = _playerCurrency.currentAmount;

        if (canSpawnHere == true && playerCoins >= tower01_cost && buildCooldown <= 0)
        {
            spawnedTower = Instantiate(tower01);
            spawnedTower.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + yOffSet, player.transform.position.z);

            buildCooldown = cooldown;

            _playerCurrency.currentAmount -= tower01_cost;

            //Destroy(noBuildZoneScript.spawnTrigger);
        }
        else
        {
            Debug.Log("cannotSpawnTowerHere");
        }
    }

    public void spawnTowerTwo()
    {
        playerCoins = _playerCurrency.currentAmount;

        if (canSpawnHere == true && playerCoins >= tower02_cost && buildCooldown <= 0)
        {
            spawnedTower = Instantiate(tower02);
            spawnedTower.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yOffSet, player.transform.position.z);
            buildCooldown = cooldown;

            _playerCurrency.currentAmount -= tower01_cost;
        }
        else
        {
            Debug.Log("cannotSpawnTowerHere");
        }
    }

    public void spawnTowerThree()
    {
        playerCoins = _playerCurrency.currentAmount;

        if (canSpawnHere == true && playerCoins >= tower03_cost && buildCooldown <= 0)
        {
            spawnedTower = Instantiate(tower03);
            spawnedTower.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yOffSet, player.transform.position.z);
            buildCooldown = cooldown;

            _playerCurrency.currentAmount -= tower01_cost;
        }
        else
        {
            Debug.Log("cannotSpawnTowerHere");
        }
    }

}
