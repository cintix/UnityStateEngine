using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : State {
    private float lastUpdate;
    private float speed;
    private float direction;
    private Vector3 velosity;

    public override void Awake(StateController controller) {
        lastUpdate = Time.realtimeSinceStartup;
        controller.SetExpression(controller.HappyExpression);
    }

    public override void LateUpdate(StateController controller) {

    }

    public override void OnAnimatorIK(StateController controller, int layerIndex) {

    }

    public override void OnCollisionEnter(StateController controller, Collision collision) {
    }

    public override void OnTriggerEnter(StateController controller, Collider other) {

    }

    public override void OnTriggerExit(StateController controller, Collider other) {

    }

    public override void OnTriggerStay(StateController controller, Collider other) {

    }

    public override void Update(StateController controller) {
        float currentUpdate = Time.realtimeSinceStartup;

        if ((currentUpdate - lastUpdate) > 0.75) controller.SetExpression(controller.FearlessExpression);
        else controller.SetExpression(controller.HappyExpression);

        direction = readHorizontalDirectionInput();
        speed = readVerticalDirectionInput();

        velosity = controller.Rigidbody().velocity;
        if (velosity.y < -5.5) {
            controller.TranssionToState(controller.FallState);
        }


        if (Input.GetKeyDown(KeyCode.Space)) {
            controller.TranssionToState(controller.JumpState);
            controller.Rigidbody().AddForce(controller.transform.forward * (controller.JumpSpeed * 20));
        }
    }


    public override void FixedUpdate(StateController controller) {
        if (ValidateNotDeadspace(direction)) {
            controller.transform.Rotate(Vector3.up * (direction * controller.RotationSpeed));
        }

        if (ValidateNotDeadspace(speed)) {
            controller.Rigidbody().MovePosition(controller.transform.position + (controller.transform.forward * (speed * controller.MovementSpeed * Time.deltaTime)));
        } else {
            controller.TranssionToState(controller.IdleState);
        }
    }


}
