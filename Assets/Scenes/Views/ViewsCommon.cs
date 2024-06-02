using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewsCommon : MonoBehaviour
{
    public VideoController vc;
    public int videoId = -1;

    public void ExitButtonClicked()
    {
        if(videoId == -1)
        {
            Debug.LogError("Video ID unset!!!");
            return;
        }
        vc.OpenVideo(videoId);
        // SceneManager.LoadScene("Game");
    }
}
