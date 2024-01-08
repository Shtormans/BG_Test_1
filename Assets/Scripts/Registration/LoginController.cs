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
    }
}
