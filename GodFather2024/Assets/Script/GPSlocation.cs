using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using Unity.VisualScripting;

public class GPSLocation : MonoBehaviour
{
    public Image testImg;
    public Text gpsOut;
    public int i;
    public float Alt;
    public float Long;
    public float Lat;
    void Start()
    {
        StartCoroutine(RunGPS());
    }

    IEnumerator RunGPS()
    {
        // Check if the user has location service enabled.
        if (!Input.location.isEnabledByUser)
            Debug.Log("Location not enabled on device or app does not have permission to access location");

        // Starts the location service.
        Input.location.Start(5f, 0.5f);

        // Waits until the location service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // If the service didn't initialize in 20 seconds this cancels location service use.
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }

        // If the connection failed this cancels location service use.
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.LogError("Unable to determine device location");
            yield break;
        }
        else
        {
            Alt = Input.location.lastData.latitude;
            Lat = Input.location.lastData.latitude;
            Long = Input.location.lastData.longitude;
            // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
            gpsOut.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
        }

        // Stops the location service if there is no need to query location updates continuously.
        Input.location.Stop();
        yield return new WaitForSeconds(1);
        
    }
}