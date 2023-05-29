using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody body;
     int[,] bombermanLayout = new int[,]
    {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 0, 0, 0, 1, 0, 0, 0, 0, 1 },
        { 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 1, 1, 1, 0, 1, 1, 1, 0, 1 },
        { 1, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 0, 1, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    };
    private float movementSpeed = 1f;
    [SerializeField] float rowPos = -4f, colPos = -4f;
    // Start is called before the first frame update
    void Start()
    {
      //  Debug.Log("Hi"); printing
        body = GetComponent<Rigidbody>();
        Application.targetFrameRate = -1;
        body.collisionDetectionMode = CollisionDetectionMode.Continuous;

        body.MovePosition(new Vector3(rowPos, 1, colPos));

        Debug.Log(rowPos + " " + colPos);
    }

    private bool validMove(float newRow, float newCol)
    {
        Debug.Log(newRow + " " + newCol);
        // if (newRow < 0 || newRow >= 10 || newCol < 0 || newCol >= 10)
        //     return false;
        // return bombermanLayout[newRow, newCol] == 0;
        return true;
    }
    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown("right"))
        {
            if (validMove(rowPos, colPos + 1))
            {
                colPos += 1f;
                body.MovePosition(new Vector3((int) rowPos, 1, (int) colPos));
            }
        }
        if (Input.GetKeyDown("left"))
        {
            colPos -= 1f;
            body.MovePosition(new Vector3((int) rowPos, 1, (int) colPos));
        }
         if (Input.GetKeyDown("up"))
        {
            rowPos += 1f;
            body.MovePosition(new Vector3((int) rowPos, 1, (int) colPos));
        }
         if (Input.GetKeyDown("down"))
        {
            rowPos -= 1f;
            body.MovePosition(new Vector3((int) rowPos, 1, (int) colPos));
        }
        // if (Input.GetKeyDown("space"))
        // {
        //     Vector3 newPosition = body.transform.position + new Vector3(0, 1, 0);

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
        
    }

}
