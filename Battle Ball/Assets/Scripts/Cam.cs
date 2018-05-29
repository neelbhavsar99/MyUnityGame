using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    // Use this for initialization
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - (target2.position + target1.position) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (target2.transform.position + target1.transform.position) / 2 + offset;
    }
}