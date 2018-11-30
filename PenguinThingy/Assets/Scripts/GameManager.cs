using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static PostProcessVolume vignetteMask;
    public static TextMeshPro birdCounter;
    public static AudioSource AudioSource;
    private static int birds;
    public static int Birds { get { return birds; } set { birds = value; birdCounter.text = birds.ToString(); } }

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        birdCounter = FindObjectOfType<TextMeshPro>();
        vignetteMask = GameObject.FindGameObjectWithTag("VignetteMask").GetComponent<PostProcessVolume>();
    }

    public static void InduceGameOver()
    {
        // urmomgaylol
    }

    public static IEnumerator DarkenScreen()
    {
        FloePhaseCC.canAct = false;
        Vignette settings;
        vignetteMask.profile.TryGetSettings<Vignette>(out settings);
        while (true)
        {
            settings.opacity.value += Time.deltaTime * .3f;
            if (settings.opacity.value < 1f) yield return null;
            else break;
        }
        Application.Quit();
    }

    public static IEnumerator DarkenScreenNext()
    {
        FloePhaseCC.canAct = false;
        Vignette settings;
        vignetteMask.profile.TryGetSettings<Vignette>(out settings);
        while (true)
        {
            settings.opacity.value += Time.deltaTime * .3f;
            if (settings.opacity.value < 1f) yield return null;
            else break;
        }
        SceneManager.LoadScene("Zwille");
    }

    public static IEnumerator LightenScreen()
    {
        Vignette settings;
        vignetteMask.profile.TryGetSettings<Vignette>(out settings);
        while (true)
        {
            settings.opacity.value -= Time.deltaTime * .6f;
            if (settings.opacity.value > 0f) yield return null;
            else break;
        }
    }
}
