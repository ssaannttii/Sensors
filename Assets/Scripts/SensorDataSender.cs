using UnityEngine;
using WebSocketSharp;
using System;

public class SensorDataSender : MonoBehaviour
{
    private WebSocket ws;

    void Start()
    {
        try
        {
            // Usa la dirección IP de tu PC
            ws = new WebSocket("ws://192.168.1.1:8080/SensorData");

            // Manejar eventos del WebSocket
            ws.OnOpen += (sender, e) => Debug.Log("WebSocket opened.");
            ws.OnMessage += (sender, e) => Debug.Log("WebSocket message received: " + e.Data);
            ws.OnError += (sender, e) => Debug.LogError("WebSocket error: " + e.Message);
            ws.OnClose += (sender, e) => Debug.LogWarning("WebSocket closed: " + e.Reason);

            ws.Connect();
            Debug.Log("WebSocket connected.");
        }
        catch (Exception e)
        {
            Debug.LogError("WebSocket connection failed: " + e.Message);
        }
    }

    void Update()
    {
        if (ws != null && ws.IsAlive)
        {
            // Obtener datos del acelerómetro
            Vector3 acceleration = Input.acceleration;

            // Enviar los datos como JSON al servidor WebSocket
            ws.Send(JsonUtility.ToJson(acceleration));
            Debug.Log("Datos enviados: " + JsonUtility.ToJson(acceleration));
        }
        else
        {
            Debug.LogWarning("WebSocket is not connected.");
        }
    }

    void OnDestroy()
    {
        // Cerrar la conexión WebSocket al destruir el GameObject
        if (ws != null)
        {
            ws.Close();
            Debug.Log("WebSocket closed.");
        }
    }
}
