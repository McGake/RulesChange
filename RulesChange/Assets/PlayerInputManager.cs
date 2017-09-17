using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum JumpBhvrs
{
    None = 0,
    Basic = 1,
}

enum MoveBhvrs
{
    None = 0,
    Basic = 1,        
}

public class PlayerInputManager : MonoBehaviour {


    PlayerStats pStats;
    JumpBhvrs curJmpBhvr = JumpBhvrs.Basic;
    MoveBhvrs curMvBhvr = MoveBhvrs.Basic;

    MvBhvrBasic mvBhvrBasic;
    JmpBhvrBasic jmpBhvrBasic;

    void Start()
    {        
        pStats = GetComponent<PlayerStats>();
        mvBhvrBasic = GetComponent<MvBhvrBasic>();
        jmpBhvrBasic = GetComponent<JmpBhvrBasic>();
          
    }

    void CheckPlayerInput()
    {
        if(Input.GetButtonDown("Jump"))
        {
            ChooseJump();
        }

        ChooseMove();


    }

    void ChooseJump()
    {
        switch (curJmpBhvr)
        {
            case JumpBhvrs.Basic:
                jmpBhvrBasic.DoBhvr();
                break;
        }

    }

    void ChooseMove()
    {
        switch (curMvBhvr)
        {
            case MoveBhvrs.Basic:
                mvBhvrBasic.DoBhvr();
                break;
        }

    }



    void Update()
    {
        CheckPlayerInput();
    }
}
