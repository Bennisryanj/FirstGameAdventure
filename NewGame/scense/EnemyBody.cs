using Godot;
using System;
using System.IO;

public partial class EnemyBody : Area2D
{
	private AnimatedSprite2D sprite2d; 
	private PathFollow2D spritePath;
	public override void _Ready()
	{
	sprite2d = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	spritePath = GetNode<PathFollow2D>("PathFollow2D");

		GD.Print(sprite2d);
		GD.Print(spritePath);
	}

	
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
			if (spritePath.ProgressRatio < .50)
			{
			
				sprite2d.FlipH = true;
			}



				sprite2d.Animation = "running";
			
	
	}
	
	public void _on_body_entered(Node2D body)
	{
		GetTree().ReloadCurrentScene();
	}
}



