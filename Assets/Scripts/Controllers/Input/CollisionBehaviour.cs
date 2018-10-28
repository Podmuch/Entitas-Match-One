using Entitas.Unity;
using UnityEngine;

public class CollisionBehaviour : MonoBehaviour
{
    private EntityLink link;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (link == null)
        {
            link = gameObject.GetEntityLink();
        }

        var targetLink = collision.gameObject.GetEntityLink();
        if (link != null && targetLink != null)
        {
            var mainEntity = link.entity as GameEntity;
            var targetEntity = targetLink.entity as GameEntity;
            var input = Contexts.sharedInstance.input.CreateEntity();
            input.AddCollision(mainEntity, targetEntity);
        }
    }
}