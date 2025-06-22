namespace WasmScreensaver;

public class TheThing
{
    public double X { get; set; }
    public double Y { get; set; }
    public double SpeedX { get; set; } = 2;
    public double SpeedY { get; set; } = 2;
    public double Width { get; set; } = 100;
    public double Height { get; set; } = 100;
    public string Color { get; set; } = "red";

    private readonly Random _random = new();
    private readonly string[] _colors = { "red", "blue", "green", "yellow", "purple", "orange" };

    public void Update(int canvasWidth, int canvasHeight)
    {
        X += SpeedX;
        Y += SpeedY;

        // Check for collisions with boundaries
        if (X <= 0 || X + Width >= canvasWidth)
        {
            SpeedX *= -1;
            ChangeColor();
        }

        if (Y <= 0 || Y + Height >= canvasHeight)
        {
            SpeedY *= -1;
            ChangeColor();
        }
    }

    public bool CheckCornerHit(int canvasWidth, int canvasHeight)
    {
        return (X <= 0 && Y <= 0) ||
            (X + Width >= canvasWidth && Y <= 0) ||
            (X <= 0 && Y + Height >= canvasHeight) ||
            (X + Width >= canvasWidth && Y + Height >= canvasHeight);
    }

    private void ChangeColor()
    {
        Color = _colors[_random.Next(_colors.Length)];
    }
}