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
    void Update() {
        bounceTimer -= Time.deltaTime;
        if (bounceTimer < 0) {
            rb.isKinematic = false;
            bounceTimer = bounceTime * Random.value;
            rb.AddForce(new Vector2(0f, bounceHeight), ForceMode2D.Impulse);
        } else if (transform.position.y < 0) {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            rb.isKinematic = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        player.pickupBattery();
        Destroy(this.gameObject);
    }
}
