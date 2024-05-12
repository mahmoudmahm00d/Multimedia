namespace Multimedia.Helpers;

public class ColorMaps
{
    public static Color[] GetColorMap(Color color)
    {
        Color[] colormap = new Color[256];
        for (int i = 0; i < 256; i++)
        {
            int A = (int)(255 * (i / 255.0));
            colormap[i] = Color.FromArgb(
                Math.Abs(color.R - A),
                Math.Abs(color.G - A),
                Math.Abs(color.B - A)
            );
        }

        return colormap;
    }

    public static Color[] GetHeatColorMap()
    {
        Color[] heatColorMap = new Color[256];

        for (int i = 0; i < 256; i++)
        {
            float hue = i / 255f;
            heatColorMap[i] = Color.FromArgb(255, (int)(255 * hue), (int)(255 * (1f - hue)), 0);
        }

        return heatColorMap;
    }

    public static Color[] GetRainbowColorMap()
    {
        Color[] rainbowColorMap = new Color[256];

        for (int i = 0; i < 256; i++)
        {
            float hue = (float)i / 255f;
            rainbowColorMap[i] = Color.FromArgb(
                255,
                (int)Math.Abs(255 * Math.Sin(hue * Math.PI * 2)),
                (int)Math.Abs(255 * Math.Sin((hue + 1f / 3f) * Math.PI * 2)),
                (int)Math.Abs(255 * Math.Sin((hue + 2f / 3f) * Math.PI * 2))
            );
        }

        return rainbowColorMap;
    }

    public static Color[] GetCoolWarmColorMap()
    {
        Color[] coolWarmColorMap = new Color[256];

        for (int i = 0; i < 256; i++)
        {
            float t = i / 255f;
            int r = (int)Math.Abs(255 * (1 - t) * 0.2235 + 255 * t * 0.8039);
            int g = (int)Math.Abs(255 * (1 - t) * 0.2235 + 255 * t * 0.8039);
            int b = (int)Math.Abs(255 * (1 - t) * 0.6471 + 255 * t * 0.1961);
            coolWarmColorMap[i] = Color.FromArgb(255, r, g, b);
        }

        return coolWarmColorMap;
    }

    public static Color[] GetPurpleBlueColorMap()
    {
        Color[] purpleBlueColorMap = new Color[256];

        for (int i = 0; i < 256; i++)
        {
            float t = i / 255f;
            int r = (int)Math.Abs(255 * (1 - t) * 0.5294 + 255 * t * 0.2);
            int g = (int)Math.Abs(255 * (1 - t) * 0.1294 + 255 * t * 0.6);
            int b = (int)Math.Abs(255 * (1 - t) * 0.9294 + 255 * t * 0.8);
            purpleBlueColorMap[i] = Color.FromArgb(255, r, g, b);
        }

        return purpleBlueColorMap;
    }

    public static Color[] GetParulaColorMap()
    {
        Color[] parulaColorMap = new Color[256];

        for (int i = 0; i < 256; i++)
        {
            float t = (float)i / 255f;
            int r = (int)
                Math.Abs(255 * (0.2081 + 2.0770 * t - 13.1402 * t * t + 15.8136 * t * t * t));
            int g = (int)
                Math.Abs(255 * (0.1664 + 2.0810 * t - 24.7808 * t * t + 25.4788 * t * t * t));
            int b = (int)
                Math.Abs(255 * (0.5094 + 0.5210 * t - 5.5129 * t * t + 4.2520 * t * t * t));
            parulaColorMap[i] = Color.FromArgb(
                255,
                Math.Max(0, Math.Min(255, r)),
                Math.Max(0, Math.Min(255, g)),
                Math.Max(0, Math.Min(255, b))
            );
        }

        return parulaColorMap;
    }

    public static void AddColorMaps(List<Color[]> list)
    {
        list.Add(GetCoolWarmColorMap());
        list.Add(GetParulaColorMap());
        list.Add(GetHeatColorMap());
        list.Add(GetPurpleBlueColorMap());
        list.Add(GetRainbowColorMap());
    }
}
