namespace arboles_analisis
{
    public class Nodo
    {
        // Valor que almacena el nodo
        public string valor;

        // Referencias a otros nodos
        public Nodo izquierda;
        public Nodo derecha;

        // Constructor del nodo
        public Nodo(string valor)
        {
            this.valor = valor;
            this.izquierda = null;
            this.derecha = null;
        }
    }
}
