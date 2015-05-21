using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    //public float speed;
    public bool isMoving;
    public float power;
    public bool activeControl;

    private Rigidbody2D rb;
    private GameManager gm;
    private Animator animator;
    private bool isStanding = true;
    private float maxJumpTime = 0.7f;
    private float jumpTimer = 0;


    void Start() {
        GameObject gmObj = GameObject.FindGameObjectWithTag("GameManager");
        gm = gmObj.GetComponent<GameManager>();
        animator = GetComponentInChildren<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        isMoving = false;
    }

    void Update() {
        if (!activeControl) {
            return;
        }
        Jump();

        jumpTimer -= Time.deltaTime;
        if (isStanding && gm.GetButtonPressedOnce()) {
            animator.speed = 1f;
            animator.SetTrigger("Jump");
            Debug.Log("Jumping");
            jumpTimer = maxJumpTime;
            rb.AddForce(new Vector2(0f, 30f), ForceMode2D.Impulse);
            isStanding = false;
        } else if (jumpTimer > 0f && Input.anyKey) {
            rb.AddForce(new Vector2(0f, 4000f * Time.deltaTime), ForceMode2D.Force);
            isMoving = false;
        } else {
            if (isStanding) {
                animator.SetFloat("RunSpeed", rb.velocity.x);
                animator.speed = rb.velocity.x;
            }
            if (rb.velocity.magnitude < 2f) {
                animator.SetFloat("RunSpeed", 0);
                gm.meterMode();
            }
        }
    }

    void Jump() {

    }

    void OnCollisionEnter2D(Collision2D collision) {
        isStanding = true;
    }

    public void StartMoving(float speed) {
        isMoving = true;
        rb.AddForce(new Vector2(speed * 40f, 0f), ForceMode2D.Impulse);
    }

    public void pickupBattery() {
        power += 10;
    }

    public void hitRock() {
        animator.SetTrigger("Hit");
    }

    public void slow() {
        rb.velocity = rb.velocity * 0.9f;
    }

    public void activateControl() {
        activeControl = true;
    }
    public void deactivateControl() {
        activeControl = false;
    }
}
