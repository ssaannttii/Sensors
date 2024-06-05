using UnityEngine;

public class BoardController : MonoBehaviour
{
    public float maxTiltAngle = 30.0f;   // �ngulo m�ximo de inclinaci�n en grados
    public float smoothing = 0.1f;       // Factor de suavizado

    private Vector3 smoothedAcceleration;

    void Start()
    {
        // Inicializar el valor suavizado con la aceleraci�n inicial
        smoothedAcceleration = Input.acceleration;
    }

    void Update()
    {
        Vector3 acceleration = Input.acceleration;

        // Aplicar suavizado
        smoothedAcceleration = Vector3.Lerp(smoothedAcceleration, acceleration, smoothing);

        // Convertir la aceleraci�n suavizada a �ngulos de inclinaci�n
        float tiltAroundZ = Mathf.Clamp(smoothedAcceleration.x * maxTiltAngle, -maxTiltAngle, maxTiltAngle);
        float tiltAroundX = Mathf.Clamp(smoothedAcceleration.y * maxTiltAngle, -maxTiltAngle, maxTiltAngle);

        // Crear una nueva rotaci�n basada en los �ngulos calculados
        Quaternion targetRotation = Quaternion.Euler(tiltAroundX, 0, -tiltAroundZ);

        // Aplicar la rotaci�n directamente al tablero
        transform.rotation = targetRotation;
    }
}
