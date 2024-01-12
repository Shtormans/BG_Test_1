using UnityEngine;
using TMPro;

public class LoginController : MonoBehaviour
{
    [SerializeField] private TMP_InputField _email;
    [SerializeField] private TMP_InputField _password;

    [SerializeField] private ErrorDisplayer _errorDisplayer;

    public void Login()
    {
        var emailResult = Email.Create(_email.text);
        if (emailResult.IsFailure)
        {
            _errorDisplayer.DisplayError(emailResult.Error);
            return;
        }

        var passwordResult = Password.Create(_password.text);
        if (passwordResult.IsFailure)
        {
            _errorDisplayer.DisplayError(passwordResult.Error);
            return;
        }

        User user = new User()
        {
            Email = emailResult.Value,
            Password = passwordResult.Value
        };

        FirebaseRepository.Instance.LoginUser(user, LoginFinished);
    }

    private void LoginFinished(Result result)
    {
        if (result.IsFailure)
        {
            _errorDisplayer.DisplayError(result.Error);
        }
        else
        {
            SceneController.ChangeSceneToGame();
        }
    }
}
