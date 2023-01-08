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
    GameObject EarLeft1;
    [SerializeField]
    GameObject EarLeft2;
    [SerializeField]
    GameObject EarRight1;
    [SerializeField]
    GameObject EarRight2;
    [SerializeField]
    Sprite HeartSprite;
    [SerializeField]
    Sprite EyeSprite;
    [SerializeField]
    GameObject Bubble;
    [SerializeField]
    Sprite[] BubbleSprites;
    [SerializeField]
    Sprite[] BubbleFallingSprites;
    [SerializeField]
    GameObject Tongue;
    [SerializeField]
    GameObject FallingHeartPrefab;
    [SerializeField]
    GameObject HeartContainer;
    [SerializeField]
    GameObject BubbleSpot;

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
    float earRightTimer = 0f;
    float earRightTimerMax = 2f;
    float earLeftTimer = 0f;
    float earLeftTimerMax = 2f;
    float bubbleTimer = 6f;
    float bubbleTimerMax = 6f;
    float showBubbleTimer = 0;
    float showBubbleTimerMax = 4f;
    float tongueTimer = 0;
    float tongueTimerMax = 2f;
    float spotTimer = 0;
    float spotTimerMax = 4f;

    int bubbleIndex = 0;

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
        if (bubbleTimer > 0)
        {
            bubbleTimer -= Time.deltaTime;
            if (bubbleTimer <= 0)
            {
                bubbleIndex = Random.Range(0, BubbleSprites.Length);
                Bubble.GetComponent<Image>().sprite = BubbleSprites[bubbleIndex];
                Bubble.transform.localScale = new Vector3(.1f, .1f, .1f);
                Bubble.SetActive(true);
                Bubble.GetComponent<GrowAndShrink>().StartEffect();
                showBubbleTimer = showBubbleTimerMax;
                audioManager.PlayPopSound();
            }
        }
        if (showBubbleTimer > 0)
        {
            showBubbleTimer -= Time.deltaTime;
            if (showBubbleTimer <= 0)
            {
                Bubble.SetActive(false);
                bubbleTimer = bubbleTimerMax;
            }
        }
        if (spotTimer > 0)
        {
            spotTimer -= Time.deltaTime;
            if (spotTimer <= 0)
            {
                BubbleSpot.SetActive(false);
            }
        }
        if (tongueTimer > 0)
        {
            tongueTimer -= Time.deltaTime;
            if (tongueTimer <= 0)
            {
                Tongue.SetActive(false);
            }
        }
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
        if (earRightTimer > 0)
        {
            earRightTimer -= Time.deltaTime;
            if (earRightTimer <= 0)
            {
                EarRight1.SetActive(true);
                EarRight2.SetActive(false);
            }
        }
        if (earLeftTimer > 0)
        {
            earLeftTimer -= Time.deltaTime;
            if (earLeftTimer <= 0)
            {
                EarLeft1.SetActive(true);
                EarLeft2.SetActive(false);
            }
        }
    }

    void ResetBubbleTimer()
    {
        bubbleTimer = bubbleTimerMax;
    }

    public void LookRight()
    {
        audioManager.PlaySwooshSound();
        lookTimer = lookTimerMax;
        EyeLeft.anchoredPosition = new Vector2(InitialEyeLeftPos.x + 65f, InitialEyeLeftPos.y);
        EyeRight.anchoredPosition = new Vector2(InitialEyeRightPos.x + 75f, InitialEyeRightPos.y);
        ResetBubbleTimer();
    }
    public void LookLeft()
    {
        audioManager.PlaySwooshSound();
        lookTimer = lookTimerMax;
        EyeLeft.anchoredPosition = new Vector2(InitialEyeLeftPos.x - 65f, InitialEyeLeftPos.y);
        EyeRight.anchoredPosition = new Vector2(InitialEyeRightPos.x - 75f, InitialEyeRightPos.y);
        ResetBubbleTimer();
    }
    public void LookUp()
    {
        audioManager.PlaySwooshSound();
        lookTimer = lookTimerMax;
        EyeLeft.anchoredPosition = new Vector2(InitialEyeLeftPos.x, InitialEyeLeftPos.y + 50f);
        EyeRight.anchoredPosition = new Vector2(InitialEyeRightPos.x, InitialEyeRightPos.y + 65f);
        ResetBubbleTimer();
    }
    public void LookDown()
    {
        audioManager.PlaySwooshSound();
        lookTimer = lookTimerMax;
        EyeLeft.anchoredPosition = new Vector2(InitialEyeLeftPos.x, InitialEyeLeftPos.y - 50f);
        EyeRight.anchoredPosition = new Vector2(InitialEyeRightPos.x, InitialEyeRightPos.y - 65f);
        ResetBubbleTimer();
    }
    public void LookDownRight()
    {
        audioManager.PlaySwooshSound();
        lookTimer = lookTimerMax;
        EyeLeft.anchoredPosition = new Vector2(InitialEyeLeftPos.x + 65f, InitialEyeLeftPos.y - 50f);
        EyeRight.anchoredPosition = new Vector2(InitialEyeRightPos.x + 75f, InitialEyeRightPos.y - 65f);
        ResetBubbleTimer();
    }
    public void LookDownLeft()
    {
        audioManager.PlaySwooshSound();
        lookTimer = lookTimerMax;
        EyeLeft.anchoredPosition = new Vector2(InitialEyeLeftPos.x - 45f, InitialEyeLeftPos.y - 40f);
        EyeRight.anchoredPosition = new Vector2(InitialEyeRightPos.x - 75f, InitialEyeRightPos.y - 65f);
        ResetBubbleTimer();
    }
    public void LookCenter()
    {
        audioManager.PlaySwooshSound();
        lookTimer = lookTimerMax;
        EyeLeft.anchoredPosition = new Vector2(InitialEyeLeftPos.x + 65f, InitialEyeLeftPos.y);
        EyeRight.anchoredPosition = new Vector2(InitialEyeRightPos.x - 65f, InitialEyeRightPos.y);
        ResetBubbleTimer();
    }
    public void PokeLeftEye()
    {
        audioManager.PlayPokeSound();
        EyeLidLeft.SetActive(true);
        blinkTimer = Random.Range(3f, 6f);
        blinkCloseTimer = pokeCloseTimerMax;
        ResetBubbleTimer();
    }
    public void PokeRightEye()
    {
        audioManager.PlayPokeSound();
        EyeLidRight.SetActive(true);
        blinkTimer = Random.Range(3f, 6f);
        blinkCloseTimer = pokeCloseTimerMax;
        ResetBubbleTimer();
    }
    public void PokeMouth()
    {
        audioManager.PlayGrowlSound();
        SmallMouth.SetActive(true);
        smallMouthTimer = smallMouthTimerMax;
        ResetBubbleTimer();
    }
    public void PokeHeart()
    {
        audioManager.PlayKindGrowlSound();
        EyeImageLeft.sprite = HeartSprite;
        EyeImageRight.sprite = HeartSprite;
        heartTimer = heartTimerMax;
        ResetBubbleTimer();

        int numHearts = 10;
        for (int x = 0; x < numHearts; x++)
        {
            Instantiate(FallingHeartPrefab, new Vector2(Random.Range(700f, 1220f), Random.Range(1200f, 1700f)), Quaternion.identity, HeartContainer.transform);
        }
    }
    public void PokeLeftEar()
    {
        audioManager.PlaySmallGrowl1Sound();
        EarLeft1.SetActive(false);
        EarLeft2.SetActive(true);
        earLeftTimer = earLeftTimerMax;
        LookLeft();
        ResetBubbleTimer();
    }
    public void PokeRightEar()
    {
        audioManager.PlaySmallGrowl2Sound();
        EarRight1.SetActive(false);
        EarRight2.SetActive(true);
        earRightTimer = earRightTimerMax;
        LookRight();
        ResetBubbleTimer();
    }
    public void PokeTongue()
    {
        audioManager.PlayGrowlSound();
        Tongue.SetActive(true);
        tongueTimer = tongueTimerMax;
        ResetBubbleTimer();
    }
    public void PokeSpot()
    {
        audioManager.PlayPopSound();
        BubbleSpot.SetActive(true);
        spotTimer = spotTimerMax;
        ResetBubbleTimer();
        Bubble.SetActive(false);
        LookDown();
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
        ResetBubbleTimer();
    }
    public void TapBubble()
    {
        audioManager.PlayPopSound();
        int numHearts = 10;
        for (int x = 0; x < numHearts; x++)
        {
            GameObject go = Instantiate(FallingHeartPrefab, new Vector2(Random.Range(700f, 1220f), Random.Range(1200f, 1700f)), Quaternion.identity, HeartContainer.transform);
            go.GetComponent<Image>().sprite = BubbleFallingSprites[bubbleIndex];
        }
    }
}
