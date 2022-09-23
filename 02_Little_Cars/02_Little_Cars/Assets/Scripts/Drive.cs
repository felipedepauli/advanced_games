using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public WheelCollider WC;
    public GameObject wheelMesh;
    public float maxTorque = 200;
    public float maxSteerAngle = 30;
    public bool canTurn = false;
    public float maxBrakeTorque = 500;

    // Start is called before the first frame update
    void Start()
    {
        WC = this.GetComponent<WheelCollider>();
    }
    // Update is called once per frame
    // Here we get the direction os arrows
    // void Update()
    // {
    //     float a = Input.GetAxis("Vertical");
    //     float s = Input.GetAxis("Horizontal");
    //     go(a, s);
    // }



    public void go(float accel, float steer, float brake)
    {
        accel = Mathf.Clamp(accel, -1, 1);
        
        float trustTorque = accel * maxTorque;
        WC.motorTorque = trustTorque;
        
        if (canTurn) {
            steer = Mathf.Clamp(steer, -1, 1) * maxSteerAngle;
            WC.steerAngle = steer;
        }
        else {
            brake = Mathf.Clamp(brake, -1, 1) * maxBrakeTorque;
            WC.brakeTorque = brake;
        }
            

        Quaternion quat;
        Vector3 position;
        WC.GetWorldPose(out position, out quat);
        wheelMesh.transform.position = position;
        wheelMesh.transform.rotation = quat;
    }
}
