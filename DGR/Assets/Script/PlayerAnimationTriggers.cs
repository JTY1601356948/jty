using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player player=>GetComponentInParent<Player>();      //�Ӹ��ڵ�Player�е��ö���player
    //  =>�൱��{get;}������ֻ�����Բ���ֵ

    private void AnimationTrigger()
    {
        player.AnimationTrigger();      //ʹ��ɵ�����player
        // �������ͨ����������һ���ض�����Ϸ����������Animator�����������ڿ��Ƹö����ϵĶ���
        //Ȼ�󶯻��¼���ֻ�ܵ��ñ���λ����Animator�����ͬ��GameObject�ϵĺ���
        //�������´�����һ���ű���Ȼ��Player player ��Ȼ��������ű������trigger
        //Ȼ�������ű��ŵ�Ҫ�����ĵط��� �������trigger
    }
}
