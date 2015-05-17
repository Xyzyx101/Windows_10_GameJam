using UnityEngine;
using System.Collections;

public class ParallaxLayerFactory : MonoBehaviour {
    public Sprite sprite;
    public int number;
    public float layerSizeX;
    public float offsetY;
    public float randFactor;

    void Start() {
        for (int i = 0; i < number; ++i) {
            GameObject newObject = new GameObject();
            newObject.AddComponent<SpriteRenderer>();
            SpriteRenderer spriteRenderer = newObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;

            float subDistance = 1 - Random.value * randFactor;
            spriteRenderer.color = new Color(subDistance, subDistance, subDistance, 1.0f);

            newObject.transform.SetParent(transform);
            float offsetX = Random.Range(0, layerSizeX * 0.01f);
            newObject.transform.localPosition = new Vector3(offsetX, offsetY, -subDistance);
            newObject.transform.localScale = new Vector3(Random.value > 0.5f ? subDistance : -subDistance, subDistance, 1f);
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
