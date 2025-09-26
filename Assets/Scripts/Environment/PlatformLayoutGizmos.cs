using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLayoutGizmos : MonoBehaviour
{
    [Header("Layout References")]
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    [SerializeField] private Transform highestPoint;
    [SerializeField] private Transform lowestPoint;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(start.position, new Vector2(start.position.x, start.position.y + 1000));
        Gizmos.DrawLine(start.position, new Vector2(start.position.x, start.position.y - 1000));

        Gizmos.DrawLine(end.position, new Vector2(end.position.x, end.position.y + 1000));
        Gizmos.DrawLine(end.position, new Vector2(end.position.x, end.position.y - 1000));

        Gizmos.DrawLine(highestPoint.position, new Vector2(highestPoint.position.x + 1000, highestPoint.position.y));
        Gizmos.DrawLine(highestPoint.position, new Vector2(highestPoint.position.x - 1000, highestPoint.position.y));

        Gizmos.DrawLine(lowestPoint.position, new Vector2(lowestPoint.position.x + 1000, lowestPoint.position.y));
        Gizmos.DrawLine(lowestPoint.position, new Vector2(lowestPoint.position.x - 1000, lowestPoint.position.y));
    }
}
