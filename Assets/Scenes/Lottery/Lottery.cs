using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lottery : MonoBehaviour
{
    public RawImage glowing;
    public Vector2[] glowingPositions;
    public Image[] coupons;

    void Start()
    {
        for(int i = 0; i < coupons.Length; i++)
        {
            coupons[i].enabled = false;
        }
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
        while(previous == 0 || resulting == 4)
        {
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
            yield return new WaitForSeconds(2f);
        }
        coupons[resulting-1].enabled = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game");
    }

    public void ExitButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }
}

