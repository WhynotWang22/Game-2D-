using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class movebytouch : MonoBehaviour
{


    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Animator animator;
        [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(joystick.Horizontal * moveSpeed,_rigidbody.velocity.y,joystick.Vertical * moveSpeed);
    }
}
