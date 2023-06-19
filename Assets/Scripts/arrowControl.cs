using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrowControl : MonoBehaviour
{
    public Color newColor;
    private Rigidbody rb;
    public ShipController shipController;
    private Renderer objectRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        objectRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // We adjust the rotation according to the direction of the wind
        Quaternion targetRotation = Quaternion.Euler(0, (shipController.wind + 60f)%360, 90f);
        transform.rotation = targetRotation;
        // We set the color we get from the ship as the color of the arrow
        newColor = shipController.color;
        ChangeObjectColor();
    }
    public void ChangeObjectColor()
    {
        objectRenderer.material.color = newColor;
    }
}
