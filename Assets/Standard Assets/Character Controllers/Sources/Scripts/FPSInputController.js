private var motor : CharacterMotor;
public var WASDMode = 0;
//private var manager : Trip_state_manager[] = FindObjectsOfType(Trip_state_manager) as Trip_state_manager[];
//private var trip_level = Trip_state_manager[0].tripLevel;
//public var manager = 0;

// Use this for initialization
function Awake () {
	motor = GetComponent(CharacterMotor);
	
}

// Update is called once per frame
function Update () {
	// Get the input vector from keyboard or analog stick
	var directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	
	// reverse horizontal
	if (WASDMode == 1) {
		directionVector.z = directionVector.z * - 1;
	} else if (WASDMode == 2) {
		directionVector.x = directionVector.x * - 1;
	} else if (WASDMode == 3) {
		var temp = directionVector.z;
		directionVector.z = directionVector.x;
		directionVector.x = temp * -1;
	}
		
		
	
	if (directionVector != Vector3.zero) {
		// Get the length of the directon vector and then normalize it
		// Dividing by the length is cheaper than normalizing when we already have the length anyway
		var directionLength = directionVector.magnitude;
		directionVector = directionVector / directionLength;
		
		// Make sure the length is no bigger than 1
		directionLength = Mathf.Min(1, directionLength);
		
		// Make the input vector more sensitive towards the extremes and less sensitive in the middle
		// This makes it easier to control slow speeds when using analog sticks
		directionLength = directionLength * directionLength;
		
		// Multiply the normalized direction vector by the modified length
		directionVector = directionVector * directionLength;
	}
	
	// Apply the direction to the CharacterMotor
	motor.inputMoveDirection = transform.rotation * directionVector;
	motor.inputJump = Input.GetButton("Jump");
}


// Require a character controller to be attached to the same game object
@script RequireComponent (CharacterMotor)
@script AddComponentMenu ("Character/FPS Input Controller")
