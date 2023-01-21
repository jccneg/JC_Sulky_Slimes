using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [Header("Mouse Info")]
    public Vector3 clickStartLocation;

    [Header("Physics")]
    public Vector3 launchVector;
    public float launchForce;
    public Vector3 launchPower;

    [Header("Slime")]
    public Transform slimeTransform;
    public Rigidbody slimeRigidbody;
    Vector3 originalSlimePosition;
    Quaternion originalSlimeRotation;
    public GameObject Slime;

    // Start is called before the first frame update
    void Start()
    {
        originalSlimePosition = slimeTransform.position;
        originalSlimeRotation = slimeTransform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickStartLocation = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mouseDifference = clickStartLocation - Input.mousePosition;
            launchVector = new Vector3(
                mouseDifference.x * 1f,
                mouseDifference.y * 1.2f,
                mouseDifference.y * 1.5f
            );
            slimeTransform.position = originalSlimePosition - launchVector / 500;
            launchVector.Normalize();
        }

        if (Input.GetMouseButtonUp(0))
        {
            slimeRigidbody.isKinematic = false;
            launchPower = launchForce * launchVector;
            slimeRigidbody.AddForce(launchPower);
            
        }

        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown("space"))
        {
            Slime.transform.position = originalSlimePosition;
            Slime.transform.rotation = originalSlimeRotation;
            slimeRigidbody.isKinematic = true;
        }
    }
}
