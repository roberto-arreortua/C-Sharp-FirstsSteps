using System;

namespace CSharpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            string is_par;
            for(i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    is_par = " es par";
                }
                else
                {
                    is_par = " no es par";
                }
                Console.WriteLine("Iterador " + i.ToString() + is_par);
            }
            Persona roberto = new Persona("Roberto", 23);
            Persona rebeca = new Persona("Rebeca", 24);
            rebeca.Action();
            roberto.Action();
          
            Console.WriteLine(roberto.MessagePrivate);
            roberto.MessagePrivate = "Mensaje privado cambiado";
            Console.WriteLine(roberto.MessagePrivate);
            var (str,integer,booleano) = roberto.Tupla();
            Console.WriteLine(str + integer.ToString() + booleano.ToString());


            Empleado empleado1 = new Empleado();
            string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };
            foreach (string k in cars)
            {
                Console.WriteLine(k);
            }

            for (int j = 0; j < cars.Length; j++)
            {
                Console.WriteLine(cars[j]);
            }

            Cat cat = new Cat { Age = 10, Name = "Fluffy" };
            Cat sameCat = new Cat("Fluffy") { Age = 10 };
            Cat[] objectArray = { cat, sameCat }; 

            foreach (var propertyInfo in cat.GetType().GetProperties())
            {
                Console.WriteLine(propertyInfo);
            }
            foreach(Cat catValue in objectArray)
            {
                Console.WriteLine(catValue.Name);
            }
        }
    }
    public class Cat
    {
        // Auto-implemented properties.
        public int Age { get; set; }
        public string Name { get; set; }

        public Cat()
        {
        }

        public Cat(string name)
        {
            this.Name = name;
        }
    }
    class Persona : Interface1<Persona>
    {
        public string name;
        public int age;
        public int id;
        public static int idCounter;
        private string messagePrivate = "Mensaje privado";
        public string MessagePrivate{
            get { return messagePrivate; }
            set { this.messagePrivate = value; }
        }
        public Persona(string name, int age)
        {
            this.name = name;
            this.age = age;
            this.ContadorAdd();
            Console.WriteLine("Constructor sobrecarga");
        }
        public bool Metodo1(Persona persona)
        {
            return true;
        }
        public Persona()
        {
            Console.WriteLine("Constructor basio Persona");
        }

        public void Action()
        {
            Console.WriteLine("Esta es una accion de la clase Persona");
            Console.WriteLine("id: " + this.id.ToString()+ " nombre: " + this.name + " edad: " + this.age.ToString());

        }
        public  void ContadorAdd()
        {
            Persona.idCounter ++;
            this.id = Persona.idCounter;


        }
        protected void FunctionHere()
        {
            Console.WriteLine("Funcion heredad");
        }

        private void FunctionPrivate()
        {
            Console.WriteLine("Funcion privada");
        }

        public (string, int, bool) Tupla()
        {
            return ("String",23,true);
        }

        
    }

    class Empleado : Persona
    {
        public Empleado(): base()
        {
            Console.WriteLine("Empledo constructor");
        }
    }

}
