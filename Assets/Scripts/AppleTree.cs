using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Tree Movement")]
    public float speed = 5f;
    public float leftAndRightDistance = 10f;

    [Header("Apple Spawning")]
    public GameObject applePrefab;
    public float appleDropDelay = 2f;

    private Vector3 startPosition;
    private int direction = 1;
    private float appleDropTime;

    void Start()
    {
        startPosition = transform.position;
        appleDropTime = appleDropDelay;
    }

    void Update()
    {
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        if (transform.position.x > startPosition.x + leftAndRightDistance)
        {
            direction = -1;
        }
        else if (transform.position.x < startPosition.x - leftAndRightDistance)
        {
            direction = 1;
        }

        appleDropTime -= Time.deltaTime;

        if (appleDropTime <= 0)
        {
            DropApple();
            appleDropTime = appleDropDelay;
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate (
            applePrefab,
            transform.position,
            Quaternion.identity
        );
    }
}


