using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToObject : MonoBehaviour {

    [SerializeField] GameObject target;
    [SerializeField] float speed=1;


    void Update () {
        if (!target) return;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), Time.deltaTime * speed);
    }
}
