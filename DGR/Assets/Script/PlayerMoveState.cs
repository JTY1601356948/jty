using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    // Start is called before the first frame update
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
            
    }

    public override void Update()
    {
        base.Update();


        player.SetVelocity(xInput * player.moveSpeed, player.rb.linearVelocity.y);
        //ע�⣺�˴�����дΪplayer.rb.velocity.y,��Ϊ��״̬���Ŀɶ��Ժ������ԣ�����playerState������rb�Ի���

        if (xInput==0&&player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);
    }
}
