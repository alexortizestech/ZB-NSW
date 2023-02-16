using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
public class BetterJumping : MonoBehaviour
{
    [SerializeField] public Player player;
    private Rigidbody2D rb;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    [SerializeField] public int playerID = 0;

    void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }else if(rb.velocity.y > 0 && !player.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
