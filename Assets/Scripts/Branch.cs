using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    public float catchDistance = 1.5f;

    void Update()
    {
        Basket[] baskets = FindObjectsByType<Basket>(FindObjectsSortMode.None);

        foreach (Basket basket in baskets)
        {
            float horizontalDistance = Mathf.Abs(
                transform.position.x - basket.transform.position.x
            );

            float verticalDistance = Mathf.Abs(
                transform.position.y - basket.transform.position.y
            );

            if (horizontalDistance <= catchDistance &&
                verticalDistance <= catchDistance)
            {
                GameController gameController =
                    FindFirstObjectByType<GameController>();

                if (gameController != null)
                {
                    gameController.BranchCaught();
                }

                Destroy(gameObject);

                return;
            }
        }
    }
}