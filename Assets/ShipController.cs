using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] float thrustPower = 100f;
    [SerializeField] float rotationSpeed = 100f;

    Rigidbody rigidBody;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Friendly":
                print("alive");
                break;
            default:
                print("dead");
                break;
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * thrustPower);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            audioSource.Stop();
        }
    }

private void Rotate()
    {
        rigidBody.freezeRotation = true;

        var rotationVector = rotationSpeed * Time.deltaTime * Vector3.forward;

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
        {

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-rotationVector);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(rotationVector);
        }

        rigidBody.freezeRotation = false;
    }
}
