using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextureChanger : MonoBehaviour
{
    public Renderer soilRenderer1;
    public Renderer soilRenderer2;  
    public Renderer soilRenderer3;  
    public Texture sandySoilTexture;
    public Texture loamySoilTexture;
    public Texture claySoilTexture;
   

    void Start()
    {
        
        
            soilRenderer1.material.mainTexture = loamySoilTexture;
            soilRenderer2.material.mainTexture = loamySoilTexture;
            soilRenderer3.material.mainTexture = loamySoilTexture;
        
    }

    public void ChangeToSandySoil()
    {
       
        
            soilRenderer1.material.mainTexture = sandySoilTexture;
            soilRenderer2.material.mainTexture = sandySoilTexture;
            soilRenderer3.material.mainTexture = sandySoilTexture;
            Debug.Log("Changed to Sandy Soil");
        
    }

    public void ChangeToLoamySoil()
    {
        
        
            soilRenderer1.material.mainTexture = loamySoilTexture;
            soilRenderer2.material.mainTexture = loamySoilTexture;
            soilRenderer3.material.mainTexture = loamySoilTexture;
            Debug.Log("Changed to Loamy Soil");
        
    }

    public void ChangeToClaySoil()
    {
       
            soilRenderer1.material.mainTexture = claySoilTexture;
            soilRenderer2.material.mainTexture = claySoilTexture;
            soilRenderer3.material.mainTexture = claySoilTexture;
            Debug.Log("Changed to Clay Soil");
        
    }
}
