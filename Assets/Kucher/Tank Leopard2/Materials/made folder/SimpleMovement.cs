using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    void Update()
    {
        // Forward / Backward movement
        float move = Input.GetAxis("Vertical"); // W / S
        transform.Translate(Vector3.forward * move * moveSpeed * Time.deltaTime);

        // Rotation (left / right)
        float turn = Input.GetAxis("Horizontal"); // A / D
        transform.Rotate(Vector3.up * turn * rotationSpeed * Time.deltaTime);
    }
}
