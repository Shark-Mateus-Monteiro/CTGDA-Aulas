using Godot;
using System;

public partial class Var:Node3D
{
	private int _coinCount = 0; //Variavel que guarda o num de moedas apanhadas
	private Label _CoinLabel; //Variavel

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_CoinLabel = GetNode<Label>("../CanvasLayer/CoinLabel");
		if(_CoinLabel == null)
			return;

		UpdateCoinLabel();
	}
	public void AddCoin()
	{
		_coinCount++;
		UpdateCoinLabel();
	}
	public void UpdateCoinLabel()
	{
		_CoinLabel.Text = $"Coins: {_coinCount}";
	}

}
