using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State {
    private Vector3 velosity;
    public override void Awake(StateController controller) {
        controller.SetExpression(controller.FunnyExpression);
        controller.Rigidbody().AddForce(Vector3.up * (controller.JumpSpeed * 100));
    }

    public override void FixedUpdate(StateController controller) {

    }

    public override void LateUpdate(StateController controller) {

    }

    public override void OnAnimatorIK(StateController controller, int layerIndex) {

    }

    public override void OnTriggerEnter(StateController controller, Collider other) {

    }

    public override void OnTriggerExit(StateController controller, Collider other) {

    }

    public override void OnTriggerStay(StateController controller, Collider other) {

    }
    public override void OnCollisionEnter(StateController controller, Collision collision) {
    }

    public override void Update(StateController controller) {
        velosity = controller.Rigidbody().velocity;
        if (velosity.y < 0) {
            controller.TranssionToState(controller.FallState);
        }
    }
}
