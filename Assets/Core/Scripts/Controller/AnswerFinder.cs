using System.Collections.Generic;
using Core.Scripts.View;
using UnityEngine;

namespace Core.Scripts.Controller
{
    public class AnswerFinder : MonoBehaviour
    {
        [SerializeField] private LayerMask _targetLayer;

        public List<AnswerItem> ShootRaycastToFindAnswers()
        {
            List<AnswerItem> foundItems = new List<AnswerItem>();
            
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, 
                Vector2.right, Mathf.Infinity, _targetLayer);
            
            foreach (var hit in hits)
            {
                if (hit.collider != null && hit.collider.tag.Equals(Tags.AnswerItem))
                {
                    if (hit.collider.TryGetComponent(out AnswerItem item))
                    {
                        foundItems.Add(item);
                    }
                }
            }

            return foundItems;
        }
    }
}