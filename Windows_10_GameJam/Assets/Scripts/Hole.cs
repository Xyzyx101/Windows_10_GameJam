using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {
    private Player player;

    void Start() {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Hit hole");
    }
}
