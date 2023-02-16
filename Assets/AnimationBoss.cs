using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBoss : MonoBehaviour
{
    public float shootcount;
    public GameObject cloneExplosion, Explosion;
    public ShootBoss shoot;
    public GameObject Sparkles;
    public bool canHurt;
    public FinalBoss boss;
    public float count;
    public Animator anim;
    public bool Pulse, Shoot;
    public PulseBoss pulse;
    public int Damageable, Damaged;
    public BoxCollider2D bc;
    public GameObject spawn;
    public AudioSource Arm,pulseSound,ShootSound,Tension,electric;
    // Start is called before the first frame update
    void Start()
    {
       
        boss = GetComponentInParent<FinalBoss>();
    }

    // Update is called once per frame
    void Update()
    {
        count += 1 * Time.deltaTime;

        if (count >= 6f && !boss.isAttacking)
        {
            SpawnAnimation();

        }

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Pulse") || anim.GetCurrentAnimatorStateInfo(0).IsName("VerticalAttack"))
        {
            boss.isAttacking = true;
        }else if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Pulse") && !anim.GetCurrentAnimatorStateInfo(0).IsName("VerticalAttack"))
        {
            boss.isAttacking = false;
        }

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Spawn") || anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            bc.enabled = false;
        }
        else
        {
            bc.enabled = true;
        }
            
        if (boss.isAttacking)
        {
            count = 0;
        }

        if (boss.Health == Damageable)
        {
            canHurt = true;
        }

        if (boss.Health == Damaged)
        {
            Explosion.SetActive(true);
            Destroy(Explosion, 2f);
         
            canHurt = false;
            Sparkles.SetActive(true);
            electric.Play();
        }
    }

    public void SpawnAnimation()
    {

        int i = (int)Random.Range(1, 3);
        
        if(boss.Health==1 && Pulse)
        {
            i = 2;
        }


        if (boss.Health == 1 && Shoot)
        {
            return;
        }
        if (i == 1)
        {
            StartCoroutine(AudioArm());
            anim.SetTrigger("Vertical");
        }
        else if (i == 2)
        {
            
            anim.SetTrigger("Pulse");
            if (Pulse)
            {
                pulseSound.Play();
                pulse.PulseAttack();
            }

            if (shoot)
            {
                StartCoroutine(ShootRoutine());
            }

        }
        count = 0;
        Debug.Log("Random Range" + i);
        
    }


    IEnumerator ShootRoutine()
    {
        yield return new WaitForSeconds(2.5f);
        ShootSound.Play();
        shoot.ShootAttack();
        yield return new WaitForSeconds(1f);
        ShootSound.Play();
        shoot.ShootAttack();
        yield return new WaitForSeconds(1f);
        ShootSound.Play();
        shoot.ShootAttack();
        yield return new WaitForSeconds(1f);
        ShootSound.Play();
        shoot.ShootAttack();
        yield return new WaitForSeconds(1f);
        ShootSound.Play();
        shoot.ShootAttack();
        yield return new WaitForSeconds(1f);
    }

    IEnumerator AudioArm()
    {
        Tension.Play();
        yield return new WaitForSeconds(2.8f);
        Arm.Play();
        yield return new WaitForSeconds(3.5f);
        Tension.Stop();
        Arm.Play();

    }
}
