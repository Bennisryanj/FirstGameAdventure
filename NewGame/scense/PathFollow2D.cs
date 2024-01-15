using Godot;
using System;

public partial class PathFollow2D : Godot.PathFollow2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}


	double speeds = 300;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		ProgressRatio += (float)(delta * speeds);
	}
}
