using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UploaDataGPS : MonoBehaviour
{
    GPSLocation gpsLocation;
    PositionPlayer positionPlayer;
    private int i = 0;
    private string pos;

    private void FixedUpdate()
    {
        i++;
        if (i == 60)
        {
            i = 0;
            UploadGPS();
        }
    }

    private void UploadGPS()
    {
        pos = gpsLocation.Lat + "/" + gpsLocation.Long + "/" + gpsLocation.Alt;
        positionPlayer.SetLeaderboardEntry(pos, positionPlayer.keyPlayer);
    }
}
