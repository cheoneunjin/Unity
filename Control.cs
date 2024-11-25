using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;
    private float r = 0.0f;
    private float rotationSpeed = 100.0f;
    private float moveSpeed = 10.0f;
    private Transform playerTr;
    private int key = 0;
    private AudioSource myAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GetComponent<Transform>();
        myAudio = GetComponent<AudioSource>();
        myAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");
        
        playerTr.Translate(new Vector3(h, 0, v)* moveSpeed * Time.deltaTime);
        playerTr.Rotate(new Vector3(0, r, 0) * rotationSpeed * Time.deltaTime);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Key")
        {
            GameObject.Find("item").GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            key += 1;
        }

        if (collision.gameObject.tag == "Monster")
        {
            SceneManager.LoadScene("GameOverScene");
        }

        if (collision.gameObject.tag == "Door")
        {
            if (key >= 1)
            {
                SceneManager.LoadScene("EndingScene");
            }
            else
            {
                SceneManager.LoadScene("WarningScene");
            }
        }
    }
}
