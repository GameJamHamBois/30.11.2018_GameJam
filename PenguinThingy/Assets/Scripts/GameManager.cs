using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static TextMeshPro birdCounter;
    public static AudioSource AudioSource;
    private static int birds;
    public static int Birds { get { return birds; } set { birds = value; birdCounter.text = birds.ToString(); } }

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        birdCounter = FindObjectOfType<TextMeshPro>();
    }

    public static void InduceGameOver()
    {
        Debug.Log("You Lost");
    }
}
