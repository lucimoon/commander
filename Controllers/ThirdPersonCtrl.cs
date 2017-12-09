using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;

public class ThirdPersonCtrl : MonoBehaviour {
  [SerializeField]
  private float speed = 1.0f;
  [SerializeField]
  private float rotationSpeed = 1.0f;
  [SerializeField]
  private float jumpStrength = 1.0f;
  [SerializeField]
  private Transform head;

  private KeyCode walkForward = KeyCode.W;
  private KeyCode walkLeft = KeyCode.A;
  private KeyCode walkRight = KeyCode.D;
  private KeyCode walkBack = KeyCode.S;
  private KeyCode jump = KeyCode.Space;
  private DudeAnimations animator;
  private State state;
  private Vector3 leftRotation;
  private Vector3 rightRotation;

  private enum Direction {
    forward,
    back,
    left,
    right
  };

  void Start() {
    ConnectState();
    animator = GetComponent<DudeAnimations>();
    leftRotation = new Vector3(0f, -10f, 0f);
    rightRotation = new Vector3(0f, 10f, 0f);
  }

  private void ConnectState() {
    state = gameObject.GetComponent<State>();

    if (state == null) {
      Debug.Log("WARNING: Character missing State.");
    }
  }

	// Update is called once per frame
	void Update () {
    GetInput();
	}

  void OnCollisionEnter (Collision collision) {
    if (collision.gameObject.tag == "Floor") {
      Debug.Log("Landed.");
      state.IsJumping = false;
    }
  }

  private void GetInput () {
    bool notWalking = (!Input.GetKey(walkForward) && !Input.GetKey(walkBack) && !Input.GetKey(walkLeft) && !Input.GetKey(walkRight));

    if (notWalking) {
      state.IsWalking = false;
    } else {
      if (Input.GetKey(walkForward)) {
        Walk(Direction.forward);
        if (Input.GetKey(walkLeft)) Walk(Direction.left);
        if (Input.GetKey(walkRight)) Walk(Direction.right);
      }

      if (Input.GetKey(walkBack)) {
        Walk(Direction.back);
        if (Input.GetKey(walkLeft)) Walk(Direction.right);
        if (Input.GetKey(walkRight)) Walk(Direction.left);
      }

      state.IsWalking = true;
    }

    if (Input.GetKey(jump)) Jump();

    animator.animate(state);
  }

  // This belongs somewhere else
  private void Walk (Direction direction) {
    if (direction == Direction.forward) {
      gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    } else if (direction == Direction.left) {
      gameObject.transform.Rotate(leftRotation * rotationSpeed * Time.deltaTime);
    } else if (direction == Direction.right) {
      gameObject.transform.Rotate(rightRotation * rotationSpeed * Time.deltaTime);
    } else if (direction == Direction.back) {
      gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
  }

  private void LerpFace (Transform transform, Vector3 subject) {
    LerpFace(transform, subject, false);
  }

  private void LerpFace (Transform transform, Vector3 subject, bool ignoreY) {
    Vector3 directionToTarget;
    Quaternion lookRotation;

    directionToTarget = subject - transform.position;

    if (ignoreY) directionToTarget.y = 0f;

    lookRotation = Quaternion.LookRotation(directionToTarget);

    transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, (Time.deltaTime * rotationSpeed));
  }

  private void Jump () {
    if (state.IsJumping == false) {
      Debug.Log("Jump");
      Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();

//      state.IsJumping = true;
      rigidbody.AddForce(Vector3.up * jumpStrength, ForceMode.VelocityChange);
    }
  }

  public void GoTo () {
    Debug.Log("Going To... ");
  }


  public void WalkForward () {
    state.IsWalking = true;
    animator.animate(state);
    this.Walk(Direction.forward);
  }

  public void Greet () {
    Debug.Log("Greeting...");
  }

  public void Face (Vector3 subject) {
    LerpFace(gameObject.transform, subject, true);
  }

  public void LookAt (Vector3 subject) {
    if (head != null) LerpFace(head, subject);
  }

  public void LookAhead () {
    if (head != null) {
      head.transform.rotation = Quaternion.Lerp(head.transform.rotation, transform.rotation, (Time.deltaTime * rotationSpeed));
    }
  }
}
