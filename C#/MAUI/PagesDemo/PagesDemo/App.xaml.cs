namespace PagesDemo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		var navigationPage = new NavigationPage(new MainPage());
		navigationPage.BarBackgroundColor = Colors.Chocolate;
		navigationPage.BarTextColor = Colors.White;
		MainPage = navigationPage;
	}
}
