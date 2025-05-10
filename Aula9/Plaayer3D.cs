using Godot;
using System;

public partial class Plaayer3D : CharacterBody3D
{
		//bool para fazer o personagem andar para a esquerda
		public bool _AndarE = false;
		//bool para fazer o personagem andar para a direita
		public bool _AndarD = false;
		//bool para fazer o personagem andar para a frente
		public bool _AndarF = false;
		//bool para fazer o personagem andar para tras
		public bool _AndarT = false;
		//
		public int Speed = 14;
		//
		public int Gravity = 75;
		//
		private Vector3 _velocity = Vector3.Zero;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var direction = Vector3.Zero;

		if(Input.IsActionPressed("ui_left"))
		_AndarE = true;
		if(Input.IsActionPressed("ui_right"))
		_AndarD = true;
		if(Input.IsActionPressed("ui_up"))
		_AndarF = true;
		if(Input.IsActionPressed("ui_down"))
		_AndarT = true;

		if(_AndarE == true) _velocity.X = -4.0f;
		if(_AndarD == true) _velocity.X = 4.0f;
		if(_AndarF == true) _velocity.Z = -4.0f;
		if(_AndarT == true) _velocity.Z = 4.0f;

		if(_AndarE == true) direction.X += 1.0f;
		if(_AndarD == true) direction.X -= 1.0f;
		if(_AndarF == true) direction.Z += 1.0f;
		if(_AndarT == true) direction.Z -= 1.0f;

	    Velocity = _velocity;
		MoveAndSlide();

	}
}
