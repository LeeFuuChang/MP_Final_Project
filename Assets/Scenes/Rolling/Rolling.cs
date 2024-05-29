using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Rolling : MonoBehaviour
{
    public TextMeshProUGUI text;
    public RawImage rawImageBg;

    void Start()
    {
        rawImageBg.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    public void StartRolling()
    {
        rawImageBg.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        StartCoroutine(WaitForRollingResult());
    }

    IEnumerator WaitForRollingResult()
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
            text.text = $"{resulting}";
            yield return new WaitForSeconds(interval);
            previous = resulting;
            interval *= ijumping;
        }
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Game");
    }
}
