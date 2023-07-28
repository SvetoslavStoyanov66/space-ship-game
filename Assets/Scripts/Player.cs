using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.3f;
    private float _startFire = -1.0f;
    [SerializeField]
    private bool _tribleActive = false;
    [SerializeField]
    private GameObject _triblePrefab;
    void Start()
    {
        
        transform.position = new Vector3(0, -1, 0);
    }
    void Update()
    {
        Movement();
        shootLazer();
        
       
        
    }
    void Movement()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(_speed * HorizontalInput * Time.deltaTime * Vector3.right);

        float VerticalInput = Input.GetAxis("Vertical");
        transform.Translate(_speed * VerticalInput * Time.deltaTime * Vector3.up);

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        } 
        if (transform.position.x > 11.25)
        {
            transform.position = new Vector3(-11.25f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.25)
        {
            transform.position = new Vector3(11.25f, transform.position.y, 0);
        }
    }
    void shootLazer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _startFire)
        {
            _startFire = Time.time + _fireRate;
            if (_tribleActive == false) {
                Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y + 0.9f), Quaternion.identity);
            }
            else
            {
                Instantiate(_triblePrefab, new Vector3(transform.position.x, transform.position.y ), Quaternion.identity);
            }
        }
    }

    public void TribleShotActive()
    {
        _tribleActive = true;
        StartCoroutine(TribleShotTimer());
    }
    IEnumerator TribleShotTimer()
    {
        yield return new WaitForSeconds(3);
        _tribleActive = false;

    }
   
}
