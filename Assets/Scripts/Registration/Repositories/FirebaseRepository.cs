using Firebase;
using Firebase.Auth;
using System;
using System.Collections;
using UnityEngine;

public class FirebaseRepository : MonoBehaviour, IRepository
{
    [SerializeField] private DependencyStatus _dependencyStatus;
    private FirebaseAuth _auth;

    private void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            _dependencyStatus = task.Result;

            if (_dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + _dependencyStatus);
            }
        });
    }

    private void InitializeFirebase()
    {
        _auth = FirebaseAuth.DefaultInstance;
    }

    public void LoginUser(User user)
    {
        StartCoroutine(Login(user));
    }

    public void RegisterUser(User user)
    {
        StartCoroutine(Register(user));
    }

    private IEnumerator Register(User user)
    {
        var registerTask = _auth.CreateUserWithEmailAndPasswordAsync(user.Email.Value, user.Password.Value);
        
        yield return new WaitUntil(() => registerTask.IsCompleted);

        if (registerTask.Exception != null)
        {
            yield break;
        }

        FirebaseUser firebaseUser = registerTask.Result;

        UserProfile profile = new UserProfile()
        {
            DisplayName = user.Username.Value
        };

        var profileTask = firebaseUser.UpdateUserProfileAsync(profile);

        yield return new WaitUntil(() => profileTask.IsCompleted);

        Debug.Log("Registered");
    }

    private IEnumerator Login(User user)
    {
        var loginTask = _auth.SignInWithEmailAndPasswordAsync(user.Email.Value, user.Password.Value);

        yield return new WaitUntil(() => loginTask.IsCompleted);

        if (loginTask.Exception != null)
        {
            yield break;
        }

        FirebaseUser firebaseUser = loginTask.Result;
        Debug.Log($"{firebaseUser.DisplayName} {firebaseUser.Email}");
    }
}
