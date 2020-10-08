using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    private float verticalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        var newPosition = new Vector3(0.0f, verticalSpeed, 0.0f);
        transform.position -= newPosition;
    }

    private void Reset()
    {
        transform.position = new Vector3(0.0f, 10.0f, 0.0f);
    }

    private void CheckBounds()
    {
        if (transform.position.y <= -10)
        {
            Reset();
        }
    }
}
