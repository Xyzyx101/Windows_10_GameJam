using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public int points;
    public int level;
    public float power;

    private Player player;
    private PowerMeter powerMeter;
    private bool isLevelLoaded;
    private bool buttonPressed;

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
        if (instance == null) {
            instance = this;
        } else {
            DestroyImmediate(this);
        }
    }

    // Use this for initialization
    void Start() {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
        GameObject powerMeterObj = GameObject.FindGameObjectWithTag("PowerMeter");
        powerMeter = powerMeterObj.GetComponent<PowerMeter>();
        if (!isLevelLoaded) {
            GameObject levelFactoryObject = GameObject.FindGameObjectWithTag("LevelFactory");
            LevelFactory lf = levelFactoryObject.GetComponent<LevelFactory>();
            lf.createLevel(level);
            isLevelLoaded = true;
        }
        meterMode();
    }

    void OnLevelWasLoaded(int level) {
        Start();
    }

    // Update is called once per frame
    void Update() {
        buttonPressed = Input.anyKeyDown;
    }

    public bool GetButtonPressedOnce() {
        bool temp = buttonPressed;
        buttonPressed = false;
        return temp;
    }

    public void goal() {
        Debug.Log("gmGoal");
        ++level;
        isLevelLoaded = false;
        Application.LoadLevel("TestLevel0");
    }

    public void playerMode() {
        Debug.Log("player mode");
        powerMeter.deactivateControl();
        player.activateControl();
    }

    public void meterMode() {
        Debug.Log("meter mode");
        powerMeter.activateControl();
        player.deactivateControl();
    }
}