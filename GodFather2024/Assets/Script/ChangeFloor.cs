using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFloor : MonoBehaviour
{
    [SerializeField] GameObject[] Floors;
    [SerializeField] Button prevBtn;
    [SerializeField] Button nextBtn;
    private GameObject prevFloor;
    private GameObject nextFloor;
    private GameObject currentFloor;

    private void Start()
    {
        for (int i = 0; i < Floors.Length; i++)
        {
            if (Floors[i].gameObject.activeInHierarchy)
            {
                Floors[i - 1] = prevFloor;
                Floors[i + 1] = nextFloor;
                Floors[i] = currentFloor;
            }
        }
    }

    void Update()
    {
        Debug.Log(currentFloor.gameObject.name);
    }

    public void CurrentFloor()
    {
        for (int i = 0; i < Floors.Length; i++)
        {
            if (Floors[i].activeInHierarchy)
            {
                Floors[i - 1] = prevFloor;
                Floors[i + 1] = nextFloor;
                Floors[i] = currentFloor;
            }
        }
    }
    public void ChangeNextFloor()
    {
        currentFloor.gameObject.SetActive(false);
        currentFloor = nextFloor;
        currentFloor.gameObject.SetActive(true);

    }
    public void ChangePrevFloor()
    {
        currentFloor.gameObject.SetActive(false);
        currentFloor = prevFloor;
        currentFloor.gameObject.SetActive(true);
    }
}
