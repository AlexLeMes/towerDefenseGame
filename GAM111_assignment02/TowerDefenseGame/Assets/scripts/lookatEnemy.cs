using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatEnemy : MonoBehaviour {

    public turretTarget _target;

    Transform target;

    void Update ()
    {
        target = _target.target;

        transform.LookAt(target);
    }
}
