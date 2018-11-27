using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Button : MonoBehaviour {

    [SerializeField] CubeGame target;
    [SerializeField] string methodName;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.E) && Eyeshot.hoverObj == this.transform && Eyeshot.distance < 6) {
            target.GetType().GetMethod(methodName).Invoke(target, null);
            GetComponent<Animation>().Play("Button");
        }
        
    }
}
