using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public int points;
    public int level;
    public float power;

    private bool isLevelLoaded;

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
        Debug.Log("gmAwake");
    }

	// Use this for initialization
	void Start () {
        Debug.Log("gmStart");
        if (!isLevelLoaded) {
            GameObject levelFactoryObject = GameObject.FindGameObjectWithTag("LevelFactory");
            LevelFactory lf = levelFactoryObject.GetComponent<LevelFactory>();
            lf.createLevel(level);
            isLevelLoaded = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void goal() {
        Debug.Log("gmGoal");
        ++level;
        isLevelLoaded = false;
        Application.LoadLevel("TestLevel0");
    }
}
