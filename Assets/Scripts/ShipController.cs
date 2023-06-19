using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{
    Vector3 currentVelocity;
    Quaternion currentRotation;
    private Rigidbody rb;
    public bool keylock = false;
    bool keyW = false;
    bool keyS = false;
    bool keyA = false;
    bool keyD = false;
    float moveSpeed = 35f;
    public float wind;
    public int puan;
    public float score;
    public int time;
    public int countdownIndex;
    public Color color;
    public bool finish = false;

    private float currentZRotation = 0f;
    private float currentYRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        countdownIndex = 150;
        keylock =false;
        time = 0;
        puan = 0;
        score = 0f;
        rb = GetComponent<Rigidbody>();
        wind = UnityEngine.Random.Range(0, 360f);

    }
    // Update is called once per frame
    void Update()
    {
        currentRotation = rb.rotation;
        currentVelocity = rb.velocity;
        // Getting pressed keys
        if (!keylock)
        {
            if (Input.GetKey("w"))
            {
                keyW = true;
            }
            if (Input.GetKey("a"))
            {
                keyA = true;
            }
            if (Input.GetKey("d"))
            {
                keyD = true;
            }
        }
    }
    private void FixedUpdate()
    {
        currentRotation = rb.rotation;
        currentVelocity = rb.velocity;
        // if all the objects are collected we end the game
        if (puan == 100)
        {
            keylock = true;
            score = time;
            Invoke("restart", 5f);
            finish = true;
        }
        // Countdown
        if (countdownIndex>0)
        {
            countdownIndex--;
        }
        else
        {
            if(!finish)
            {
                time++;
            }
            // If she presses W, we apply thrust with different forces according to the direction of the wind.
        if (keyW)
        {
            if (wind<240)
            {
                if (transform.rotation.eulerAngles.y > wind && transform.rotation.eulerAngles.y < wind+120f)
                {
                    if(transform.rotation.eulerAngles.y > wind + 30f && transform.rotation.eulerAngles.y < wind + 90f)
                    {
                        rb.AddForce(transform.forward * 2f, ForceMode.VelocityChange);
                    }
                    else
                    {
                        rb.AddForce(transform.forward * 1.5f, ForceMode.VelocityChange);
                    }
                }
                else
                {
                    rb.AddForce(transform.forward * 1f, ForceMode.VelocityChange);
                }
            }
            else
            {
                if (transform.rotation.eulerAngles.y > wind || transform.rotation.eulerAngles.y < (wind + 120f) % 360)
                {
                    if (wind < 270)
                    {
                        if (transform.rotation.eulerAngles.y > wind + 30f && transform.rotation.eulerAngles.y < wind + 90f)
                        {
                            rb.AddForce(transform.forward * 2f, ForceMode.VelocityChange);
                        }
                        else
                        {
                            rb.AddForce(transform.forward * 1.5f, ForceMode.VelocityChange);
                        }
                    }
                    else
                    {
                        if (transform.rotation.eulerAngles.y > wind + 30f || transform.rotation.eulerAngles.y < (wind + 90f) % 360)
                        {
                            rb.AddForce(transform.forward * 2f, ForceMode.VelocityChange);
                        }
                        else
                        {
                            rb.AddForce(transform.forward * 1.5f, ForceMode.VelocityChange);
                        }
                    }
                }
                else
                {
                    rb.AddForce(transform.forward * 1f, ForceMode.VelocityChange);
                }
            }
           
            keyW = false;
            
        }
        if (keyA && keyD)
        { 
            keyA = false;
            keyD = false;
        }
            // We make the rotation settings with the A and D keys.
        if (keyA && !keyD)
        {
            transform.Rotate(Vector3.up, -moveSpeed * 3 / 2 * Time.deltaTime);
            float currentY = transform.rotation.eulerAngles.y;
            float currentZ = transform.rotation.eulerAngles.z;
            if (transform.rotation.eulerAngles.z < 19 || currentZ > 341)
            {
                //to slowly change
                transform.rotation = Quaternion.Euler(0, currentY, currentZ + 1);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, currentY, 20);
            }
            keyA = false;
        }
        if (keyD && !keyA)
        {

            transform.Rotate(Vector3.up, +moveSpeed *3/2 * Time.deltaTime);
            float currentY = transform.rotation.eulerAngles.y;
            float currentZ = transform.rotation.eulerAngles.z;
            if (transform.rotation.eulerAngles.z > 341 || currentZ < 19)
            {
              transform.rotation = Quaternion.Euler(0, currentY, (currentZ+360 - 1) %360);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, currentY, -20);
            }
            
            keyD = false;
        }
        // We determine the color of the arrow on the sailing according to its direction
        if (wind < 240)
        {
            if (transform.rotation.eulerAngles.y > wind && transform.rotation.eulerAngles.y < wind + 120f)
            {
                if (transform.rotation.eulerAngles.y > wind + 30f && transform.rotation.eulerAngles.y < wind + 90f)
                {
                    color = Color.green;
                }
                else
                {
                    color = Color.yellow;
                }
            }
            else
            {
                color = Color.red;
            }
        }
        else
        {
            if (transform.rotation.eulerAngles.y > wind || transform.rotation.eulerAngles.y < (wind + 120f) % 360)
            {
                if (wind < 270)
                {
                    if (transform.rotation.eulerAngles.y > wind + 30f && transform.rotation.eulerAngles.y < wind + 90f)
                    {
                        color = Color.green;
                    }
                    else
                    {
                        color = Color.yellow;
                    }
                }
                else
                {
                    if (transform.rotation.eulerAngles.y > wind + 30f || transform.rotation.eulerAngles.y < (wind + 90f) % 360)
                    {
                        color = Color.green;
                    }
                    else
                    {
                        color = Color.yellow;
                    }
                }
            }
            else
            {
                color = Color.red;
            }
        }
        }
    }
    // When the game is over
    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }


    public GameObject[] areaNesneleri;
    public AudioSource audioSource;
    // We make him collect the objects it needs to collect in order
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "area")
        {
            int nesnePuan = collision.GetComponent<NesnePuan>().puan; 
            if (nesnePuan == puan)
            {
                rb.angularVelocity = Vector3.zero;
                Destroy(collision.gameObject);
                rb.velocity = currentVelocity;
                rb.rotation = currentRotation;
                puan += 10;
                Debug.Log(puan);
                if (nesnePuan == 90)
                {
                    audioSource.Play();
                }
            }
        }
    }
}
