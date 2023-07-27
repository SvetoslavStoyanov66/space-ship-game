using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(_speed * HorizontalInput * Time.deltaTime * Vector3.right);

        float VerticalInput = Input.GetAxis("Vertical");
        transform.Translate(_speed * VerticalInput * Time.deltaTime * Vector3.up);

        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0);
        }
        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f);
        }
        //-11.25, 9.1    
        if (transform.position.x > 11.25)
        {
            transform.position = new Vector3(-11.25f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.25)
        {
            transform.position = new Vector3(11.25f, transform.position.y, 0);
        }
    }
}
