using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circuit : MonoBehaviour
{
    public GameObject[] waypoints;

    void OnDrawGizmos()
    {
        drawGizmos(false);
    }
    void onDrawGizmosSelected()
    {
        drawGizmos(true);
    }
    void drawGizmos(bool selected)
    {
        if (selected == false) return;
        if (waypoints.Length > 1) {
            Vector3 prev = waypoints[0].transform.position;
            for (int i = 1; i < waypoints.Length; i++) {
                Vector3 next = waypoints[i].transform.position;
                Gizmos.DrawLine(prev, next);
            }
            Gizmos.DrawLine(prev, waypoints[0].transform.position);
        }
    }
}
