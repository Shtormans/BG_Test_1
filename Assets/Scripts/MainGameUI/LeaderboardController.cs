using System.Collections.Generic;
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
    [SerializeField] private Transform _leaderboardScroll;
    [SerializeField] private LeaderboardPanel _leaderboardPanel;

    public void UpdateLeaderboardTable(List<UserWithScore> users)
    {
        var currentUserId = FirebaseRepository.Instance.GetCurrentUserId();

        foreach (var user in users)
        {
            LeaderboardPanel panel = Instantiate(_leaderboardPanel, _leaderboardScroll);
            panel.SetData(user.Username, user.Score.ToString());

            if (user.UserId == currentUserId)
            {
                panel.MakeUsernameBold();
            }
        }
    }
}
