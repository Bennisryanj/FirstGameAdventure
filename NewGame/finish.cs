using Godot;
using System;

public partial class finish : Area2D
{
	[Export]
	private PackedScene TargetLevel;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	private void _on_body_entered(Node2D body)
{
	if(body.Name == "CharacterBody2D")
	{
		GetTree().ChangeSceneToPacked(TargetLevel);
	}
	
}
}



