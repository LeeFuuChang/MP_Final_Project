using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Fate : MonoBehaviour
{
    public GameObject fateContainer;

    public Image[] fateResults;

    void Start()
    {
        for(int i = 0; i < fateResults.Length; i++)
        {
            fateResults[i].enabled = false;
        }
    }

    public void BegChoosingFate()
    {
        Debug.Log("Beg");
        int possibleFates = fateContainer.transform.childCount;
        int randomedFate = Random.Range(0, fateResults.Length);
        fateResults[randomedFate].enabled = true;
    }
}
