using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour
{
    [SerializeField]
    RectTransform EyeLeft;
    [SerializeField]
    RectTransform EyeRight;

    private AudioManager audioManager;

    Vector2 InitialEyeRightPos;
    Vector2 InitialEyeLeftPos;

    float lookTimer = 0;
    float lookTimerMax = 2f;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = this.GetComponent<AudioManager>();
        InitialEyeLeftPos = EyeLeft.anchoredPosition;
        InitialEyeRightPos = EyeRight.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (lookTimer > 0)
        {
            lookTimer -= Time.deltaTime;
            if (lookTimer <= 0)
            {
                EyeLeft.anchoredPosition = InitialEyeLeftPos;
                EyeRight.anchoredPosition = InitialEyeRightPos;
            }
        }
    }

    public void LookRight()
    {
        audioManager.PlaySwooshSound();
        lookTimer = lookTimerMax;
        EyeLeft.anchoredPosition = new Vector2(InitialEyeLeftPos.x + 75f, InitialEyeLeftPos.y);
        EyeRight.anchoredPosition = new Vector2(InitialEyeRightPos.x + 75f, InitialEyeRightPos.y);
    }
    public void LookLeft()
    {
        audioManager.PlaySwooshSound();
        lookTimer = lookTimerMax;
        EyeLeft.anchoredPosition = new Vector2(InitialEyeLeftPos.x - 75f, InitialEyeLeftPos.y);
        EyeRight.anchoredPosition = new Vector2(InitialEyeRightPos.x - 75f, InitialEyeRightPos.y);
    }
    public void LookUp()
    {
        audioManager.PlaySwooshSound();
        lookTimer = lookTimerMax;
        EyeLeft.anchoredPosition = new Vector2(InitialEyeLeftPos.x, InitialEyeLeftPos.y + 65f);
        EyeRight.anchoredPosition = new Vector2(InitialEyeRightPos.x, InitialEyeRightPos.y + 65f);
    }
    public void LookDown()
    {
        audioManager.PlaySwooshSound();
        lookTimer = lookTimerMax;
        EyeLeft.anchoredPosition = new Vector2(InitialEyeLeftPos.x, InitialEyeLeftPos.y - 65f);
        EyeRight.anchoredPosition = new Vector2(InitialEyeRightPos.x, InitialEyeRightPos.y - 65f);
    }
    public void LookCenter()
    {
        audioManager.PlaySwooshSound();
        lookTimer = lookTimerMax;
        EyeLeft.anchoredPosition = new Vector2(InitialEyeLeftPos.x + 65f, InitialEyeLeftPos.y);
        EyeRight.anchoredPosition = new Vector2(InitialEyeRightPos.x - 65f, InitialEyeRightPos.y);
    }
}
