using UnityEngine;
using TMPro;

public class ErrorDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _errorText;

    public void DisplayError(Error error)
    {
        _errorText.text = error.Message;
    }
}
