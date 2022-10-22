using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using Trivia.ViewModel;

namespace Trivia;

public partial class MainPage : ContentPage
{
    private ProgressArc _progressArc;

    private double _progress;

    private int _duration = 10;
    private DateTime _startime;

    public CancellationTokenSource _cancellationTokenSource = new();

    public MainPage(TriviaViewModel triviaViewModel)
	{
		InitializeComponent();
		BindingContext = triviaViewModel;
        _progressArc = new ProgressArc();
    }

    protected override bool OnBackButtonPressed()
    {
		return false;
    }

    private void ResetView()
    {
        _progress = 0;
        _progressArc.Progress = 100;
        ProgressView.Invalidate();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ProgressView.Drawable = _progressArc;
    }

    private async void UpdateArc()
    {
            
            //_progress = Math.Ceiling();
            _progress %= _duration;
            _progressArc.Progress = _progress / _duration;
            ProgressView.Invalidate();

            //if (rema == 0)
            //{
                //return;
           // }

            await Task.Delay(1000);
            ResetView();
    }

        
}

public class ProgressArc : IDrawable
{
    public double Progress { get; set; }
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        var endAngle = 90;
        canvas.StrokeColor = Color.FromRgba("6599ff");
        canvas.StrokeSize = 10;

        canvas.DrawArc(5, 5, (dirtyRect.Width - 10), (dirtyRect.Height - 10), 360, endAngle, false, false);
    }
}

