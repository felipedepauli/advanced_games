using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;


public class Mover : MonoBehaviour
{
//  A ray is a structure that holds and controls the space for Unity
    Ray lastRay;

//  A target is a structure that holds and controls a target point
    [ SerializeField ] Transform target;   
    
    void Update()
    {
        //  If the player click the button, the camera will point to it 
            if (Input.GetMouseButtonDown(0)) {
                moveToCursor();
                // lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            }
        //  But it will be the destiny only if the character does not hit at something
        

        //  It's a good idea to draw it on the screen to Debug
            // Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
            // GetComponent<NavMeshAgent>().destination = target.position;

        //  
            UpdateAnimator();
    }
    private void moveToCursor()
    {
        //  The camera will point to cursor position all the time
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        //  But it will be the destiny only if the character does not hit at something
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);
            if (hasHit) {
                GetComponent<NavMeshAgent>().destination = hit.point;
            }
    }

    private void UpdateAnimator()
    {
        //  First we need the data from Character NavMeshAgent
            Vector3 velocity        = GetComponent<NavMeshAgent>().velocity;

        //  We got a lot of data, but we just want the velocity. Then we create a local variable
            Vector3 localVelocity   = transform.InverseTransformDirection(velocity); // It's necessary to transform a Global var into Local

        //  and extract the velocity from it
            float speed = localVelocity.z;

        //  In the end, we nee to send the velocity to animator, then it can change the sprint
            GetComponent<Animator>().SetFloat("forwardSpeed", speed); // Instead changing on hand

    }
}





        // It's a good idea to draw it on the screen to Debug
        // Debug.DrawRay(lastRay.origin, lastRay.direction * 100);