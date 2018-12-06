namespace RayTracinginOneWeekendExamples
{
    public class Camera
    {
        private Vector3 lower_left;
        private Vector3 horizontal;
        private Vector3 vertical; 
        private Vector3 origin; 

        public Camera() {
            lower_left = new Vector3(-2.0f, -1.0f, -1.0f);
            horizontal = new Vector3(4.0f, 0.0f, 0.0f);
            vertical = new Vector3(0.0f, 2.0f, 0.0f);
            origin = new Vector3(0.0f, 0.0f, 0.0f);
        }

        /**
        *
        * @param u 距离lower_left的横向距离
        * @param v 距离lower_left的纵向距离
        * @return 光线向量
        */
        public Ray GetRay(float u, float v)
        {
            return new Ray(origin, lower_left +  horizontal * u + vertical * v);
        }
    }   
}