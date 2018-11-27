using UnityEngine;

public class Eyeshot : MonoBehaviour {
    public static RaycastHit hit;
    public static float distance;
    public static Transform hoverObj;

    //private static Transform old;

    void LateUpdate() {
        Run();
    }

    private static void Run() {
        Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f)), out hit, 50f);
        distance = hit.distance;
        hoverObj = hit.transform;
        //if (hit.transform != old) {
        //    old = hit.transform;
        //}
    }
}
