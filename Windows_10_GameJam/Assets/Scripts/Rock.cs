using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {
    private Player player;

    void Start() {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
    }
	
	void OnTriggerEnter2D(Collider2D other) {
        player.hitRock();
    }
}
