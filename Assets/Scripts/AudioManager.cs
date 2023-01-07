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

}
