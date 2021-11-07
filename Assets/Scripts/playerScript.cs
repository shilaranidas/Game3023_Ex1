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
    public bool isGrounded=true;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = false;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isGrounded = true;
        }
        if (isGrounded)
        {
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");

            if (inputX != 0)
            {
                animator.SetBool("IsWalking", true);
                animator.SetBool("IsFly", false);
                inputX = FlipVertically(inputX);
                transform.position += new Vector3(inputX * moveSpeed * Time.deltaTime, inputY * moveSpeed * Time.deltaTime, 0);
            }
            else
            { 
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsFly", false);
            }
        }
        else
        {

            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");

            if (inputX != 0)
            {
                animator.SetBool("IsWalking", true);
                animator.SetBool("IsFly", true);
                inputX = FlipVertically(inputX);
                transform.position += new Vector3(inputX * moveSpeed * Time.deltaTime, inputY * moveSpeed * Time.deltaTime, 0);
            }
            else
            { 
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsFly", true);
            }
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
