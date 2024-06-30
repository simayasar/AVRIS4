using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGenerator : MonoBehaviour
{
    public GameObject water;
    public OptionsMenu1 options;
    // Start is called before the first frame update
    void Start()
    {
        options = GameObject.Find("Canvas").gameObject.transform.GetComponent<OptionsMenu1>();
        Debug.Log("options script ready");

    }
    public void GenerateWater()
    {
        Vector3 position = new Vector3(0.0f, 0.15f, 0.0f);
        water.transform.localScale = new Vector3(1.1f, 1.0f, 4.0f);

        GameObject newWater = Instantiate(water, position, Quaternion.identity);
        newWater.tag = "Water";
        //options.furrow = true;
    }

    public void DeactivateWater()
    {
        GameObject[] waters = GameObject.FindGameObjectsWithTag("Water");
        foreach (GameObject water in waters)
        {
            Destroy(water);
        }
        Debug.Log("water deactivated");
        //water.SetActive(false);
        //Debug.Log("water deactivated");

    }

    // Update is called once per frame 
    void Update()
    {
        
    }
}
