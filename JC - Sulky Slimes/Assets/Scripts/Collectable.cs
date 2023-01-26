using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public float distanceToMove;

    private Vector3 startingPosition;
    private Vector3 endingPosition;

    public float speed = 0.1f;
    public float direction = -1f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        endingPosition = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startingPosition.x)
        {
            direction = 1f;
        }

        if (transform.position.x > endingPosition.x)
        {
            direction = -1f;
        }

        transform.position = new Vector3 (transform.position.x + speed * direction * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
