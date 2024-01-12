using UnityEngine;

public class ApplicationFPS : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
