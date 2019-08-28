using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Moving,
    Attacking,
    Interacting,
    Dead
}

public class Player : Entity
{
    public float speed;
    public PlayerEquipment.Weapon weapon;
    public PlayerState state;

    public Chakram chakramPrefab;
    public Bomb bombPrefab;

    private Vector2 _direction;
    private Chakram _chakramInstance;
    private Bomb _bombInstance;

    private float _invicility;
    public float invicibilyTime;

    public bool isPaused = false;
    [HideInInspector] public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _direction = Vector2.right;
        state = PlayerState.Moving;
        inventory = GetComponent<Inventory>();
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
            return;

        _invicility -= Time.deltaTime;

        if (state == PlayerState.Moving)
        {

            if (Input.GetButtonUp("NextWep"))
            {
                weapon = inventory.nextWeapon();
            }

            if (Input.GetButtonUp("PrevWep"))
            {
                weapon = inventory.previousWeapon();
            }
            // If pressed attack button
            if (Input.GetButtonUp("Submit"))
            {
                animator.SetBool("IsMoving", false);
                Debug.DrawRay((Vector2)transform.position, movement * 2, Color.green);
                RaycastHit2D sightTestResult = Physics2D.Raycast(transform.position, movement, 2, LayerMask.GetMask("Collision"));
                if (sightTestResult)
                {
                    var interactable = sightTestResult.collider.gameObject.GetComponent<Interactable>();
                    if (interactable != null)
                    {
                        interactable.Interact();
                    }
                    else
                    {
                        Attack();
                    }
                }
                else
                {
                    Attack();
                }
            }

            // if not attacking, then allow movement
            else
            {
                var movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

                if (movement != Vector2.zero)
                {
                    this.movement = movement;
                    var direction = RoundVector(movement);
                    animator.SetBool("IsMoving", true);
                    animator.SetFloat("X", direction.x);
                    animator.SetFloat("Y", direction.y);
                    body.MovePosition(body.position + Time.deltaTime * speed * this.movement);
                    _direction = this.movement.normalized;
                }
                else
                {
                    animator.SetBool("IsMoving", false);
                }
            }
        }
    }

    void Attack()
    {
        switch (weapon)
        {
            case PlayerEquipment.Weapon.Sword:
                state = PlayerState.Attacking;
                animator.SetTrigger("Attack");
                GameManager.managerInstance.audioManager.PlaySwordSound();
                break;

            case PlayerEquipment.Weapon.Chakram:
                if (_chakramInstance == null)
                {
                    _chakramInstance = Instantiate(chakramPrefab, transform.position, transform.rotation);
                    _chakramInstance.owner = gameObject;
                    _chakramInstance.direction = _direction;
                    GameManager.managerInstance.audioManager.PlayProjectileSound();
                }
                break;

            case PlayerEquipment.Weapon.Bomb:
                if (_bombInstance == null)
                {
                    _bombInstance = Instantiate(bombPrefab, transform.position, transform.rotation);
                    _bombInstance.GetComponent<Rigidbody2D>().velocity = _direction * 20;
                }
                break;

            default:
                throw new InvalidOperationException();
        }
    }

    public void Recover()
    {
        if (state == PlayerState.Attacking)
        {
            state = PlayerState.Moving;
        }
    }

    public override void Damage(float amount)
    {
        if (_invicility <= 0)
        {
            _invicility = invicibilyTime;
            health -= amount;
            if (health <= 0)
            {
                state = PlayerState.Dead;
                GameManager.managerInstance.audioManager.PlayKillSound();
                GameManager.managerInstance.gameover.ShowDialogue("Game Over. Press the Attack key to respawn.");
                animator.SetBool("IsMoving", false);
            }
        }
    }
}

