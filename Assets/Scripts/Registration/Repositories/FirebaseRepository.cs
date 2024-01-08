using UnityEngine;

public class FirebaseRepository : MonoBehaviour, IRepository
{
    public void LoginUser(User user)
    {
        throw new System.NotImplementedException();
    }

    public void RegisterUser(User user)
    {
        string json = JsonConverter.SerializeResponse(user);


    }
}
