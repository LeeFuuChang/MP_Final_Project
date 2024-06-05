using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharactor : MonoBehaviour
{
    public void SelectCharactorMale()
    {
        SetCharactor("M");
    }

    public void SelectCharactorFemale()
    {
        SetCharactor("F");
    }

    private void SetCharactor(string selected)
    {
        PlayerPrefs.SetString("Charactor", selected);
        SceneManager.LoadScene("Game");
    }
}
