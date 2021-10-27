using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 1.0f;
    [SerializeField]
    public Rigidbody2D rigidbody = null;
    SavePlayerPos savePlayerPos;
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
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(inputX * moveSpeed * Time.deltaTime, inputY * moveSpeed * Time.deltaTime, 0);
        //rigidbody.velocity = new Vector3(inputX * moveSpeed , inputY * moveSpeed , 0);
    }
}
