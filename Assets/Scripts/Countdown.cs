using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text countdown;
    public ShipController shipController;
    public int countdownIndex = 10;
    public int startTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // to write the countdown on the screen
        if (shipController.countdownIndex > 0)
        {
            countdownIndex = (shipController.countdownIndex / 50) % 60 +1;
            countdown.text = "Countdown: " + countdownIndex;
        }
    }

    private void FixedUpdate()
    {
        // when the countdown ends, to type start and write the next text
        if (shipController.countdownIndex == 0 && startTime < 50)
        {
            startTime++;
            countdown.text = "Start....";
        }
        else if (startTime == 50)
        {
            startTime++;
            countdown.text = "";
        }

    }
}
