using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_GeneratorSp : MonoBehaviour
{

    public GameObject gridObject;
    public GameObject tomato;
    public GameObject potato;
    public GameObject aub;

    public int rows = 10;
    public int columns = 6;
    public float spacing = 0.5f;

    public int startrow = 0;
    public int startcolumn = -5;



    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        Debug.Log("fuck you");
    }

    public void GenerateGrid()
    {

        for (int i = startcolumn; i < columns; i++)
        {
            Debug.Log("outer loop");
            for (int j = startrow; j < rows; j++)
            {
                Debug.Log("entered inner loop");
                Vector3 position = new Vector3(i * spacing, 0, j * spacing);
                GameObject obj = Instantiate(gridObject, position, Quaternion.identity);
                if (!obj) Debug.LogError("Failed to instantiate gridObject!");

            }
        }

    }

    public void GenerateTomato()
    {
        //Debug.Log("entered tomato function");
        for (int i = startcolumn; i < columns; i++)
        {
            //Debug.Log("entered loop");
            for (int j = startrow; j < rows; j++)
            {
                Debug.Log("entered snd loop");
                Vector3 position = new Vector3(i * spacing, 0, j * spacing);
                Debug.Log("tomato position ready");
                Instantiate(tomato, position, Quaternion.identity);
                Debug.Log("tomato placed");

            }
        }
    }

    public void GeneratePotato()
    {
        for (int i = startcolumn; i < columns; i++)
        {
            for (int j = startrow; j < rows; j++)
            {
                Vector3 position = new Vector3(i * spacing, 0, j * spacing);
                Instantiate(potato, position, Quaternion.identity);

            }
        }
    }

    public void GenerateAub()
    {
        for (int i = startcolumn; i < columns; i++)
        {
            for (int j = startrow; j < rows; j++)
            {
                Vector3 position = new Vector3(i * spacing, 0, j * spacing);
                Instantiate(aub, position, Quaternion.identity);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
