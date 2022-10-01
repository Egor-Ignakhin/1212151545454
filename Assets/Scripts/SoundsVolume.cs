using UnityEngine;

public class SoundsVolume : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolume = 1f;

    // Start is called before the first frame update
    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        audioSrc.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}