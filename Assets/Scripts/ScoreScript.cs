using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text score;
    public ShipController shipController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //to write the score on the screen
        if (shipController.keylock) 
        {
            score.text = "Score: " +shipController.score.ToString();
        }
        
    }
}
