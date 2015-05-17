using UnityEngine;
using System.Collections;

public class Battery : MonoBehaviour {
    public float bounceTime;
    public float bounceHeight;

    private float bounceTimer;
    private Player player;
    private Rigidbody2D rb;

    void Start() {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () {
        bounceTimer -= Time.deltaTime;
        Debug.Log(bounceTimer);
        if (bounceTimer < 0) {
            bounceTimer = bounceTime;
            rb.AddForce(new Vector2(0f, bounceHeight), ForceMode2D.Impulse);
        }
	}

    void OnCollisionEnter2D(Collision2D collision) {
        player.pickupBattery();
        Destroy(this.gameObject);
    }
}
