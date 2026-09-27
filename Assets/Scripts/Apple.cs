using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public float bottomY = -6f;

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            GameController gameController = FindFirstObjectByType<GameController>();

            if (gameController != null)
            {
                gameController.AppleMissed();
            }
            Destroy(gameObject);
        }
    }
}