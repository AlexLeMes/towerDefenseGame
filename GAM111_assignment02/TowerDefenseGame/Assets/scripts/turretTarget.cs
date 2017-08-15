using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretTarget : MonoBehaviour {

    public List<Transform> enemies;

    public Transform target;

    public turret turretScript;

    float distance;

    float towerRange = 8f;

    float dis;

    public int i = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            enemies.Add(other.gameObject.transform);

            target = enemies[i];

            turretScript.target = target;

            turretScript.shootTarget();
        }
        
    }

}