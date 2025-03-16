namespace Control_lights;

public partial class UserMainPage : ContentPage
{
	public UserMainPage()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
        CreateElementFrame();
    }

    private Frame CreateElementFrame()
    {

        Label TextLabel = new Label()
        {
            Text = "1",
            FontFamily = "Poppins-Medium",
            FontSize = 21,
            HorizontalOptions = LayoutOptions.Center,
        };

        Image trafficLight = new Image()
        {
            Source = "trafficlight.png",
            HeightRequest = 70
        };

        VerticalStackLayout layout = new VerticalStackLayout()
        { 
            Children = {TextLabel, trafficLight},
            Spacing= 5
        };

        Frame frame = new Frame()
        {
            Content = layout,
            HorizontalOptions = LayoutOptions.Center,
            HasShadow = true,
            Padding = 5,  // Reduced padding
            CornerRadius = 10,
            Margin = 5,    // Reduced margin
            BackgroundColor = Color.FromArgb("#e1f2d9"),
            Shadow = new Shadow
            {
                Brush = Color.FromRgba(0, 0, 0, 0.4), // Shadow color (black with 40% opacity)
                Offset = new Point(5, 5), // Shadow position offset (X, Y)
                Radius = 20, // Blur radius of the shadow
                Opacity = 1 // Shadow transparency
            }
        };


        ElementsLayout.Children.Add(frame);
        return frame;

    }
}