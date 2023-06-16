using System.Collections;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;

public class FourFrameSwitchingAnimation : MonoBehaviour {
    public Sprite idleSprite1;
    public Sprite idleSprite2;
    public Sprite idleSprite3;
    public Sprite idleSprite4;
    public Sprite shootingSprite1;
    public Sprite shootingSprite2;
    public Sprite shootingSprite3;
    public Sprite shootingSprite4;
    public int frame = 1;
    private bool idle;
    public float timeUntilNextFrame;
    private float timer;
    private SpriteRenderer sr;
    private PlayerController player;

    void Start() {
        timer = timeUntilNextFrame;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if(player.Shooting) {
            idle = false;
        }
        if(!(player.Shooting)) {
            idle = true;
        }
        timer -= Time.deltaTime;
        if(timer <= 0) {
            timer = timeUntilNextFrame;
            frame += 1;
        }
        if(frame >= 4) {
            frame = 1;
        }
        CheckFrame();
    }

    private void CheckFrame() {
        if(frame == 1 && idle) {
            sr.sprite = idleSprite1;
        }
        if(frame == 2 && idle) {
            sr.sprite = idleSprite2;
        }
        if(frame == 3 && idle) {
            sr.sprite = idleSprite3;
        }
        if(frame == 4 && idle) {
            sr.sprite = idleSprite4;
        }
        if(frame == 1 && !idle) {
            sr.sprite = shootingSprite1;
        }
        if(frame == 2 && !idle) {
            sr.sprite = shootingSprite2;
        }
        if(frame == 3 && !idle) {
            sr.sprite = shootingSprite3;
        }
        if(frame == 4 && !idle) {
            sr.sprite = shootingSprite4;
        }
    }
}