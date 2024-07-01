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
    public Grid_GeneratorW grid_GeneratorW;
    public Grid_GeneratorF grid_GeneratorF;
    public Grid_GeneratorSum grid_GeneratorSum;
    public TextureChanger textureChanger;
    private Light directionalLight;
    private Dropdown drowpdown;
    private TMP_Dropdown myDropdownWeather;
    private TMP_Dropdown myDropdownSeed;
    private TMP_Dropdown myDropdownSoil;
    private TMP_Dropdown myDropdownIrrigation;
    private TMP_Dropdown myDropdownDistance;
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

        //Get dropdown fo distance
        GameObject distance = BUTTONS.transform.Find("Buttons").gameObject.transform.Find("Distance").gameObject;
        myDropdownDistance = distance.GetComponent<TMP_Dropdown>();

        pipeGenerator = GameObject.Find("XR Origin (XR Rig)").GetComponent<PipeGenerator>();
        Debug.Log("pipeGenerator ready");

        waterGenerator = GameObject.Find("XR Origin (XR Rig)").GetComponent <WaterGenerator>();
        Debug.Log("waterGenerator ready");

        gridGenerator = GameObject.Find("XR Origin (XR Rig)").GetComponent<Grid_Generator>();
        Debug.Log("waterGenerator ready");

        textureChanger = GameObject.Find("XR Origin (XR Rig)").GetComponent<TextureChanger>(); 

        grid_GeneratorSp = GameObject.Find("XR Origin (XR Rig)").GetComponent<Grid_GeneratorSp>();

        grid_GeneratorW = GameObject.Find("XR Origin (XR Rig)").GetComponent<Grid_GeneratorW>();

        grid_GeneratorF = GameObject.Find("XR Origin (XR Rig)").GetComponent<Grid_GeneratorF>();

        grid_GeneratorSum = GameObject.Find("XR Origin (XR Rig)").GetComponent<Grid_GeneratorSum>();


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
        DeactivateAllIrrigationSystems();
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
                ActivateDrip();
                Debug.Log("pipes activated");
                break;
            case 1: // Sprinkler
                Debug.Log("changed to sprinkler");
                break;
            case 2: // Furrow
                ActivateFurrow();
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
      
            case 1: // Aub
                changeToAub();
                break;

        }

       
        switch (myDropdownSoil.value)
        {
            case 0: // Sandy Soil
                textureChanger.ChangeToLoamySoil();
                break;
            case 1: // Loamy Soil
                textureChanger.ChangeToSandySoil();
                break;
            case 2: // Clay Soil
               textureChanger.ChangeToClaySoil();
                break;
        }

        switch (myDropdownDistance.value)
        {
            case 0: //30cm
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    grid_GeneratorF.spacing = 1;
                }
                else if (SceneManager.GetActiveScene().buildIndex == 4)
                {
                    grid_GeneratorSum.spacing = 1;
                }
                else if (SceneManager.GetActiveScene().buildIndex == 5)
                {
                    grid_GeneratorW.spacing = 1;
                }
                else if (SceneManager.GetActiveScene().buildIndex == 6)
                {
                    grid_GeneratorSum.spacing = 1;
                }
                else { break; }
                
                
                
                Debug.Log("Changed to 30cm");
                break;
            case 1: //60cm

                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    grid_GeneratorF.spacing = 2;
                }
                else if (SceneManager.GetActiveScene().buildIndex == 4)
                {
                    grid_GeneratorSum.spacing = 2;
                }
                else if (SceneManager.GetActiveScene().buildIndex == 5)
                {
                    grid_GeneratorW.spacing = 2;
                }
                else if (SceneManager.GetActiveScene().buildIndex == 6)
                {
                    grid_GeneratorSp.spacing = 2;
                }
                else { break; }
                Debug.Log("Changed to 60cm");
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

    private void DeactivateAllIrrigationSystems()
    {
        waterGenerator.DeactivateWater();
        pipeGenerator.DeactivatePipes();
        
    }
    private void ActivateDrip()
    {
        pipeGenerator.GeneratePipes();
    }

    private void ActivateFurrow()
    {
        waterGenerator.GenerateWater();
    }

    private void changeToTomato() 
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 3: //Fall
                grid_GeneratorF.GenerateTomato();
                break;
            case 4: // Summer
                grid_GeneratorSum.GenerateTomato();
                break;
            case 5: // Winter
                grid_GeneratorW.GenerateTomato();
                break;
            case 6: // Spring
                grid_GeneratorSp.GenerateTomato();
                break;
            case 1:
                gridGenerator.GenerateTomato();
                break;



        }
    }
    private void changeToAub()
    {
      
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 3: //Fall
                grid_GeneratorF.GenerateAub();
                break;
            case 4: // Summer
                grid_GeneratorSum.GenerateAub();
                break;
            case 5: // Winter
                grid_GeneratorW.GenerateAub();
                break;
            case 6: // Spring
                grid_GeneratorSp.GenerateAub();
                break;
            case 1:
                gridGenerator.GenerateAub();
                break;

        }
    }
    
}
