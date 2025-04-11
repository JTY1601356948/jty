using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Component
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }      //�������޷��޸�
    #endregion

    [Header("Collision info")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;

    public  int facingDir { get; private set; } = 1;
    protected  bool facingRight = true;


    protected virtual void Awake()     //virtual����ʽʹ�ú�������override��д�������޷������ิд����֧������ʱ��̬
    //voidʹ�������᷵��ֵ
    {

    }

    protected virtual void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {

    }

    #region Velocity
    public void ZeroVelocity() => rb.linearVelocity = new Vector2(0, 0);

    public void SetVelocity(float _xInput, float _yInput)
    {
        rb.linearVelocity = new Vector2(_xInput, _yInput);
        FlipController(_xInput);        //�ڴ˴�����flip��ʹֻ�е�����ʱ����ת�򣬱�����˻�����ʱ�㲻�ᷴת�����Ӿ��ܣ�������update���޷�ʵ��
    }
    #endregion
    #region Collision
    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);

    public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }
    #endregion
    //Ϊ�˿������ิд��public bool=>public virtual bool;private void=>protected virtual void


    #region Flip
    public virtual void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public virtual void FlipController(float _x)
    {
        if (_x > 0 && !facingRight)
            Flip();
        else if (_x < 0 && facingRight)
            Flip();
    }
    #endregion
}
