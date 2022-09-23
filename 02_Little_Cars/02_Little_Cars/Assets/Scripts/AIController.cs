using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    Drive[] ds;
    public Circuit circuit;
    public float steeringSensitivity = 0.01f;
    Vector3 target;
    int currentWP = 0;
    Rigidbody rb;
    public GameObject breakLightLeft;
    public GameObject breakLightRight;
    
    // Start is called before the first frame update
    void Start()
    {
        ds = this.GetComponentsInChildren<Drive>();
        target = circuit.waypoints[currentWP].transform.position;
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 localTarget = this.transform.InverseTransformPoint(target);
        float distanceToTarget = Vector3.Distance(target, this.transform.position);
        float targetAngle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

        float a = 15.5f;
        float s = Mathf.Clamp(targetAngle * steeringSensitivity, -1, 1) * Mathf.Sign(rb.velocity.magnitude);
        float b = 0;

        if (distanceToTarget < 10) {
            b = 0.5f;
        }

        for (int i = 0; i < ds.Length; i++)
            ds[i].go(a, s, b);

        if (b > 0) {
            breakLightRight.SetActive(true);
            breakLightLeft.SetActive(true);
        } else {
            breakLightRight.SetActive(false);
            breakLightLeft.SetActive(false);
        }

        if (distanceToTarget < 4) {
            currentWP++;
            if(currentWP >= circuit.waypoints.Length)
                currentWP = 0;

            target = circuit.waypoints[currentWP].transform.position;
        }
    }
}
