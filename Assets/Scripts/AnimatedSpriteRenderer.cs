using System;
using UnityEngine;

public class AnimatedSpriteRenderer : MonoBehaviour{
    private SpriteRenderer _spriteRenderer;

    public Sprite idleSprite;
    public Sprite[] animationSprites;
    
    public float animationTime = 0.25f;
    private int _animationFrame;

    public bool loop = true;
    public bool idle = true;
    private void Awake(){
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable(){
        _spriteRenderer.enabled = true;
    }

    private void OnDisable(){
        _spriteRenderer.enabled = false;
    }

    private void Start(){
        InvokeRepeating(nameof(NextFrame), animationTime, animationTime);
    }

    private void NextFrame(){
        _animationFrame++;

        if (loop && _animationFrame >= animationSprites.Length){
            _animationFrame = 0;
        }

        if (idle){
             _spriteRenderer.sprite = idleSprite;
        }
        else if(_animationFrame >= 0 && _animationFrame < animationSprites.Length){
            _spriteRenderer.sprite = animationSprites[_animationFrame];
        }
    }
}
