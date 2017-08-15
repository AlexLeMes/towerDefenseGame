using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretBullet : MonoBehaviour {

    private Transform target;

    public float bulletSpeed = 15f;

    public void seekTarget (Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if(target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, bulletSpeed * Time.deltaTime);
    }
}
