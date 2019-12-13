using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour {
    public float m_speed = 5f;
    //private Transform m_transform;          
    //private float rotationz = 0.0f;         //Z轴旋转量
    //public float rotateSpeed_Axisy = 45f;     //绕Z轴旋转速度
    private Vector2 touchPosition;          //触摸点坐标
    private float screenWeight;             //屏幕宽度
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
    private Vector2 FirstTouch;
    private Vector2 direction;
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


        int touchNum = Input.touchCount;

        if (touchNum > 0)
        {
            
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                 FirstTouch = touch.position;
            }
            if ((touch.phase == TouchPhase.Moved) || (touch.phase == TouchPhase.Stationary))
            {
                Characterismoving = true;
                _animator.SetBool("Characterismoving", true);
                direction =  touch.position-FirstTouch;
                Vector3 dir = new Vector3(direction.x / Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2)), 0f, direction.y / Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2)));
                controller.Move(dir *MoveSpeed* Time.deltaTime);
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