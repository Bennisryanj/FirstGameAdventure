using Godot;
using System;
using System.Diagnostics;

public partial class MainCharater : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	public const float wallGravityMod = 0.75f;
	private AnimatedSprite2D sprite2d; 
	public int jumpcount = 0; 
	public int DoubleJump = 2;

	public int maxJump = 3; 
	public const float WallJumpPushBack = -100.0f;
	  private bool isSliding = false;
	private Stopwatch timer = new Stopwatch();
	
	  public override void _Ready()
	{
		sprite2d = GetNode<AnimatedSprite2D>("Sprite2D");
		GD.Print(sprite2d);
	}
 

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Animations
		 if (IsOnFloor())
		{
			// On the floor, check for running or default animation
			if (Math.Abs(velocity.X) > 1)
				sprite2d.Animation = "running";
			else
				sprite2d.Animation = "default";
		}
		else if(IsOnWall())
		{
		sprite2d.Animation = "WallJump";
		GD.Print("ON thewall");

			if (!timer.IsRunning)
			{
				timer.Start();
			}

			if (timer.Elapsed.TotalSeconds < 2)
			{
				velocity.Y *= wallGravityMod;
			}
			else
			{
				// Start sliding down the wall

				isSliding = true;
				GD.Print("Sliding");
				timer.Stop();
				timer.Reset();
			}

		}
		else
		{
			if (jumpcount == 2)
			{
				sprite2d.Animation = "DoubleJump";
			}else
			{
				sprite2d.Animation = "Jumping";
				
			}

			if (!isSliding)
			{
				velocity.Y += gravity * (float)delta;
			}
		}
		

		if (IsOnFloor())
		{
			jumpcount = 0;
			isSliding = false;
		}

		if (isSliding)
		{
			GD.Print("On the wall and slidign");
		 velocity.Y += 1000.0f * (float)delta;
		 jumpcount = 0;

		}
	
		
		if (Input.IsActionJustPressed("jump") && jumpcount < maxJump)
		{

			// Perform regular jump
			velocity.Y = JumpVelocity;
			jumpcount++;
			
		}
		
		if(jumpcount == 2)
		{
			sprite2d.Animation = "DoubleJump";
			
		}

			

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("left", "right", "ui_up", "ui_down");
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
		
		// Flip the sprite based on the direction.
		bool isLeft = velocity.X < 0;
		sprite2d.FlipH = isLeft;
		
		
	}
	
	private void jump()
	{
		Vector2 velocity = Velocity;
		velocity.Y = JumpVelocity; 
	}

	
	
}
