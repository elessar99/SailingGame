using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuoyArrow : MonoBehaviour
{
    public Color newColor;
    public NesnePuan nPuan;
    public ShipController shipController;
    private Renderer objectRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
        objectRenderer = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // We make the arrow on the object that is to be collected green, if it is the not then red
        if (shipController.puan == nPuan.puan)
        {
            newColor = Color.green;
        }
        else
        {
            newColor = Color.red;
        }
        ChangeObjectColor();
    }
    public void ChangeObjectColor()
    {
        objectRenderer.material.color = newColor;
    }
}
