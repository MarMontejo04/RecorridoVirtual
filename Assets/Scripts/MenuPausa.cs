using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;

    public static bool enPausa = false;

    void Start()
    {
        // Al iniciar, oculta y bloquea el cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (enPausa)
                Reanudar();
            else
                Pausa();
        }
    }

    public void Pausa()
    {
        enPausa = true;
        Time.timeScale = 0f;
        menuPausa.SetActive(true);

        // Mostrar cursor y desbloquearlo
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Reanudar()
    {
        enPausa = false;
        Time.timeScale = 1f;
        menuPausa.SetActive(false);

        // Ocultar cursor y bloquearlo al centro
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void CerrarJuego()
    {
        enPausa = false;
        Time.timeScale = 1f;
        Application.Quit();
    }
}
