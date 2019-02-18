using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControl : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animate;

    private float moveSpeed = 2;
    private float turnSpeed = 200;

    private float tempV = 0;
    private float tempH = 0;
    private readonly float backwards = 0.66f;
    private bool isGrounded;
    private int count;

    public GameObject pickupEffect;
    public GameObject door;
    public string mainMenuScene;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        animate.SetBool("Grounded", isGrounded);

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        if (v < 0)
        {
            v *= backwards;
        }

        tempV = Mathf.Lerp(tempV, v, Time.deltaTime * 10);
        tempH = Mathf.Lerp(tempH, h, Time.deltaTime * 10);

        transform.position += transform.forward * tempV * moveSpeed * Time.deltaTime;
        transform.Rotate(0, tempH * turnSpeed * Time.deltaTime, 0);

        animate.SetFloat("MoveSpeed", tempV);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Instantiate(pickupEffect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            count++;

            if( count == 3)
            {
                door.GetComponent<Animation>().Play("DoorOpen");
            }
            else if (count == 4)
            {
                SceneManager.LoadScene(mainMenuScene);
            }
        }
    }
}

