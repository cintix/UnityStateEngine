using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StateController : MonoBehaviour {

    public SpriteRenderer face;

    public Sprite IdleExpression;
    public Sprite ThinkingExpression;
    public Sprite FearlessExpression;
    public Sprite FunnyExpression;
    public Sprite MadExpression;
    public Sprite CrazyExpression;
    public Sprite WorriedExpression;
    public Sprite HappyExpression;
    public Sprite SadExpression;

    public State IdleState = new IdleState();
    public State JumpState = new JumpState();
    public State FallState = new FallingState();
    public State MovmentState = new MovingState();

    private State currentState;
    private Rigidbody rigidbody;

    public Rigidbody Rigidbody() { return rigidbody; }
    
    public float JumpSpeed = 5f;
    public float RotationSpeed = 25f;
    public float MovementSpeed = 2.5f;

    void OnTriggerStay(Collider other) {
        currentState.OnTriggerStay(this, other);
    }

    void OnTriggerExit(Collider other) {
        currentState.OnTriggerExit(this, other);
    }

    void OnTriggerEnter(Collider other) {
        currentState.OnTriggerEnter(this, other);
    }

    void OnAnimatorIK(int layerIndex) {
        currentState.OnAnimatorIK(this, layerIndex);
    }

    void LateUpdate() {
        currentState.LateUpdate(this);
    }

    void FixedUpdate() {
        currentState.FixedUpdate(this);
    }

    void Update() {
        currentState.Update(this);
    }

    void OnCollisionEnter(Collision collision) {
        currentState.OnCollisionEnter(this, collision);
    }


    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        TranssionToState(IdleState);
    }

    public void TranssionToState(State state) {
        currentState = state;
        currentState.Awake(this);
    }

    public void SetExpression(Sprite sprite) {
        face.sprite = sprite;
    }

}
