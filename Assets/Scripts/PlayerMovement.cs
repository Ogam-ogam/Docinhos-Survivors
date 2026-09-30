using UnityEngine;
using UnityEngine._inputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] float _speed = 7f;
    private Vector2 _input;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(_inputValue value)
    {
        _input = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        if (_input != Vector2.zero){
            _rb.linearVelocity = _input * _speed;
        }
        else
        {
            _rb.linearVelocity = new Vector2(Mathf.MoveTowards(_rb.linearVelocity.x, 0f, 25f * Time.deltaTime), 
            Mathf.MoveTowards(_rb.linearVelocity.y, 0f, 25f * Time.deltaTime));
        }
    }

}