using Godot;
using System;

public partial class PlayerController : CharacterBody2D
{
	//Variaveis para o movimento do personagem

	private float _Speed = 450.0f;

	private float _JumpVelocity = -550.0f;

	private float gravity = 1000.0f;

	//Referências para os sprites do jogador

	private TileMap _tileMap;

	private Sprite2D _IdleSprite;

	private AnimatedSprite2D _WalkSprite;

	private AnimatedSprite2D JumpSprite;

	private AnimatedSprite2D AttackSprite;

	//Vaariavel para a velocidade do ator

	private Vector2 _velocity = Vector2.zero;

	//Variavel booleana para o ataque

	private bool _isAttacking = false;
	
	//Função Chamada quando o nó está pronto
	public override void Ready()
	{
		//Guarda referências dos nodes nas variáveis ppara o controle do personagem
		_tileMap = GetNode<TileMap>("root/Main/TileMap");
		_IdleSprite = GetNode<Sprite2D>("Idle");
		_AttackSprite = GetNode<AnimatedSprite2D>("AttackSprite");
		_JumpSprite = GetNode<AnimatedSprite2D>("JumpSprite");
		_WalkSprite = GetNode<AnimatedSprite2D>("WalkSprite");

		//Define a visibilidade dos sprites no início da cena
		_WalkSprite.visible = false;
		_AttackSprite.visible = false;
		_JumpSprite.visible = false;
		_IdleSprite.Visible =true;
	}
}
