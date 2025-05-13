using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenZoneManager : MonoBehaviour
{
    [SerializeField] GameObject greenZoneUI;

    // Start is called before the first frame update
    void Start()
    {
        greenZoneUI.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            greenZoneUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            greenZoneUI.SetActive(false);
        }
    }
}

