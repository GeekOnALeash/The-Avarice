using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Nav
{
    public sealed class Waypoint : MonoBehaviour
    {
        [SerializeField] private float debugDrawRadius = 0.08F;
        [SerializeField] private Color color = Color.red;

        private void OnDrawGizmos()
        {
            Gizmos.color = color;
            Gizmos.DrawWireSphere(transform.position, debugDrawRadius);
        }
    }
}