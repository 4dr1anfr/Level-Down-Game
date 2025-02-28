using UnityEngine;

public class HideCube : MonoBehaviour
{
    [Header("NEU")]
        public float Testung;
    void Start()
    {
        // Deaktiviert den Renderer des Cubes, wodurch er unsichtbar wird
        GetComponent<Renderer>().enabled = false;
    }
}
