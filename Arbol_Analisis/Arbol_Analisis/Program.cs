using System;
namespace Arboles_Analisis
{
    class Program
    {
        static void Main(string[] args)
        {
            Nodo ejemplo1 = new Nodo("5");
            Nodo ejemplo2 = new Nodo("3");
            Nodo ejemplo3 = new Nodo("2");
            // Se crea el nodo para la suma dentro del paréntesis
            Nodo suma = new Nodo("+");
            suma.izquierda = ejemplo1;
            suma.derecha = ejemplo2;
           // Se crea la raíz para la multiplicación
            Nodo raizEjemplo = new Nodo("*");
            raizEjemplo.izquierda = suma;
            raizEjemplo.derecha = ejemplo3;
            // Se muestra la expresión y su resultado
            Console.WriteLine("(5 + 3) * 2");
            Console.WriteLine("RESULTADO: " + evaluar(raizEjemplo));
            // Operaciones ingresadas por el usuario
            Console.Write("Ingresa el primer numero: ");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ingresa el segundo numero: ");
            double num2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ingresa el tercer numero: ");
            double num3 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nOPERACION DENTRO DEL PARENTESIS");
            // Para que puedas escoger qué operación quieres hacer dentro de los paréntesis
            Console.WriteLine("1. Suma (+)");
            Console.WriteLine("2. Resta (-)");
            Console.WriteLine("3. Multiplicacion (*)");
            Console.WriteLine("4. Division (/)");
            Console.Write("Elige una opcion: ");
            int op1 = Convert.ToInt32(Console.ReadLine());
            string operacion1 = operador(op1);

            Console.WriteLine("\nOPERACION FUERA DEL PARENTESIS");
            // Operación fuera de los paréntesis
            Console.WriteLine("1. Suma (+)");
            Console.WriteLine("2. Resta (-)");
            Console.WriteLine("3. Multiplicacion (*)");
            Console.WriteLine("4. Division (/)");
            Console.Write("Elige una opcion: ");
            int op2 = Convert.ToInt32(Console.ReadLine());
            string operacion2 = operador(op2);
            // Se crean los nodos que guardarán los números
            // Hojas del árbol
            Nodo n1 = new Nodo("" + num1);
            Nodo n2 = new Nodo("" + num2);
            Nodo n3 = new Nodo("" + num3);
            Nodo interno = new Nodo(operacion1);
            // Se crea este nodo para que guarde la operación dentro del paréntesis
            interno.izquierda = n1;
            interno.derecha = n2;

            Nodo raiz = new Nodo(operacion2);
            // Se crea la raíz, que es el nodo principal del árbol
            raiz.izquierda = interno;
            // Es para que se conecte la operación interna a la izquierda y el último número se vaya a la derecha
            raiz.derecha = n3;

            Console.WriteLine("\nEXPRESION ALGEBRAICA");
            Console.WriteLine("(" + num1 + " " + operacion1 + " " + num2 + ") " + operacion2 + " " + num3);
            Console.WriteLine("\nARBOL: ");
            mostrarArbol(raiz);
            Console.WriteLine("\nRESULTADO: " + evaluar(raiz));
            Console.ReadKey();
        }
        // Método que convierte la opción en el signo correspondiente
        static string operador(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    return "+";
                case 2:
                    return "-";
                case 3:
                    return "*";
                case 4:
                    return "/";
                default:throw new ArgumentException("Opcion incorrecta");
                    // Por si el usuario ingresa una opción que no existe
            }
        }
        // Método que recorre el árbol y realiza las operaciones para mostrar el resultado
        static double evaluar(Nodo nodo)
        {
            if (nodo.izquierda == null && nodo.derecha == null)
            {
                // Comprueba si el nodo es hoja
                return Convert.ToDouble(nodo.valor);
                // Convierte el valor guardado en el nodo a número para poder realizar las operaciones
            }
double izquierda = evaluar(nodo.izquierda);
            // Se obtienen los resultados de los nodos izquierdo y derecho mediante recursividad
            double derecha = evaluar(nodo.derecha);

            switch (nodo.valor)
            {
                // Dependiendo del signo guardado en el nodo, se realiza la operación correspondiente
                case "+":
                    return izquierda + derecha;
                case "-":
                    return izquierda - derecha;
                case "*":
                    return izquierda * derecha;
                case "/":
                    if (derecha == 0)
                    {
                        // Comprueba que el divisor no sea cero
                        throw new ArithmeticException("No se puede dividir entre cero");
                    }
                    return izquierda / derecha;
            }
            return 0;
        }
        // Método para mostrar el árbol en la consola
        static void mostrarArbol(Nodo raiz)
        {
            Console.WriteLine("       " + raiz.valor);
            Console.WriteLine("      /   \\");
            Console.WriteLine("     " + raiz.izquierda.valor
                + "     " + raiz.derecha.valor);
            Console.WriteLine("    / \\");
            Console.WriteLine("   " + raiz.izquierda.izquierda.valor
                + "   " + raiz.izquierda.derecha.valor);
        }
    }

    // Clase que representa cada nodo del árbol
    class Nodo
    {
        // Valor que guarda el nodo
        public string valor;
        // Referencia al nodo izquierdo
        public Nodo izquierda;
        // Referencia al nodo derecho
        public Nodo derecha;
        // Constructor para crear un nodo con su valor
        public Nodo(string valor)
        {
            this.valor = valor;
            izquierda = null;
            derecha = null;
        }
    }
}


