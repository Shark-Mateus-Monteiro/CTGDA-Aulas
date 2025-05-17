using Godot;
using System;

public partial class Moeda:Area3D
{
    private const float Amplitude = 0.5f;
    private const float Frequency = 0.1f;
    private float _time = 0.0f;
    public override void _Ready()
    {
        Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
    }
    public override void _Process(double delta)
    {
        _time += (float)delta;
        float newY = Mathf.Sin(_time * Frequency) * Amplitude;
        Transform3D transform = Transform;
        transform.Origin = new Vector3(transform.Origin.X, newY, transform.Origin.Z);
        Transform = transform;
    }
    public void OnBodyEntered(Node body)
    {
            if (body is CharacterBody3D)
                CollectCoin();
    }
    private void CollectCoin()
    {
        var gameManager = GetNode<Var>("/root/World/Var");
        if (gameManager != null)
        {
            gameManager.AddCoin();
        }
        QueueFree();
    }
}