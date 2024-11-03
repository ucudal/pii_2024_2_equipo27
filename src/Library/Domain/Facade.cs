// namespace Ucu.Poo.DiscordBot.Domain;
//
// /// <summary>
// /// Esta clase recibe las acciones y devuelve los resultados que permiten
// /// implementar las historias de usuario. Otras clases que implementan el bot
// /// usan esta <see cref="Facade"/> pero no conocen el resto de las clases del
// /// dominio. Esta clase es un singleton.
// /// </summary>
// public class Facade
// {
//     private static Facade? _instance;
//
//     // Este constructor privado impide que otras clases puedan crear instancias
//     // de esta.
//     private Facade()
//     {
//         this.WaitingList = new WaitingList();
//         this.BattlesList = new BattlesList();
//     }
//
//     /// <summary>
//     /// Obtiene la única instancia de la clase <see cref="Facade"/>.
//     /// </summary>
//     public static Facade Instance
//     {
//         get
//         {
//             if (_instance == null)
//             {
//                 _instance = new Facade();
//             }
//
//             return _instance;
//         }
//     }
//
//     /// <summary>
//     /// Inicializa este singleton. Es necesario solo en los tests.
//     /// </summary>
//     public static void Reset()
//     {
//         _instance = null;
//     }
//     /// <summary>
//     /// ////////////////////de aca para arriba ? ////////////////////////////////////////////////////////
//     /// </summary>
//     
// }
