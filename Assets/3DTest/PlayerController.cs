using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    private Animator m_Animator;
    private Rigidbody m_Rigidbody;
    private AudioSource m_AudioSource;

    private float m_MoveSpeed;
    private static readonly int SpeedId = Animator.StringToHash("Speed");
    private static readonly int Jump = Animator.StringToHash("Jump");

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        m_MoveSpeed = 0; 
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
            m_MoveSpeed = speed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.back * (speed * Time.deltaTime));
            m_MoveSpeed = -speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
            m_MoveSpeed = speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * (speed * Time.deltaTime));
            m_MoveSpeed = -speed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && m_Rigidbody.velocity.y == 0)
        {
            m_Animator.SetTrigger(Jump);
            m_AudioSource.Play();
        }
        
        m_Animator.SetFloat(SpeedId,m_MoveSpeed);
    }
}
