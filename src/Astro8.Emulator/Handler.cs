using Astro8.Devices;

namespace Astro8;

public abstract class Handler
{
    public abstract void SetPixel(int address, ScreenColor color);

    public abstract void LogSpeed(int steps, float value);
}
