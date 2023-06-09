using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody body;
    private int bombRadius = 6;
    public GameObject sphere;
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
    [SerializeField] int rowPos = -4, colPos = -4;
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
    private IEnumerator abc(int a)
    {
        Debug.Log(a);
        yield return new WaitForSeconds(2f);
        Debug.Log(45);
    }

    private bool validMove(int newRow, int newCol)
    {
        int rowHold = newRow + 5;
        int colHold = newCol + 5;
        if (rowHold < 0 || rowHold >= 10 || colHold < 0 || colHold >= 10)
             return false;
         return bombermanLayout[rowHold, colHold] == 0;
    }
    private void SpawnSphere(int row, int col)
    {
        Instantiate(sphere, new Vector3(row, 1, col), Quaternion.identity);
    }
    // Update is called once per frame
    private IEnumerator bfs(int row, int col, int radius)
    {
        if (radius <= 0)
            yield break;
        if (row + 5 < 0 || row + 5 >= 10 || col + 5 < 0 || col + 5 >= 10)
            yield break;
        bombermanLayout[row + 5, col + 5] = 2;
        bool top = validMove(row - 1, col);
        bool bottom = validMove(row + 1, col);
        bool left = validMove(row, col - 1);
        bool right = validMove(row, col + 1) ;
        if (top)
        {
            SpawnSphere(row - 1, col);
          //  bfs(row - 1, col, radius - 1);
        }
        if (bottom)
        {
            SpawnSphere(row + 1, col);
         //   bfs(row+ 1, col, radius - 1);
        }
        if (left)
        {
            SpawnSphere(row, col - 1);
         //   bfs(row, col - 1, radius - 1);
        }
        if (right)
        {
            SpawnSphere(row, col + 1);
        //    bfs(row, col + 1, radius - 1);
        }
        yield return new WaitForSeconds(1f);
        radius--;
        if (top)
        {
            StartCoroutine(bfs(row - 1, col, radius));
        }
        if (bottom)
        {
            StartCoroutine(bfs(row + 1, col, radius));
        }
        if (left)
        {
            StartCoroutine(bfs(row, col - 1, radius));
        }
        if (right)
        {
            StartCoroutine(bfs(row, col + 1, radius));
        }

    }
    void Update()
    { 
        if (Input.GetKeyDown("right"))
        {
            if (validMove(rowPos, colPos + 1))
            {
                colPos += 1;
                body.MovePosition(new Vector3((int) rowPos, 1, (int) colPos));
            }
        }
        if (Input.GetKeyDown("left"))
        {
            if (validMove(rowPos, colPos - 1))
            {
                colPos -= 1;
                body.MovePosition(new Vector3((int) rowPos, 1, (int) colPos));
            }
        }
        if (Input.GetKeyDown("up"))
        {
            if (validMove(rowPos - 1, colPos))
            {
                rowPos -= 1;
                body.MovePosition(new Vector3((int) rowPos, 1, (int) colPos));
            }
        }
        if (Input.GetKeyDown("down"))
        {
            if (validMove(rowPos + 1, colPos))
            {
                rowPos += 1;
                body.MovePosition(new Vector3((int) rowPos, 1, (int) colPos));
            }
        }
    
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space");
            StartCoroutine(bfs(rowPos, colPos, bombRadius));
          ;
        }
  
       
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
