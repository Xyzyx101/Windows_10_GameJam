using UnityEngine;
using System.Collections;

public class PowerMeter : MonoBehaviour {
    private Player player;
    private SpriteRenderer spriteRender;
    private GameManager gm;
    private Vector3 originalPosition;
    private bool activeControl;
    private bool goingUp;
    public float meterPosition;
    private float lerpTimer;
    private float lerpTime;


    void Awake() {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
        GameObject gmObj = GameObject.FindGameObjectWithTag("GameManager");
        gm = gmObj.GetComponent<GameManager>();
        spriteRender = GetComponent<SpriteRenderer>();
        originalPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
    }

    void Start() {
        lerpTime = 1.5f;
        lerpTimer = 0f;
        goingUp = true;
    }

    void Update() {
        if (!activeControl) {
            return;
        }
        if (goingUp) {
            lerpTimer += Time.deltaTime;
        } else {
            lerpTimer -= Time.deltaTime;
        }
        if (lerpTimer > lerpTime) {
            lerpTimer = lerpTime;
            goingUp = false;
        } else if (lerpTimer <= 0f) {
            goingUp = true;
        }
        meterPosition = EaseInQuad(lerpTimer / lerpTime, lerpTime);

        /* meterPosition is a number from 0 to 1 that is used to set player speed
         * The following three line are just cosmetic and can be replaced with a
         * nicer looking meter */
        spriteRender.color = Color.Lerp(Color.red, Color.green, meterPosition);
        transform.localScale = new Vector3(Mathf.Max(meterPosition, 0.25f), Mathf.Max(meterPosition, 0.25f), 1f);
        transform.localPosition = new Vector3(originalPosition.x + 0.2f * meterPosition, originalPosition.y, originalPosition.z);

        if ( gm.GetButtonPressedOnce() ) {
            player.StartMoving(meterPosition);
            gm.playerMode();
        }
    }

    public void activateControl() {
        spriteRender.enabled = true;
        activeControl = true;
        goingUp = true;
        meterPosition = 0;
    }

    public void deactivateControl() {
        spriteRender.enabled = false;
        activeControl = false;
    }

    static float EaseInQuad(float elapsedTime, float duration) {
        float clampedTime = Mathf.Min(elapsedTime, 1.0f);
        return clampedTime * clampedTime * clampedTime * duration;
    }
}
