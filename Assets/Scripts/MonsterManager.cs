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
    [SerializeField]
    GameObject EyeLidLeft;
    [SerializeField]
    GameObject EyeLidRight;

    private AudioManager audioManager;

    Vector2 InitialEyeRightPos;
    Vector2 InitialEyeLeftPos;

    float lookTimer = 0;
    float lookTimerMax = 2f;

    float blinkTimer = 4f;
    float blinkCloseTimer = 0;
    float blinkCloseTimerMax = .25f;
    float pokeCloseTimerMax = 1f;

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
        if (blinkTimer > 0)
        {
            blinkTimer -= Time.deltaTime;
            if (blinkTimer <= 0)
            {
                EyeLidLeft.SetActive(true);
                EyeLidRight.SetActive(true);
                blinkTimer = Random.Range(3f, 6f);
                blinkCloseTimer = blinkCloseTimerMax;
            }
        }
        if (blinkCloseTimer > 0)
        {
            blinkCloseTimer -= Time.deltaTime;
            if (blinkCloseTimer <= 0)
            {
                EyeLidLeft.SetActive(false);
                EyeLidRight.SetActive(false);
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
    public void PokeLeftEye()
    {
        audioManager.PlayPokeSound();
        EyeLidLeft.SetActive(true);
        blinkTimer = Random.Range(3f, 6f);
        blinkCloseTimer = pokeCloseTimerMax;
    }
    public void PokeRightEye()
    {
        audioManager.PlayPokeSound();
        EyeLidRight.SetActive(true);
        blinkTimer = Random.Range(3f, 6f);
        blinkCloseTimer = pokeCloseTimerMax;
    }
}
