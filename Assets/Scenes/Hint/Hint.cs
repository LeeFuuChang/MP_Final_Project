using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hint : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(WaitForPlayerReadHint());
    }

    IEnumerator WaitForPlayerReadHint()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("SelectCharactor");
    }
}
