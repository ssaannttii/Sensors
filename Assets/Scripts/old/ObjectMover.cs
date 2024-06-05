using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Server;


public class ObjectMover : MonoBehaviour
{
    public GameObject quad;

    public void UpdateQuadPosition(Vector3 sensorData)
    {
        // Mover el quad basado en los datos del sensor
        quad.transform.position += sensorData * Time.deltaTime;
    }
}
