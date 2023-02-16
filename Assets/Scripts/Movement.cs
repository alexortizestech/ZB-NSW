using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Rewired;
using UnityEngine.Rendering.PostProcessing;
using Com.LuisPedroFonseca.ProCamera2D;
#if UNITY_SWITCH
using Rewired.Platforms.Switch;
#endif
public class Movement : MonoBehaviour
{
    public KeyCode Attack,JumpKey;

    public NailedRigidbody nr;
    private Collision coll;
    [HideInInspector]
    public Rigidbody2D rb;
    private AnimationScript anim;
    

    [Space]
    [Header("Stats")]
    public float speed = 5.5f;
    public float jumpForce = 50;
    public float slideSpeed = 6f;
    public float wallJumpLerp = 10;
    public float dashSpeed = 20;

    [Space]
    [Header("Booleans")]
    public bool canMove;
    public bool wallGrab;
    public bool wallJumped;
    public bool wallSlide;
    public bool isDashing;
    public bool isRecharging;
    public bool isStunned;
    public bool isDead;

    [Space]

    private bool groundTouch;
    private bool hasDashed;

    public int side = 1;

    [Space]
    [Header("Polish")]
    public ParticleSystem dashParticle;
    public ParticleSystem jumpParticle;
    public ParticleSystem wallJumpParticle;
    public ParticleSystem slideParticle;
    public ParticleSystem deathParticle;
    public ParticleSystem Dashps;
    public ParticleSystem StunParticle;


    [Space]
    [Header("Slash")]

    public float radius;
    public float CountSlash;
    public float ComboTime;
    public float limit=0;
    public LayerMask enemyLayer;
    public int Damage;
    public bool Combo;
    public GameObject SpriteSlash;
    public GameObject ReloadParticles;
    public GameObject cloneReload;
    public float enemiesHit;
    public float Touch;
    public TimeStop TimeStop;
    public GameObject LightSlash;



    [Space]
    [Header("Player")]
    public GameObject main;
    public int Health;
    public Vector3 lastPos;
    public GameObject ComboPlaceHolder,door;
    
    [SerializeField] public int playerID = 0;
    [SerializeField] public Player player;
    [SerializeField] public float reload;
    public float MoveAgain;
    public float hits;
    public GameObject PlayerModel;
    public GameObject Spawn;
    public LayerMask WallLayer;
    public float XMirror;
    public bool Inside, Out;
    public GameObject KeySprite;
    public AudioSource BossHit;



    [Space]
    [Header("Management")]
    public Scene currentScene;
    public GameManager gm;
    public bool ipPackage, controlPackage, PuzzleKey;
    public int ipCount;
    [SerializeField] public int ipKills;
    public int DashNerf;
    public bool canDash, canBulletTime, canNail;
    public float TimeLevel;
    public GameObject PostProcessing;
    RLProBleed Bleed;
    public RLProNegative Negative;
    public RLProGlitch2 GlitchWin;
    public RLProGlitch1 GlitchKill;
    public Vector2 directionAxis;
    [SerializeField] public ProCamera2D ProCam;
    public float offsetX, ofssetY,offset2;
    [SerializeField] public GameObject CenterObject;
    public float directionX, directionY;
    public Slider slide;
    public GameObject SliderContent;
    public GameObject RtButton;
    public PhysicsMaterial2D RbMaterial;
    public float SpriteTime;
    [SerializeField] public GameObject padlock;
    public ProCamera2DCameraWindow maincam;
    public bool RaycastWall;
    public GameObject DoorText;
    public GameObject PuzzleDoor;
    public GameObject DeathExplosion;
    public GameObject PlatformParticles;
    public GameObject Simple,Unlocked;
    public CameraShake Shake;
    public float timerReload;
    public GameObject FullBoss;
    public bool Wingame;

    [Space]
    [Header("Vibration")]
    // Set vibration in all Joysticks assigned to the Player
    int motorIndex = 0; // the first motor
    public float motorLevel = 0.3f; // full motor speed
    float duration = 0.3f; // 2 seconds

 


    // Start is called before the first frame update


    [Space]
    [Header("Coyote Time")]
    public float coyoteTime= 0.1f;
    public float coyoteTimeCounter;

    public float jumpBuffering= 0.2f;
    public float jumpBufferingCounter;

    public float DashTime=0.1f;
    public float DashTimeCounter;



    [Space]
    [Header("Fill Value")]
    public Image Wheel;
    public GameObject Fill;

    [Space]
    [Header("Sounds")]
    public GameObject audioSlash;
    public GameObject audioDeath;
    public GameObject audioJump;

    [Space]
    [Header("Data")]
    public int Deaths;
    public int Kills;
    


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (!ES3.KeyExists("TotalDeaths"))
        {
            ES3.Save("TotalDeaths", 0);
        }

        if (!ES3.KeyExists("TotalKills"))
        {
            ES3.Save("TotalKills", 0);
        }
        main = GameObject.Find("MainCamera");
        XMirror = PlayerModel.transform.localScale.x;
        TimeStop = GetComponent<TimeStop>();
        coyoteTime = 0.1f;
        //Simple = GameObject.Find("Simple");
        limit = 0;
        //Dashps = TrailsSlash.GetComponent<ParticleSystem>();
        // DoorText = GameObject.Find("DoorText");
        PlayerModel = GameObject.Find("playercharacter");
        //  padlock = GameObject.Find("padlock");
        maincam = ProCam.GetComponent<ProCamera2DCameraWindow>();
        audioDeath  = GameObject.Find("MyDeath");
        audioSlash = GameObject.Find("SlashSound");
        audioJump = GameObject.Find("Salto");
        ipPackage = false;
        controlPackage = false;
        playerID = 0;
        player = ReInput.players.GetPlayer(playerID);
        currentScene = SceneManager.GetActiveScene();
        Health = 1;
        CountSlash = 1;
        Damage = 1;
        //enemyLayer = LayerMask.NameToLayer("Enemy");
        WallLayer = LayerMask.NameToLayer("Wall");
        coll = GetComponent<Collision>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<AnimationScript>();
        nr.GetComponent<NailedRigidbody>();
        PostProcessVolume volume = PostProcessing.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out Bleed);
        volume.profile.TryGetSettings(out Negative);
        volume.profile.TryGetSettings(out GlitchWin);
        
        // Bleed = PostProcessing.GetComponent<RLProBleed>();
        GlitchWin.enabled.value = true;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("Direction Switch " + directionX);
        Deaths = ES3.Load<int>("TotalDeaths");
        Kills = ES3.Load<int>("TotalKills");
      //  Debug.Log("Health "+ Health );
        PuzzleDoor = GameObject.Find("PuzzleDoor");
        Dashps = GameObject.Find("TrailBlack").GetComponent<ParticleSystem>();   
        Spawn = GameObject.Find("SpawnRaycast");
      //  Debug.Log("ENEMIES HITTED " + hits);
        TimeLevel = Time.timeSinceLevelLoad;
        float x = player.GetAxis("Move Horizontal");
        float y = player.GetAxis("Move Vertical");
        float xRaw = player.GetAxisRaw("Move Horizontal");
        float yRaw = player.GetAxisRaw("Move Vertical");
        Vector2 dir = new Vector2(x, y);
        directionAxis = dir;
        Walk(dir);
        anim.SetHorizontalMovement(x, y, rb.velocity.y);
        directionX = x;
        directionY = y;
        ComboTime -= 1 * Time.deltaTime;
     
        RaycastHit2D hit = Physics2D.Raycast(Spawn.transform.position, new Vector2(side,0),WallLayer);;
        if (hit.collider != null){
          //  Debug.Log("DISTANCE: " + hit.distance);
            if (hit.distance <= 2.0f)
            {
                RaycastWall = true;
               // Debug.Log("Colliding in Wall");
            }else if (hit.distance > 1.0f)
            {
                RaycastWall = false;
               // Debug.Log("Not Colliding in Wall");
            }

        }
        else
        {
            RaycastWall = false;
          //  Debug.Log("Not Colliding in Wall");
        }
        Debug.DrawRay(Spawn.transform.position, new Vector2(side, 0), Color.red);
        if (x > 0 || x == 0 && !wallSlide)
        {
            //PlayerModel.transform.localScale = new Vector3(XMirror, PlayerModel.transform.localScale.y, PlayerModel.transform.localScale.z);
            
         PlayerModel.transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (x < 0 && !wallSlide)
        {
         //   PlayerModel.transform.localScale = new Vector3(-XMirror, PlayerModel.transform.localScale.y, PlayerModel.transform.localScale.z);
            PlayerModel.transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        if (side < 0)
        {
            PlayerModel.transform.rotation = Quaternion.Euler(0, -90, 0);
        }else if(side> 0)
        {
            PlayerModel.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Time.timeSinceLevelLoad > 0.5f)
        {
            GlitchWin.enabled.value = false;

        }
        if (ComboTime <= limit)
        {
            
            Combo = false;

        }

        if (Combo == false)
        {
            Damage = 1;
            Fill.SetActive(false);
            hits = 0;
           
        }
        
      
            if (coll.onGround)
        {
            coyoteTimeCounter = coyoteTime;
            RbMaterial.friction = 0;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        /* if (coll.onWall &&  canMove)
         {
             if(side != coll.wallSide)
                 anim.Flip(side*-1);
            wallGrab = true;
             wallSlide = false;


         }*/
        if (coll.onWall || coll.onGround)
        {
            anim.anim.SetBool("isJumping", false);
            anim.anim.ResetTrigger("jump");
        }

        if (gm.GetComponent<JoystickDetector>().PS4_Controller == 1)
        {

            motorLevel = 0.8f;

        }
        else if (gm.GetComponent<JoystickDetector>().Xbox_One_Controller == 1)
        {
            motorLevel = 0.1f;
        }
        if (coll.onWall && coll.onGround && DashTimeCounter<=0)
        {
            
            //  x = 0;
            if (x != 0)
            {
               rb.AddForce(Vector2.up * Time.deltaTime*speed,ForceMode2D.Impulse);
            }
            //coll.onGround = false;
            coll.onWall = false;
        //    Debug.Log("freeze");
           // rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
      /*  if (Input.GetButtonUp("Fire3") || !coll.onWall) // || !canMove
        {
            wallGrab = false;
            wallSlide = false;
          
        }*/

        if (coll.onGround && !isDashing)
        {
            wallJumped = false;
            GetComponent<BetterJumping>().enabled = true;
        }

        

      
     


        


        if (wallGrab && !isDashing)
        {
            rb.gravityScale = 0;
            if(x > .2f || x < -.2f)
            rb.velocity = new Vector2(rb.velocity.x, 0);

            float speedModifier = y > 0 ? .5f : 1;

            rb.velocity = new Vector2(rb.velocity.x, y * (speed * speedModifier));
        }
        else
        {
            rb.gravityScale = 3;
        }

        if(coll.onWall && !coll.onGround)
        {
            if (x != 0 && !wallGrab)
            {
                wallSlide = true;
                WallSlide();
            }
        }

        if (!coll.onWall || coll.onGround)
            wallSlide = false;

        if (player.GetButtonDown("Jump") && canMove)
        {
            jumpBufferingCounter = jumpBuffering;
           

           
            if (coll.onWall && !coll.onGround)
                WallJump();
        }
        else
        {
            jumpBufferingCounter -= Time.deltaTime;
        }
      

        if (coyoteTimeCounter > 0f && jumpBufferingCounter>0f)
        {
            
            Jump(Vector2.up, false);
            jumpBufferingCounter = 0f;
        }
        if (player.GetButtonUp("Jump"))
        {
            coyoteTimeCounter = 0f;
        }
        //Debug.Log("Hits " + hits);
        if (player.GetButtonDown("Slash") && !hasDashed && Time.timeSinceLevelLoad>0.5f)
        {
            if (CountSlash == 1 && canDash && !isStunned)
            {
               

                if (xRaw != 0 || yRaw != 0)
                {
                    Shake.shakeDuration = 0.25f;
                    Dash(xRaw, yRaw);
                }
                   
                    


                if (xRaw == 0 && yRaw == 0)
                {
                    Shake.shakeDuration = 0.25f;
                    Dash(side, 0);
                }
                hits = 0;
                Touch = 0;
            }

        }
        if (isDashing)
        {
            DashTimeCounter = DashTime;
        }else if (!isDashing)
        {
            DashTimeCounter -= Time.deltaTime;
        }
        if (DashTimeCounter>0)
        {
            
           // Health = 10;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayer);
            Gizmos.DrawSphere(transform.position, radius);
            foreach (Collider2D enemy in hitEnemies)
            {

                if (enemy.gameObject.CompareTag("Boss"))
                {
                    anim.anim.SetTrigger("Damage");
                    TimeStop.StopTime(0.05f, 25, 0f);
                    rb.AddForce(enemy.transform.position * 2.5f, ForceMode2D.Force);
                }
                if (enemy.GetComponent<EnemyBehaviour>().attack != "Melee")
                {
                    anim.anim.SetTrigger("Damage");
                    TimeStop.StopTime(0.05f, 25, 0f);
                    rb.AddForce(enemy.transform.position * 2.5f, ForceMode2D.Force);
                    //TimeStop.StopTime(0.05f, 10, 0.1f);
                    enemy.GetComponent<EnemyBehaviour>().TakeDamage(Damage);
                   
                    // hits += 1;
                }
                else if (enemy.GetComponent<EnemyBehaviour>().attack == "Melee")
                {
                    Combo = false;
                    //knockback;
                    Knockback(10);
                   
                }
              
                
                if (enemy.GetComponent<EnemyBehaviour>().Health>Damage)
                {
                    Combo = false;
                    Debug.Log("Failed Kill");
                }
                else
                {
                   
                }
               // Debug.Log("Killed");
               
               
                DashTimeCounter = 0;
            }

           // Debug.Log("HIT ENEMIES: " + hitEnemies.Length);
            //  StartCoroutine(KillCheck());
            
            
        }


        if (DashTimeCounter <= -0.5f)
        {

            StopCoroutine(LightSlasher());



            if (Touch == 0)
            {
                Combo = false;
               // Debug.Log("Combo failed");

            }
            else if (Touch >= 1)
            {
                     if (hits > 0)
                {
                    Combo = true;
                }
            }
            if (ComboTime <= limit)
            {
                Combo = false;
            }
         
        }

      
        
        if (!isDashing)
        {
            var emission = Dashps.emission;
            emission.rateOverTime = 0;
            emission.burstCount = 0;
            //hits = 0;
        }

        if (coll.onGround && !groundTouch)
        {
            GroundTouch();
            groundTouch = true;
        }
        if(!coll.onGround && groundTouch)
        {
            groundTouch = false;
        }

        WallParticle(y);

        

        if(x > 0)
        {
            side = 1;
            anim.Flip(side);
        }
        if (x < 0)
        {
            side = -1;
            anim.Flip(side);
        }

        if (CountSlash == 1)
        {
            SpriteTime = 0f;
            RtButton.SetActive(false);
            speed = 7;
            reload = 0;
            //  SpriteSlash.SetActive(true);
        }
        else if (CountSlash == 0)
        {
            bool toStop=false;
            SpriteTime += Time.deltaTime;

            if (DashTimeCounter <= -0.5f || coll.onWall)
            {
                RtButton.SetActive(true);
            }
            MoveAgain += 1 * Time.deltaTime;

            // SpriteSlash.SetActive(false);
            reload -= 0.25f * Time.deltaTime;
            if (reload <= 0)
            {
                reload = 0;

            }
            else if (reload >= 3)
            {
                SliderContent.SetActive(false);
                isRecharging = false;
                CountSlash = 1;
                if (toStop)
                {
                    
                    
                }
                

            }
            
            if (player.GetButtonDown("Reload") && !isDashing && coll.onGround && !isStunned && CountSlash==0)
            //if(!isDashing && !isStunned)
            {
               
                 
                rb.velocity = new Vector2(0, 0);
                StartCoroutine(DisableMovement(0.5f));
                toStop = true;
                SliderContent.SetActive(true);
                slide.value = reload;
                isRecharging = true;
                cloneReload = Instantiate(ReloadParticles, transform.position, transform.rotation);
                Destroy(cloneReload, 1.5f);
                MoveAgain = 0;
                speed = 0;
                reload += 125f * Time.deltaTime;
               
                //MoveAgain += 1 * Time.deltaTime;

            }
            if(!player.GetButtonDown("Reload"))
            {
                timerReload += 1 * Time.deltaTime;
                
            }
            if (timerReload >= 0.5f)
            {
                speed = 7;
                isRecharging = false;
                timerReload = 0;
            }
           
            else if (!player.GetButtonDown("Reload") && !isStunned && CountSlash==0 && DashTimeCounter<=-0.5f)
            {
                reload += Time.deltaTime ;
                SliderContent.SetActive(true);
                slide.value = reload;
            }
            if(reload >= 3)
            {
                SliderContent.SetActive(false);
            }

            if (CountSlash == 1)
            {
                SliderContent.SetActive(false);
            }
           /* if (MoveAgain > 1)
            {

                isRecharging = false;
                speed = 7;
                SliderContent.SetActive(false);

            }*/
            

        }
        if (canMove)
        {

            StunParticle.Stop();
               isStunned = false;
            anim.anim.ResetTrigger("isStunned1");
            // SliderContent.SetActive(false);
        }
        if (Health <= 0)
        {
            Die();
        }

        if(coll.onWall && Health <= 0)
        {
            Die();
        }

      //  Debug.Log("RIGHTY: " + player.GetAxis("CameraMovement"));
      /*  if (player.GetAxis("CameraMovement") ==1 )
        {

            ProCam.OffsetY += offset2;

            if(ProCam.OffsetY>= ofssetY + 8f)
            {
                ProCam.OffsetY = ofssetY + 8f;
            }
        }
        else if (player.GetAxis("CameraMovement") == -1)
        {

            ProCam.OffsetY -= offset2;

            if (ProCam.OffsetY <= ofssetY - 8f)
            {
                ProCam.OffsetY = ofssetY - 8f;
            }
        }
        if (player.GetAxis("CameraMovement") == 0)
        {
            
            if (transform.position.x < CenterObject.transform.position.x)
            {
                ProCam.OffsetX = offsetX;
            }
            else if (transform.position.x > CenterObject.transform.position.x)
            {
                ProCam.OffsetX = -(offsetX + offset2);
            }

            if (transform.position.y < CenterObject.transform.position.y)
            {
                ProCam.OffsetY = ofssetY;
            }
            else if (transform.position.y > CenterObject.transform.position.y)
            {
                ProCam.OffsetY = -ofssetY;
            }
        }*/
       
        /*if (nr.isHooking)
        {
            lastPos = transform.position;
        }*/

        if (Combo)
        {
            if(coll.onWall || !coll.onWall)
            FillTime();
            ComboPlaceHolder.SetActive(true);
        }else if (!Combo)
        {
            ComboPlaceHolder.SetActive(false);
        }

        if (ipCount >= ipKills)
        {
            ipPackage = true;
        }

        if (ipPackage == true)
        {
          /*  if (DoorText != null)
            {
                DoorText.SetActive(true);
                Destroy(DoorText, 5f);
            }*/

            //Simple.SetActive(false);
            //door.SetActive(true);
            Color tmp = door.GetComponentInChildren<SpriteRenderer>().color;
            tmp.a += Time.deltaTime*0.3f;
            door.GetComponentInChildren<SpriteRenderer>().color = tmp;

        }

        if (controlPackage == true && ipPackage==true)
        {
            var tr = door.transform.Find("Unlocked");
            Unlocked = tr.gameObject;
            
            door.GetComponent<BoxCollider2D>().enabled = true;
            padlock.SetActive(false);
            Unlocked.SetActive(true);
            
        }

       
        if (player.GetButtonDown("Restart"))
        {
          //  Debug.Log("Reload Pressed");
            gm.GameOver();
        }
       // Debug.Log("Combo: " + Combo);
      //  Debug.Log(Damage);

        
            if (player.GetButtonDown("Pause"))
            {
              if (gm.gamePaused)
                {
                  gm.Resume();
                }
             else
                {
                 gm.Pause();
                }
                
            }


       // Debug.Log("SIDE " + side);
    }

    public void Die()
    {

        TimeStop.RestoreTime = true;
;        ES3.Save("TotalDeaths", Deaths + 1);
        Deaths = ES3.Load<int>("TotalDeaths");

        main.GetComponent<AudioListener>().enabled = true;
        Time.timeScale = 1;
        isDead = true;
        GlitchWin.enabled.value = true;
        audioDeath.GetComponent<AudioSource>().Play();
        Instantiate(deathParticle, transform.position, transform.rotation);
      
       // StopCoroutine(DashWait());
        gm.GameOver();
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);
    }
    void GroundTouch()
    {
        hasDashed = false;
        isDashing = false;

       // side = anim.sr.flipX ? -1 : 1;

        jumpParticle.Play();
    }

    private void Dash(float x, float y)
    {
        
        anim.SetTrigger("dash");
        var emission = Dashps.emission;
        emission.rateOverTime = 40;
       
        ControllerVibration(motorIndex, motorLevel, duration);
        audioSlash.GetComponent<AudioSource>().Play();
        isDashing = true;
       
        CountSlash = 0;
        reload = 0;
        Camera.main.transform.DOComplete();
        Camera.main.transform.DOShakePosition(.2f, .5f, 14, 90, false, true);
        FindObjectOfType<RippleEffect>().Emit(Camera.main.WorldToViewportPoint(transform.position));

        hasDashed = true;

      
        

        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2(x/1.5f, y/1.5f);

        rb.velocity += dir.normalized * dashSpeed/DashNerf;

      
        StartCoroutine(DashWait());
        
        
    }

    public void Killed()
    {
        //Kills = ES3.Load<int>("TotalKills");
        ES3.Save("TotalKills", Kills + 1);
        Kills = ES3.Load<int>("TotalKills");
      
        if (Combo)
        {

            Damage += 1;
        }
        else if (!Combo)
        {
            Combo = true;
        }
        CountSlash = 1;
        ComboTime =10;
        StartCoroutine(BleedEffect(0.03f));

    }
  /*  private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }*/
    IEnumerator DashWait()
    {
        isDashing = true;
       // FindObjectOfType<GhostTrail>().ShowGhost();
        StartCoroutine(GroundDash());
        DOVirtual.Float(14, 0, .8f, RigidbodyDrag);

        dashParticle.Play();
        rb.gravityScale = 0;
        GetComponent<BetterJumping>().enabled = false;
        wallJumped = true;
       

        yield return new WaitForSeconds(.3f);
        isDashing = false;
        if (!coll.onGround)
        {
            isDashing = false;
            rb.gravityScale = 0.75f;
            yield return new WaitForSeconds(2F);
        }

      
        dashParticle.Stop();
        rb.gravityScale = 3;
        GetComponent<BetterJumping>().enabled = true;
        wallJumped = false;
        isDashing = false;
        Health = 1;
    }

    IEnumerator GroundDash()
    {
        yield return new WaitForSeconds(.15f);
        //if (coll.onGround)
            hasDashed = false;
    }

    private void WallJump()
    {
        anim.anim.SetBool("isJumping", true);
        anim.SetTrigger("jump");
        if ((side == 1 && coll.onRightWall) || side == -1 && !coll.onRightWall)
        {
            side *= -1;
            anim.Flip(side);
        }

        StopCoroutine(DisableMovement(0));
        StartCoroutine(DisableMovement(.1f));

        Vector2 wallDir = coll.onRightWall ? Vector2.left : Vector2.right;
        float divider=2.0f;
        if(coll.onRightWall && directionX > 0.8f)
        {
            divider = 4.0f;
        }else if (coll.onRightWall && directionX < 0.8f)
        {
            divider = 2.0f;
        }

        if(coll.onLeftWall && directionX < -0.8f)
        {
            divider = 4.0f;
        }else if (coll.onLeftWall && directionX > -0.8f)
        {
            divider = 2.0f;
        }
        Jump((Vector2.up  + wallDir / divider), true);
       // Jump((Vector2.up), true);
        wallJumped = true;
    }

    private void WallSlide()
    {
       if(coll.wallSide != side)
         anim.Flip(side * -1);

        if (!canMove)
            return;

        bool pushingWall = false;
        if((rb.velocity.x > 0 && coll.onRightWall) || (rb.velocity.x < 0 && coll.onLeftWall)||coyoteTimeCounter>0)
        {
            pushingWall = true;
        }
        float push = pushingWall ? 0 : rb.velocity.x;
       // StartCoroutine(WallPush(push));
        if (coyoteTimeCounter<=0)
        {
            rb.velocity = new Vector2(push, -slideSpeed);
        }
 
    }

    private void Walk(Vector2 dir)
    {
        if (!canMove)
            return;

        if (wallGrab)
            return;

        if (!wallJumped)
        {
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * speed, rb.velocity.y)), wallJumpLerp * Time.deltaTime);
        }
    }

    private void Jump(Vector2 dir, bool wall)
    {
        anim.SetTrigger("jump");
        slideParticle.transform.parent.localScale = new Vector3(ParticleSide(), 1, 1);
        ParticleSystem particle = wall ? wallJumpParticle : jumpParticle;
        audioJump.GetComponent<AudioSource>().Play();


        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce;

        particle.Play();
        return;
    }

    IEnumerator DisableMovement(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;

        
    }

    void RigidbodyDrag(float x)
    {
        rb.drag = x;
    }

    void WallParticle(float vertical)
    {
        var main = slideParticle.main;

        if (wallSlide || (wallGrab && vertical < 0))
        {
            slideParticle.transform.parent.localScale = new Vector3(ParticleSide(), 1, 1);
            main.startColor = Color.white;
        }
        else
        {
            main.startColor = Color.clear;
        }
    }

    int ParticleSide()
    {
        int particleSide = coll.onRightWall ? 1 : -1;
        return particleSide;
    }
    public void Knockback(float multiplier)
    {
        anim.anim.SetTrigger("isStunned1");
        isStunned = true;
        StunParticle.Play();
        StopCoroutine(DashWait());

        // transform.position -= new Vector3(1, 1,0);
        rb.velocity = new Vector2(-directionX, -directionY);
        rb.AddForce((-directionAxis)*multiplier,ForceMode2D.Impulse);
        StartCoroutine(DisableMovement(2f));
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!isDashing && DashTimeCounter<=0) //other.GetComponent<VisionRange>().canSeePlayer == true &&
            {
                Health--;
            }else if(DashTimeCounter>0 && other.GetComponent<EnemyBehaviour>().attack!="Melee")
            {
                rb.AddForce(other.transform.position * 1.5f, ForceMode2D.Force);
                TimeStop.StopTime(0.05f, 25, 0f);
                anim.anim.SetTrigger("Damage");
                StartCoroutine(LightSlasher());
                other.GetComponent<EnemyBehaviour>().TakeDamage(Damage);
            }else if (isDashing && other.GetComponent<EnemyBehaviour>().attack == "Melee")
            {
                Combo = false;
                Knockback(10);
            }
            if (other.GetComponent<EnemyBehaviour>().Health > Damage)
            {
                Combo = false;
               // Debug.Log("Failed Kill");
            }
          //  Debug.Log("Trigger Works");
            if (coll.onWall || wallSlide == true)
            {
                if (!isDashing && DashTimeCounter <= 0) //other.GetComponent<VisionRange>().canSeePlayer == true &&
                {
                    Health--;
                }
                else if (DashTimeCounter > 0 && other.GetComponent<EnemyBehaviour>().attack != "Melee")
                {

                    other.GetComponent<EnemyBehaviour>().TakeDamage(Damage);
                }
                else if (isDashing && other.GetComponent<EnemyBehaviour>().attack == "Melee")
                {
                    Combo = false;
                    Knockback(10);
                }
                if (other.GetComponent<EnemyBehaviour>().Health > Damage)
                {
                    Combo = false;
                   // Debug.Log("Failed Kill");
                }
            }
        }

        if (other.CompareTag("ipPackage"))
        {
            ipPackage = true;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Boss"))
        {
            if (DashTimeCounter > 0)
            {
                if (Damage >= 3 && other.GetComponentInParent<AnimationBoss>().canHurt)
                {
                    BossHit.Play();
                    other.GetComponentInParent<AnimationBoss>().count = 0;
                    other.GetComponentInParent<AnimationBoss>().StopAllCoroutines();
                    other.GetComponentInParent<FinalBoss>().Health -= 1;
                    TimeStop.StopTime(0.05f, 25, 0f); 
                    anim.anim.SetTrigger("Damage");
                    other.GetComponentInParent<AnimationBoss>().anim.SetTrigger("Death");
                    //Destroy(other.gameObject);
                    Combo = true;
                    Damage = 1;
                }
                else if (Damage < 3 || other.GetComponentInParent<AnimationBoss>().canHurt==false)
                {
                    Combo = true;
                  //  Damage = 1;
                }

            }
            else
            {
                Die();
            }
            
        }

        if (other.CompareTag("EyeBoss"))
        {
            if (DashTimeCounter >=-0.5f)
            {
                if (Damage >= 3)
                { //final boss win routine
                    other.GetComponent<BossEnding>().enabled = true;
                    Wingame = true;
                    gm.Win();
                   
                    //Debug.Log("WINEYE");
                    this.GetComponent<CapsuleCollider2D>().enabled =false;
                    
                    anim.anim.SetTrigger("Damage");
                    TimeStop.StopTime(0.05f, 25, 0f);
                    gm.hasWon = true;
                    ES3.Save("GameComplete", true);
                    ES3.Save("Passed FinalBossScene", true);
                    GlitchWin.enabled.value = true;
                    
                    Time.timeScale = 1;
                }
                else if (Damage < 3)
                {
                    Combo = true;
                }
            }
            else
            {
                Die();
            }
               
        }

        if (other.CompareTag("ControlPackage"))
        {
           other.GetComponentInChildren<BoxCollider2D>().enabled = false;
           other.GetComponentInChildren<Animator>().SetTrigger("get");  
           other.transform.Find("ControlPackageAnimatePos").transform.Find("LlaveCenter").GetComponent<Animator>().SetTrigger("get");
           controlPackage = true;
            KeySprite.SetActive(true);
            Destroy(other.gameObject, 1f);
            
            
        }
        if (other.CompareTag("PuzzleKey"))
        {
           // PuzzleDoor.GetComponent<CapsuleCollider2D>().enabled = false;
            PuzzleKey = true;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("PuzzleDoor"))
        {
            if(other.GetComponent<BoolDoor>().Greater){
               if( side <0 && DashTimeCounter >= 0)
            {
                Destroy(other.gameObject);
                CountSlash = 1;
                ComboTime = 10;
                    Touch += 1;
                    GameObject cloneParticles;
                    cloneParticles = Instantiate(DeathExplosion, new Vector2(other.transform.position.x, (other.transform.position.y + 0.7f)), Quaternion.Euler(0, 180, -90));
                    var capsule = other.GetComponent<CapsuleCollider>().enabled = false;
                
                Destroy(cloneParticles, 2f);


            }
            else if (side > 0 && DashTimeCounter <= 0)
            {
                //Knockback(0.5f);
                }
                else
                {
                   // Knockback(0.5f);
                }
            }

            if (other.GetComponent<BoolDoor>().Less)
            {
                if (side >0 &&DashTimeCounter >= 0)
                {
                    Destroy(other.gameObject);
                    CountSlash = 1;
                    ComboTime = 10;
                    Touch += 1;
                    GameObject cloneParticles;
                    cloneParticles = Instantiate(DeathExplosion, new Vector2(other.transform.position.x, (other.transform.position.y + 0.7f)), Quaternion.Euler(0, 180, -90));
                    //var capsule = other.GetComponent<CapsuleCollider2D>().enabled = false;
                   
                    Destroy(cloneParticles, 2f);


                }
                else if(side < 0 && DashTimeCounter <= 0)
                {
                   // Knockback(0.5f);
                }
                else
                {
                   // Knockback(0.5f);
                }
            }
        }
        if (other.CompareTag("Door") && controlPackage==true)
        {
            
            gm.Win();
            //this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
          //  Instantiate(deathParticle,transform.position,transform.rotation);
        }
        
        if (other.CompareTag("Disappear"))
        {
            Destroy(other.gameObject, 0.5f);
            GameObject cloneParticles;
            cloneParticles = Instantiate(PlatformParticles, new Vector2(other.transform.position.x, (other.transform.position.y)), Quaternion.Euler(0, 180, -90));
        }
        if (other.CompareTag("Platform"))
        {
            Die();
        }
        if (other.CompareTag("Recharge"))
        {
            SliderContent.SetActive(false);
            Touch += 1;
            CountSlash = 1;
            ComboTime = 10;
        }
        if (other.CompareTag("DeathZone"))
        {
            Die();
        }

        if (other.CompareTag("Propulse"))
        {
          
            if (other.GetComponent<PropulseScript>().LaunchX)
            {
                if (directionX == 0)
                {
                    StartCoroutine(PropulseRoutine(1, 0));
                }else if (directionX != 0)
                {
                    if (directionX < 0)
                    {
                        StartCoroutine(PropulseRoutine(-1, 0));
                    }else if (directionX > 0)
                    {
                        StartCoroutine(PropulseRoutine(1, 0));

                    }
                   
                }
                
            }else if (other.GetComponent<PropulseScript>().LaunchY)
            {
                if (directionY == 0){
                    StartCoroutine(PropulseRoutine(0, 1));
                }
                else if (directionY != 0)
                {
                    if (directionY < 0)
                    {
                        StartCoroutine(PropulseRoutine(0, -1));
                    }else if(directionY > 0)
                    {
                        StartCoroutine(PropulseRoutine(0, 1));
                    }
                   
                }
                
            }
        }

        if (other.CompareTag("Pulse"))
        {
           
            
            if (DashTimeCounter >= 0f)
            {
                Touch += 1;
                CountSlash = 1;
                ComboTime = 10;
                Inside = true;
                Out = false;

            }
            else if(DashTimeCounter<0)
            {
                
                Die();
            }


        }
        else
        {
            Inside = false;
            
        }

   
       // Bleed.enabled.value = false;
       // Negative.enabled.value = false;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
       if (other.CompareTag("Pulse"))
        {
            Inside = true;
            Health = 1;
            if (other.gameObject == null)
            {
                Inside = false;
            }
        }
        else
        {
            Inside = false;
            Out = true;
        }

      
        if (other.CompareTag("Enemy"))
        {
            if (!isDashing)
            {
                Health--;
            }
        }
        if (other.CompareTag("Propulse"))
        {
           
            //rb.velocity = 0f;
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (other.CompareTag("PuzzleDoor"))
        {
            if (other.GetComponent<BoolDoor>().Greater)
            {
                if (side < 0 && DashTimeCounter >= 0)
                {
                    Destroy(other.gameObject);
                    CountSlash = 1;
                    ComboTime = 10;
                    Touch += 1;
                    GameObject cloneParticles;
                    cloneParticles = Instantiate(DeathExplosion, new Vector2(other.transform.position.x, (other.transform.position.y + 0.7f)), Quaternion.Euler(0, 180, -90));
                    var capsule = other.GetComponent<CapsuleCollider>().enabled = false;

                    Destroy(cloneParticles, 2f);


                }
                else if (side > 0 && DashTimeCounter <= 0)
                {
                    //Knockback(0.5f);
                }
                else
                {
                    // Knockback(0.5f);
                }
            }

            if (other.GetComponent<BoolDoor>().Less)
            {
                if (side > 0 && DashTimeCounter >= 0)
                {
                    Destroy(other.gameObject);
                    CountSlash = 1;
                    ComboTime = 10;
                    Touch += 1;
                    GameObject cloneParticles;
                    cloneParticles = Instantiate(DeathExplosion, new Vector2(other.transform.position.x, (other.transform.position.y + 0.7f)), Quaternion.Euler(0, 180, -90));
                    var capsule = other.GetComponent<CapsuleCollider2D>().enabled = false;

                    Destroy(cloneParticles, 2f);


                }
                else if (side < 0 && DashTimeCounter <= 0)
                {
                    // Knockback(0.5f);
                }
                else
                {
                    // Knockback(0.5f);
                }
            }
        }
    }
    IEnumerator BleedEffect(float time)
    {
        Bleed.enabled.value = true;
        yield return new WaitForSeconds(time);
        Bleed.enabled.value = false;
    }
   IEnumerator LightSlasher ()
    {
        LightSlash.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        LightSlash.SetActive(false);
    }
    private void OnTriggerExit2D (Collider2D other)
    {
       
       /* if (other.CompareTag("Enemy"))
        {
            if (DashTimeCounter<=-0.5f)
            {
                other.GetComponent<EnemyBehaviour>().Failed = true;
                other.GetComponent<EnemyBehaviour>().myFunctionDone = false;
            }
        }*/


        if (other.CompareTag("Pulse") && other.isActiveAndEnabled)
        {
            if (DashTimeCounter > 0f)
            {
                Inside = false;
                Out = true;
                Inside = false;
                Touch += 1;
                ComboTime = 10;
                CountSlash = 1;
            }

            if (DashTimeCounter <= 0f && Out==false)
            {
                Inside = false;
                Die();
            }
        }
    }
    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }

    IEnumerator WallPush(float push)
    {
        yield return new WaitForSeconds(0.5f);
        rb.velocity = new Vector2(push, -slideSpeed);
    }
    
    IEnumerator PropulseRoutine(float x, float y)
    {
        
        yield return new WaitForSeconds(0.3f);
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        canMove = false;
        yield return new WaitForSeconds(1f);

        rb.AddForce(new Vector2(x, y)*dashSpeed, ForceMode2D.Impulse);

        //yield return new WaitForSeconds(1f);
        canMove = true;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

    }
    public void ControllerVibration(int motorIndex, float motorLevel, float duration)
    {
        player.SetVibration(motorIndex, motorLevel, duration);
    }

    public void FillTime()
    {
        Fill.SetActive(true);
        float fillValue;
        fillValue = ComboTime / 10;
         Wheel.fillAmount = fillValue;
        if (fillValue <= 0.3)
        {
            Animator anim = Wheel.GetComponentInParent<Animator>();
            anim.enabled = true;
        }
       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            
           
        }

        if (collision.gameObject.CompareTag("Platform"))
        {

            Die();
           
        }
    }
}
