using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [Header("Componentes")]
    public VideoPlayer videoPlayer;
    public MeshRenderer meshRenderer; // el renderer del Plane
    public float fadeSpeed = 1f;

    private bool playerInside = false;
    private float targetAlpha = 0f;

    private void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Pause();
        }

        SetMaterialAlpha(0f); // Empieza invisible
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            targetAlpha = 1f;
            if (!videoPlayer.isPlaying)
                videoPlayer.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            targetAlpha = 0f;
        }
    }

    private void Update()
    {
        if (meshRenderer == null) return;

        float currentAlpha = meshRenderer.material.color.a;
        float newAlpha = Mathf.MoveTowards(currentAlpha, targetAlpha, fadeSpeed * Time.deltaTime);
        SetMaterialAlpha(newAlpha);

        if (!playerInside && newAlpha <= 0f && videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
    }

    private void SetMaterialAlpha(float alpha)
    {
        Color c = meshRenderer.material.color;
        c.a = alpha;
        meshRenderer.material.color = c;
    }
}
