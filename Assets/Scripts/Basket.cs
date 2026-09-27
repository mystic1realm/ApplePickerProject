using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public float xMin = -10f;
    public float xMax = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
}
