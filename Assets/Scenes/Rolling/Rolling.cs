using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Rolling : MonoBehaviour
{
    public Transform rollingBG;

    public float initialSpeed = 1000f;
    public float speedDecay = 1.25f;

    private bool rolled = false;
    private float rollingSpeed = 0f;

    void Update()
    {
        rollingBG.Rotate(new Vector3(0, 0, this.rollingSpeed * Random.Range(0.75f, 1.25f) * Time.deltaTime));
    }

    public void StartRolling()
    {
        if(this.rolled) return;
        this.rolled = true;
        this.rollingSpeed = this.initialSpeed;
        rollingBG.Rotate(new Vector3(0, 0, Random.Range(0f, 360f)));
        StartCoroutine(WaitForRollingResult());
    }

    IEnumerator WaitForRollingResult()
    {
        while(this.rollingSpeed > 2)
        {
            yield return new WaitForSeconds(0.5f);
            this.rollingSpeed /= this.speedDecay;
        }
        this.rollingSpeed = 0;
        int result = this.getRollingResultByAngle((rollingBG.localEulerAngles.z+360f)%360f);
        PlayerPrefs.SetInt("Rolling", result);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game");
    }

    private int getRollingResultByAngle(float angle)
    {
        if(337.5f < angle && angle <=  22.5f) return 1;
        if( 22.5f < angle && angle <=  67.5f) return 2;
        if( 67.5f < angle && angle <= 112.5f) return 3;
        if(112.5f < angle && angle <= 157.5f) return 4;
        if(157.5f < angle && angle <= 202.5f) return 5;
        if(202.5f < angle && angle <= 247.5f) return 6;
        if(247.5f < angle && angle <= 292.5f) return 7;
        if(292.5f < angle && angle <= 337.5f) return 8;
        return 1;
    }
}
