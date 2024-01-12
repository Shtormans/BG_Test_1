using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    private void Awake()
    {
        FirebaseRepository.Instance.DatabaseLoaded += OnDatabaseLoaded;
    }

    private void OnDatabaseLoaded()
    {
        if (FirebaseRepository.Instance.CheckIfPlayerIsSignedIn())
        {
            SceneController.ChangeSceneToGame();
        }
        else
        {
            SceneController.ChangeSceneToMainMenu();
        }
    }
}

