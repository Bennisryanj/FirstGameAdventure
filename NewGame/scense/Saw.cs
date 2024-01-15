using Godot;
using System;

public partial class Saw : Area2D
{
	
	private AnimatedSprite2D sprite2d; 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sprite2d = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		GD.Print(sprite2d);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		sprite2d.Animation = "default";
		
	}
	private void _on_body_entered(Node2D body)
	{
	GetTree().ReloadCurrentScene();
	}

}


