using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity     //���Ĺ������
{
    //public bool isBusy {  get; private set; }
    [Header("Move info")]
    public float moveSpeed = 12f;
    public float jumpForce = 12f;

    [Header("Dash info")]
    [SerializeField] private float dashCooldown;
    private float dashUsageTimer;
    public float dashSpeed;
    public float dashDuration;
    public float dashDir {  get; private set; }
    

    public PlayerStateMachine stateMachine { get; private set; }        //����ֻ����״̬�����ԣ����ڹ���״̬�л�
    public PlayerIdleState idleState { get; private set; }      //�����Ŀ���״̬���ƶ�״̬���ԣ�Ԥ����n�ֻ���״̬
    public PlayerMoveState moveState { get; private set; }

    public PlayerDashState dashState { get; private set; }


    protected override void Awake()         //public�κεط������Է��ʣ������ƣ�     protected������ǰ��?����������??���ʣ��ܱ�����
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();        //����״̬��ʵ��
        idleState =new PlayerIdleState(this,stateMachine,"Idle");       //��ʼ��n��״̬
        moveState = new PlayerMoveState(this, stateMachine, "Move");

        dashState = new PlayerDashState(this, stateMachine, "Dash");

    }
    protected override void Start()
    {
        base.Start();
        
        stateMachine.Initialize(idleState);     //���ó�ʼ״̬Ϊ����״̬

    }

    

    protected override void Update()       //��������update�е��¼�����Ϊÿ֡���ûή������
    {
        base.Update();

        stateMachine.currentState.Update();     //���µ�ǰ״̬��״̬

        CheckForDashInput();
        //StartCoroutine("BusyFor", .1f);
    }

    //public IEnumerator BusyFor(float _seconds)
    //{
    //    isBusy = true;
    //    yield return new WaitForSeconds(_seconds);
    //    isBusy=false;
    //}

    public void AnimationTrigger()=>stateMachine.currentState.AnimationFinishTrigger();

    private void CheckForDashInput()
    {
        
        dashUsageTimer -= Time.deltaTime;

        if(IsWallDetected()) 
            return;

        if(Input.GetKey(KeyCode.LeftShift) &&dashUsageTimer<0)
        {
            dashUsageTimer = dashCooldown;
            dashDir = Input.GetAxisRaw("Horizontal");

            if(dashDir == 0)
                dashDir=facingDir;

            stateMachine.ChangeState(dashState);
        }
    }
    


}
