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
        [SerializeField, Header("�����V�ϥ�")]
        private Transform traDirectionIcon;
        [SerializeField, Header("�����V�ϥܽd��")]
        private float rangeDirectionIcon = 2.5f;
        [SerializeField, Header("�������t��"), Range(0, 100)]
        private float speedTurn = 1.5f;
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
            UpdateDirectionIconPos();
            LookDirectionIcon();
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
        /// ��s�����V�ϥܪ��y��
        /// </summary>
        private void UpdateDirectionIconPos()
        {
            //�s�y�� = ����y�� + �T���V�q(�����n�쪺�����P����) * ��V�ϥܽd��
            Vector3 pos = transform.position + new Vector3(-joystick.Vertical, 0.5f, joystick.Horizontal) * rangeDirectionIcon;

            //��s��V�ϥܪ��y�� = �s�y��
            traDirectionIcon.position = pos;
        }

        /// <summary>
        /// ���V��V�ϥ�
        /// </summary>
        private void LookDirectionIcon()
        {
            //���o���V���� = �|�줸.���V����(��V�ϥ� - ����) - ��V�ϥܻP���⪺�V�q
            Quaternion look = Quaternion.LookRotation(traDirectionIcon.position - transform.position);

            //���⪺���� = �|�줸.����(���⪺���סA���V���סA����t�� * �@�V���ɶ�)
            transform.rotation = Quaternion.Lerp(transform.rotation, look, speedTurn * Time.deltaTime);

            //���⪺�کԨ��� = �T���V�q(0�A�쥻���کԨ��סA0)
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }

        /// <summary>
        /// ��s�ʵe
        /// </summary>
        private void UpdateAnimation()
        {
            //�O�_�]�B = �����n�� ���� ����0 �� ���� ����0
            bool run = joystick.Horizontal != 0 || joystick.Vertical != 0;
            ani.SetBool(parameterWalk, run);
        }
    }
}

