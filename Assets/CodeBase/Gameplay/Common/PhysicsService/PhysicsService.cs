using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Gameplay.Common.PhysicsService
{
    public class PhysicsService : IPhysicsService
    {
        private static readonly RaycastHit2D[] Hits = new RaycastHit2D[128];
        private static readonly Collider2D[] OverlapHits = new Collider2D[128];
    
      
        public int CircleCastGround(Vector3 position, float circleOffsetY, float circleRadius, int layerMask)
        {
            Vector2 playerCenter = (Vector2)position + new Vector2(0.0f, circleOffsetY);
            
            return Physics2D.OverlapCircleAll(playerCenter, circleRadius, layerMask).Length;
            
            
        }
        public int CircleCastCube(Vector3 position, float circleOffsetY, float circleRadius, int layerMask, GameObject parent)
        {
            Vector2 playerCenter = (Vector2)position + new Vector2(0.0f, circleOffsetY);
            
            Collider2D[] hits = Physics2D.OverlapCircleAll(playerCenter, circleRadius, layerMask);

            int count = 0;

            foreach (Collider2D hit in hits)
            {
                if (hit.gameObject != parent && !hit.transform.IsChildOf(parent.transform))
                {
                    count++;
                }
            }

            return count;

        }

        public Collider2D[] CircleCastCollider(Vector3 position, float circleOffsetX, float circleRadius, int layerMask)
        {
            Vector2 playerCenter = (Vector2)position + new Vector2(circleOffsetX, 0);

            return Physics2D.OverlapCircleAll(playerCenter, circleRadius, layerMask);
        }

        

        public int OverlapCircle(Vector3 worldPos, float radius, Collider2D[] hits, int layerMask) =>
            Physics2D.OverlapCircleNonAlloc(worldPos, radius, hits, layerMask);

        
        private static void DrawDebug(Vector2 worldPos, float radius, float seconds, Color color)
        {
            Debug.DrawRay(worldPos, radius * Vector3.up, color, seconds);
            Debug.DrawRay(worldPos, radius * Vector3.down, color, seconds);
            Debug.DrawRay(worldPos, radius * Vector3.left, color, seconds);
            Debug.DrawRay(worldPos, radius * Vector3.right, color, seconds);
        }
    }
}