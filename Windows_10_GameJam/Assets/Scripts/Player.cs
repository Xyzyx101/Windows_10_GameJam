using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    //public float speed;
    public bool isMoving;
    public float power;

    private Rigidbody2D rb;
    private bool isStanding = true;
    private float maxJumpTime = 0.7f;
    private float jumpTimer;
    

    // Use this for initialization
    void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        isMoving = false;

        //FIXME
        StartMoving(30f);
    }

    void Update() {
        Jump();
    }

    void Jump() {
        jumpTimer -= Time.deltaTime;
        if (isStanding && Input.anyKey) {
            jumpTimer = maxJumpTime;
            rb.AddForce(new Vector2(0f, 30f), ForceMode2D.Impulse);
            isStanding = false;
        } else if (jumpTimer > 0f && Input.anyKey) {
            rb.AddForce(new Vector2(0f, 4000f * Time.deltaTime), ForceMode2D.Force);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        isStanding = true;
    }

    void StartMoving(float speed) {
        rb.AddForce(new Vector2(speed, 0f), ForceMode2D.Impulse);
    }

    public void pickupBattery() {
        power += 10;
    }

    public void hitRock() {
        rb.AddForce(new Vector2(5f, 35f), ForceMode2D.Impulse);
    }
}
