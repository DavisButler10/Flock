using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorAndWeight
{
    public SteeringBehavior behavior = null;
    public float weight = 0f;
}

public class BlendedSteering : MonoBehaviour
{
    public BehaviorAndWeight[] behaviors;

    float maxAcceleration = 1f;
    float maxRotation = 5f;

    public SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        foreach(BehaviorAndWeight b in behaviors)
        {
            SteeringOutput s = b.behavior.getSteering();
            if(s != null)
            {
                result.linear += s.linear * b.weight;
                result.angular += s.angular * b.weight;
            }
        }
        result.linear = result.linear.normalized * maxAcceleration * Mathf.Min(maxAcceleration, result.linear.magnitude);
        float angularAcc = Mathf.Abs(result.angular);
        if(angularAcc > maxRotation)
        {
            result.angular /= angularAcc;
            result.angular *= maxRotation;
        }
        return result;
    }
}
