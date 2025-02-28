using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;        // Ego-Perspektive
    public Camera alternateCamera;   // 3rd-Person-Perspektive
    public Transform playerBody;     // Spieler-Transform (zum Rotieren)
    public float mouseSensitivity = 100f;
    public float cameraDistance = 3f; // Abstand der Kamera zum Spieler

    private bool isMainActive = true;
    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        // Nur eine Kamera aktivieren
        mainCamera.enabled = true;
        alternateCamera.enabled = false;

        // Mauszeiger sperren
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchCamera();
        }

        // Maussteuerung für die aktive Kamera
        LookAround();
    }

    void SwitchCamera()
    {
        isMainActive = !isMainActive;
        mainCamera.enabled = isMainActive;
        alternateCamera.enabled = !isMainActive;

        Debug.Log(isMainActive ? "📷 Hauptkamera aktiv!" : "📷 Alternative Kamera aktiv!");
    }

    void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        if (isMainActive)
        {
            // Ego-Perspektive: Spieler horizontal drehen, Kamera vertikal neigen
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Begrenzung für Kopfbewegung

            playerBody.Rotate(Vector3.up * mouseX);
            mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
        else
        {
            // 3rd-Person-Steuerung: Kamera frei um den Spieler bewegen (inkl. Y-Achse)
            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f); // Begrenzung für Blickwinkel

            // Kamera-Position basierend auf Rotation um den Spieler setzen
            Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0);
            Vector3 direction = new Vector3(0, 0, -cameraDistance);
            alternateCamera.transform.position = playerBody.position + rotation * direction;

            // Kamera soll den Spieler immer anschauen
            alternateCamera.transform.LookAt(playerBody.position);
        }
    }
}
