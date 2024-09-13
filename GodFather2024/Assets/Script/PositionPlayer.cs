using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
public class PositionPlayer : MonoBehaviour
{
    [SerializeField]private List<TextMeshProUGUI> Names;
    [SerializeField] private List<TextMeshProUGUI> Pos;
    private string publicLeaderboardKey = "ba3c28f21071c93fc1038b73d3a39454e52d993894a3a76e42ca8e3161708156";
    public int keyPlayer;

    private void Start()
    {
        GetLeaderBoard();
    }
    public void GetLeaderBoard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) => {
            int loopLenght = (msg.Length < Names.Count) ? msg.Length : Names.Count;
            keyPlayer = Names.Count-1;
            for (int i = 0; i < loopLenght; i++)
            {
                Names[i].text = msg[i].Username;
                Pos[i].text = msg[i].Score.ToString();
            }
        }));
    }


    public void SetLeaderboardEntry(string username, int pos)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, pos, ((msg) =>
        {
            GetLeaderBoard();
        }));
    }

   
}
