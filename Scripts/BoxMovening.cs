using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoxMovening : MonoBehaviour
{
    [SerializeField] private float moveBound = 25.0f;
    [SerializeField] private float moveStep = 1f;
    [SerializeField] private float moveSpeed = 8.0f;
    private Vector3 boxPos;
    private bool moveSide;  // true is left, false is right
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        moveSide = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameManager.isGameActive)

    {
            boxPos = transform.position;

            switch (moveSide)
            {
                case false:
                    transform.Translate(new Vector3(0, 0, moveStep) * Time.deltaTime * moveSpeed);
                    if (boxPos.z > moveBound)
                    {
                        moveSide = true;
                    }
                    break;

                case true:
                    transform.Translate(new Vector3(0, 0, -moveStep) * Time.deltaTime * moveSpeed);
                    if (boxPos.z < -moveBound)
                    {
                        moveSide = false;
                    }
                    break;
            } 
        }

    }
}
