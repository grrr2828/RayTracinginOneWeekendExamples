namespace RayTracinginOneWeekendExamples
{
    public class HitRecord
    {
        public float t;  
        public Vector3 p;    
        public Vector3 normal;
        public HitRecord()
        {
            t = 0;
            p = new Vector3(0,0,0);
            normal = new Vector3(0,0,0);
        }
    }
}