using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinControl : MonoBehaviour
{
    public float startTime;

    public float minX, maxX;

    [Range(1, 100)]
    public float moveSpeed;

    public int sign = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= startTime)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime * sign, 0, 0);

            if (transform.position.x <= minX || transform.position.x >= maxX)
            {
                sign *= -1;
            }
        }
    }
}