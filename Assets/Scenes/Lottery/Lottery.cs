using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lottery : MonoBehaviour
{
    public RawImage glowing;
    public Vector2[] glowingPositions;

    void Start()
    {
        glowing.gameObject.SetActive(false);
    }

    public void LotteryButtonClicked()
    {
        StartCoroutine(WaitForLotteryResult());
    }

    IEnumerator WaitForLotteryResult()
    {   
        int resulting = Random.Range(1, 7);
        int previous = 0;
        float interval = 0.05f;
        float ijumping = 1.2f;
        while(interval < 2f)
        {
            while(previous == resulting)
            {
                resulting = Random.Range(1, 7);
            }
            if(resulting > glowingPositions.Length)
            {
                glowing.gameObject.SetActive(false);
            }
            else
            {
                glowing.gameObject.SetActive(true);
                RectTransform picture = glowing.gameObject.GetComponent<RectTransform>();
                picture.anchoredPosition = glowingPositions[resulting-1];
            }
            yield return new WaitForSeconds(interval);
            previous = resulting;
            interval *= ijumping;
        }
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Game");
    }

    public void ExitButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }
}

