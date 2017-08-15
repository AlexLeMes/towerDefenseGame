using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerShoot : MonoBehaviour {

    public Slider powerBar;

    float powerBarValue = 0f;
    public float power = 0.2f;
    public float releasePower = 0f;

    public GameObject projectile;
    GameObject spawnedProjectile;

    float destoryTime = 5f;

    public float projectileDamage = 0.03f;

    Rigidbody projectileRb;

    public float projectileForce = 25f;

    private void Awake()
    {
        powerBar.value = powerBarValue;
    }

    void Update ()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            powerBarValue += power * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (powerBar.value > 1)
            {
                powerBarValue = 1f;
            }

            releasePower = powerBarValue;

            spawnedProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            projectileRb = spawnedProjectile.GetComponent<Rigidbody>();
            projectileRb.AddForce(transform.forward * projectileForce * releasePower);

            projectileDamage = releasePower;

            Destroy(spawnedProjectile, destoryTime);

            powerBarValue = 0f;
        }

        powerBar.value = powerBarValue;
    }
}
