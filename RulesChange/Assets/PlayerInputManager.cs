using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum JumpBhvrs
{
    None = 0,
    Basic = 1,
}

public enum MoveBhvrs
{
    None = 0,
    Basic = 1,        
}

public enum WallBhvrs
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
    WallBhvrBasic wallBhvrBasic;

    CurRules curRules;


    void Start()
    {
        curRules = GameObject.Find("CurrentRules").GetComponent<CurRules>();
        pStats = GetComponent<PlayerStats>();
        mvBhvrBasic = GetComponent<MvBhvrBasic>();
        jmpBhvrBasic = GetComponent<JmpBhvrBasic>();
        wallBhvrBasic = GetComponent<WallBhvrBasic>();


    }

    void CheckPlayerInput()
    {
        if(Input.GetButtonDown("Jump"))
        {
            ChooseJump();
        }

        ChooseMove();

        ChooseWallBhvr();


    }

    void ChooseJump()
    {
        switch (curRules.curJmpBhvr)
        {
            case JumpBhvrs.Basic:
                Debug.Log("jump chosen");
                jmpBhvrBasic.DoBhvr();
                break;
        }

    }

    void ChooseMove()
    {
        switch (curRules.curMvBhvr)
        {
            case MoveBhvrs.Basic:
                mvBhvrBasic.DoBhvr();
                break;
        }

    }

void ChooseWallBhvr()
    {
        switch (curRules.curWallBhvr)
        {
            case WallBhvrs.Basic:
                wallBhvrBasic.DoBhvr();
                break;
        }
    }



    void Update()
    {
        CheckPlayerInput();
    }
}
