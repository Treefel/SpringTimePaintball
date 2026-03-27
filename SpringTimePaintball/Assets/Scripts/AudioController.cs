using UnityEngine;

public class AudioController : MonoBehaviour
{
   [SerializeField] private AudioClip[] arraySounds;
   private AudioSource audioSource;

   [SerializeField] private AudioClip[] awakeSounds;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
        if (awakeSounds != null)
        {
            AudioClip awakeSound = awakeSounds[Random.Range(0, awakeSounds.Length)];
            audioSource.PlayOneShot(awakeSound);
        }
    }

    public void seriesSounds()
    {
        for (int i = 0; i < arraySounds.Length; i++)
        {
            AudioClip arraySound = arraySounds[i];
            audioSource.PlayOneShot(arraySound);
        }      
    }
}
