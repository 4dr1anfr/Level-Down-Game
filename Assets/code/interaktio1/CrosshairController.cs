using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    public GameObject crosshair;  // Das Crosshair-UI-Element

    void Start()
    {
        // Crosshair verstecken oder anzeigen, wenn benötigt
        crosshair.SetActive(true);  // Wenn du es immer angezeigt haben möchtest
    }

    void Update()
    {
        // Du kannst hier später noch Code hinzufügen, um das Crosshair z.B. bei bestimmten Aktionen auszublenden
    }
}
