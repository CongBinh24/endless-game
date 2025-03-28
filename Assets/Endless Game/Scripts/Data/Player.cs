using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DataStruct;

public class Player : MonoBehaviour, ICompChk
{
    public float jumpForce;
    public LayerMask blockLayer;
    public float blockCheckingRadius;
    public float blockCheckingOffset;
    public GameObject landVfx;

    private Rigidbody2D m_rb;
    private Animator m_anim;
    private int m_blockId;
    private bool m_isDead;
    private bool m_isOnBlock;
    private Vector2 m_centerPos;


    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isDead || IsComponentsNull()) return;

        Jump();

        if (m_rb.velocity.y < 0)
        {
            if (m_isOnBlock)
            {
                m_anim.SetBool(ChacAnim.Jump.ToString(), false);
                m_anim.SetBool(ChacAnim.Land.ToString(), true);
            }
            else
            {
                m_anim.SetBool(ChacAnim.Jump.ToString(), false);
            }
        }
    }

    private void FixedUpdate()
    {
        IsOnBlock();
    }

    public bool IsComponentsNull()
    {
        return m_rb == null || m_anim == null;
    }
    
    private void IsOnBlock()
    {
        m_centerPos = new Vector3(transform.position.x,
                transform.position.y - blockCheckingOffset, transform.position.z
                );
        Collider2D col = Physics2D.OverlapCircle(m_centerPos, blockCheckingRadius, blockLayer);

        m_isOnBlock = col != null ? true : false;
    }

    public void Jump()
    {
        if (!GamepadController.Ins.CanJump || !m_isOnBlock || IsComponentsNull()) return;

        GamepadController.Ins.CanJump = false;

        m_rb.velocity = Vector2.up * jumpForce;

        m_anim.SetBool(ChacAnim.Jump.ToString(), true);
        m_anim.SetBool(ChacAnim.Land.ToString(), false);

    }

    public void BackToIdle()
    {
        m_anim.SetBool(ChacAnim.Land.ToString(), false);
        m_anim.SetTrigger(ChacAnim.Idle.ToString());
    }

    private void OnDrawGizmos()
    {
        m_centerPos = new Vector3(transform.position.x,
            transform.position.y - blockCheckingOffset, transform.position.z
            );
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(m_centerPos, blockCheckingRadius);
    }
}
