using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float speed;

    private bool isStanding = false;
    private float maxJumpTime = 0.8f;
    private float jumpTimer;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.Translate(speed * Vector3.right * Time.deltaTime);
        jumpTimer -= Time.deltaTime;
        if (isStanding && Input.anyKey) {
            Jump();

        } else if (jumpTimer > 0) {

        }
    }

    void Jump() {
        Debug.Log("Jump");
        isStanding = false;
    }
}
