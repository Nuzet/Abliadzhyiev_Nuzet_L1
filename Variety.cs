using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace OOP_L1
{
    class Variety
    {
        private List<int> elements = new List<int>();

        private string js { set; get; }

        private int a;
        public int _A
        {
            get { return a; }
            set { a = value; }
        }


        private int b;
        public int _B
        {
            get { return b; }
            set { b = value; }
        }

        private int c;
        public int _C
        {
            get { return c; }
            set { c = value; }
        }
        private int d;
      

        public int _D
        {
            get { return d; }
            set { d = value; }
        }

       

        public Variety(int a, int b, int c, int d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;

            elements.Add(this.a);
            elements.Add(this.b);
            elements.Add(this.c);
            elements.Add(this.d);
        }
        


        public void PrintVariety()
        {
            Console.Write("{ ");
            foreach (var item in elements)
            { 
                Console.Write(item + " ");
            }
            Console.Write("}");
        }
        public void AddElement(int value)
        {
            elements.Add(value);
        }

        public void RemoveElement(int value)
        {
            elements.Remove(value);
        }

        public void EqualsVariety(Variety variety)
        {
            if (elements == variety.elements)
            {
                Console.WriteLine("Множини рiвнi");
            }
            else
                Console.WriteLine("Множини не рiвнi");
        }

        public void ElementsIntersection(Variety variety)
        {
            List<int> v = new List<int>();
            foreach (var item in elements)
            {
                foreach (var item2 in variety.elements)
                {
                    if (item == item2)
                    {
                        v.Add(item2);
                    }
                }
            }
            Console.Write("{ ");
            foreach (var item in v)
            {
                Console.Write(item + " ");
            }
            Console.Write("}");
        }
        public void ElementsUnion(Variety variety)
        {
            List<int> v = new List<int>();
            foreach (var item in variety.elements)
            {
                v.Add(item);
            }
            foreach (var item2 in elements)
            {
                v.Add(item2);
            }

            for (int i = 0; i < v.Count; i++)
                for (int j = i + 1; j < v.Count; j++)
                    if (v[i] == v[j])
                        v.RemoveAt(j);

            Console.Write("{ ");
            foreach (var item in v)
            {
                Console.Write(item + " ");
            }
            Console.Write("}");
        }

        public void isElementOfVariety(int value)
        {
            foreach (var item in elements)
            {
                if (item == value)
                {
                    Console.Write($" Елемент [{value}] належить множинi");
                    break;
                }
                else
                    Console.Write($" Елемент [{value}] не належить множинi");
                break;
            }
        }

        public void VarietyDifference(Variety variety)
        {
            List<int> v = new List<int>();
            foreach (var item in variety.elements)
            {
                v.Add(item);
            }
            foreach (var item in elements)
            {
                foreach (var item2 in variety.elements)
                {
                    if (item == item2)
                    {
                        v.Add(item2);
                    }
                }
            }
            for (int i = 0; i < v.Count; i++)
                for (int j = i + 1; j < v.Count; j++)
                    if (v[i] == v[j])
                    {
                        v.RemoveAt(j);
                        v.RemoveAt(i);
                    }
            Console.Write("{ ");
            foreach (var item in v)
            {
                Console.Write(item + " ");
            }
            Console.Write("}");
        }
        public void VarietySimDifference(Variety variety)
        {
            List<int> v = new List<int>();
            foreach (var item in variety.elements)
            {
                v.Add(item);
            }
            foreach (var item2 in elements)
            {
                v.Add(item2);
            }
            for (int i = 0; i < v.Count; i++)
                for (int j = i + 1; j < v.Count; j++)
                    if (v[i] == v[j])
                        v.RemoveAt(j);

            foreach (var item in elements)
            {
                foreach (var item2 in variety.elements)
                {
                    if (item == item2)
                    {
                        v.Remove(item2);
                    }
                }
            }

            Console.Write("{ ");
            foreach (var item in v)
            {
                Console.Write(item + " ");
            }
            Console.Write("}");
        }

        public void FileToJson()
        {
            
            js= JsonConvert.SerializeObject(this);
            var pathout = Path.Combine(Environment.CurrentDirectory, "varietyout.json");
            File.WriteAllText(pathout, js);
            Console.WriteLine("\nДанi створенi у файлi json");
          
        }

        public  void  FileFromJson()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "varietyfrom.json");
            var json2 = File.ReadAllText(path);
            Variety variety1 = JsonConvert.DeserializeObject<Variety>(json2);
           
            Variety variety = new Variety(variety1._A, variety1._B, variety1._C, variety1._D);
            Console.Write("Множина з файлу json: ");
            variety.PrintVariety();



        }

    }
}


