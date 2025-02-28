using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;
    public Camera alternateCamera;
    private bool isMainActive = true;

    void Start()
    {
        // Stelle sicher, dass nur eine Kamera aktiv ist
        mainCamera.enabled = true;
        alternateCamera.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchCamera();
        }
    }

    void SwitchCamera()
    {
        isMainActive = !isMainActive;
        mainCamera.enabled = isMainActive;
        alternateCamera.enabled = !isMainActive;

        Debug.Log(isMainActive ? "📷 Hauptkamera aktiv!" : "📷 Alternative Kamera aktiv!");
    }
}
