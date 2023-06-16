using System.Collections;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;

public class FourFrameEnemySwitchingAnimation : MonoBehaviour {
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public int frame = 1;
    public float timeUntilNextFrame;
    private float timer;
    private SpriteRenderer sr;
    private PlayerController player;

    void Start() {
        timer = timeUntilNextFrame;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update() {
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
        if(frame == 1) {
            sr.sprite = sprite1;
        }
        if(frame == 2) {
            sr.sprite = sprite2;
        }
        if(frame == 3) {
            sr.sprite = sprite3;
        }
        if(frame == 4) {
            sr.sprite = sprite4;
        }
    }
}