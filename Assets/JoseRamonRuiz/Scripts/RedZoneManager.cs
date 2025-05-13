using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZoneManager : MonoBehaviour
{
    [SerializeField] GameObject redZoneUI;

    // Start is called before the first frame update
    void Start()
    {
        redZoneUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            redZoneUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            redZoneUI.SetActive(false);
        }
    }
}
