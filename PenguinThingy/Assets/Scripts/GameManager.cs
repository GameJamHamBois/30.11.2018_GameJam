using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static AudioSource AudioSource;
    public static int Birds { get; set; }

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public static void InduceGameOver()
    {
        Debug.Log("You Lost");
    }
}
