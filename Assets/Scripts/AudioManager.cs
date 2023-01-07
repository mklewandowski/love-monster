using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField]
    AudioClip SwooshSound;
    [SerializeField]
    AudioClip PokeSound;

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

}
