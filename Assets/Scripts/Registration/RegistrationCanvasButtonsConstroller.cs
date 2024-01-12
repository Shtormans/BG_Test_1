using UnityEngine;

public class RegistrationCanvasButtonsController : MonoBehaviour
{
    [SerializeField] private UIForm _registrationCanvas;
    [SerializeField] private UIForm _loginCanvas;

    public void ChangeToLogin()
    {
        _registrationCanvas.Disable();
        _loginCanvas.Enable();

    }

    public void ChangeToRegistration()
    {
        _loginCanvas.Disable();
        _registrationCanvas.Enable();
    }
}
