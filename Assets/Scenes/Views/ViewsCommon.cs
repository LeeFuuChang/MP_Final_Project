using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class ViewsCommon : MonoBehaviour
{
    private GameObject infoLayer;
    private GameObject continueButton;
    private GameObject exitButton;
    
	void Start()
    {
        continueButton = GameObject.Find("continueBtn");
		Button continueBtn = continueButton.GetComponent<Button>();
        continueBtn.onClick.AddListener(this.ContinueButtonClicked);

        exitButton = GameObject.Find("exitBtn");
		Button exitBtn = exitButton.GetComponent<Button>();
        exitBtn.onClick.AddListener(this.ExitButtonClicked);

        infoLayer = GameObject.Find("InfoLayer");
        infoLayer.SetActive(!GameObject.Find("360"));
    }

    void LateUpdate() 
    {
        if(!GameObject.Find("360")) return;

        int turnSpeedMouse = 100;

        Transform camera = GameObject.Find("Main Camera").GetComponent<Transform>();
        camera.Rotate(new Vector3(Input.GetAxis("Mouse Y"),-Input.GetAxis("Mouse X"), 0)*Time.deltaTime*turnSpeedMouse);
    }

    public void ContinueButtonClicked()
    {
        infoLayer.SetActive(true);
    }

    public void ExitButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }
}
