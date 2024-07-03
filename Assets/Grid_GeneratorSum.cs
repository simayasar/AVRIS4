using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_GeneratorSum : MonoBehaviour
{

    public GameObject gridObject;
    public GameObject tomato;
    public GameObject potato;
    public GameObject aub;

    public int rows = 10;
    public int columns = 6;
    public float spacing = 0.5f;
    public float vertSpacing = 1.0f;
    public int startrow = 0;
    public int startcolumn = -5;

    public GameObject badTomatoPrefab;
    public GameObject okTomatoPrefab;
    public GameObject goodTomatoPrefab;
    public GameObject badAubPrefab;
    public GameObject okAubPrefab;
    public GameObject goodAubPrefab;



    // Start is called before the first frame update
    void Start()
    {
        //GenerateGrid();
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



    /*
    public void GenerateTomato()
    {
        vertSpacing = 2.0f;
        //Debug.Log("entered tomato function");
        for (int i = startcolumn; i < columns; i++)
        {
            //Debug.Log("entered loop");
            for (int j = startrow; j < rows; j++)
            {
                if ((j * vertSpacing <= 20) && (j * vertSpacing >= -20))
                {
                    Debug.Log("entered snd loop");
                    Vector3 position = new Vector3(i * spacing + 0.5f, 0, j * vertSpacing);
                    Debug.Log("tomato position ready");
                    Instantiate(tomato, position, Quaternion.identity);
                    Debug.Log("tomato placed");

                }


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
        vertSpacing = 1.0f;

        for (int i = startcolumn; i < columns; i++)
        {
            for (int j = startrow; j < rows; j++)
            {
                if ((j * vertSpacing <= 20) && (j * vertSpacing >= -20))
                {
                    Vector3 position = new Vector3(i * spacing, 0, j * vertSpacing);
                    Instantiate(aub, position, Quaternion.identity);
                }


            }
        }
    }

    */
    public void DeactivatePlants()
    {
        GameObject[] plants = GameObject.FindGameObjectsWithTag("Plant");
        foreach (GameObject plant in plants)
        {
            Destroy(plant);
        }
        GameObject[] tomatoes = GameObject.FindGameObjectsWithTag("Tomato");
        foreach (GameObject tomato in tomatoes)
        {
            Destroy(tomato);
        }

        GameObject[] aubs = GameObject.FindGameObjectsWithTag("Aub");
        foreach (GameObject aub in aubs)
        {
            Destroy(aub);
        }


        Debug.Log("All plants deactivated");
    }

    public void GenerateTomato()
    {
        DeactivatePlants();
        for (int i = startcolumn; i < columns; i++)
        {
            for (int j = startrow; j < rows; j++)
            {
                if ((j * vertSpacing <= 20) && (j * vertSpacing >= -20))
                {
                    Vector3 position = new Vector3(i * spacing + 0.5f, 0.2f, j * vertSpacing);
                    GameObject newTomato = Instantiate(tomato, position, Quaternion.identity);
                    newTomato.tag = "Tomato";
                    Debug.Log("Tomato placed");
                }
            }
        }
    }

        public void GenerateAub()
        {
            DeactivatePlants();
            for (int i = startcolumn; i < columns; i++)
            {
                for (int j = startrow; j < rows; j++)
                {
                    if ((j * vertSpacing <= 20) && (j * vertSpacing >= -20))
                    {
                        Vector3 position = new Vector3(i * spacing + 0.5f, 0.2f, j * vertSpacing);
                        GameObject newAub = Instantiate(aub, position, Quaternion.identity);
                        newAub.tag = "Aub";
                        Debug.Log($"Aub placed at {position}");
                    }

                }
            }
        }

        //try
        public void GeneratePlants(string seedType, int score)
    {
        DeactivatePlants();

        GameObject plantPrefab = null;

        Debug.Log($"Generating plants for seed type: {seedType} with score: {score}");

        if (seedType == "Tomato")
        {
            if (score >= 0 && score <= 1) plantPrefab = badTomatoPrefab;
            else if (score == 2) plantPrefab = okTomatoPrefab;
            else if (score >= 3 && score <= 4) plantPrefab = goodTomatoPrefab;
        }
        else if (seedType == "Aub")
        {
            if (score >= 0 && score <= 1) plantPrefab = badAubPrefab;
            else if (score == 2) plantPrefab = okAubPrefab;
            else if (score >= 3 && score <= 4) plantPrefab = goodAubPrefab;
        }

        if (plantPrefab != null)
        {
            for (int i = startcolumn; i < columns; i++)
            {
                for (int j = startrow; j < rows; j++)
                {
                    if ((j * vertSpacing <= 20) && (j * vertSpacing >= -20))
                    {
                        Vector3 position = new Vector3(i * spacing + 0.5f, 0.2f, j * vertSpacing);
                        GameObject newPlant = Instantiate(plantPrefab, position, Quaternion.identity);
                        newPlant.tag = "Plant";
                        Debug.Log($"{seedType} placed with score {score}");
                    }
                }
            }
        }
        else
        {
            Debug.LogError("No plant prefab found");
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
