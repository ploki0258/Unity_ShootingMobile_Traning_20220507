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

        private Rigidbody rig;

        private void Awake()
        {
            rig = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            //GetJoystickValue();
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
    }
}

