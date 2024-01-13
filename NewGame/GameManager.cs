using Godot;
using System;

public partial class GameManager : Node
{

	private Label point_label;

public override void _Ready()
	{
	point_label = GetNode<Label>("/root/Node/CanvasLayer/Panel/PointsLabel");
	GD.Print(point_label);
	}

	int points = 0; 
	
	public void AddPoints()
	{
		points += 1;
		GD.Print(points);
		point_label.Text = $"Total Points: {points.ToString()}";
		
	}


}


