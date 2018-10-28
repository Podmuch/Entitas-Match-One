using Entitas.Unity;
using UnityEngine;

public class TriggerEnterBehaviour : MonoBehaviour
{
    private EntityLink link;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (link == null)
        {
            link = gameObject.GetEntityLink();
        }
        var targetLink = collision.gameObject.GetEntityLink();
        if (targetLink == null)
        {
            targetLink = collision.gameObject.GetComponentInParent<EntityLink>();
        }
        
        if (link != null && targetLink != null)
        {
            var mainEntity = link.entity as GameEntity;
            var targetEntity = targetLink.entity as GameEntity;
           var input = Contexts.sharedInstance.input.CreateEntity();
            input.AddCollision(mainEntity, targetEntity);
        }
    }
}
