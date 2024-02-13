using spark_demo.Application.Models;

namespace spark_demo.Pages.Components;

public class PageState
{
	public User User { get; set; } = new();
	public string AppName { get; set; }
}