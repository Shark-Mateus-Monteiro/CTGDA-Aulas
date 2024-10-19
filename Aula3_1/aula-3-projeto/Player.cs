using Godot;
using System;

public partial class Player : Node
{
	// Definir a velocidade do personagem.
	private Vector2 _speed = new Vector2(400,0);

// Refêrencia ao sprite
private Sprite2D _sprite;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// 
		_sprite = GetNode<Sprite2D>("Sprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//atualiza a posição do personagem com base na velocidade e no tempo
		_sprite += _speed * (float)delta;

		//se o personagem ultrapassar a posição de X de 1000
		if (_sprite.Position.X > 1000)

		//reposiciona o personagem na posição inicial
		_sprite.Position = new Vector2(-100, 350);	}
}
