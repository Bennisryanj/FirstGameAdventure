using Godot;
using System;

public partial class EnemyBody : CharacterBody2D
{
	private AnimatedSprite2D sprite2d; 
	public override void _Ready()
	{
	sprite2d = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		GD.Print(sprite2d);
	}

	
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
			Vector2 velocity = Velocity;
			if (Math.Abs(velocity.X) > 1)
				sprite2d.Animation = "running";
			
	
	}
}
