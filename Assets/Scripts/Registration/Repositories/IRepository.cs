using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRepository
{
    void RegisterUser(User user);

    void LoginUser(User user);
}

