using Godot;
using System;

public partial class Enemie : CharacterBody2D
{

	public const float Speed = 100;
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
		
		velocity.Y += gravity * (float)delta;
		
		velocity.X = -Speed;

		MoveAndSlide();
		GD.Print("Velocity:", velocity);
		GD.Print("Position:", Position);

		
	}
}
