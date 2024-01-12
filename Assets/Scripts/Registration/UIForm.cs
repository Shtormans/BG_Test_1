using TMPro;
using UnityEngine;

public class UIForm : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _errorText;

    public void Disable()
    {
        _errorText.text = string.Empty;
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }
}
