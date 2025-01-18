using Godot;
using System;

public partial class PlayerController : CharacterBody2D
{
    // A velocidade que o jogador se move
    public float moveSpeed = 200.0f;
    // A força do pulo do jogador
    public float jumpVelocity = -600.0f;
    // A força da gravidade que puxa o jogador para baixo
    public float gravity = 1000.0f;

    // Variáveis para armazenar diferentes partes do nosso jogo
    private TileMap _tilemap;
    private Sprite2D _idleSprite;
    private AnimatedSprite2D _walkSprite;
    private AnimatedSprite2D _jumpSprite;
    private AnimatedSprite2D _attackSprite;


    // A velocidade do jogador
    private Vector2 _velocity = Vector2.Zero;
    // Se o jogador está atacando ou não
    private bool _isAttacking = false;

	private int _score = 0;

    // Função que é chamada quando o jogo começa
    public override void _Ready()
    {
        // Obtém as partes do nosso jogo e armazena nas variáveis
        _tilemap = GetNode<TileMap>("TileMap");
        _idleSprite = GetNode<Sprite2D>("Idle");
        _walkSprite = GetNode<AnimatedSprite2D>("WalkSprite");
        _jumpSprite = GetNode<AnimatedSprite2D>("JumpSprite");
        _attackSprite = GetNode<AnimatedSprite2D>("AttackSprite");


        // Esconde algumas partes do jogador que não são necessárias no início
        _walkSprite.Visible = false;
        _jumpSprite.Visible = false;
        _attackSprite.Visible = false;
    }

    // Função que é chamada em cada quadro do jogo para atualizar a física
    public override void _PhysicsProcess(double delta)
    {
        // Reseta a velocidade horizontal do jogador
        _velocity.X = 0;

        // Verifica se o jogador está pressionando a tecla de mover para a esquerda
        if (Input.IsActionPressed("ui_left"))
        {
            _velocity.X = -moveSpeed;
        }
        // Verifica se o jogador está pressionando a tecla de mover para a direita
        else if (Input.IsActionPressed("ui_right"))
        {
            _velocity.X = moveSpeed;
        }

        // Adiciona a gravidade à velocidade vertical do jogador
        _velocity.Y += gravity * (float)delta;
        _jumpSprite.Visible = false;

        // Verifica se o jogador está pressionando a tecla de pular
        if (Input.IsActionPressed("ui_up"))
        {
            _velocity.Y = jumpVelocity;
            _jumpSprite.Visible = true;
            _isAttacking = false;

            _idleSprite.Visible = true;
            _walkSprite.Visible = false;
            _attackSprite.Visible = false;

            _jumpSprite.Play("jump");
        }

        // Verifica se o jogador está pressionando a tecla de atacar
        if (Input.IsActionPressed("ui_attack"))
        {
            _isAttacking = true;
            _jumpSprite.Visible = false;

            _idleSprite.Visible = false;
            _walkSprite.Visible = false;
            _attackSprite.Visible = true;

            _attackSprite.Play("attack");
        }
        else
        {
            _isAttacking = false;
            _attackSprite.Visible = false;
        }

        // Atualiza as animações do jogador
        _UpdateSpriteRenderer(_velocity.X);

        // Move o jogador com base na velocidade calculada
        Velocity = _velocity;
        MoveAndSlide();

        // Se o jogador sair da tela pela direita, volta para a esquerda
        if (Position.X > 3300)
        {
            Position = new Vector2(-100, 250);
            _velocity = Vector2.Zero;
        }

        // Impede o jogador de cair fora da tela
        if (Position.Y > 450)
        {
            Position = new Vector2(Position.X, 450);
            _velocity.Y = 0;
        }
    }

    // Função para atualizar as animações do jogador
    private void _UpdateSpriteRenderer(float velX)
    {
        bool walking = Mathf.Abs(velX) > 0 && !_isAttacking && !_jumpSprite.Visible;
        bool idle = !walking && !_isAttacking && !_jumpSprite.Visible;

        _idleSprite.Visible = idle;
        _walkSprite.Visible = walking;

        if (_isAttacking)
        {
            _attackSprite.Visible = true;
            _attackSprite.Play("attack");
        }
        else
        {
            _attackSprite.Visible = false;
            _attackSprite.Stop();
        }

        if (_jumpSprite.Visible)
        {
            _jumpSprite.Visible = true;
            _jumpSprite.Play("jump");
        }
        else
        {
            _jumpSprite.Visible = false;
            _jumpSprite.Stop();
        }

        if (walking)
        {
            _walkSprite.Play();
            _walkSprite.FlipH = velX < 0;
        }
    }

    // Função para verificar se o jogador está atacando
    public bool IsAttacking()
    {
        return _isAttacking;
    }

	public void AddPoints(int points)
	{
		_score += points;
		GD.Print("Score: " +_score);
	}
}





/*public partial class PlayerController : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	//Varievel para o movimento do personagem

	private float _Speed = 300.0f;

	private float _JumpVelovity= -400.0f

	private float gravity = 1000.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}*/