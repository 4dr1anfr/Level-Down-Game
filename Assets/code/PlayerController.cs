using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Jump Settings")]
    public float jumpForce = 5f; // Sprungkraft, über den Inspector einstellbar
    public bool isGrounded;      // Prüft, ob der Spieler den Boden berührt
    public LayerMask groundLayer; // Layer, der als Boden definiert ist

    [Header("Respawn Settings")]
    public Transform respawnPoint; // Der Punkt, an dem der Spieler respawnt
    public float fallHeight = -50f; // Y-Koordinate, unter der der Spieler respawnt

    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 100f;
    public Transform cameraTransform;

    private Rigidbody rb;
    private float xRotation = 0f;

    void Start()
    {
        // Sperrt den Mauszeiger in der Mitte des Bildschirms und macht ihn unsichtbar
        Cursor.lockState = CursorLockMode.Locked;

        // Zugriff auf das Rigidbody-Component
        rb = GetComponent<Rigidbody>();

        // Verhindert Rotation durch Physik
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Maussteuerung
        LookAround();

        // Springen
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // Respawn über "R"-Taste
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }

        // Respawn, wenn der Spieler zu tief fällt (unter Y = -50)
        if (transform.position.y < fallHeight)
        {
            Respawn();
        }
    }

    void FixedUpdate()
    {
        // Physikbasierte Bewegung
        Move();
    }

    private void Move()
    {
        // Eingaben für Bewegung
        float moveX = Input.GetAxis("Horizontal"); // A und D
        float moveZ = Input.GetAxis("Vertical");   // W und S

        // Bewegung relativ zur Kamera
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

        // Physikbasiertes Bewegen
        Vector3 velocity = moveDirection * moveSpeed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z); // Behalte die Y-Gravitation bei
    }

    private void LookAround()
    {
        // Mausbewegung erfassen
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Vertikale Rotation (Kamera kippen)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Begrenzung, damit man nicht "überkopf" schauen kann
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Horizontale Rotation (Spieler drehen)
        transform.Rotate(Vector3.up * mouseX);
    }

    private void Jump()
    {
        // Sprungkraft anwenden
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void Respawn()
    {
        // Setzt den Spieler zurück zum Respawn-Punkt und setzt die Geschwindigkeit zurück
        transform.position = respawnPoint.position;
        rb.linearVelocity = Vector3.zero; // Setzt die Bewegungsgeschwindigkeit auf 0
    }

    private void OnCollisionStay(Collision collision)
    {
        // Prüft, ob der Spieler den Boden berührt
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Setzt den Bodenstatus zurück, wenn der Spieler den Boden verlässt
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = false;
        }
    }
}
