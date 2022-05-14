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

        private Rigidbody rig;

        private void Awake()
        {
            rig = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            GetJoystickValue();
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
        /// 5
        /// </summary>
        private void Move()
        {
            rig.velocity = new Vector3(0, 0, joystick.Horizontal);
        }
    }
}

