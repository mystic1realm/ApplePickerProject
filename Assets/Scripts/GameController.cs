using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject gameOverScreen;

    public AppleTree appleTree;
    public GameObject basketPrefab;

    public int currentRound = 1;
    public int maxRounds = 4;

    public TMP_Text roundText;

    private GameObject[] baskets = new GameObject[4];
    private int basketsRemaining = 4;

    void Awake()
    {
        roundText.gameObject.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        gameOverScreen.SetActive(false);

        currentRound = 1;
        basketsRemaining = 4;

        roundText.gameObject.SetActive(true);
        roundText.text = "Round " + currentRound;

        for (int i = 0; i < 4; i++)
        {
            baskets[i] = Instantiate(
                basketPrefab,
                new Vector3(0f, -4f + (i * 1.25f), 0f),
                Quaternion.identity
            );
        }

        appleTree.enabled = true;
    }

    public void AppleMissed()
    {
        if (basketsRemaining <= 0)
        {
            return;
        }

        // Clear all apples currently falling
        Apple[] apples = FindObjectsByType<Apple>(FindObjectsSortMode.None);

        foreach (Apple apple in apples)
        {
            Destroy(apple.gameObject);
        }

        int basketIndex = basketsRemaining - 1;

        if (baskets[basketIndex] != null)
        {
            Destroy(baskets[basketIndex]);
            baskets[basketIndex] = null;
        }

        basketsRemaining--;

        if (currentRound >= maxRounds)
        {
            roundText.text = "Game Over";
            appleTree.enabled = false;
            gameOverScreen.SetActive(true);
            return;
        }

        currentRound++;
        roundText.text = "Round " + currentRound;
    }

    public void RestartGame()
    {
        // Remove any remaining baskets
        for (int i = 0; i < baskets.Length; i++)
        {
            if (baskets[i] != null)
            {
                Destroy(baskets[i]);
                baskets[i] = null;
            }
        }

        basketsRemaining = 0;

        // Clear any remaining apples
        Apple[] apples = FindObjectsByType<Apple>(FindObjectsSortMode.None);

        foreach (Apple apple in apples)
        {
            Destroy(apple.gameObject);
        }

        // Hide Game Over screen
        gameOverScreen.SetActive(false);

        // Show the start screen
        startScreen.SetActive(true);

        // Hide round text
        roundText.gameObject.SetActive(false);

        // Stop the tree
        appleTree.enabled = false;

        currentRound = 1;
        basketsRemaining = 4;
    }

    public void BranchCaught()
    {
        Apple[] apples = FindObjectsByType<Apple>(FindObjectsSortMode.None);

        foreach (Apple apple in apples)
        {
            Destroy(apple.gameObject);
        }

        appleTree.enabled = false;

        roundText.text = "Game over";
        gameOverScreen.SetActive(true);
    }
}