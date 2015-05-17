using UnityEngine;
using System.Collections;

public class Battery : MonoBehaviour {
    
    private Player player;
    private Rigidbody2D rb;

    void Start() {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        player.pickupBattery();
        Destroy(this.gameObject);
    }
}
