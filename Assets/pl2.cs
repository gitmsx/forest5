using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class pl2 : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;
    [SerializeField] private float beam = 1.0f;


    private Rigidbody2D _playerRigidbody;


    private bool FaceRight = true;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        if (_playerRigidbody == null)
        {
            Debug.LogError("Player is missing a Rigidbody2D component");
        }
    }
    private void Update()
    {
        MovePlayer();



        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
          //  Debug.Log("WWW");
            if (IsGrounded())
                Jump();

        }

    }
    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, _playerRigidbody.velocity.y);

        if ((horizontalInput < 0) && (FaceRight == true))
        {
            flip();
        }
        else if ((horizontalInput > 0) && (FaceRight != true) )
        {
            flip();
        }


    }

    private void flip()
    {
        FaceRight = !FaceRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.x);
    }
    private void Jump() => _playerRigidbody.velocity = new Vector2(0, jumpPower);

    private bool IsGrounded()
    {
        var groundCheck = Physics2D.Raycast(transform.position, Vector2.down, beam);

       
        
        Debug.DrawRay(transform.position, Vector2.down, Color.green, beam);

        var hit2 = Physics2D.Raycast(transform.position, Vector2.down, beam);
        var hit3 = Physics2D.Raycast(transform.position, Vector2.up, beam);

        //  Debug.Log($" transform.position {transform.position}");
        //   Debug.Log($" hit2 {hit2.point}");
        // Debug.Log($" hit3 {hit3.point}");
        Debug.Log($" groundCheck.collider  {groundCheck.collider != null}");
        Debug.Log($" groundCheck.collider.CompareTag(\"Ground\") {groundCheck.collider.CompareTag("Ground")}");


        return groundCheck.collider != null;
        // && groundCheck.collider.CompareTag("Ground");
    }


}