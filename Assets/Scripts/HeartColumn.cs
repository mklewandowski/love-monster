using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartColumn : MonoBehaviour
{
    [SerializeField]
    RectTransform[] HeartRows;

    private Vector2 heartMovement = new Vector2(0, -20f);

    // Update is called once per frame
    void Update()
    {
        float minY = -750f;
        for (int i = 0; i < HeartRows.Length; i++)
        {
            if (HeartRows[i].anchoredPosition.y < minY)
            {
                int abutIndex = i == 0 ? HeartRows.Length - 1 : i - 1;
                HeartRows[i].anchoredPosition = new Vector2(
                        HeartRows[i].anchoredPosition.x,
                        HeartRows[abutIndex].anchoredPosition.y + 350f
                    );
            }
        }
    }

    void FixedUpdate()
    {
        for (int i = 0; i < HeartRows.Length; i++)
        {
            HeartRows[i].anchoredPosition = new Vector2(
                    HeartRows[i].anchoredPosition.x,
                    HeartRows[i].anchoredPosition.y + heartMovement.y * Time.deltaTime
                );
        }
    }
}
