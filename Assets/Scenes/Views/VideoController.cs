using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject game, video;
    public GameObject gameUI, videoUI;
    public VideoPlayer[] videos;
    public int preIndex;
    public float timer;
    public bool isPlay;
    public Vector3 targetPos, originPos;
    public bool isPause;
    void Start()
    {
        video.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay && !isPause)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                CloseVideo();
            }
        }
    }
    public void Pause()
    {
        isPause = !isPause;
        if (isPause)
        {
            videos[preIndex].Pause();
        }
        else
        {
            videos[preIndex].Play();
        }
    }
    public void OpenVideo(int index)
    {
        videos[index].gameObject.transform.position = targetPos;
        videos[index].SetDirectAudioMute(0, false);
        videos[index].Play();
        timer = (float)videos[index].clip.length;
        game.SetActive(false);
        video.SetActive(true);
        gameUI.SetActive(false);
        videoUI.SetActive(true);
        isPlay = true;
        isPause = false;
        preIndex = index;
    }
    public void CloseVideo()
    {
        videos[preIndex].gameObject.transform.position = originPos;
        videos[preIndex].SetDirectAudioMute(0, true);
        videos[preIndex].Stop();
        timer = 0;
        game.SetActive(true);
        video.SetActive(false);
        gameUI.SetActive(true);
        videoUI.SetActive(false);
        isPlay = false;
        isPause = false;
        SceneManager.LoadScene("Game");
    }
}
