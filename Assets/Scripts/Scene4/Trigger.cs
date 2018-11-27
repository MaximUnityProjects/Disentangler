using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {


    [SerializeField] GameObject GameScript;


    private void OnTriggerEnter(Collider other) {
        GameScript.GetComponent<CubeGame>().CubeInTrigger(other.transform.name == "WinCube");
    }
}
