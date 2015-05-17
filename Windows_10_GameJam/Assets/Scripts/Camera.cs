using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
    public float smoothTime = 0.3F;

    private Vector3 velocity = Vector3.zero;
    private Player player;

	// Use this for initialization
	void Start () {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = transform.position;
        targetPosition.x = player.transform.position.x;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}
}