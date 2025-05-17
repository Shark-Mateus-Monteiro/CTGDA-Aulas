using Godot;
using System;

public partial class Plaayer3D:CharacterBody3D
{
		//
		public int Speed = 1;

		//
		public int Gravity = 2;
		//
		public int Jump = 6;
		private Vector3 _PlayerVelocity = Vector3.Zero;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var direction = Vector3.Zero;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var direction = Vector3.Zero;

		if(Input.IsActionPressed("ui_left")) direction.X -= 1.0f;
		if(Input.IsActionPressed("ui_right")) direction.X += 1.0f;
		if(Input.IsActionPressed("ui_up")) direction.Z -= 1.0f;
		if(Input.IsActionPressed("ui_down")) direction.Z += 1.0f;
		if(Input.IsActionPressed("ui_accept"))
			_PlayerVelocity.Y = Jump * Speed;
		direction = direction.Normalized();
		_PlayerVelocity.Z = direction.Z * Speed;
		_PlayerVelocity.X = direction.X * Speed;
		Rotation = new Vector3(0,Mathf.Atan2(direction.X, direction.Y), 0);
		if(!IsOnFloor())
			_PlayerVelocity.Y = -1 * Gravity * (float)delta;
		Velocity = _PlayerVelocity;
		MoveAndSlide();

	}
}
