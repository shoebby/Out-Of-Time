using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : Singleton<PlayerScript>
{
    public CharacterController controller;
    private Animator playerAnim;

    public bool canMove = true;
    public float walkSpeed = 1f;
    public float turnSpeed = 90f;

    private float animTimer = 0f;

    protected override void Awake()
    {
        base.Awake();
        controller = GetComponent<CharacterController>();
        playerAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        canMove = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
        #region Movement

        if (canMove)
        {
            Vector3 movDir;

            //check if strafing before applying movement
            if (Input.GetKey(KeyCode.Z))
            {
                movDir = transform.right * -walkSpeed;
            }
            else if (Input.GetKey(KeyCode.C))
            {
                movDir = transform.right * walkSpeed;
            }
            else
            {
                //rotation and forward movement
                transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
                movDir = transform.forward * Input.GetAxis("Vertical") * walkSpeed;
            }
            // move the character
            controller.Move(movDir * Time.deltaTime - Vector3.up * 0.1f);

            //animation stuff
            animTimer -= Time.deltaTime;

            if (movDir != Vector3.zero)
            {
                playerAnim.Play("player_walk");
                animTimer = 0f;
            } else
            {
                if (animTimer <= 0f)
                {
                    if (Random.Range(1, 100) <= 75)
                        playerAnim.Play("player_idle");
                    else
                    {
                        playerAnim.Play("player_tpose");
                        ConsoleLogger.Instance.MakeLog("Could not find frame <" + Random.Range(1,60) + "> of 'player_idle.anim'", LogType.Log);
                    }

                    animTimer = Random.Range(1, 10);
                }
                
            }
        }
        #endregion

        
    }
}