using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Outside : MonoBehaviour {
    [SerializeField] Transform u;[SerializeField] Transform c;


    private void OnTriggerEnter(Collider other) {
        if(other.transform == u || other.transform == c) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        other.transform.gameObject.SetActive(false);
    }
}
