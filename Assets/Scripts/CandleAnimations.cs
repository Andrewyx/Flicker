using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CandleAnimations : MonoBehaviour
{
    public PlayerController m_PlayerController;
    public bool attackability = true;
    public bool switchability = true;
    private AudioSource _audioSource;
    public bool obstructAbove, obstructUnder;
    public AudioClip breth;
    public AudioClip noGo;
    public AudioClip thwack;


    Animator m_animator;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        obstructAbove = m_PlayerController.GetComponent<PlayerController>().obstructAbove;
        obstructUnder = m_PlayerController.GetComponent<PlayerController>().obstructUnder;
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!obstructAbove && !obstructUnder){
                m_animator.SetBool("Switch", true);
            }
            else {
                _audioSource.PlayOneShot(noGo, 0.1f);
            }
        }

        if (Input.GetMouseButtonDown(1)) {
            m_animator.SetBool("Attack", true);
        }

    }

    public void canAttack()
    {
        attackability = true;
        m_animator.SetBool("Attack", false);
    }

    public void cantAttack()
    {
        attackability = false;
    }

    public void cantSwitch()
    {
        switchability = true;
    }

    public void canSwitch()
    {
        switchability = false;
        m_animator.SetBool("Switch", false);
    }

    public void doDaSwitch()
    {
        m_PlayerController.swapDimension();
        Debug.Log("swap.");
    }
    
    public void playBreath()
    {
        _audioSource.PlayOneShot(breth);
    }

    public void playThwack()
    {
        _audioSource.PlayOneShot(thwack, 0.5f);
    }


}
