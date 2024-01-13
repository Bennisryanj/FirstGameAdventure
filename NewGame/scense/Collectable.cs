using Godot;
using System;
using System.Collections;

public partial class Collectable : Area2D
{
	  private GameManager gameManager;

	public override void _Ready()
	{
		// Get a reference to the existing GameManager node in the scene
		gameManager = GetNode<GameManager>("/root/Node/GameManager");
	}
	
	
	
private void _on_body_entered(Node2D body)
{
	if(body.Name == "CharacterBody2D")
	{
		gameManager.AddPoints();
		QueueFree();
		
	}
	
}

}
