using Entitas;

[Input]
public sealed class PressPointComponent : IComponent
{
    public int x;
    public int y;
}

[Input]
public sealed class CollisionComponent : IComponent
{
    public GameEntity from;
    public GameEntity to;
}

[Input]
public sealed class TimeComponent : IComponent
{
    public float deltaTime;
    public float unscaledDeltaTime;
}
