using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightTilt : MonoBehaviour
{

    public float rotation;

    Vector3[] positions = new Vector3[10];
    int positionCounter;
    Vector3 positionAverage;

    public Transform playerSprite;

    void Start()
    {
        for (int i = 0; i < positions.Length; i++)
            positions[i] = transform.position;
    }

    void FixedUpdate()
    {
        positionAverage = Vector3.zero;

        for (int i = 0; i < positions.Length; i++)
            positionAverage += (transform.position - positions[i]).normalized;

        positionAverage /= positions.Length;

        positions[positionCounter] = transform.position;
        playerSprite.eulerAngles = new Vector3(0, 0, Time.deltaTime * (positionAverage.x * rotation));

        positionCounter++;
        if (positionCounter >= positions.Length)
            positionCounter = 0;
    }
}
