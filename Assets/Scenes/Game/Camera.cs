using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float viewAngle = 60f;
    public float radius = 0.8125f;
    public float slope = 0.6364f;
    public GameObject player;

    void Start()
    {
        radius = Vector3.Scale(this.gameObject.transform.position, new Vector3(1, 0, 1)).magnitude;
        slope = this.gameObject.transform.position.magnitude;
    }

    void Update()
    {
        float scale = this.gameObject.transform.position.magnitude / slope;
        Vector3 vec = new Vector3(player.transform.position.x, 0, player.transform.position.z).normalized * radius * scale;
        this.gameObject.transform.position = new Vector3(vec.x, this.gameObject.transform.position.y, vec.z);
        this.gameObject.transform.LookAt(new Vector3(0, this.gameObject.transform.position.y, 0));
        this.gameObject.transform.rotation = this.gameObject.transform.rotation * Quaternion.Euler(viewAngle, 0, 0);
    }
}
