using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNumber : MonoBehaviour {

    [SerializeField] Material hide;
    Material temp;
    [SerializeField] GameObject target;

    // Use this for initialization
    void Start() {
        temp = target.gameObject.GetComponent<Renderer>().material;
        target.gameObject.GetComponent<Renderer>().material = hide;

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == Game.Player)
            target.gameObject.GetComponent<Renderer>().material = temp;
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject == Game.Player)
            target.gameObject.GetComponent<Renderer>().material = hide;
    }
}
