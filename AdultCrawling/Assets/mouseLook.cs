using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add a rigid body to the capsule
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSWalker script to the capsule

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class mouseLook : MonoBehaviour
{

	public Transform[] targets;
	public float rotateSpeed = 90;
	public GameObject Player;

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 5F;
    public float sensitivityY = 5F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationX = 0F;
    float rotationY = 0F;

	float targetDetectDistance = 5F;
	Vector3 originalDir;

	bool nearedTarget = false;

    Quaternion originalRotation;

    void Update()
    {
		int closestTargetIndex = getClosestTarget ();
		float distance = getDistance (closestTargetIndex);
		if (distance < targetDetectDistance) {
			if (distance < targetDetectDistance - 0.1) {
				originalDir = Player.transform.forward;
				lookAway (closestTargetIndex);
//				Player.transform.position.x
//				nearedTarget = true;
			} else {
				// look back;
//				Quaternion q = Quaternion.LookRotation(originalDir);
//				transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * rotateSpeed);
				lookBack(originalDir);
//				nearedTarget = false;
			}
		}

		else if (axes == RotationAxes.MouseXAndY)
        {
			// Read the mouse input axis
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            rotationY = ClampAngle(rotationY, minimumY, maximumY);

            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);

            transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        }
        else if (axes == RotationAxes.MouseX)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);

            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = ClampAngle(rotationY, minimumY, maximumY);

            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);
            transform.localRotation = originalRotation * yQuaternion;
        }
    }

    void Start()
    {
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
        originalRotation = transform.localRotation;
		Player = GameObject.Find("Player");
		originalDir = Player.transform.forward;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

	private void lookAway (int closestObjectIndex) {
		Vector3 lookDir = targets[closestObjectIndex].position - transform.position;
		Quaternion q = Quaternion.LookRotation(lookDir);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * rotateSpeed);

//
//		if (Input.GetKeyDown (KeyCode.B)) {
//			currTarget = (currTarget + 1) % targets.Length;
//		}
	}

	private void lookBack (Vector3 originalDir) {
		Vector3 lookDir = originalDir - transform.position;
		Quaternion q = Quaternion.LookRotation(lookDir);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * rotateSpeed);
	}

	private int getClosestTarget () {
		float minDistance = Vector3.Distance (Player.transform.position, targets [0].transform.position);
		int min = 0;
		for (int i = 0; i < targets.Length; i++) {
			if (Vector3.Distance (Player.transform.position, targets [i].transform.position) < minDistance) {
				min = i;
			}
		}
		return min;
	}

	private float getDistance (int targetIndex) {
		return Vector3.Distance (Player.transform.position, targets [targetIndex].transform.position);
	}
}