

namespace RayTracinginOneWeekendExamples
{
  public static class Mathf
  {
    public const float PI = 3.141593f;

    public static float Clamp(float value, float min, float max)
    {
      if (value > max)
        return max;
      if (value < min)
        return min;
      return value;
    }

    public static float Max(float a, float b)
    {
      if (a > b)
        return a;
      return b;
    }

    public static float Min(float a, float b)
    {
      if (a < b)
        return a;
      return b;
    }

    public static float Sqrt(float a)
    {
      return (float)System.Math.Sqrt(a);
    }

    public static float Sin(float a)
    {
      return (float)System.Math.Sin(a);
    }

    public static float Cos(float a)
    {
      return (float)System.Math.Cos(a);
    }

    public static float Atan2(float a, float b)
    {
      return (float)System.Math.Atan2(a, b);
    }
  }
}
