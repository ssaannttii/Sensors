using UnityEngine;

public class AccelerometerController : MonoBehaviour
{
    public GameObject quad;
    public float speed = 10.0f;

    void Update()
    {
        Vector3 acceleration = Input.acceleration;

        // Mover el objeto basado en el acelerómetro
        Vector3 movement = new Vector3(acceleration.x, 0, acceleration.y) * speed * Time.deltaTime;
        quad.transform.Translate(movement);
    }
}
