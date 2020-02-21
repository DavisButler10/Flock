using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separation : SteeringBehavior
{
    public Kinematic character;
    public Kinematic[] targets;

    private float maxAcceleration = 25f;
    private float threshold = 5f;
    private float decayCoefficient = 10f;


    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        for (int i = 0; i < targets.Length; i++)
        {
            Vector3 direction = character.transform.position - targets[i].transform.position;
            float distance = direction.magnitude;


            if (distance < threshold)
            {
                float strength = Mathf.Min(decayCoefficient / (distance * distance), maxAcceleration);

                direction = direction.normalized;
                result.linear += strength * direction;
            }
            
        }
        return result;
    }
}