using Godot;
using System;

public partial class LifeLabel : Label
{
	private int _lifeCount = 3;
	private Label _LifeLabel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_LifeLabel = GetNode<LifeLabel>("../CanvasLayer/LifeLabel");
		if (_LifeLabel == null)
			return;

		UpdateLifeLabel();
	}
	public void LoseLife()
	{
		_lifeCount--;
		UpdateLifeLabel();
	}
	public void UpdateLifeLabel()
	{
		_LifeLabel.Text = $"HP: {_lifeCount}";
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
