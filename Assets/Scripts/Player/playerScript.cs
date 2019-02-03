using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

    public float speed;
    public string axnameA, axnameB;
    Vector3 startPos, endPos;
    public bool isMoving, canMove, inBattle;
    Vector2 input;
    RaycastHit2D hit;
    Animator anim;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        canMove = true;
    }

    void FixedUpdate()
    {
 

    }
    // Update is called once per frame
    void Update() {

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            anim.SetBool("moving", true);
        else
            anim.SetBool("moving", false);

        if (!isMoving && !inBattle)
        {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                input.y = 0;
            else
                input.x = 0;

            if (input != Vector2.zero)
            {
                StartCoroutine(Move(transform));
            }
            canMove = true;

        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            StartCoroutine(animationDelay());
            anim.SetBool("side", true);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            Vector3 tempScale = transform.localScale;
            tempScale.x = 1;
            transform.localScale = tempScale;
        }
        else
if (Input.GetAxis("Horizontal") < 0)
        {
            StartCoroutine(animationDelay());
            anim.SetBool("side", true);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            Vector3 tempScale = transform.localScale;
            tempScale.x = -1;
            transform.localScale = tempScale;

        }
        else
 if (Input.GetAxis("Vertical") > 0)
        {
            StartCoroutine(animationDelay());
            anim.SetBool("up", true);
            anim.SetBool("side", false);
            anim.SetBool("down", false);
        }
        else
if (Input.GetAxis("Vertical") < 0)
        {
            StartCoroutine(animationDelay());
            anim.SetBool("down", true);
            anim.SetBool("up", false);
            anim.SetBool("side", false);
        }

    }

    public IEnumerator Move(Transform obj)
    {
        isMoving = true;
        startPos = obj.position;

        float t = 0;
        if (Input.GetAxis("Horizontal") != 0)
            hit = Physics2D.Raycast(transform.position, Vector2.right * System.Math.Sign(input.x), 1);

        if (Input.GetAxis("Vertical") != 0)
            hit = Physics2D.Raycast(transform.position, Vector2.up * System.Math.Sign(input.y), 1);


        if (hit && hit.transform.tag == "border")
        {
            //Debug.Log(hit.transform.tag);
            canMove = false;
        }


        endPos = new Vector3(startPos.x + System.Math.Sign(input.x), startPos.y + System.Math.Sign(input.y), startPos.z);


        if (canMove)
        {
            while (t < 1f)
            {
                t += Time.deltaTime * speed;
                obj.position = Vector3.Lerp(startPos, endPos, t);
                yield return null;
            }
        }
        isMoving = false;


        yield return 0;
    }

    IEnumerator animationDelay()
    {
        yield return new WaitForSeconds(.2f);
    }

}
