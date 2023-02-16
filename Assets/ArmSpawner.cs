using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSpawner : MonoBehaviour
{
    bool Done1, Done2;
    public FinalBoss boss;
    public GameObject leftArm, centerArm;
    // Start is called before the first frame update
    void Start()
    {
        leftArm.GetComponent<AnimationBoss>().enabled = false;
        leftArm.GetComponent<ShootBoss>().enabled = false;
        centerArm.GetComponent<AnimationBoss>().enabled = false;
        centerArm.GetComponent<PulseBoss>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.Health == 3 &&!Done1)
        {
            leftArm.GetComponent<Animator>().SetTrigger("Spawn");
            leftArm.GetComponent<Animator>().SetBool("Sleeping",false);
            leftArm.GetComponent<AnimationBoss>().enabled = true;
            leftArm.GetComponent<ShootBoss>().enabled = true;
            leftArm.GetComponent<AnimationBoss>().count = 3;
            Done1 = true;
        }

        if (boss.Health == 2 && !Done2)
        {
            centerArm.GetComponent<Animator>().SetTrigger("Spawn");
            centerArm.GetComponent<Animator>().SetBool("Sleeping", false);
            centerArm.GetComponent<AnimationBoss>().enabled = true;
            centerArm.GetComponent<PulseBoss>().enabled = true;
            centerArm.GetComponent<AnimationBoss>().count = 3;
            Done2 = true;
        }

        if (boss.Health == 1)
        {
            //open eye
        }
    }
}
