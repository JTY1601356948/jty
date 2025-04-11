using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine        
{
    // ��ǰ����״̬��ֻ�����ԣ��ⲿֻ�ܻ�ȡ����ֱ���޸ģ�
    public PlayerState currentState{ get; private set; }

    public void Initialize(PlayerState _startstate)
    {
        currentState = _startstate;     // ���ó�ʼ״̬
        currentState.Enter();       // ִ�г�ʼ״̬�Ľ����߼�
    }

    public void ChangeState(PlayerState _newstate)
    {
        currentState.Exit();        // �˳���ǰ״̬
        currentState = _newstate;       // ���µ�ǰ״̬����
        currentState.Enter();       // ִ����״̬�Ľ����߼�
    }
}
