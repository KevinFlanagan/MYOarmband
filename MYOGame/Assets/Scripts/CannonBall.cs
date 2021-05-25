using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CannonBall : MonoBehaviour
{
    public Rigidbody2D rb; // rigidbody for the ball
    public Rigidbody2D anchor;

    public float releaseTime = .20f; // delay for when the ball is released from the anchor
    public float maxDragDis = 2f; 
    public GameObject nextCannonBall;

    private bool isPressed = false; // mouse click
    

    void Update()
    {
        if(isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePos, anchor.position) > maxDragDis)
                rb.position = anchor.position + (mousePos - anchor.position).normalized * maxDragDis;
            else
                rb.position = mousePos;
        }
    }

    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(Release()); // calling the Coroutine
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds (2f);

        if(nextCannonBall != null)
        {
            nextCannonBall.SetActive(true);
        }else
        {
            Enemy.EnemiesLeft = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //Game over scene

        }
        
    }
}
