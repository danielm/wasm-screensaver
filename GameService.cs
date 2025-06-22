using Microsoft.JSInterop;

namespace WasmScreensaver;

public class GameService(IJSRuntime jsRuntime) : IDisposable
{
    private readonly TheThing _theThing = new();
    private readonly IJSInProcessRuntime _jsRuntime = (IJSInProcessRuntime)jsRuntime;
    private Timer? _timer;
    private bool _isRunning;

    public void StartGame()
    {
        if (_isRunning) return;

        _isRunning = true;
        _timer = new Timer(UpdateGame, null, 0, 16); // ~60fps
    }

    private void UpdateGame(object? state)
    {
        var windowSize = _jsRuntime.Invoke<int[]>("getWindowSize");
        _theThing.Update(windowSize[0], windowSize[1]);

        _jsRuntime.InvokeVoid("drawTheThing",
            _theThing.X, _theThing.Y, _theThing.Width, _theThing.Height, _theThing.Color);

        if (_theThing.CheckCornerHit(windowSize[0], windowSize[1]))
        {
            _jsRuntime.InvokeVoid("alert", "OMG It hit the corner!");
        }
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}