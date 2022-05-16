using System;
using System.Collections.Specialized;
using UnityEngine;

//namespace �R�W�Ŷ�:�{���϶�
namespace JACK
{
    /// <summary>
    /// ����t��:��ð����ʥ\��
    /// �����n�챱����
    /// </summary>
    public class SystemControl : MonoBehaviour
    {
        [SerializeField, Header("�����n��")]
        private Joystick joystick;
        [SerializeField, Header("���ʳt��"), Range(0, 300)]
        private float speed = 3.5f;
        [SerializeField, Header("�ʵe�Ѽƶ]�B")]
        private string parameterWalk = "�}���]�B";


        private Rigidbody rig;
        private Animator ani;

        private void Awake()
        {
            rig = GetComponent<Rigidbody>();
            ani = GetComponent<Animator>();
        }

        private void Update()
        {
            //GetJoystickValue();
            UpdateAnimation();
        }

        private void FixedUpdate()
        {
            Move();
        }

        /// <summary>
        /// ���o�����n���
        /// </summary>
        private void GetJoystickValue()
        {
            print("<color=yellow>����:" + joystick.Horizontal + "</color>");
        }

        /// <summary>
        /// ���ʥ\��
        /// </summary>
        private void Move()
        {
            //����.�[�t�� = �T���V�q(X,Y,Z)
            rig.velocity = new Vector3(-joystick.Vertical, 0, joystick.Horizontal) * speed;
        }

        /// <summary>
        /// ��s�ʵe
        /// </summary>
        private void UpdateAnimation()
        {
            //�O�_�]�B = �����n�� ���� ����0 �� ���� ����0
            bool run = joystick.Horizontal != 0 || joystick.Vertical != 0;
            ani.SetBool(parameterWalk,run);
        }
    }
}

