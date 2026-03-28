using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float shipSpeed = 10f;
    public float rotationSpeed = 50f;
    public ShipControlStation controlStation;
    public Rigidbody playerRb; // reference to player Rigidbody

    void Update()
    {
        if (controlStation.playerInControlZone)
        {
            // Freeze player in pilot seat
            if (playerRb != null) playerRb.isKinematic = true;

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 move = transform.forward * v + transform.right * h;
            GetComponent<Rigidbody>().AddForce(move * shipSpeed * Time.deltaTime, ForceMode.VelocityChange);

            // Ship rotation
            float rotH = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float rotV = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotH, Space.World);
            transform.Rotate(Vector3.right, -rotV, Space.Self);
        }
        else
        {
            if (playerRb != null) playerRb.isKinematic = false;
        }
    }
}