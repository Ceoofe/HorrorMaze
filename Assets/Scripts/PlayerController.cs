using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static int health = 100;
    public float speed;
    public float jump;
    Rigidbody rb;
    bool isGrounded = true;
    public static bool isCinemaMode = true;
    bool lowFuel = false;
    bool rotateCam = false;
    GameObject cinema;
    Transform mainCam;
    GameObject flashLight;
    bool isOn = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("NoFuel");
        cinema = GameObject.Find("Canvas/Cinema");
        mainCam = transform.Find("Main Camera");
        flashLight = transform.Find("Main Camera/Spot Light").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isCinemaMode)
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.F) && !isCinemaMode)
        {
            if (isOn)
            {
                flashLight.SetActive(false);
                isOn = false;
            }
            else if (isOn == false)
            {
                flashLight.SetActive(true);
                isOn = true;
            }
        }
    }

    void FixedUpdate() // Movement
    {
        if (isCinemaMode) // No movement
        {
            transform.Translate(Vector3.forward * Mathf.Pow(speed, 3) * Time.deltaTime);
            if (lowFuel)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (rotateCam)
            {
                mainCam.Rotate(0,0,0.1f, Space.World);
            }
            return;
        }

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * hor * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * ver * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    IEnumerator NoFuel()
    {
        yield return new WaitForSeconds(18f);
        lowFuel = true;
        yield return new WaitForSeconds(1f);
        rotateCam = true;
        yield return new WaitForSeconds(.5f);
        isCinemaMode = false;
        cinema.SetActive(false);
    }
}
