using UnityEngine;

public class MusicController : MonoBehaviour
{
    [Header("Configuración Audio")]
    public AudioSource audioSource;
    public float fadeSpeed = 0.5f;

    private bool playerInside = false;
    private float targetVolume = 0f;

    private void Start()
    {
        if (audioSource != null)
        {
            audioSource.volume = 0f;
            audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            targetVolume = 1f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            targetVolume = 0f;
        }
    }

    private void Update()
    {
        if (audioSource == null) return;

        audioSource.volume = Mathf.MoveTowards(
            audioSource.volume,
            targetVolume,
            fadeSpeed * Time.deltaTime
        );

        if (!playerInside && audioSource.volume <= 0f)
        {
            audioSource.Stop();
        }
        else if (playerInside && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
