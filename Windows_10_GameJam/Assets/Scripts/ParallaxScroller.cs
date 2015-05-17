using UnityEngine;
using System.Collections;

public class ParallaxScroller : MonoBehaviour {
   
    // tileSizeX is the size of the scolling layer
    public float layerSizeX;
    // scroll speed is used for parallax effect 1 is full speed - 0 is no movement
    public float scrollSpeed;

    private Vector3 startPosition;
    private Player player;

    void Start() {
        startPosition = transform.localPosition;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
    }
	
	void Update () {
       float newPosition = Mathf.Repeat(player.transform.position.x * scrollSpeed, layerSizeX * 0.01f);
        transform.localPosition = startPosition + Vector3.left * newPosition;
	}
}
