﻿using Trivia.Services;

namespace Trivia;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		AIService service = new AIService();
	}
}
