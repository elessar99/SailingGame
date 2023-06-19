using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public Text time;
    int sec= 0;
    int min= 0;
    public ShipController shipController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FixedUpdate()
    {
        // to write the time on the screen
        sec = (shipController.time / 50) % 60;
        min = (shipController.time / 50) / 60;
        time.text = "Time: " + min.ToString() + ":" + sec.ToString();
    }

}
