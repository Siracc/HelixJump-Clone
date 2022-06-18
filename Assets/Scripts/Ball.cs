using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] GameObject _splashImg, _particleRed, _particleGreen, _particleBlue;
    [SerializeField] float _jumpForce;
    GameManager _gm;
    Ring _ring;
    
    void Start()
    {
        _gm = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        _rb.AddForce(Vector3.up * _jumpForce);
        GameObject splash =  Instantiate(_splashImg, transform.position - new Vector3(0, 0.22f, 0f), transform.rotation);
        splash.transform.SetParent(other.gameObject.transform);
        Destroy(splash, 1);

        string metarialName = other.gameObject.GetComponent<MeshRenderer>().material.name;
        if(metarialName == "Unsafe Color (Instance)") 
        {
            _gm.restartGame();
        }
        else if (metarialName == "Finish White (Instance)" || metarialName == "Finish Black (Instance)")
        {
            _particleRed.SetActive(true);
            _particleGreen.SetActive(true);
            _particleBlue.SetActive(true);
        }
    }
}
