using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    void Awake()
    {
        enabled = false;
    }

    [Header("Tree Movement")]
    public float speed = 5f;
    public float leftAndRightDistance = 10f;

    [Header("Apple Spawning")]
    public GameObject applePrefab;
    public float appleDropDelay = 2f;

    [Header("Branch Spawning")]
    public GameObject branchPrefab;
    public float branchChance = 0.1f;

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
            DropObject();
            appleDropTime = appleDropDelay;
        }
    }

    void DropObject()
    {
        if (Random.value < branchChance)
        {
            Instantiate(
                branchPrefab,
                transform.position,
                Quaternion.identity
            );
        }
        else
        {
            Instantiate(
                applePrefab,
                transform.position,
                Quaternion.identity
            );
        }
    }
}