using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerrigidbody;
    public float jumpforce= 10;
    public float gravityModifer;
    public bool isOnGround = true;
    public bool gameOver;
    public Animator playeranim;
    public ParticleSystem explosionpartical;
    public ParticleSystem dirtpartical;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    void Start()
    {
        playerrigidbody = GetComponent<Rigidbody>();
        playeranim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifer;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)  && isOnGround && !gameOver)
        {
            playerrigidbody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isOnGround = false;
            playeranim.SetTrigger("Jump_trig");
            dirtpartical.Stop();
            playerAudio.PlayOneShot(jumpSound,1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtpartical.Play();

        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playeranim.SetBool("Death_b",true);
            playeranim.SetInteger("DeathType_int",1);
            dirtpartical.Stop();
            explosionpartical.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }

    }
}
