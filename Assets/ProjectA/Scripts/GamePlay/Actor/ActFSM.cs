using System.Collections;
using UnityEngine;

public class ActFSM : MonoBehaviour
{
    public class Settings
    {
        // FSM �ӽ��� ����ϴ� ��ü�� ����
        public eACT_FSM State;
        
        // FSM �ӽ��� ���� ������ �� �Ѿ�� �ð�
        public float ThinkTime;
    }
    public Settings FSM = new Settings() { State = eACT_FSM.Default , ThinkTime = 0 };

    public eACT_FSM FS => FSM.State;

    /// <summary>
    /// FSM ���� ��
    /// </summary>
    public void OnFSM()
    {
        StartCoroutine(FSM.State.ToString());
    }

    /// <summary>
    /// ���� ��ü�ϴ� �Լ�
    /// </summary>
    public void OnChangeState()
    {
        if (FSM.State != eACT_FSM.Dead)
            StartCoroutine(FSM.State.ToString());
        else
            OnDead();
    }

    public virtual void OnIdle()
    {
    }

    public virtual void OnAttack()
    {
    }

    public virtual void OnDefense()
    {
    }

    public virtual void OnDead()
    {
    }

    private IEnumerator Idle()
    {
        while (FS == eACT_FSM.Idle)
        {
            OnIdle();
            yield return new WaitForSeconds(FSM.ThinkTime);
        }
        OnChangeState();
    }

    private IEnumerator Attack()
    {
        while (FS == eACT_FSM.Attack)
        {
            OnAttack();
            yield return new WaitForSeconds(FSM.ThinkTime);
        }
        OnChangeState();
    }

    private IEnumerator Defense()
    {
        while (FS == eACT_FSM.Defense)
        {
            OnDefense();
            yield return new WaitForSeconds(FSM.ThinkTime);
        }
        OnChangeState();
    }
}
