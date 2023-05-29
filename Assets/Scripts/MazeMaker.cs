using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMaker : MonoBehaviour
{
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
    public GameObject boxPrefab; // Reference to the box prefab
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            if (bombermanLayout[i, j] == 1)           
                SpawnBox(new Vector3(i-5,1,j-5));
        }
    }
    void SpawnBox(Vector3 position)
    {
        Instantiate(boxPrefab, position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
