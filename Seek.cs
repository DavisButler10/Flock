using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehavior
{
    public Kinematic character;
    public GameObject target;

    public float maxAcceleration = 1f;
    public float maxSpeed = 1f;

    public bool flee = false;

    protected virtual Vector3 getTargetPosition()
    {
        return target.transform.position;
    }

    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();


        result.linear = getTargetPosition() - character.transform.position;
        //Debug.Log(result.linear);
        if (result.linear.magnitude >= maxSpeed)
        {
            result.linear.Normalize();
            result.linear *= maxAcceleration;
        }
        else {
            result.linear.Normalize();
        }
        

        result.angular = 0;
        return result;
    }
}