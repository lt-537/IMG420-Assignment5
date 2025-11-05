using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] public float Speed = 200f;
	
	public override void _PhysicsProcess(double delta)
	{
		// TODO: Implement basic movement (WASD or Arrow Keys)
		// TODO: Use MoveAndSlide()
				
		float x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
		float y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
		
		Vector2 input = new Vector2(x, y);
		
		if(input.LengthSquared() > 1f)
		{
			input = input.Normalized();
		}
		
		// Get input and move
		Velocity = input * Speed;
		MoveAndSlide();
	}
}
