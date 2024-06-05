using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class ViewsCommon : MonoBehaviour
{
    public void ExitButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }
}
