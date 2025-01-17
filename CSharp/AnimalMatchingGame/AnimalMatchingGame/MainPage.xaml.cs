namespace AnimalMatchingGame
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void PlayAgainButton_Clicked(object sender, EventArgs e)
        {
            ColorButtons.IsVisible = true;
            PlayAgainButton.IsVisible = false;

            List<Color> colors =
            [
                Colors.HotPink, Colors.HotPink,
                Colors.RoyalBlue, Colors.RoyalBlue,
                Colors.IndianRed, Colors.IndianRed,
                Colors.MediumAquamarine, Colors.MediumAquamarine,
                Colors.SaddleBrown, Colors.SaddleBrown,
                Colors.MediumPurple, Colors.MediumPurple,
                Colors.ForestGreen, Colors.ForestGreen,
                Colors.BurlyWood, Colors.BurlyWood,
            ];

            foreach (var button in ColorButtons.Children.OfType<Button>())
            {
                button.IsEnabled = true;
                int index = Random.Shared.Next(colors.Count);
                Color nextColor = colors[index];
                button.BackgroundColor = nextColor;
                colors.RemoveAt(index);
            }

            Dispatcher.StartTimer(TimeSpan.FromSeconds(.1), TimerTick);
        }

        int tenthsOfSecondsElapsed = 0;

        private bool TimerTick()
        {
            if (!this.IsLoaded) return false;

            tenthsOfSecondsElapsed++;

            TimeElapsed.Text = "Time elapsed: " +
                (tenthsOfSecondsElapsed / 10F).ToString("0.0s");

            if (PlayAgainButton.IsVisible)
            {
                tenthsOfSecondsElapsed = 0;
                return false;
            }

            return true;
        }

        Button lastClicked;
        bool findingMatch = false;
        int matchesFound;

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button buttonClicked)
            {
                if (findingMatch == false)
                {
                    lastClicked = buttonClicked;
                    lastClicked.BackgroundColor = buttonClicked.BackgroundColor;
                    findingMatch = true;
                }
                else
                {
                    if (buttonClicked.BackgroundColor.Equals(lastClicked.BackgroundColor)
                        && buttonClicked != lastClicked)
                    {
                        matchesFound++;
                        lastClicked.IsEnabled = false;
                        buttonClicked.IsEnabled = false;
                    }

                    findingMatch = false;
                }
            }

            if (matchesFound == 8)
            {
                matchesFound = 0;
                ColorButtons.IsVisible = false;
                PlayAgainButton.IsVisible = true;
            }
        }
    }
}