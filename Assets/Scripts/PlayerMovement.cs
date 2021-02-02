using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameObject[] skillParticles;
    private IEnumerator coroutine;

    void Start()
    {
        animator = GetComponent<Animator>();
        for (int i = 0; i < skillParticles.Length; i++)
        {
            skillParticles[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        Sprint();
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
        if (Input.GetKeyDown(KeyCode.Alpha1)) UseSkill(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) UseSkill(2);
        if (Input.GetKeyDown(KeyCode.Alpha3)) UseSkill(3);
        if (Input.GetKeyDown(KeyCode.Alpha4)) UseSkill(4);
        if (Input.GetKeyDown(KeyCode.Alpha5)) UseSkill(5);
    }

    public void UseSkill(int skillNumber)
    {
        animator.SetTrigger("skill" + skillNumber);
        skillParticles[skillNumber - 1].SetActive(true);

        switch(skillNumber)
        {
            case 1:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 5);
                break;

            case 2:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 3);
                break;

            case 3:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 3);
                break;

            case 4:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 6);
                break;

            case 5:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 5);
                break;
        }

        StartCoroutine(coroutine);
    }

    IEnumerator WaitToEnableObject(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }

    public void Jump()
    {
        animator.SetTrigger("jump");
    }

    public void Sprint()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("sprint", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("sprint", false);
        }
    }
}
