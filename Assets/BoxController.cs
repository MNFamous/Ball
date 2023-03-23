using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField]private int _jumpCountApply;
    [SerializeField]private float _jumpCooldown;
    Rigidbody rb;
    public float baseAcceleration, baseJump,smashDistance, baseSmash,CooldownTime;
    public int jumpCount;
    public Vector3 movementInput;
    RaycastHit hit;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _jumpCountApply = jumpCount;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Smash();
        if (!Physics.Raycast(transform.position, Vector3.down, out hit)) return;
    }
    private void Move()
    {
        movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVector = movementInput * baseAcceleration;
        rb.velocity = new Vector3(moveVector.x, rb.velocity.y, moveVector.z);
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            rb.AddForce(Vector3.up * baseJump, ForceMode.Impulse);
            _jumpCooldown = CooldownTime;
            jumpCount--;
        }
        if (_jumpCooldown > 0)
        {
            _jumpCooldown -= Time.deltaTime;
        }
        if (hit.distance < 0.6 && _jumpCooldown <= 0)
        {
            jumpCount = _jumpCountApply;
        }
    }
    private void Smash()
    {
        Debug.Log(hit.distance);
        if (Input.GetKeyDown(KeyCode.LeftShift) && hit.distance > smashDistance)
        {
            rb.AddForce(Vector3.down * baseSmash, ForceMode.Impulse);
        }
    }
}
