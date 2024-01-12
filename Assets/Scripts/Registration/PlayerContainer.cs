using UnityEngine;

public class PlayerContainer : MonoBehaviour
{
    private int _maxScore;

    public int MaxScore => _maxScore;

    private void Awake()
    {
        FirebaseRepository.Instance.GetMaxScore(OnGetMaxScoreCompleted);
    }

    public void SetMaxScore(int maxScore)
    {
        _maxScore = maxScore;
    }

    private void OnGetMaxScoreCompleted(Result<int> result)
    {
        SetMaxScore(result.Value);
    }
}
