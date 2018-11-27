using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor1 : MonoBehaviour {
    [SerializeField] Vector3 displacement;
    [SerializeField] Transform target;
    [SerializeField] bool done = false;
    [SerializeField] private GameObject SoundEmitter = null;
    [SerializeField] bool smoosh = false;
    bool on = false;
    [SerializeField] private float speed = 1;
    private Vector3 start;
    [SerializeField] private bool view = true;

    [SerializeField] private bool disableKinematic = true;

    private void Update() {
        if (view && !done && Input.GetKeyDown(KeyCode.E) && Eyeshot.hoverObj == this.transform && Eyeshot.distance < 4) {
            Go();
        }


        Smoosh();


    }


    void Smoosh() {
        if (!on) return;
        target.transform.position = Vector3.Lerp(target.transform.position, start + displacement, Time.deltaTime * speed);
        if (Vector3.Distance(start, start + displacement) < 1f) {
            on = false;
            done = true;
        }
    }

    public void Go() {
        if (disableKinematic) {
            var rig = GetComponent<Rigidbody>();
            if (rig != null) rig.isKinematic = false;
        }

        if (smoosh) {
            start = target.transform.position;
            on = true;
        }
        else {
            target.transform.position += displacement;
        }



        if (SoundEmitter != null) Destroy(Instantiate(SoundEmitter, target.transform.position, target.transform.rotation) as GameObject, 2f);
        done = true;
    }

}
