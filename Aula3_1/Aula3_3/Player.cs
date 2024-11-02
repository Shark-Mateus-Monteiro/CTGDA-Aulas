using Godot;
using System;

public partial class Player : Node
{

	// Definir a velocidade do personagem.
	private Vector2 _speed = new Vector2(200,0);

	//criar forca de salto
	private float _jumpvelocity = 600.0f; 

	//forca de gravidade
	private float gravity = 1000.0f;

	// Refêrencia ao sprite
	private Sprite2D _sprite;

	private Vector2 _velocity = Vector2.Zero;

	private bool isonFloor()
	{
		return _sprite.Position.Y >= 350;
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
		//atualiza a posição do personagem com base na velocidade e no tempo
		_sprite.Position += _speed * (float)delta;

		//aplicação da gravidade ao jogador
		_sprite.Position.Y += gravity * (float)delta;

		//salta se a tecla up for pressionada e tiver no chão
		if (isonFloor() && (Input.IsActionJustPressed("ui_up")))
		{
		
			_velocity.Y = _jumpvelocity;
		
		}

		_sprite.Position = _velocity * (float)delta;

		//se o personagem ultrapassar a posição de X de 1200
		if (_sprite.Position.X > 1200)
		{
			//reposiciona o personagem na posição inicial
			_sprite.Position = new Vector2(-100, 350);	
		}

		//Se o personagem estiver abaixo do chao
		if (_sprite.Position.Y > 350)
		{
			//o sprite fica com a velocidade nula e com a posição de 350 no eixo y
			_sprite.Position = new Vector2(_sprite.Position.X, 350);
			_velocity.Y = 0;
		}
	}

}
