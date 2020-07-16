using UnityEngine;

public abstract class State  {

    public abstract void Awake(StateController controller);

    public abstract void OnTriggerStay(StateController controller, Collider other);

    public abstract void OnTriggerExit(StateController controller, Collider other);

    public abstract void OnTriggerEnter(StateController controller, Collider other);

    public abstract void OnAnimatorIK(StateController controller, int layerIndex);

    public abstract void LateUpdate(StateController controller);

    public abstract void FixedUpdate(StateController controller);

    public abstract void Update(StateController controller);

    public abstract void OnCollisionEnter(StateController controller, Collision collision);


    public float readHorizontalDirectionInput() {
        float direction = Input.GetAxis("Horizontal");
        return direction;
    }
    public float readVerticalDirectionInput() {
        float direction = Input.GetAxis("Vertical");
        return direction;
    }

    public bool ValidateNotDeadspace(float direction) {
        if (direction > 0.01f || direction < -0.01f) {
            return true;
        }
        return false;
    } 
}