using CtrlLights.Data.Models;
using CtrlLights.Data.Api_Service;
using SkiaSharp;

namespace CtrlLights
{
    public partial class MainPage : ContentPage
    {

        private ApiService _apiService;
        private bool _isRunning = true;

        public MainPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Add data after the page has appeared
            StartAutoRefresh();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _isRunning = false; // Stop the loop when the page disappears
        }

        private async void StartAutoRefresh()
        {
            while (_isRunning) // Keep refreshing while the page is visible
            {
                AddDataTrafficLights();
                SetBusyness();
                RefreshedDateLabel.Text = $"Last refreshed: {DateTime.Now.ToString("HH:mm:ss")}";
                infoBtn.Padding = 100;
                // Refresh data
                await Task.Delay(3000); // Wait 3 seconds before the next refresh
            }
        }

        private async void AddDataTrafficLights()
        {
            try
            {
                List<TrafficLights> TlList = await _apiService.GetTrafficLightsAsync();

                if (TlList == null || TlList.Count == 0)
                {
                    Console.WriteLine("No traffic lights found.");
                    return;
                }

                ElementsLayout.Children.Clear(); // Clear old UI elements before adding new ones

                foreach (TrafficLights tl in TlList)
                {
                    UpdateMapLights(tl.LightStatus, tl.Id);
                    CreateElementFrame(tl.Id.ToString(), tl.LightStatus);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddDataTrafficLights: {ex.Message}");
            }
        }

        private Frame CreateElementFrame(string label, char light)
        {

            Label TextLabel = new Label()
            {
                Text = label,
                FontFamily = "Poppins-Medium",
                FontSize = 21,
                TextColor = Colors.Black,
                HorizontalOptions = LayoutOptions.Center,
            };

            Image trafficLight = new Image()
            {
                Source = SetImage(light),
                HeightRequest = 70
            };

            VerticalStackLayout layout = new VerticalStackLayout()
            {
                Children = { TextLabel, trafficLight },
                Spacing = 5
            };

            Frame frame = new Frame()
            {
                Content = layout,
                HorizontalOptions = LayoutOptions.Center,
                HasShadow = true,
                Padding = 5,  // Reduced padding
                CornerRadius = 10,
                Margin = 5,    // Reduced margin
                BackgroundColor = Colors.White,
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

        public static SKColor GetRandomColor()
        {
            Random rand = new Random();
            byte r = (byte)rand.Next(256); // Random Red (0-255)
            byte g = (byte)rand.Next(256); // Random Green (0-255)
            byte b = (byte)rand.Next(256); // Random Blue (0-255)

            return new SKColor(r, g, b);
        }

        private void UpdateMapLights(char value, int id)
        {
            if(id == 1)
            {
                pngOne.Source = SetImage(value);
            }
            else if (id == 2)
            {
                pngTwo.Source = SetImage(value);
            }
            else if (id == 3)
            {
                pngThree.Source = SetImage(value);
            }
            else if (id == 4)
            {
                pngFour.Source = SetImage(value);
            }
            else if (id == 5)
            {
                pngFive.Source = SetImage(value);
            }
            else if (id == 6)
            {
                pngSix.Source = SetImage(value);
            }
            else if (id == 7)
            {
                pngSeven.Source = SetImage(value);
            }
            else if (id == 8)
            {
                pngEight.Source = SetImage(value);
            }


        }

        public string SetImage(char value)
        {
            if (value == 'R')
            {
                return "svetofarcherven.png";
            }
            else if(value == 'Y')
            {
                return "svetofarjult.png";
            }
            else
            {
                return "svtetofarzelen.png";
            }
        }

        private async void SetBusyness()
        {
            List<TrafficLights> TlList = await _apiService.GetTrafficLightsAsync();

            foreach (TrafficLights ll in TlList)
            {
                if(ll.Id == 1 || ll.Id == 2)
                {
                    if (ll.Busyness == "L")
                    {
                        StatusUp.BackgroundColor = Colors.LightGreen;
                    }
                    else if (ll.Busyness == "M")
                    {
                        StatusUp.BackgroundColor = Color.FromHex("#d8ef06");
                    }
                    else if (ll.Busyness == "H")
                    {
                        StatusUp.BackgroundColor = Colors.DarkRed;
                    }
                }
                else if (ll.Id == 3 || ll.Id == 4)
                {
                    if (ll.Busyness == "L")
                    {
                        StatusRight.BackgroundColor = Colors.LightGreen;
                    }
                    else if (ll.Busyness == "M")
                    {
                        StatusRight.BackgroundColor = Color.FromHex("#d8ef06");
                    }
                    else if (ll.Busyness == "H")
                    {
                        StatusRight.BackgroundColor = Colors.DarkRed;
                    }
                }
                else if (ll.Id == 5 || ll.Id == 6)
                {
                    if (ll.Busyness == "L")
                    {
                        StatusDown.BackgroundColor = Colors.LightGreen;
                    }
                    else if (ll.Busyness == "M")
                    {
                        StatusDown.BackgroundColor = Color.FromHex("#d8ef06");
                    }
                    else if (ll.Busyness == "H")
                    {
                        StatusDown.BackgroundColor = Colors.DarkRed;
                    }
                }
                else if (ll.Id == 7 || ll.Id == 8)
                {
                    if(ll.Busyness == "L")
                    {
                        StatusLeft.BackgroundColor = Colors.LightGreen;
                    }
                    else if (ll.Busyness == "M")
                    {
                        StatusLeft.BackgroundColor = Color.FromHex("#d8ef06");
                    }
                    else if (ll.Busyness == "H")
                    {
                        StatusLeft.BackgroundColor = Colors.DarkRed;
                    }
                }
            }
        }

        
        private async void InfoBtn_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Information", "Here you can see the trafic condition in the chosen region. The 'bubbles' on the roed shows the busyness on the road. If it is light, the " +
                "the bubble would be green, if it is something in the middle it is going to be yellow anf if there is big traffic on the road, the bubbles are going to be " +
                "painted with red. The other information that we are getting is the live status of a traffic light.", "Ok");
        }

     
    }

}
