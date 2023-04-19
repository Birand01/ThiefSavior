using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        PistolInteraction.OnPlayerPistolHandler += PistolWalkVector;
        PoliceSpawner.OnLevelSuccessfullyEnd += WinAnimation;
        PlayerInput.OnPlayerInput += MovementAnimation;
    }

    private void MovementAnimation(Vector3 movementVector)
    {
        if (movementVector.x != 0 || movementVector.z != 0)
        {
            anim.SetFloat("Speed", 1.0f);
        }
        else
        {
            anim.SetFloat("Speed", 0.0f);
        }

    }
    private void PistolWalkVector()
    {
        PlayerInput.OnPlayerInput += PistolWalkAnimation;

    }

    private void PistolWalkAnimation(Vector3 vector)
    {
        if (vector.x != 0 || vector.z != 0)
        {
            anim.SetBool("PistolWalk", true);
        }
        else
        {
            anim.SetBool("PistolWalk",false);
        }
       
    }
    private void WinAnimation()
    {
        anim.SetTrigger("Victory");
    }
    private void OnDisable()
    {
        PlayerInput.OnPlayerInput -= PistolWalkAnimation;
        PistolInteraction.OnPlayerPistolHandler -= PistolWalkVector;
        PoliceSpawner.OnLevelSuccessfullyEnd -= WinAnimation;
        PlayerInput.OnPlayerInput -= MovementAnimation;

    }
}
