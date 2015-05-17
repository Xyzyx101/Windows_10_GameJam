using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float speed;
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
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(speed * Vector3.right * Time.deltaTime);
        Jump();
        //Debug.Log(Input.anyKey);
    }

    void Jump() {
        jumpTimer -= Time.deltaTime;
        //Debug.Log(jumpTimer);
        if (isStanding && Input.anyKey) {
            Debug.Log("JumpInit");
            jumpTimer = maxJumpTime;
            rb.AddForce(new Vector2(0f, 25f), ForceMode2D.Impulse);
            isStanding = false;
        } else if (jumpTimer > 0f && Input.anyKey) {
            Debug.Log("JumpCont");
            rb.AddForce(new Vector2(0f, 4000f * Time.deltaTime), ForceMode2D.Force);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        isStanding = true;
    }

    void StartMoving(float speed) {

    }
}
