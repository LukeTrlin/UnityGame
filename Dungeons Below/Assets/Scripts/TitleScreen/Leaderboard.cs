using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
public class Leaderboard : MonoBehaviour
{
  [SerializeField]
  private List<TextMeshProUGUI> names;
  [SerializeField]
  private List<TextMeshProUGUI> scores;


    private string publicLeaderboardKey =
    "a03c5e81ea6741e950aac7f95bd153bba818580650645abdc456030a7487c5f3";



    public void Start()
    {
        GetLeaderBoard();


    }
  public void GetLeaderBoard()
  {
    LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) => {
        int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
        for (int i = 0; i < loopLength; ++i)
        {
            names[i].text = msg[i].Username;
            scores[i].text = msg[i].Score.ToString();



        }

    }));
  }
 
 


public void SetLeaderboardEntry(string Username, int score)
{
    LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, Username, score, ((msg) => {
        Username.Substring(0, 3);
        GetLeaderBoard();


    }));
    LeaderboardCreator.ResetPlayer();

}
}
