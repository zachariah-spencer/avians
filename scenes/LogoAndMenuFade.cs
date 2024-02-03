using Godot;
using System;
using System.Diagnostics;

public partial class LogoAndMenuFade : AnimationPlayer
{
	// Called when the node enters the scene tree for the first time.

	
	public override void _Ready()
	{
		Play("logoFade");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void OnAnimationFinish(StringName animationName)
	{
		if(animationName == "logoFade")
		{
			Play("bgFadeFromBlack");
		}
	}
	
}
