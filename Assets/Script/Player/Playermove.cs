using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour {
    public float m_speed = 5f;
    //private Transform m_transform;          
    //private float rotationz = 0.0f;         //Z轴旋转量
    //public float rotateSpeed_Axisy = 45f;     //绕Z轴旋转速度
    private Vector2 touchPosition;          //触摸点坐标
    //private float screenWeight;             //屏幕宽度
    public Vector3 fristPos;//接触时的position 
    public Vector3 twoPos;//移动后的position 

    private Vector3 moveDirection;
    public float speeduptimer;
    public float MoveSpeed;
    private float NormalSpeed;
    private float SpeedUpMoveSpeed;
    public float jumpForce;
    public CharacterController controller;
    public float gravityScale;
    public bool Characterismoving =false;
    private Animator _animator;

    //碰撞
    //包含上述MoveSpeed
    public float deltaTime;
    public Vector3 deltaMove;

    public GameObject target;

    // Use this for initialization
    void Start () {
        //m_transform = this.transform;
        //screenWeight = Screen.width;        //获取屏幕宽度
        controller = GetComponent<CharacterController>();  //設置controller為角色控制器
        _animator = this.GetComponent<Animator>();
        NormalSpeed = MoveSpeed;
        SpeedUpMoveSpeed = 1.5f * MoveSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        
#if UNITY_IOS || UNITY_ANDROID
...//这里的代码在IOS和Android平台都会编译

        float moveY = 0;// 上下移动的速度         
        float moveX = 0;//左右移动的速度
        if (Input.touchCount > 0)   //当触摸数量大于0
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.touches[i];     //实例化当前触摸点
                touchPosition = touch.position; //获取触摸点坐标
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    if (touchPosition.x < screenWeight / 2)   //触摸点坐标的x如果在屏幕左半方
                    {
                        if (fristPos.y < twoPos.y && Camera.main.WorldToScreenPoint(transform.position).y < Screen.height)
                        {
                            moveY += m_speed * Time.deltaTime;
                        }
                        //判断向下移动,并且不出下边屏幕 
                        if (fristPos.y > twoPos.y && Camera.main.WorldToScreenPoint(transform.position).y > 0)
                        {
                            moveY -= m_speed * Time.deltaTime;
                        }
                        //判断向左移动,并且不出左边屏幕 
                        if (fristPos.x > twoPos.x && Camera.main.WorldToScreenPoint(transform.position).x > 0)
                        {
                            moveX -= m_speed * Time.deltaTime;
                        }
                        //判断向右移动,并且不出右边屏幕 
                        if (fristPos.x < twoPos.x && Camera.main.WorldToScreenPoint(transform.position).x < Screen.width)
                        {
                            moveX += m_speed *  Time.deltaTime;
                        }
                        transform.Translate(moveX, moveY, 0);
                    }
                }
            }
        }
#endif


        //風屬性改變速度
        if (speeduptimer > 0.1f)
        {
            speeduptimer -= Time.deltaTime;

            MoveSpeed = SpeedUpMoveSpeed;
        }
        else if (speeduptimer <= 0.0f)
        {
            MoveSpeed = NormalSpeed;
            speeduptimer = 0.0f;
        }

        //移動
        
        
         if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))||( Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))|| (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))||(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)))
        {
            Characterismoving = true;

            _animator.SetBool("Characterismoving", true);
            //moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);   //賦予角色跳起來後跳下來的速度
            controller.Move(moveDirection * Time.deltaTime);  //用deltatime去控制每台顯示器不同的平衡
            //moveDirection = new Vector3(Input.GetAxis("Horizontal") * MoveSpeed, moveDirection.y, Input.GetAxis("Vertical") * MoveSpeed);
            moveDirection = new Vector3(Input.GetAxis("Horizontal") / Mathf.Sqrt(2)*MoveSpeed, 0, Input.GetAxis("Vertical") / Mathf.Sqrt(2) * MoveSpeed);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Characterismoving = true;

            _animator.SetBool("Characterismoving", true);
            //moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);   //賦予角色跳起來後跳下來的速度
            controller.Move(moveDirection * Time.deltaTime);  //用deltatime去控制每台顯示器不同的平衡
            //moveDirection = new Vector3(Input.GetAxis("Horizontal") * MoveSpeed, moveDirection.y, Input.GetAxis("Vertical") * MoveSpeed);
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * MoveSpeed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            Characterismoving = true;

            _animator.SetBool("Characterismoving", true);
            //moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);   //賦予角色跳起來後跳下來的速度
            controller.Move(moveDirection * Time.deltaTime);  //用deltatime去控制每台顯示器不同的平衡
            //moveDirection = new Vector3(Input.GetAxis("Horizontal") * MoveSpeed, moveDirection.y, Input.GetAxis("Vertical") * MoveSpeed);
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical") * MoveSpeed);
        }
        else
        {
            Characterismoving = false;
            _animator.SetBool("Characterismoving", false);
        }

        //碰撞
        //deltaMove = MoveSpeed * Time.deltaTime;



        /*(Vector3 raystart = GameObject.Find("Ashe").transform.position;
        float updown = 1;
        Vector3 raydir = Vector3.right;

        target = GameObject.Find("Ashe");

        BoxCollider mycollider = target.GetComponent<BoxCollider>();
        float halfBoundY = mycollider.size.z * GameObject.Find("Ashe").transform.localScale.z; 
        float rayLength = Mathf.Abs(deltaMove.z) + halfBoundY; 

        RaycastHit rhf = new RaycastHit(); 
        if (Physics.Raycast(raystart, raydir, out rhf, rayLength))
        {
            
            if (rhf.collider != null && rhf.collider.gameObject.tag == "wall") 
            {
                Debug.Log("Success"+rhf.collider+rhf.collider.gameObject.tag);
                deltaMove.z = rhf.point.z - raystart.z + halfBoundY * -updown; 
            }
        }
        */

        /*
        //Translate移动控制函数
        float horizontal = Input.GetAxis("Horizontal"); //A D 左右
            float vertical = Input.GetAxis("Vertical"); //W S 上 下
        { 
            m_transform.Translate(Vector3.forward * vertical * m_speed * Time.deltaTime);//W S 上 下
            m_transform.Translate(Vector3.right * horizontal * m_speed * Time.deltaTime);//A D 左右
        }
        
         */
    }
}