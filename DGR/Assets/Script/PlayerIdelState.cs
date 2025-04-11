using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    // Start is called before the first frame update
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }       // ���û��๹�캯��

    public override void Enter()
    {
        base.Enter();        // ִ�л��ද����ʼ���߼�

        player.ZeroVelocity();
    }

    public override void Update()
    {
        base.Update();

        if (xInput == player.facingDir && player.IsWallDetected())
            return;
        if (xInput!=0)
            stateMachine.ChangeState(player.moveState);
    }

    public override void Exit()
    {
        base.Exit();        // ִ�л��ද�������߼�


    }
}
