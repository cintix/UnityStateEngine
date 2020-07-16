using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : State {
    public override void Awake(StateController controller) {
        controller.SetExpression(controller.WorriedExpression);
    }

    public override void FixedUpdate(StateController controller) {
        controller.transform.rotation = Quaternion.Lerp(controller.transform.rotation, Quaternion.Euler(0, controller.transform.rotation.eulerAngles.y,0), 10f * Time.deltaTime);
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
        controller.SetExpression(controller.CrazyExpression );
    }

    private bool validateMovement(Vector3 vector) {
        if (vector.x > -0.01 && vector.x < 0.01 ) {
            if (vector.y > -0.01 && vector.y < 0.01) return true;
        }
        return false;
    }

    public override void Update(StateController controller) {
        if (validateMovement(controller.Rigidbody().velocity)) {
            float speed = readVerticalDirectionInput();
            if (ValidateNotDeadspace(speed)) {
                controller.TranssionToState(controller.MovmentState);
            } else {
                controller.TranssionToState(controller.IdleState);
            }
        }

    }
}
