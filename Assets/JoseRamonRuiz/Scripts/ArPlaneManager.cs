using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI; // Importante para usar Text

public class PlaneCounter : MonoBehaviour
{
    public ARPlaneManager planeManager; // Asigna desde el inspector
    public Text planeCountText;         // Asigna el texto desde el inspector

    void Update()
    {
        if (planeManager != null && planeCountText != null)
        {
            int count = planeManager.trackables.count;
            planeCountText.text = "Planos: " + count;
        }
    }
}
