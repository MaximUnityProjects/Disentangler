using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

    public Texture2D aim;
    private void Start() {
        UnityEngine.Cursor.visible = false;

    }
    public void OnGUI() {
        GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 2, 3, 3), aim);
    }
}
