namespace RayTracinginOneWeekendExamples
{
    public abstract class Hitable
    {
        public abstract bool Hit(Ray r, float t_min, float t_max, HitRecord rec);
    }


    public class Sphere : Hitable
    {
        public Vector3 center;
        public float radius;

        public Sphere(Vector3 c, float r)
        {
            center = c;
            radius = r;
        }


        public override bool Hit(Ray r, float t_min, float t_max, HitRecord rec)
        {
            
            
            return false;
        }
    }
}