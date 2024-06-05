using System;
using WebSocketSharp;
using WebSocketSharp.Server;
using UnityEngine;

public class DataReceiver : WebSocketBehavior
{
    protected override void OnMessage(MessageEventArgs e)
    {
        string data = e.Data;
        // Aquí procesarías los datos recibidos del móvil
        ProcessSensorData(data);
    }

    void ProcessSensorData(string data)
    {
        // Parsear los datos del sensor y realizar alguna acción en Unity
        Debug.Log("Datos recibidos del sensor: " + data);
    }
}

public class WebSocketServerScript : MonoBehaviour
{
    private WebSocketServer wss;

    void Start()
    {
        // Inicializa y comienza el servidor WebSocket
        wss = new WebSocketServer("ws://0.0.0.0:8080"); // Escucha en todas las interfaces de red
        wss.AddWebSocketService<DataReceiver>("/SensorData");
        wss.Start();
        Debug.Log("Servidor WebSocket iniciado en ws://0.0.0.0:8080");
    }

    void OnDestroy()
    {
        // Detiene el servidor WebSocket cuando se destruye el GameObject
        if (wss != null)
        {
            wss.Stop();
            Debug.Log("Servidor WebSocket detenido.");
        }
    }
}
