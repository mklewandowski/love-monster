using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField]
    AudioClip SwooshSound;
    [SerializeField]
    AudioClip PokeSound;
    [SerializeField]
    AudioClip GrowlSound;
    [SerializeField]
    AudioClip ExplosionSound;
    [SerializeField]
    AudioClip KindGrowlSound;
    [SerializeField]
    AudioClip SmallGrowl1Sound;
    [SerializeField]
    AudioClip SmallGrowl2Sound;
    [SerializeField]
    AudioClip PopSound;

    void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    public void StartMusic()
    {
        audioSource.Play();
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void PlaySwooshSound()
    {
        audioSource.PlayOneShot(SwooshSound, 1f);
    }

    public void PlayPokeSound()
    {
        audioSource.PlayOneShot(PokeSound, 1f);
    }

    public void PlayGrowlSound()
    {
        audioSource.PlayOneShot(GrowlSound, 1f);
    }

    public void PlayExplosionSound()
    {
        audioSource.PlayOneShot(ExplosionSound, 1f);
    }

    public void PlayKindGrowlSound()
    {
        audioSource.PlayOneShot(KindGrowlSound, 1f);
    }

    public void PlaySmallGrowl1Sound()
    {
        audioSource.PlayOneShot(SmallGrowl1Sound, 1f);
    }

    public void PlaySmallGrowl2Sound()
    {
        audioSource.PlayOneShot(SmallGrowl2Sound, 1f);
    }

    public void PlayPopSound()
    {
        audioSource.PlayOneShot(PopSound, 1f);
    }
}
