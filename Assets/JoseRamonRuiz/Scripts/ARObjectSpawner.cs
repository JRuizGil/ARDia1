using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.EventSystems; //  Para detectar interacción con UI
using System.Collections.Generic;

public class ARPlacementController : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public Dropdown prefabDropdown;
    public List<GameObject> prefabOptions;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private List<GameObject> spawnedObjects = new List<GameObject>();

    void Update()
    {
        // Detectar toque en pantalla o clic del mouse
#if UNITY_EDITOR
        // En el editor usamos clic izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Input.mousePosition;

            // Evitar si se hizo clic sobre UI
            if (IsPointerOverUI(clickPosition)) return;

            HandlePlacement(clickPosition);
        }
#else
    // En móvil usamos Touch
    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
    {
        Touch touch = Input.GetTouch(0);

        // Evitar si el toque fue sobre UI
        if (IsPointerOverUI(touch.position)) return;

        HandlePlacement(touch.position);
    }
#endif
    }
    public void ClearAllSpawnedObjects()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        spawnedObjects.Clear();
        Debug.Log("Todas las instancias han sido eliminadas.");
    }
    private void HandlePlacement(Vector2 screenPosition)
    {
        if (raycastManager.Raycast(screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            int selectedIndex = prefabDropdown.value;

            if (selectedIndex >= 0 && selectedIndex < prefabOptions.Count)
            {
                GameObject newObject = Instantiate(prefabOptions[selectedIndex], hitPose.position, hitPose.rotation);
                spawnedObjects.Add(newObject);
            }
            else
            {
                Debug.LogWarning("Índice de prefab no válido.");
            }
        }
    }
    private bool IsPointerOverUI(Vector2 position)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = position;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }


}
