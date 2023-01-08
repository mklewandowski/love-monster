using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartFall : MonoBehaviour
{
    private Vector2 heartMovement = new Vector2(0, 0);
    private float rotation;

    // Start is called before the first frame update
    void Start()
    {
        heartMovement = new Vector2(0, Random.Range(-300f, -400f));
        rotation = Random.Range (-.05f, .05f);
        float scale = Random.Range(.1f, .5f);
        this.transform.localScale = new Vector3(scale, scale, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotation));
        if (this.GetComponent<RectTransform>().anchoredPosition.y < -1000f)
            Destroy(this.gameObject);
    }
    void FixedUpdate()
    {
        this.GetComponent<Rigidbody2D>().velocity = heartMovement;
    }
}
