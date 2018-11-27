using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject : MonoBehaviour {
    [SerializeField] private Vector3 Deviation = new Vector3(0f, 0f, 1f);

    private RaycastHit hit;
    private Transform target = null;
    [SerializeField] private float  power= 5;
    private Vector3 vector;
    private GameObject prim;
    bool cheat = false;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (target == null) {


                if (Eyeshot.hit.rigidbody) {
                    hit = Eyeshot.hit;
                    target = hit.transform;
                    hit.rigidbody.useGravity = false;
                }
            }
            else {
                hit.rigidbody.useGravity = true;
                target = null;
            }
        }
        if (Input.GetMouseButtonDown(0) && target !=null) {
            target = null;
            hit.rigidbody.useGravity = true;
            hit.rigidbody.velocity = (-transform.position + transform.TransformPoint(Deviation))*10;
        }
        if (cheat && Input.GetMouseButtonDown(1)) {
            GameObject p = GameObject.CreatePrimitive(PrimitiveType.Cube);
            p.transform.position = transform.TransformPoint(Deviation);
            p.AddComponent<Rigidbody>();
        }
        if (Input.GetKeyDown(KeyCode.F1)) {
            cheat = !cheat;
        }
    }



    void FixedUpdate() {
        if(target != null) {
            vector = (transform.TransformPoint(Deviation) - hit.transform.position);
            hit.rigidbody.velocity=(vector.normalized * Mathf.Min(vector.sqrMagnitude, 5)*power);
        }
    }
}

