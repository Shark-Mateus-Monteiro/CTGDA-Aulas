using Godot;
using System;

public partial class LifeLabel : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_LifeLabel = GetNode<LifeLabel>("../CanvasLayer/LifeLabel");
		if(_CoinLabel == null)
			return;

		UpdateLifeLabel();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
