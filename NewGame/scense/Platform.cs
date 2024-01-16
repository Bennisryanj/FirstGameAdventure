using Godot;
using System;

public partial class Platform : StaticBody2D
{
	
	private AnimatedSprite2D sprite2d; 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sprite2d = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
 
	}
	
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		sprite2d.Animation = "On";
	}
}
