using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CubeControllers : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float HorizontalSpeed = 10f;
    public float JumForce = 10f;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RestartButton1.onClick.AddListener(RestartGame);
        RestartButton2.onClick.AddListener(RestartGame);
    }

    public Button RestartButton1, RestartButton2;
    void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, MoveSpeed);

        float moveHorizontal = 0;
        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -HorizontalSpeed;
        } else if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = HorizontalSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * JumForce, ForceMode.Impulse);
        }

        rb.velocity = new Vector3(moveHorizontal, rb.velocity.y, MoveSpeed);
    }

    public GameObject PanelWin, PanelLose;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            PanelLose.SetActive(true);
            Debug.LogError("DOOR");
        }

        if (collision.gameObject.CompareTag("FinishLine"))
        {
            PanelWin.SetActive(true);
            Debug.LogError("WIN");
        }
    }
}
