using Godot;
using System;

public partial class Player : Node
{

	// Definir a velocidade do personagem.
	private float _speed = 200.0f;

	//criar forca de salto
	private float _jumpvelocity = -600.0f; 

	//forca de gravidade
	private float gravity = 1000.0f;

	// Refêrencia ao sprite
	private Sprite2D _sprite;

	private Vector2 _velocity = Vector2.Zero;

	private bool isonFloor()
	{
		return _sprite.Position.Y >= 310;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// 
		_sprite = GetNode<Sprite2D>("PlayerSprite");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_velocity.X = 0;

		//se precionarmos a tecla right anda para a direita 
		if(Input.IsActionPressed("ui_right"))
		{
			_velocity.X = _speed;
		}
		//se precionarmos a tecla left anda para a esquerda
		if(Input.IsActionPressed("ui_left"))
		{
			_velocity.X = -_speed;
		}


		//aplicação da gravidade ao jogador
		_velocity.Y += gravity * (float)delta;

		//salta se a tecla up for pressionada e tiver no chão
		if (isonFloor() && (Input.IsActionPressed("ui_up")))
		{
		
			_velocity.Y = _jumpvelocity;
		
		}

		_sprite.Position += _velocity * (float)delta;

		//se o personagem ultrapassar a posição de X de 1200
		if (_sprite.Position.X > 1200)
		{
			//reposiciona o personagem na posição inicial
			_sprite.Position = new Vector2(-100, 310);	
		}

		//Se o personagem estiver abaixo do chao
		if (_sprite.Position.Y > 310)
		{
			//o sprite fica com a velocidade nula e com a posição de 350 no eixo y
			_sprite.Position = new Vector2(_sprite.Position.X, 310);
			_velocity.Y = 0;
		}
	}

}
