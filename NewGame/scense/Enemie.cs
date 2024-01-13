using Godot;
using System;

public partial class Enemie : CharacterBody2D
{

	public const float Speed = 1;
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
		
		sprite2d.Animation = "default";

		Vector2 direction = Vector2.Right;
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		
		
		
		
		MoveAndSlide();
		
	}
}