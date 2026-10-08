using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    public AudioClip background;


    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}
