using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public static GameObject Player;
    [SerializeField] private GameObject player;

    private void Start() {
        Player = player;
    }
}
