# Unity FPS Controller

A simple yet robust first-person controller for Unity games with smooth movement and camera controls.

## Features

- Smooth first-person movement with acceleration
- Mouse look camera controls with customizable sensitivity
- Jumping with realistic physics
- Easy to integrate into any project
- Fully customizable through the Unity Inspector

## How to Use

### Setup

1. Create a new GameObject for your player in your Unity scene
2. Add a Character Controller component to your player GameObject
3. Add a Camera as a child object of your player
4. Attach the `PlayerMovement.cs` script to your player GameObject
5. Adjust settings in the Inspector to match your game's feel

### Input Settings

This controller uses Unity's default input settings:
- WASD or Arrow Keys for movement
- Mouse for looking around
- Space for jumping

To modify these inputs, edit your project's Input Manager settings.

### Customizable Parameters

All parameters can be adjusted through the Unity Inspector:

**Movement Settings:**
- Move Speed: How fast the player moves
- Acceleration: How quickly the player reaches max speed
- Jump Height: Maximum height of jump
- Gravity: How strongly gravity pulls the player down

**Camera Settings:**
- Mouse Sensitivity: How quickly the camera rotates with mouse movement
- Upper Look Limit: Maximum angle the player can look up
- Lower Look Limit: Maximum angle the player can look down

## Implementation Notes

The controller uses Unity's CharacterController component for movement, which handles collision detection and response automatically. The camera rotation is handled separately from player movement to achieve smooth first-person controls.

For jumping, the script uses the physics formula v = sqrt(2 * gravity * height) to calculate the initial velocity needed to reach the desired jump height.

## License

This project is available under the MIT License. Feel free to use and modify it for your own projects.

## Contributing

Contributions are welcome! Feel free to submit pull requests with improvements or bug fixes.

## Credits
Made By Goose
Created with ❤️ for the Unity game development community.
