using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject angle;
    [SerializeField] public Rigidbody body;
    public float power = 10;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        //angle = GameObject.Find("Fire point");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //Debug.Log(message: "Fire;");
        //    Vector3 fireAngle = (angle.transform.position - transform.position).normalized;
        //    body.AddForce(fireAngle * power * 100);
        //}
    }
}
