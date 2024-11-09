using UnityEngine;

namespace CodeBase.Gameplay.Common.PhysicsService
{
    public interface IPhysicsService
    {
        int CircleCastGround(Vector3 position, float circleOffsetY, float circleRadius, int layerMask);
        int CircleCastCube(Vector3 position, float circleOffsetY, float circleRadius, int layerMask, GameObject parent);
        Collider2D[] CircleCastCollider(Vector3 position, float circleOffsetX, float circleRadius, int layerMask);
        int OverlapCircle(Vector3 worldPos, float radius, Collider2D[] hits, int layerMask);
    }
}