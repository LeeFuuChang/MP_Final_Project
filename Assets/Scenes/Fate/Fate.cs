using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fate : MonoBehaviour
{
    public GameObject fateContainer;

    public Image[] fateResults;

    private bool fateChosen;

    void Start()
    {
        fateChosen = false;
        for(int i = 0; i < fateResults.Length; i++)
        {
            fateResults[i].enabled = false;
        }
    }

    public void ButtonClicked()
    {
        if(fateChosen) SceneManager.LoadScene("Game");
        else {
            int possibleFates = fateContainer.transform.childCount;
            int randomedFate = Random.Range(0, fateResults.Length);
            fateResults[randomedFate].enabled = true;
            fateChosen = true;
        }
    }
}
