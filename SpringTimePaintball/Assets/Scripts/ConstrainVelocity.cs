using UnityEngine;

public class ConstrainVelocity : MonoBehaviour
{
    public float maxSpeed;
    private Vector3 maxVelocity;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        maxVelocity = new Vector3(
            maxSpeed,
            maxSpeed,
            maxSpeed
        );
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude >= maxSpeed)
        {
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);
        }
    }

    public void SetMaxVelocity(float max)
    {
        maxSpeed = max;
        maxVelocity = new Vector3(
            maxSpeed,
            maxSpeed,
            maxSpeed
        );
    }
}
