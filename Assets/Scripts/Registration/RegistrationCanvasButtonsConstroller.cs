using UnityEngine;

public class RegistrationCanvasButtonsController : MonoBehaviour
{
    [SerializeField] private Canvas _registrationCanvas;
    [SerializeField] private Canvas _loginCanvas;

    public void ChangeToLogin()
    {
        _registrationCanvas.gameObject.SetActive(false);
        _loginCanvas.gameObject.SetActive(true);
    }

    public void ChangeToRegistration()
    {
        _registrationCanvas.gameObject.SetActive(true);
        _loginCanvas.gameObject.SetActive(false);
    }
}
