using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State {
    private float lastUpdate;
    private float direction;

    public override void Awake(StateController controller) {
        lastUpdate = Time.realtimeSinceStartup;
        controller.SetExpression(controller.IdleExpression);
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

        if ((currentUpdate - lastUpdate) > 2.75) {
            controller.SetExpression(controller.ThinkingExpression);
        }

        if ((currentUpdate - lastUpdate) > 3.76) {
            controller.SetExpression(controller.IdleExpression);
            lastUpdate = Time.realtimeSinceStartup;
        }

        
        direction = readHorizontalDirectionInput();
        float speed = readVerticalDirectionInput();
        if (ValidateNotDeadspace(speed)) controller.TranssionToState(controller.MovmentState); 


        if (Input.GetKeyDown(KeyCode.Space)) {
             controller.TranssionToState(controller.JumpState);
        }
    }

    public override void FixedUpdate(StateController controller) {
        if (ValidateNotDeadspace(direction)) {
            controller.transform.Rotate(Vector3.up * (direction * controller.RotationSpeed));
        }
    }
}
