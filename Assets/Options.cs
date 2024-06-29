using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.Experimental.Rendering;

public class OptionsMenu1 : MonoBehaviour
{

    bool weather;
    bool seed;
    bool soil;
    public bool pipes;
    public bool furrow;
    public bool sprinkler;
    public bool terraced;

    public GameObject buttons;
    public PipeGenerator pipeGenerator;
    public WaterGenerator waterGenerator;
    public Grid_Generator gridGenerator;
    public Grid_GeneratorSp grid_GeneratorSp;
    private Light directionalLight;
    private Dropdown drowpdown;
    private TMP_Dropdown myDropdownWeather;
    private TMP_Dropdown myDropdownSeed;
    private TMP_Dropdown myDropdownSoil;
    private TMP_Dropdown myDropdownIrrigation;
    private GameObject BUTTONS;    





    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("pressed");

        BUTTONS = GameObject.Find("Canvas");
        // Get dropdown for weather
        GameObject weather = BUTTONS.transform.Find("Buttons").gameObject.transform.Find("Weather").gameObject;
        myDropdownWeather = weather.GetComponent<TMP_Dropdown>();
        Debug.Log("found" + myDropdownWeather);

        //Get dropdown for seed
        GameObject seed = BUTTONS.transform.Find("Buttons").gameObject.transform.Find("Seed Type").gameObject;
        myDropdownSeed = seed.GetComponent<TMP_Dropdown>();
        Debug.Log("found" + myDropdownSeed);

        //Get drowpdown for soil
        GameObject soil = BUTTONS.transform.Find("Buttons").gameObject.transform.Find("Soil Type").gameObject;
        myDropdownSoil = soil.GetComponent<TMP_Dropdown>();
        Debug.Log("found" + myDropdownSoil);

        //Get dropdown for irrigation
        GameObject irrigation = BUTTONS.transform.Find("Buttons").gameObject.transform.Find("Irrigation System").gameObject;
        myDropdownIrrigation = irrigation.GetComponent<TMP_Dropdown>();
        Debug.Log("found" +  myDropdownIrrigation);

        pipeGenerator = GameObject.Find("XR Origin (XR Rig)").GetComponent<PipeGenerator>();
        Debug.Log("pipeGenerator ready");

        waterGenerator = GameObject.Find("XR Origin (XR Rig)").GetComponent <WaterGenerator>();
        Debug.Log("waterGenerator ready");

        gridGenerator = GameObject.Find("XR Origin (XR Rig)").GetComponent<Grid_Generator>();
        Debug.Log("waterGenerator ready");

        grid_GeneratorSp = GameObject.Find("XR Origin (XR Rig)").GetComponent<Grid_GeneratorSp>();
     




    }

    // Update is called once per frame

    void Update()
    {
        
    }
    public void StartApp()
    {
        Debug.Log("pressed");
        directionalLight = FindObjectOfType<Light>();
        Debug.Log("Found directional light:" + directionalLight.name);
        //directionalLight.enabled = false;
        directionalLight.color = Color.red;
    }
    public void OnDropdownValueChanged(int index)
    {
        //int selectedIndex = myDropdown.value;
        //TMP_Dropdown.OptionData selectedOption = myDropdownWeather.options[index];
        
        //Debug.Log("Dropdown value changed! Index: " + index);


        switch (myDropdownWeather.value)
        {
            case 1: // Summer
                ChangeToSummer();
                Debug.Log("changed to summer");
                break;
            case 2: // Winter
                ChangeToWinter();
                Debug.Log("changed to winter");
                break;
            case 3: // Fall
                ChangeToFall();
                Debug.Log("changed to fall");
                break;
            case 4: // Spring
                ChangeToSpring();
                Debug.Log("changed to spring");
                break;

        }

        switch (myDropdownIrrigation.value)
        {
            case 0: // Drip
                changeToDrip();
                Debug.Log("pipes activated");
                break;
            case 1: // Sprinkler
                Debug.Log("changed to sprinkler");
                break;
            case 2: // Furrow
                changeToFurrow();
                Debug.Log("changed to furrow");
                break;
            case 3: // Terraced
                Debug.Log("changed to terraced");
                break;

        }

        switch (myDropdownSeed.value) 
        {
            
            case 0: //Tomato
                changeToTomato();
                break;
            case 1: // Potato
                Debug.Log("no potato");
                break;
            case 2: // Aub
                changeToAub();
                break;

        }





    }

    private void ChangeToSummer()
    {
        SceneManager.LoadScene(4);
    }
    private void ChangeToWinter()
    {
        SceneManager.LoadScene(5);
    }
    private void ChangeToFall()
    {
        SceneManager.LoadScene(3);
    }
    private void ChangeToSpring()
    {
        SceneManager.LoadScene(6);
    }
    private void changeToDrip()
    {
        //waterGenerator.DeactivateWater();
        pipeGenerator.GeneratePipes();
    }
    private void changeToFurrow()
    {
        waterGenerator.GenerateWater();
    }
    private void changeToTomato() 
    {
        grid_GeneratorSp.GenerateTomato();
        Debug.Log("Changed to Tomato");
    }
    private void changeToAub()
    {
        grid_GeneratorSp.GenerateAub();
    }
}
