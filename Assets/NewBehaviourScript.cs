using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(Vector2.Reflect(_rigidbody2D.velocity, collision.contacts[0].normal) * 3);
        _rigidbody2D.velocity = Vector2.Reflect(_rigidbody2D.velocity, collision.contacts[0].normal) * 3;
    }
}
