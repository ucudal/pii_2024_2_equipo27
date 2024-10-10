namespace ClassLibrary
{
    /// <summary>
    /// La clase <c>Move</c> tiene la responsabilidad de almacenar y gestionar los valores de ataque, defensa y curación de un movimiento.
    /// Esto sigue el principio de responsabilidad única (SRP) ya que su única función es representar los atributos de un movimiento en el juego.
    /// </summary>
    public class Move
    {
        /// <summary>
        /// Nombre del movimiento. La clase <c>Move</c> tiene la responsabilidad de manejar el nombre ya que es parte esencial de la identidad del movimiento.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Valor del ataque del movimiento. Según el principio de "experto" (Expert), la clase <c>Move</c> es la responsable de conocer los valores de ataque 
        /// porque es quien posee los datos relacionados con cada movimiento.
        /// </summary>
        public int AttackValue { get; private set; }

        /// <summary>
        /// Valor de defensa del movimiento. De nuevo, siguiendo el principio de "experto" (Expert), la clase <c>Move</c> conoce los valores de defensa 
        /// y tiene la responsabilidad de mantener estos valores encapsulados.
        /// </summary>
        public int DefenseValue { get; private set; }

        /// <summary>
        /// Valor de curación del movimiento. La clase <c>Move</c> sigue el principio de SRP al tener la responsabilidad de almacenar 
        /// solo los datos relacionados con el movimiento, dejando las acciones más complejas (como aplicar estos valores) a otras clases.
        /// </summary>
        public int CureValue { get; private set; }

        /// <summary>
        /// Constructor de la clase <c>Move</c>. Inicializa los valores de nombre, ataque, defensa y curación.
        /// Esto sigue el principio de Liskov Substitution Principle (LSP) porque permite que cualquier clase derivada de <c>Move</c> (si la hubiera) 
        /// pueda sustituirse sin alterar el comportamiento de la lógica del juego.
        /// </summary>
        /// <param name="name">El nombre del movimiento.</param>
        /// <param name="attackValue">El valor de ataque del movimiento.</param>
        /// <param name="defenseValue">El valor de defensa del movimiento.</param>
        /// <param name="cureValue">El valor de curación del movimiento.</param>
        public Move(string name, int attackValue, int defenseValue, int cureValue)
        {
            this.Name = name;
            this.AttackValue = attackValue;
            this.DefenseValue = defenseValue;
            this.CureValue = cureValue;
        }
    }
} 