using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryControl : MonoBehaviour
{
    public GameObject[] storyImages;
    public float delay;
    void Start()
    {
        storyImages[0].SetActive(false);
        storyImages[1].SetActive(false);
        storyImages[2].SetActive(false);
        StartCoroutine(StoryTeller());
    }

    IEnumerator StoryTeller()
    {
        storyImages[0].SetActive(true);
        yield return new WaitForSeconds(delay);
        storyImages[1].SetActive(true);
        yield return new WaitForSeconds(delay);
        storyImages[2].SetActive(true);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}