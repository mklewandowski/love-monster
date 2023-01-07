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
    Image EyeImageLeft;
    [SerializeField]
    Image EyeImageRight;
    [SerializeField]
    GameObject EyeLidLeft;
    [SerializeField]
    GameObject EyeLidRight;
    [SerializeField]
    GameObject SmallMouth;
    [SerializeField]
    GameObject Explosion;
    [SerializeField]
    Sprite HeartSprite;
    [SerializeField]
    Sprite EyeSprite;

    private AudioManager audioManager;

    Vector2 InitialEyeRightPos;
    Vector2 InitialEyeLeftPos;

    float lookTimer = 0;
    float lookTimerMax = 2f;

    float blinkTimer = 4f;
    float blinkCloseTimer = 0;
    float blinkCloseTimerMax = .25f;
    float pokeCloseTimerMax = 1f;
    float smallMouthTimer = 0;
    float smallMouthTimerMax = 1f;
    float explosionTimer = 0;
    float explosionTimerMax = .5f;
    float heartTimer = 0;
    float heartTimerMax = 2f;

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
        if (smallMouthTimer > 0)
        {
            smallMouthTimer -= Time.deltaTime;
            if (smallMouthTimer <= 0)
            {
                SmallMouth.SetActive(false);
            }
        }
        if (explosionTimer > 0)
        {
            explosionTimer -= Time.deltaTime;
            if (explosionTimer <= 0)
            {
                Explosion.SetActive(false);
            }
        }
        if (heartTimer > 0)
        {
            heartTimer -= Time.deltaTime;
            if (heartTimer <= 0)
            {
                EyeImageLeft.sprite = EyeSprite;
                EyeImageRight.sprite = EyeSprite;
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
    public void PokeMouth()
    {
        audioManager.PlayGrowlSound();
        SmallMouth.SetActive(true);
        smallMouthTimer = smallMouthTimerMax;
    }
    public void PokeHeart()
    {
        audioManager.PlayKindGrowlSound();
        EyeImageLeft.sprite = HeartSprite;
        EyeImageRight.sprite = HeartSprite;
        heartTimer = heartTimerMax;
    }
    public void TapDynamite()
    {
        audioManager.PlayExplosionSound();
        explosionTimer = explosionTimerMax;
        EyeLidLeft.SetActive(true);
        EyeLidRight.SetActive(true);
        blinkTimer = Random.Range(3f, 6f);
        blinkCloseTimer = explosionTimerMax;
        Explosion.transform.localScale = new Vector3(.1f, .1f, .1f);
        Explosion.SetActive(true);
        Explosion.GetComponent<GrowAndShrink>().StartEffect();
    }
}
