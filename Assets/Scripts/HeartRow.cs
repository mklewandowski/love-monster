using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRow : MonoBehaviour
{
    [SerializeField]
    RectTransform[] Hearts;

    private Vector2 heartMovement = new Vector2(-20f, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float minX = -1200f;
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (Hearts[i].anchoredPosition.x < minX)
            {
                int abutIndex = i == 0 ? Hearts.Length - 1 : i - 1;
                Hearts[i].anchoredPosition = new Vector2(
                        Hearts[abutIndex].anchoredPosition.x + 300f,
                        Hearts[i].anchoredPosition.y
                    );
            }
        }
    }

    void FixedUpdate()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            Hearts[i].GetComponent<Rigidbody2D>().velocity = heartMovement;
        }
    }
}
