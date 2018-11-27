using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class ice : MonoBehaviour {

    [SerializeField]PhysicMaterial enter;
    [SerializeField] PhysicMaterial exit;
    void OnTriggerEnter(Collider other) {
        if (other.attachedRigidbody) {
            other.material = enter;
            other.transform.GetComponent<Rigidbody>().angularDrag = 0f;

        }

    }

    //private void OnTriggerStay(Collider other) {
    //    other.transform.GetComponent<Rigidbody>().drag = 0f;
    //}

    private void OnTriggerExit(Collider other) {
        if (other.attachedRigidbody) {
            other.material = exit;
            other.transform.GetComponent<Rigidbody>().angularDrag = 0.05f;

        }
    }
}
