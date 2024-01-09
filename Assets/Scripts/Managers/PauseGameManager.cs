using System;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameManager : MonoBehaviour
{
    public event Action Paused;
    public event Action Resumed;

    public void Pause()
    {
        Paused?.Invoke();
    }

    public void Resume()
    {
        Resumed?.Invoke();
    }
}
