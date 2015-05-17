using UnityEngine;
using System.Collections;

public class LevelFactory : MonoBehaviour {
    public GameObject rockObj;
    public GameObject holeObj;
    public GameObject batteryObj;

    public void createLevel(int level) {
        float levelLength = Random.Range(2, 5) * Mathf.Pow(1.1f, level) * 10.24f;
        GameObject.Instantiate(holeObj, new Vector3(levelLength, 0, 0), Quaternion.identity);

        int rockCount = (int)(Random.Range(2, 3) * Mathf.Pow(1.1f, level));
        Debug.Log("RockCount:" + rockCount);
        for (int i = 0; i < rockCount; ++i) {
            float rockPositionX = Random.value * levelLength * 0.8f + 0.1f; //0.8 and 0.1 is used to make sure the rocks don't spawn near the edge
            GameObject.Instantiate(rockObj, new Vector3(rockPositionX, 0, 0), Quaternion.identity);
        }

        int batteryCount = (int)(Random.value * 2f * Mathf.Pow(1.1f, level));
        Debug.Log("BatteryCount:" + batteryCount);
        for (int i = 0; i < rockCount; ++i) {
            float batteryPositionX = Random.value * levelLength * 0.8f + 0.1f; //0.8 and 0.1 is used to make sure the rocks don't spawn near the edge
            GameObject.Instantiate(batteryObj, new Vector3(batteryPositionX, 0, 0), Quaternion.identity);
        }
    }
}
