using UnityEngine;

public class PlayerFlightCheat : MonoBehaviour
{
    public float flightSpeed = 25f;
    public float normalGravity = -9.81f;
    public float flightGravity = -2f; // Langsames Sinken
    private bool isFlying = false;
    private Rigidbody rb;
    private string lastKeys = "";

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckCheatCode();

        if (isFlying)
        {
            FlyMode();
        }
    }

    void CheckCheatCode()
    {
        if (Input.anyKeyDown)
        {
            lastKeys += Input.inputString;

            if (lastKeys.Length > 5)
                lastKeys = lastKeys.Substring(lastKeys.Length - 5); // Nur letzte 5 Zeichen speichern

            if (lastKeys == "iioo1")
            {
                ActivateFlight();
                lastKeys = ""; // Reset Code
            }
            else if (lastKeys == "pp") // Deaktivieren mit `p p`
            {
                DeactivateFlight();
                lastKeys = ""; // Reset Code
            }
        }
    }

    void ActivateFlight()
    {
        isFlying = true;
        rb.useGravity = false;
        Debug.Log("🚀 Flugmodus aktiviert!");
    }

    void DeactivateFlight()
    {
        isFlying = false;
        rb.useGravity = true;
        Debug.Log("⛔ Flugmodus deaktiviert!");
    }

    void FlyMode()
    {
        float vertical = 0f;
        if (Input.GetKey(KeyCode.Space)) vertical = 1f;  // Steigen mit `Space`
        if (Input.GetKey(KeyCode.LeftShift)) vertical = -1f; // Sinken mit `Shift`

        Vector3 moveDirection = transform.forward * flightSpeed * Time.deltaTime;
        rb.linearVelocity = new Vector3(moveDirection.x, vertical * flightSpeed, moveDirection.z);
    }
}
