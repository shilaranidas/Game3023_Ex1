using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 1.0f;
    [SerializeField]
    public Rigidbody2D rigidbody = null;
    SavePlayerPos savePlayerPos;
    [SerializeField]
    private Animator animator;
    public bool isFly=false;
    public bool isWalking = false;
    private void Awake()
    {
        //savePlayerPos = FindObjectOfType<SavePlayerPos>();
        //savePlayerPos.PlayerPosLoad();
    }
    // Start is called before the first frame update
    void Start()
    {
       // rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    isGrounded = false;
        //}
        //else if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    isGrounded = true;
        //}
       
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");

        if (inputX != 0)
        {
            isWalking = true;
        }
        else
            isWalking = false;

        if (transform.position.y > -2.92)
        {
            isFly = true;
            Debug.Log("fly" + isFly);
        }
        else 
        { isFly = false;
            Debug.Log("fly" + isFly);
        }
        animator.SetBool("IsWalking", isWalking);
        animator.SetBool("IsFly", isFly);
        if (inputX != 0)
        {
            inputX = FlipVertically(inputX);
            transform.position += new Vector3(inputX * moveSpeed * Time.deltaTime, inputY * moveSpeed * Time.deltaTime, 0);
        }
        if (inputY != 0)
        {

            transform.position += new Vector3(inputX * moveSpeed * Time.deltaTime, inputY * moveSpeed * Time.deltaTime, 0);
        }


        //rigidbody.velocity = new Vector3(inputX * moveSpeed , inputY * moveSpeed , 0);
    }
    private float FlipVertically(float x)
    {
        //depeding on direction, scale accross the x axis either 1 or -1 
        x = (x > 0) ? 1 : -1; //motion to right = 1, left = -1 
        transform.localScale = new Vector3(x, 1.0f);
        return x;
    }
}
