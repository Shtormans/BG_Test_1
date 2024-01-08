using UnityEngine;
using TMPro;

public class RegistrationController : MonoBehaviour
{
    [SerializeField] private TMP_InputField _username;
    [SerializeField] private TMP_InputField _email;
    [SerializeField] private TMP_InputField _password;
    [SerializeField] private TMP_InputField _confirmedPassword;

    [SerializeField] private ErrorDisplayer _errorDisplayer;

    public void Register()
    {
        var usernameResult = Username.Create(_username.text);
        if (usernameResult.IsFailure)
        {
            _errorDisplayer.DisplayError(usernameResult.Error);
            return;
        }

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

        var confirmedPasswordResult = ConfirmedPassword.Create(_confirmedPassword.text, passwordResult.Value);
        if (confirmedPasswordResult.IsFailure)
        {
            _errorDisplayer.DisplayError(confirmedPasswordResult.Error);
            return;
        }

        User user = new User()
        {
            Username = usernameResult.Value,
            Email = emailResult.Value,
            Password = passwordResult.Value
        };
    }
}