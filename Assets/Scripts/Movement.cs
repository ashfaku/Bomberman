using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody body;
    private float movementDistance = 1f;
    // Start is called before the first frame update
    void Start()
    {
      //  Debug.Log("Hi"); printing
        body = GetComponent<Rigidbody>();
        Application.targetFrameRate = -1;
        body.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    // Update is called once per frame
    void Update()
    { 
        // if (Input.GetKeyDown("space"))
        // {
        //     Vector3 newPosition = body.transform.position + new Vector3(0, 1, 0);

        //     body.MovePosition(newPosition);
        // }
        // if (Input.GetKeyDown("left"))
        // {

        //     Vector3 newPosition = body.transform.position + new Vector3(-1, 0, 0);

        //     body.MovePosition(newPosition);
        // }
        //  if (Input.GetKeyDown("right"))
        // {

        //     Vector3 newPosition = body.transform.position + new Vector3(1, 0, 0);

        //     body.MovePosition(newPosition);
        // }
        // if (Input.GetKeyDown("up"))
        // {

        //     Vector3 newPosition = body.transform.position + new Vector3(0, 0, 1);

        //     body.MovePosition(newPosition);
        // }
        // if (Input.GetKeyDown("down"))
        // {

        //     Vector3 newPosition = body.transform.position + new Vector3(0, 0, -1);

        //     body.MovePosition(newPosition);
        // }
          
        // float horizontal = Input.GetAxis("Horizontal");
        // float vertical = Input.GetAxis("Vertical");
        // body.velocity = new Vector3(horizontal * movementSpeed, body.velocity.y, vertical * movementSpeed);
        // if (Input.GetKeyDown("space"))
        //     body.velocity = new Vector3(-body.velocity.x, 10f, -body.velocity.z);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        Vector3 movement = new Vector3(0f, 0f, -movementDistance);
        body.MovePosition(body.position + movement);
    }
}
