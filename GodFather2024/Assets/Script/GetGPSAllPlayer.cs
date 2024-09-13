using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGPSAllPlayer : MonoBehaviour
{
    PositionPlayer positionPlayer;
    private int i;
    private void FixedUpdate()
    {
        i++;
        if (i == 60)
        {
            i = 0;
            positionPlayer.GetLeaderBoard();
        }
    }
}
