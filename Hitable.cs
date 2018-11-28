using System;
using System.Collections.Generic;

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

            Vector3 oc = r.Origin() - center;
            float a = Vector3.Dot( r.Direction(), r.Direction() );
            float b = 2.0f * Vector3.Dot( r.Direction(), oc  );
            float c = Vector3.Dot( oc, oc ) - radius * radius;

            float discriminant = b*b - 4*a*c;
            if(discriminant > 0)
            {
                float discFactor = (float)Mathf.Sqrt(discriminant);
                float temp = (-b - discFactor) / (2.0f*a);
                if(temp < t_max && temp > t_min)
                {
                    rec.t = temp;
                    rec.p = r.PointAt(temp);
                    rec.normal = (rec.p - center) / radius;
                
                    return true;
                }
                temp = (-b + discFactor) / (2.0f*a);
                if(temp < t_max && temp > t_min)
                {

                    rec.t = temp;
                    rec.p = r.PointAt(temp);
                    rec.normal = (rec.p - center) / radius;
                
                    return true;
                }
            }

            
            return false;
        }
    }

    public class HitableList  : Hitable
    {
        List<Hitable> list;

        public HitableList(List<Hitable> list) {
            this.list = list;
        }
        

        public override bool Hit(Ray r, float t_min, float t_max, HitRecord rec)
        {   
            HitRecord tempRec = new HitRecord();
            bool hitAnything = false;
            float closestSoFar = t_max;
            for(int i = 0; i < list.Count; i++)
            {
                if(list[i].Hit(r, t_min, closestSoFar, tempRec))
                {
                    hitAnything = true;
                    closestSoFar = tempRec.t; 
                    rec.t = tempRec.t;
                    rec.normal = tempRec.normal;
                    rec.p = tempRec.p;
                }
            }
            return hitAnything;
        }
    }
}