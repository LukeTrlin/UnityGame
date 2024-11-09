using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
public class Leaderboardscript : MonoBehaviour
{
  public static bool NullName = false;
  [SerializeField]
  private List<TextMeshProUGUI> names;
  [SerializeField]
  private List<TextMeshProUGUI> scores;

  


    private string publicLeaderboardKey =
    "a537b6b77dbb2cd728fbf2040d314a9c0e1313996a28bb2f6429c92cc745446a";



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
