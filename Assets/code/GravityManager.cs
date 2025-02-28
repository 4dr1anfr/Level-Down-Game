using UnityEngine;

public class GravityManager : MonoBehaviour
{
    void Start()
    {
        // Setzt die globale Schwerkraft auf eine stärkere Schwerkraft
        Physics.gravity = new Vector3(0, -20f, 0); // Y-Wert negativ, um die Schwerkraft nach unten zu ziehen
    }
}
