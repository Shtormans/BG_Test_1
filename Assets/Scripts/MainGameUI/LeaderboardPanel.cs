using TMPro;
using UnityEngine;

public class LeaderboardPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _usernameText;
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void SetData(string username, string score)
    {
        _usernameText.text = username;
        _scoreText.text = score;
    }

    public void MakeUsernameBold()
    {
        _usernameText.fontStyle = FontStyles.Bold;
    }
}
