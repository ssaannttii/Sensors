using UnityEngine;

public class BoardController : MonoBehaviour
{
    public float maxTiltAngle = 30.0f;   // Ángulo máximo de inclinación en grados
    public float smoothing = 0.1f;       // Factor de suavizado

    private Vector3 smoothedAcceleration;

    void Start()
    {
        // Inicializar el valor suavizado con la aceleración inicial
        smoothedAcceleration = Input.acceleration;
    }

    void Update()
    {
        Vector3 acceleration = Input.acceleration;

        // Aplicar suavizado
        smoothedAcceleration = Vector3.Lerp(smoothedAcceleration, acceleration, smoothing);

        // Convertir la aceleración suavizada a ángulos de inclinación
        float tiltAroundZ = Mathf.Clamp(smoothedAcceleration.x * maxTiltAngle, -maxTiltAngle, maxTiltAngle);
        float tiltAroundX = Mathf.Clamp(smoothedAcceleration.y * maxTiltAngle, -maxTiltAngle, maxTiltAngle);

        // Crear una nueva rotación basada en los ángulos calculados
        Quaternion targetRotation = Quaternion.Euler(tiltAroundX, 0, -tiltAroundZ);

        // Aplicar la rotación directamente al tablero
        transform.rotation = targetRotation;
    }
}
