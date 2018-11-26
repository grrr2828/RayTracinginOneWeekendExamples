namespace RayTracinginOneWeekendExamples
{
    public class Ray
    {
        private Vector3 _a;
        private Vector3 _b;

        public Ray()
        {

        }

        public Ray(Vector3 a, Vector3 b)
        {
            _a = a;
            _b = b;
        }

        public Vector3 Origin(){ return _a; }

        public Vector3 Direction(){ return _b; }

        public Vector3 PointAt(float t)
        {
            return _a + t * _b;
        }


    }
}