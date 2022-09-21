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
}





        // It's a good idea to draw it on the screen to Debug
        // Debug.DrawRay(lastRay.origin, lastRay.direction * 100);