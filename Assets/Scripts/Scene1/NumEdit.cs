using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumEdit : MonoBehaviour {
   public int num = 0;

    private void OnMouseDown() {
        num++;
        if (num >= 10) num = 0;
        this.GetComponent<Text>().text =  num.ToString();
        Code.Refresh();
    }
}
