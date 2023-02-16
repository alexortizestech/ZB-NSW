using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float PulseCounter,PulseLimit,PulseSpeed;
    public GameObject PulsePrefab,PulseClone;
    public GameObject Particles, cloneParticles;
    public LayerMask PlayerMask,IgnoreMe;
    public Transform player,SpawnPoint;
    public Rigidbody2D rb;
    public float scuttleSpeed;
    public float turnSpeed;
    public Enemy enemy;
    public Vector3 Direction;
    public float Health;
    public float limitL, limitR,nextFire,fireRate;
    [SerializeField]
    public GameObject bullet;
    public bool myFunctionDone;
    public GameObject Player;
    public string attack;
    [SerializeField] public float dashSpeed;
    public VisionRange fov;
    public float inRange,radius;
    public float StartHealth;
    public bool Failed;
    public bool ipProvider;
    public Vector3 lastPos;
    [SerializeField] public float Walk;
    public GameObject EnemyDeathSound;
   public bool isDashing;
    public bool isShooting;
    public MeleeWareAnimation meleeanim;
    public ArrowWareAnimation arrowanim;
    public GameObject ShootSpawn; 
   public float timer = 0;
    public PsywareAnimation psyanim;
    public int Index;
    public GameObject audioShoot;
    public GameObject cloneText, TextDeath, IPTEXT,IPCLONE;
    public Canvas renderCanvas;
    public GameObject SpawnText;
    // Start is called before the first frame update
    void Start()
    {
        psyanim= GetComponentInChildren<PsywareAnimation>();
        arrowanim = GetComponentInChildren<ArrowWareAnimation>();
        meleeanim = GetComponentInChildren<MeleeWareAnimation>();
        SpawnText = this.gameObject.transform.Find("SpawnText").gameObject;

        Player = GameObject.Find("Player");
        player = GameObject.Find("Player").transform;
        EnemyDeathSound = GameObject.Find("EnemyDeath");
        StartHealth = enemy.Health;
        dashSpeed = 100;
        fov = GetComponent<VisionRange>();
        attack = enemy.Attack;
        nextFire = 0;
        fireRate = 1.5f;
        Direction = Vector3.right;
        rb = GetComponent<Rigidbody2D>();
        Health = enemy.Health;
        limitL = transform.position.x - Walk;
        limitR= transform.position.x + Walk;
        fov.direction = Vector2.left;
        audioShoot = GameObject.Find("DisparoArroware");

    }

    // Update is called once per frame
    void Update()
    {
        if (Walk > 0)
        {
            if (Direction.x > 0 && !isDashing)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (Direction.x < 0 && !isDashing)
            {
                this.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
        }

        if (nextFire >= 1)
        {
           arrowanim.anim.ResetTrigger("isShooting");
        }

        PulseCounter += Time.deltaTime;

        if (PulseCounter >= 2)
        {if(attack == "Pulse")
            psyanim.anim.ResetTrigger("Attack");
        }
        if (PulseCounter >= PulseLimit)
        {
            Destroy(PulseClone);
            if (attack == "Pulse")
            {
                PulseAttack(2f);
            }
        }

        if (PulseClone)
        {
            PulseClone.transform.localScale += new Vector3(1,1,1)*Time.deltaTime*PulseSpeed;
        }
        if ( attack!="Shoot")
        {
            if (transform.position.x >= limitR)
            {
               
                rb.velocity = new Vector3(0, 0, 0);
               
                StartCoroutine(WaitRoutineLeft(1.5f));


            }
            else if (transform.position.x <= limitL)
            {
                
                rb.velocity = new Vector3(0, 0, 0);
               
                StartCoroutine(WaitRoutineRight(1.5f));
            }
            
            rb.AddForce(Direction * scuttleSpeed * Time.deltaTime);
        }
        else if (fov.canSeePlayer && Walk>0)
        {
            if (attack == "Shoot")
            {
                //ShootAtack();
            }

            if (attack == "Dashing")
            {
              //  SlashingAttack();
            }

            if (attack == "Melee")
            {
                if (transform.position.x >= limitR)
                {

                    rb.velocity = new Vector3(0, 0, 0);

                    StartCoroutine(WaitRoutineLeft(1.5f));


                }
                else if (transform.position.x <= limitL)
                {

                    rb.velocity = new Vector3(0, 0, 0);

                    StartCoroutine(WaitRoutineRight(1.5f));
                }

               // rb.AddForce(Direction * scuttleSpeed * Time.deltaTime);
            }
        }

        if (attack == "Shoot")
        {
            


            fov.enabled = false;
            Collider2D[] Player= Physics2D.OverlapCircleAll(transform.position, radius, PlayerMask);
            foreach (Collider2D pplayer in Player)
            {
                if (player.transform.position.x > this.gameObject.transform.position.x)
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (player.transform.position.x < this.gameObject.transform.position.x)
                {
                    this.transform.rotation = Quaternion.Euler(0, -180, 0);
                }

                Debug.DrawRay(this.transform.position, player.position - this.transform.position, Color.red);
                RaycastHit2D hit = Physics2D.Raycast(this.transform.position, player.position - this.transform.position, Vector2.Distance(player.position, this.transform.position), ~IgnoreMe);

                if (pplayer.CompareTag("Player") && hit.collider.tag=="Player") 
                {
                    // StartCoroutine(ShootWait());

                    ShootAtack();
                }


            }
         //   Debug.Log(hit.collider.tag + " raycast");
        }
      

        Vector3 tmpPos = transform.position;
        tmpPos.x = Mathf.Clamp(tmpPos.x, limitL, limitR);
        transform.position = tmpPos;
        if (Health <= 0)
        {
            Die();
        }

        if (inRange >= 1.5f)
        {
            fov.canSeePlayer = false;
            inRange = 0;
        }


      
    }


    private void LateUpdate()
    {
        
      //  myFunctionDone = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           /* if (myFunctionDone && collision.GetComponent<Movement>().isDashing==false)
            {
                if (Health < StartHealth)
                {
                    Failed = true;
                    myFunctionDone = false;
                }
            }*/
            // myFunctionDone = false;
        }
    }
    public void TakeDamage(int damage)
    {
        if (!myFunctionDone)
        {
            Health -= damage;
            myFunctionDone = true;
        }
        StartCoroutine(Done());
    }
    public void Die()
    {
        float motor = 0.1f;
        if (Player.GetComponent<Movement>().gm.GetComponent<JoystickDetector>().PS4_Controller == 1)
        {
            motor = 0.8f;
        }else
        {
            motor = 0.1f;
        }
        
        motor -= 2*Time.deltaTime;
        Player.GetComponent<Movement>().ControllerVibration(0, motor, 0.4f);
        //  StartCoroutine(Player.GetComponent<Movement>().GlitchKilled(0.5f));
        Destroy(cloneText);
        cloneText = Instantiate(TextDeath, SpawnText.transform.position, transform.rotation);
        cloneText.transform.localScale = (this.transform.localScale)*2.5f;
        var canvas2 = Instantiate(renderCanvas, transform.position, transform.rotation);
        canvas2.renderMode = RenderMode.WorldSpace;
        cloneText.transform.SetParent(canvas2.transform, false);

        if (ipProvider == true)
        {
            IPCLONE = Instantiate(IPTEXT, new Vector2(SpawnText.transform.position.x-2,SpawnText.transform.position.y-2), transform.rotation);
            IPCLONE.transform.localScale = (this.transform.localScale) * 2.5f;
            IPCLONE.transform.SetParent(canvas2.transform, false);
            Destroy(IPCLONE, 2F);
        }
        Destroy(cloneText, 2f);
       // Destroy(canvas2, 2.5f);
        EnemyDeathSound.GetComponent<AudioSource>().Play();
        Player.GetComponent<Movement>().hits += 1;
        Player.GetComponent<Movement>().Touch += 1;
        Player.GetComponent<Movement>().Killed();
        Destroy(PulseClone);
        cloneParticles = Instantiate(Particles, transform.position,transform.rotation);
        Destroy(cloneParticles, 2f);
        if (ipProvider == true)
        {
            Player.GetComponent<Movement>().ipCount += 1;
        }


        
        Destroy(this.gameObject);
        
    }

    public void PulseAttack(float speed)
    {
        PulseClone = Instantiate(PulsePrefab, transform.position, transform.rotation);
        psyanim.anim.SetTrigger("Attack");
        PulseCounter = 0; 
    }
   public void ShootAtack()
    {

        
        timer += Time.deltaTime;
        if (timer >= 6f)
        {
            Instantiate(bullet, ShootSpawn.transform.position, Quaternion.identity);
            arrowanim.anim.SetTrigger("isShooting");
            arrowanim.ColorChange();
            timer = 0;
            audioShoot.GetComponent<AudioSource>().Play();

        }








    }

    
    public void MeleeAttack()
    {
        lastPos = player.position;
        var destiny = lastPos - transform.position;
        StartCoroutine(DashingEnemy(destiny, 3));
    }
   
    public void SlashingAttack()
    {
        if(player.position.y >=transform.position.y-0.5f && player.position.y <= transform.position.y +0.5f)
        lastPos = player.position;
        var destiny= lastPos - transform.position;
        StartCoroutine(DashingEnemy(destiny,1));
    }

    IEnumerator DashingEnemy(Vector3 destiny,float divide)
    {
        yield return new WaitForSeconds(0.5f);
        inRange += 1 * Time.deltaTime;
        rb.velocity = new Vector3(0, 0, 0);
        rb.velocity = new Vector3(-lastPos.x/2, 0, 0); //opcional
        yield return new WaitForSeconds(0.1f); //
        yield return new WaitForSeconds(0.5f); //1f
        if(transform.position.x>=limitL && transform.position.x<=limitR)
        rb.AddForce(destiny.normalized * dashSpeed/divide);
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator WaitRoutineLeft(float time)
    {
        yield return new WaitForSeconds(time);
        Direction = Vector3.left;
        fov.direction = Vector2.left;
      
    }
    IEnumerator WaitRoutineRight(float time)
    {
        yield return new WaitForSeconds(time);
        Direction = Vector3.right;
        fov.direction = Vector2.right;
        
    }

    IEnumerator Done()
    {
        yield return new WaitForSeconds(0.5f);
        myFunctionDone = false;
    }

   
}