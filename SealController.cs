using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealController : MonoBehaviour
{
    private bool  m_isDead       = false;
    private float m_fAngle       = 0.0f;
    private Animator m_animator  = null;
    private Rigidbody2D m_rbBody = null;

    public float m_fMaxHeight         = 0.0f;
    public float m_fFlapVelocity      = 0.0f;
    public float m_fRelativeVelocityX = 0.0f;
    public GameObject m_objSprite     = null;

    void Awake()
    {
        m_rbBody   = GetComponent<Rigidbody2D>();
        m_animator = m_objSprite.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && transform.position.y < m_fMaxHeight)
        {
            Flap();
        }

        ApplyAngle();

        m_animator.SetBool("flap", m_fAngle >= 0.0f);
    }

    void ApplyAngle()
    {
        float fTargetAngle = 0.0f;

        if(m_isDead)
        {
            fTargetAngle = -90.0f;
        }
        else
        {
            fTargetAngle = Mathf.Atan2(m_rbBody.velocity.y, m_fRelativeVelocityX) * Mathf.Rad2Deg;
        }

        m_fAngle     = Mathf.Lerp(m_fAngle, fTargetAngle, Time.deltaTime * 10.0f);

        m_objSprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, m_fAngle);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (m_isDead)
            return;

        Camera.main.SendMessage("Clash");

        m_isDead = true;
    }

    public bool IsDead()
    {
        return m_isDead;
    }

    public void Flap()
    {
        if (m_isDead)
            return;

        if (m_rbBody.isKinematic)
            return;

        m_rbBody.velocity = new Vector2(0.0f, m_fFlapVelocity);
    }

    public void SetSteerActive(bool isActive)
    {
        m_rbBody.isKinematic = !isActive;
    }
}
