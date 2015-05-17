using UnityEngine;
using System.Collections;

public class PowerMeter : MonoBehaviour {

    private Player player;
    private SpriteRenderer spriteRender;
    private GameManager gm;
    private bool activeControl;
    private bool goingUp;
    public float meterPosition;
    private float lerpTimer;
    private float lerpTime;

    void Start() {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
        GameObject gmObj = GameObject.FindGameObjectWithTag("GameManager");
        gm = gmObj.GetComponent<GameManager>();
        spriteRender = GetComponent<SpriteRenderer>();
        lerpTime = 2f;
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
            lerpTime = 1f;
            goingUp = false;
        } else if (lerpTimer <= 0f) {
            goingUp = true;
        }
        meterPosition = EaseInQuad(0, 1, lerpTimer / lerpTime, lerpTime);
        spriteRender.color = Color.Lerp(Color.red, Color.green, meterPosition);
        if ( gm.GetButtonPressedOnce() ) {
            player.StartMoving(meterPosition);
            gm.playerMode();
        }
    }

    public void activateControl() {
        activeControl = true;
        goingUp = true;
        meterPosition = 0;
    }

    public void deactivateControl() {
        activeControl = false;
    }

    static float EaseInQuad(float start, float distance,
                     float elapsedTime, float duration) {
        float clampedTime = Mathf.Min(elapsedTime / duration, 1.0f);
        return distance * clampedTime * clampedTime + start;
    }
}
