using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float horizontalSpeed;
    [SerializeField]
    private Rigidbody2D rb;
    public float maximumVelocity;
    public float horizontalBoundary;
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var touch in Input.touches)
        {
            if (Camera.main.ScreenToWorldPoint(touch.position).x > transform.position.x)
            {
                rb.velocity = Move(1.0f) * 0.95f;
            }

            if (Camera.main.ScreenToWorldPoint(touch.position).x < transform.position.x)
            {
                rb.velocity = Move(-1.0f) * 0.95f;
            }
            Debug.Log(Camera.main.ScreenToWorldPoint(touch.position));
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            rb.velocity = Move(1.0f) * 0.95f;
        }
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            rb.velocity = Move(-1.0f) * 0.95f;
        }

        CheckBounds();
        if (Time.frameCount % 50 == 0)
        {
            gameController.GetBullet(transform.position);
        }

    }

    private void CheckBounds()
    {
        if (transform.position.x <= -horizontalBoundary)
        {
            transform.position = new Vector3(-horizontalBoundary, transform.position.y, transform.position.z);
        }

        if (transform.position.x >= horizontalBoundary)
        {
            transform.position = new Vector3(horizontalBoundary, transform.position.y, transform.position.z);
        }
    }

    private Vector2 Move(float dir)
    {
        var newVelocity = new Vector2(horizontalSpeed * dir, 0.0f);
        
        return Vector2.ClampMagnitude(rb.velocity + newVelocity, maximumVelocity);
    }
}
