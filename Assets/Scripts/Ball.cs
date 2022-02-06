using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle paddle;
    private bool hasStarted = false;
 
    private Rigidbody2D paddleToBallVector;
    private Vector3 ballStartPosition;
   
    void Start()
    {
        //detection des objects de unity
        paddle = GameObject.FindObjectOfType<Paddle>();

        //obtenir les infos de terrin
        paddleToBallVector = GetComponent<Rigidbody2D>();
        ballStartPosition = this.transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            // bloquer la balle devant la3sa
            this.transform.position = paddle.transform.position + ballStartPosition;
        }
        //attendre la click de souris pour lancer la balle
        if (Input.GetMouseButtonDown(0))
        {
            print("clic souris pour commencer" );
            hasStarted = true;
            this.paddleToBallVector.velocity = new Vector2(2f, 10f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 breakEndlessLoops = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            this.GetComponent<Rigidbody2D>().velocity += breakEndlessLoops;
        }
    }
}