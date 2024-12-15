using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandClimb : MonoBehaviour
{
    public ClimbingMechanic climbingMechanic;
    public bool isLeftHand;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {
            if (isLeftHand)
            {
                climbingMechanic.leftHandClimbing = true;
            }
            else
            {
                climbingMechanic.rightHandClimbing = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {
            if (isLeftHand)
            {
                climbingMechanic.leftHandClimbing = false;
            }
            else
            {
                climbingMechanic.rightHandClimbing = false;
            }
        }
    }
}
