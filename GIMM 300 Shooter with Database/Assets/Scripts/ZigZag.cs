using UnityEngine;
using System.Collections;

public class ZigZag : MonoBehaviour
{
    public float tilt;
    private float lapsPerSecond;
    public Boundary boundary;

    private float horizontalSpeed;
    private Rigidbody rb;

    private float newXPos;

    void Start()
    {
        lapsPerSecond = Random.Range(0.1f, 0.75f);
        rb = GetComponent<Rigidbody>();

        horizontalSpeed = lapsPerSecond * ((float) 0.02) * boundary.xMax * 2;
    }

    void FixedUpdate()
    {

        newXPos = rb.position.x + horizontalSpeed;
        if (newXPos > boundary.xMax)
        {
            newXPos = boundary.xMax;
            horizontalSpeed *= -1;
        } else if (newXPos < boundary.xMin)
        {
            newXPos = boundary.xMin;
            horizontalSpeed *= -1;
        }

        rb.position = new Vector3
            ( newXPos, 0.0f, Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax) );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}