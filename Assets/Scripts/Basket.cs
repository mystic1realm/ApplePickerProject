using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public float xMin = -15f;
    public float xMax = 15f;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = -Camera.main.transform.position.z;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        worldPos.y = transform.position.y;
        worldPos.z = transform.position.z;

        worldPos.x = Mathf.Clamp(worldPos.x, xMin, xMax);

        transform.position = worldPos;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
        }
    }
}