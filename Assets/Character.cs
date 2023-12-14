using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField, Range(1f,5f)] private float speed;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _characterController.Move(Vector3.down * 9.8f*Time.deltaTime);
        _characterController.Move(Input.GetAxis("Horizontal") * Vector3.right * speed*Time.deltaTime);
        _characterController.Move(Input.GetAxis("Vertical") * Vector3.forward * speed*Time.deltaTime);
    }
}
