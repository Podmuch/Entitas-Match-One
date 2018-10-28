using UnityEngine;

public class TimeInputController : MonoBehaviour
{
    Contexts _contexts;

    void Awake()
    {
        _contexts = Contexts.sharedInstance;
    }

    void Update()
    {
        _contexts.input.CreateEntity().AddTime(Time.deltaTime, Time.unscaledDeltaTime);
    }
}