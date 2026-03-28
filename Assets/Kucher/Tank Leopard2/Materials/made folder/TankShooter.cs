using UnityEngine;

public class TankShooter : MonoBehaviour
{
    [Header("Shooting")]
    public GameObject shellPrefab;
    public Transform firePoint;
    public KeyCode shootKey = KeyCode.Space;

    [Header("Shell Settings")]
    public float shellSpeed = 50f;
    public float shellLifetime = 5f;

    [Header("Cooldown")]
    public float fireCooldown = 0.5f;

    // Enum declared OUTSIDE the class fields — no Header on enum
    public enum FireDirection { Forward, Up, Right, Back }

    [Header("Debug - Try each until shell flies forward")]
    public FireDirection fireDirection = FireDirection.Forward;

    private float lastFireTime = -999f;

    void Awake()
    {
        if (firePoint == null)
        {
            Transform found = transform.Find("FirePoint");
            if (found != null) firePoint = found;
        }

        if (shellPrefab == null)
            Debug.LogWarning($"[TankShooter] shellPrefab not assigned on '{gameObject.name}'!", gameObject);
        if (firePoint == null)
            Debug.LogWarning($"[TankShooter] firePoint not assigned on '{gameObject.name}'!", gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(shootKey))
            TryShoot();
    }

    void TryShoot()
    {
        if (Time.time < lastFireTime + fireCooldown)
            return;

        lastFireTime = Time.time;
        Shoot();
    }

    void Shoot()
    {
        if (shellPrefab == null || firePoint == null) return;

        GameObject shell = Instantiate(shellPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = shell.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;

            Vector3 direction;
            switch (fireDirection)
            {
                case FireDirection.Up: direction = firePoint.up; break;
                case FireDirection.Right: direction = firePoint.right; break;
                case FireDirection.Back: direction = -firePoint.forward; break;
                default: direction = firePoint.forward; break;
            }

            rb.linearVelocity = direction * shellSpeed;
            Debug.Log($"[TankShooter] Fired in {fireDirection} direction at speed {shellSpeed}");
        }
        else
        {
            Debug.LogWarning("[TankShooter] Shell prefab has no Rigidbody!", shell);
        }

        Destroy(shell, shellLifetime);
    }

    void OnDrawGizmosSelected()
    {
        if (firePoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(firePoint.position, 0.1f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(firePoint.position, firePoint.forward * 3f);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(firePoint.position, firePoint.up * 3f);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(firePoint.position, firePoint.right * 3f);
    }
}