using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code : MonoBehaviour {
    public float[] values;
    public GameObject[] counters;

    public static float[] Values;
    public static GameObject[] Counters;
    public static GameObject th;

    private void Start() {
        Values = values;
        Counters = counters;
        th = gameObject;
    }


    public static void Refresh() {
        
        for(int i=0;i<Values.Length; i++) {
            if(Values[i] != Counters[i].GetComponent<NumEdit>().num) {
                return;
            }
        }
        th.GetComponent<OpenDoor1>().Go();
    }
}
