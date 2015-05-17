using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {
    private Player player;
    private GameManager gm;

    void Start() {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
        GameObject gmObject = GameObject.FindGameObjectWithTag("GameManager");
        gm = gmObject.GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Hit hole");
        gm.goal();
    }
}
