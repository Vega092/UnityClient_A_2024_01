using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExParentClass : MonoBehaviour      //��� : ����Ƽ ������Ʈ���� �����ϰ�
{
    //protected�� ����� ������ ���� Ŭ���� �� �Ļ� Ŭ�������� ���� ����
    protected int protectedValue;
}

public class ExChildClass : ExParentClass       //ExParentClass�� ���
{
    void Start()
    {
        //ExParentCalss�� Protected ������ ���� ����
        Debug.Log("Protected Value From Child Class : " + protectedValue);
    }
}