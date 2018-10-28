using System.Collections.Generic;
using System.Linq;
using Entitas;

public sealed class InputSystem : ReactiveSystem<InputEntity>, ICleanupSystem {

    readonly Contexts _contexts;
    readonly IGroup<InputEntity> _input;
    readonly List<InputEntity> _inputBuffer = new List<InputEntity>();

    public InputSystem(Contexts contexts) : base(contexts.input) {
        _contexts = contexts;
        _input = contexts.input.GetGroup(InputMatcher.PressPoint);
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
        return context.CreateCollector(InputMatcher.PressPoint);
    }

    protected override bool Filter(InputEntity entity) {
        return entity.hasPressPoint;
    }

    protected override void Execute(List<InputEntity> entities) {
        var inputEntity = entities.SingleEntity();
        var input = inputEntity.pressPoint;

        foreach (var e in _contexts.game.GetEntitiesWithPosition(new IntVector2(input.x, input.y)).Where(e => e.isInteractive)) {
            e.isDestroyed = true;
        }
    }

    public void Cleanup() {
        foreach (var e in _input.GetEntities(_inputBuffer)) {
            e.Destroy();
        }
    }
}
