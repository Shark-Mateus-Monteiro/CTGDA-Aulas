using Godot;
using System;

public partial class ZombieIdk : CharacterBody3D
{

		public int Speed = 30;
		public int Gravity = 196;
	public override void _Ready()
	{
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void OnBodyEntered(Node body)
    {
            if (body is CharacterBody3D)
                LoseLife();
    }
	private void LoseLife()
    {
        var gameManager = GetNode<ZombieIdk>("/root/");
        if (gameManager != null)
        {
            gameManager.LoseLife();
        }
        QueueFree();
    }
}
