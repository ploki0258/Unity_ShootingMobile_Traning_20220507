using System;
using System.Collections.Specialized;
using UnityEngine;

//namespace 命名空間:程式區塊
namespace JACK
{
    /// <summary>
    /// 控制系統:荒野亂鬥移動功能
    /// 虛擬搖桿控制角色動
    /// </summary>
    public class SystemControl : MonoBehaviour
    {
        [SerializeField, Header("虛擬搖桿")]
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
        /// 取得虛擬搖桿值
        /// </summary>
        private void GetJoystickValue()
        {
            print("<color=yellow>水平:" + joystick.Horizontal + "</color>");
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

