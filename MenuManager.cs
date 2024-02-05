using Godot;
using System;
using System.Collections.Generic;

public partial class MenuManager : Node
{
	MenuStateBase currentState;
	
	public StartMenu startMenu = new StartMenu();
	public MenuTwo menuTwo = new MenuTwo();

    public static Button startButton;
    public static Button quitButton;

    public override void _Ready()
    {
		startMenu.menuManager = this;
		menuTwo.menuManager = this;

		startButton = (Button)GetNode("StartButton");
		quitButton = (Button)GetNode("QuitButton");

		currentState = startMenu;
		currentState.OnEnter();
		currentState.OnEnter();		
    }

	private void OnStartButtonPressed()
	{
		currentState.OnStartButtonPressed();
	}

	private void OnQuitButtonPressed()
	{
		GetTree().Quit();
	}
    public void SwitchState(MenuStateBase switchTo)
	{
		currentState.OnExit();
		currentState = switchTo;
		currentState.OnEnter();
	}


}

public abstract class MenuStateBase
{
	public MenuManager menuManager;
    virtual public void OnEnter()
	{

	}

	virtual public void OnExit()
	{

	}

	virtual public void OnStartButtonPressed()
	{

	}
}

public class StartMenu : MenuStateBase
{
	public override void OnEnter()
	{
		Console.WriteLine("d");
		MenuManager.startButton.Show();
		MenuManager.quitButton.Show();
	}

    public override void OnExit()
    {
		MenuManager.startButton.Hide();
		MenuManager.quitButton.Hide();
    }

    public override void OnStartButtonPressed()
    {
		menuManager.SwitchState(menuManager.menuTwo);
    }
}

public class MenuTwo : MenuStateBase
{
    public override void OnEnter()
    {
		MenuManager.startButton.Show();
    }

    public override void OnExit()
    {
		MenuManager.startButton.Hide();
    }
}