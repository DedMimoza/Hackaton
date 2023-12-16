using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class Character : MonoBehaviour
{
    private CharacterController _characterController;
    private Animator _animator;
    [SerializeField, Range(1f,5f)] public float speed;
    public float rotatoinSpeed;

    //Sound
    SoundActivator soundActivator;
    void Start()
    {
        soundActivator = GetComponent<SoundActivator>();
        soundActivator.isPhone = false;

        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    


    
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5f;
            soundActivator.SwapMusic(true);
        }
        else if (Input.GetKey(KeyCode.C))
        {
            speed = 1.5f;
            soundActivator.SwapMusic(false);
        }
        else
        {
            speed = 3f;
            soundActivator.SwapMusic(false);
        }
    }

    void Move()
    {
        
        Vector3 movmentDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        _characterController.Move(Vector3.down * 9.8f*Time.deltaTime);
        _characterController.Move(movmentDirection * -speed*Time.deltaTime);


        
        movmentDirection.Normalize();
        
        

        if (movmentDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(-movmentDirection,Vector3.up);
            transform.rotation=Quaternion.RotateTowards(transform.rotation,toRotation,rotatoinSpeed* Time.deltaTime);
        }
        
        
        
        Vector3 horizontalVelocity = _characterController.velocity;
        horizontalVelocity = new Vector3(_characterController.velocity.x, _characterController.velocity.y, _characterController.velocity.z);

        // The speed on the x-z plane ignoring any speed
        float horizontalSpeed = horizontalVelocity.magnitude;
        
        _animator.SetFloat("Speed", horizontalSpeed);


        if (horizontalSpeed > 0f) soundActivator.PlaySoundMove();
        else soundActivator.StopMusic();
        
    }
}
