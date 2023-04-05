using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CandleAnimations : MonoBehaviour
{
    public bool attackability = true;
    Animator m_animator;
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            m_animator.SetBool("Attack", true);
        }
    }

    public void canAttack()
    {
        attackability = true;
    }

    public void cantAttack()
    {
        attackability = false;
    }

    public void finishAttack()
    {
        m_animator.SetBool("Attack", false);
    }

}
