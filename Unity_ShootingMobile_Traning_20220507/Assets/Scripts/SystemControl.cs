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
        [SerializeField, Header("移動速度"), Range(0, 300)]
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
        /// 取得虛擬搖桿值
        /// </summary>
        private void GetJoystickValue()
        {
            print("<color=yellow>水平:" + joystick.Horizontal + "</color>");
        }

        /// <summary>
        /// 移動功能
        /// </summary>
        private void Move()
        {
            //剛體.加速度 = 三維向量(X,Y,Z)
            rig.velocity = new Vector3(-joystick.Vertical, 0, joystick.Horizontal) * speed;
        }
    }
}

