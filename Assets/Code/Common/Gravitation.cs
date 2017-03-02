using UnityEngine;

namespace Assets.Code
{
    public static class Gravitation
    {
        public const double G = 6.67408e-11;

        public static double GetOrbitalSpeed(double mass, double distance)
        {
            return Mathf.Sqrt((float) (G * mass / distance));
        }
    }
}