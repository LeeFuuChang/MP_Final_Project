using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("Rolling", 0);
        PlayerPrefs.SetInt("Position", 0);
    }

    public void StartButtonClicked()
    {
        SceneManager.LoadScene("Guide");
    }
}
