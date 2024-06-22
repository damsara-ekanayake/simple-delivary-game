using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.1f;
    [SerializeField] float moveSpeed = 0.01f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float breakSpeed = 10f;
    [SerializeField] float fixedMoveSpeed = 1.0f;

    [SerializeField] float timeBoosting = 1.0f;
    private float boostTimer = 0f;
    private bool boosting;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

        //temp boost
        if(boosting)
        {
            boostTimer += Time.deltaTime;
            if(boostTimer >= timeBoosting)
            {
                moveSpeed = fixedMoveSpeed;
                boostTimer = 0f;
                boosting = false;
                //Debug.Log(moveSpeed);
            }

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Speedboost")
        {
            boosting = true;
            //Debug.Log("speed has increased");
            moveSpeed = boostSpeed;
            Destroy(collision.gameObject, 0.1f);
            //Debug.Log(moveSpeed);
        }

        if (collision.tag == "Speedbreak")
        {
            boosting = true;
            //Debug.Log("speed has decreased");
            moveSpeed = breakSpeed;
            Destroy(collision.gameObject, 0.1f);
            //Debug.Log(moveSpeed);
        }

        if (collision.tag == "Other")
        {
            boosting = true;
            //Debug.Log("hit");
            moveSpeed = breakSpeed;
            //Debug.Log(moveSpeed);
            
        }
    }
}