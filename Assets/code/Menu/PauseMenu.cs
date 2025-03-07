using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Name der neuen Szene, die du laden möchtest
    public string sceneName = "Main"; // Passe diesen Namen an die gewünschte Szene an

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        // Überprüfen, ob die ESC-Taste gedrückt wurde
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Lade die neue Szene
            SceneManager.LoadScene(sceneName);
        }
    }
}
