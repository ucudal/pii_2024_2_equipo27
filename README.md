# Pokemon Battle Chatbot 🤖

Este proyecto consiste en el desarrollo de un chatbot multijugador por turnos que simula batallas de Pokémon, desarrollado como parte del segundo semestre de 2024 en el curso de programación. El chatbot permitirá a los jugadores seleccionar sus Pokémon, atacar, cambiar de Pokémon y realizar todas las acciones típicas de una batalla de Pokémon mediante mensajes, sin necesidad de una interfaz gráfica.

## Descripción

El objetivo del proyecto es crear un chatbot que permita a dos o más jugadores simular una batalla de Pokémon en una plataforma de mensajería, como Discord. El juego se desarrollará por turnos, y los jugadores podrán elegir movimientos, cambiar Pokémon y recibir actualizaciones sobre el estado de la batalla.

### Características:

- Selección de 6 Pokémon de un catálogo disponible.
- Ataques por turnos con visualización de los movimientos disponibles.
- Los ataques especiales solo pueden usarse cada dos turnos.
- Visualización del HP (puntos de vida) de los Pokémon en combate.
- Sistema de efectividad de ataques según los tipos de Pokémon (fuego, agua, planta, etc.).
- Cambio de Pokémon que implica la pérdida del turno.
- La batalla termina cuando los Pokémon de un jugador llegan a 0 HP.

## Requisitos Técnicos

### Lenguajes y Herramientas:

- **Lenguaje**: C#
- **Plataforma de Mensajería**: Discord (mediante la API de Discord)
- **Diagrama de Clases**: DrawIO
- **Repositorio de Código**: https://github.com/ucudal/pii_2024_2_equipo27.git 

### API Utilizada:

- **API de Discord**: Para enviar y recibir mensajes en el bot.

## Estructura del Proyecto
- `src`: Contiene el código fuente del proyecto, con las clases de dominio como `Pokemon`, `Move`, y `Turn` y las clases de comando que permiten la integración con la API de WhatsApp.
- `tests`: Contiene las pruebas unitarias para verificar la lógica del juego y cada historia de usuario por separado.
- `docs`: Contiene documentación del proyecto, como el diagrama de clases y Doxify.

## Roadmap del Proyecto

1. **Kick-off** (2 al 4 de septiembre): Inicio del proyecto y creación del repositorio.
2. **Primera entrega** (11 de octubre): Entrega de tarjetas CRC, diagrama de clases, y código inicial de las clases de dominio.
3. **Segunda entrega** (8 de noviembre): Implementación de las historias de usuario principales y pruebas.
4. **Entrega final** (26 de noviembre): Bot funcionando completamente con su documentación.
5. **Defensa del proyecto** (27 al 29 de noviembre): Presentación final y defensa del proyecto ante el tribunal.

## Historias de Usuario

1. Como jugador, quiero elegir 6 Pokémons del catálogo disponible para comenzar la batalla.
2. Como jugador, quiero ver los ataques disponibles de mis Pokémons para poder elegir cuál usar en cada turno.
3. Como jugador, quiero ver la cantidad de vida (HP) de mis Pokémons y de los Pokémons oponentes para saber cuánta salud tienen.
4. Como jugador, quiero atacar en mi turno y hacer daño basado en la efectividad de los tipos de Pokémon.
5. Como jugador, quiero saber de quién es el turno para estar seguro de cuándo atacar o esperar.
6. Como jugador, quiero ganar la batalla cuando la vida de todos los Pokémons oponente llegue a cero.
7. Como jugador, quiero poder cambiar de Pokémon durante una batalla.
8. Como jugador, quiero poder usar un ítem durante una batalla.
9. Como jugador, quiero unirme a la lista de jugadores esperando por un oponente.
10. Como jugador, quiero ver la lista de jugadores esperando por un oponente.
11. Como jugador, quiero iniciar una ballata con un jugador que está esperando por un oponente.

## Instrucciones del Juego y Comandos
- !help: Muestra los comandos disponibles y las instrucciones de juego.
- !rules: Muestra las reglas del juego.
- Cada jugador debe unirse a la lista de espera con !join, para salir de la misma se usa !leave.
- Usa !waiting para ver los jugadores que están esperando
- Usa !battle {username} para comenzar una batalla (el username es opcional).
- Antes de la batalla, usa !catalog para ver los Pokémon disponibles.
- Selecciona seis Pokémon con !choose {pokemon1 pokemon2 pokemon3 pokemon4 pokemon5 pokemon6}. Asegúrate de separar los Pokémon con espacios.
- El juego elige aleatoriamente quién comienza.
- Se pueden ver los movimientos disponibles de tu Pokémon activo con !moves.
- Se pueden ver los items disponibles y su cantidad con !items
- Se enfrentan los primeros Pokémon vivos de cada jugador.
- Usa !turn para verificar de quién es el turno.
- En tu turno, puedes realizar una de las siguientes acciones:
  - Usar un ataque con !attack {move} seleccionando un movimiento que tenga tu pokémon.
  - Cambiar de Pokémon con !change {pokemon}
  - Usar un ítem con !useitem {item}.
- Usa !hp para consultar los HP de tus Pokémon y los del oponente.
- La batalla termina cuando todos los Pokémon de un jugador llegan a 0 HP.


## Cómo Funciona el Ataque 
- Usa !attack {move} para atacar con el movimiento seleccionado del Pokémon activo.
- Los ataques tienen diferentes niveles de efectividad según los tipos de Pokémon (fuego, agua, planta, etc.).
- Los ataques especiales pueden usarse cada dos turnos y tienen efectos adicionales:
   - Sleep: El Pokémon queda inactivo entre 1 y 4 turnos, sin poder atacar.
   - Paralize: El Pokémon tiene una probabilidad de fallar su turno de manera aleatoria.
   - Poison: El Pokémon pierde el 5% de su HP cada turno.
   - Burn: El Pokémon pierde el 10% de su HP cada turno.
- Que se produzca un ataque o no depende de su valor de precisión y es aleatorio.
- El daño infligido por los ataques depende de si es un golpe crítico
- Un golpe crítico aumenta el daño en un 20% y tiene una probabilidad del 10%.
- Si un pokemon alcanza 0 HP, el pokemon actual de un jugador pasa al siguiente Pokémon en la lista.

## Cómo Funcionan los Ítems 
- Usa !useitem {item} para aplicar un efecto durante tu turno.
- Los ítems pueden:
  - Revive: Revive a un Pokémon con el 50% de su HP total. (Cada jugador tiene 1)
  - FullHeal: Elimina efectos de estados especiales como parálisis, dormir, envenenamiento o quemaduras.(Cada jugador tiene 2)
  - SuperPotion: Restaura 70 puntos de HP. (Cada jugador tiene 4)
- Usar un ítem consume tu turno actual.

## Notas de Reflexión

Uno de los mayores desafíos que enfrentamos fue avanzar en el proyecto cuando todas las clases dependían entre sí, pero debíamos desarrollarlas por separado. Esto nos obligó a planificar con mucho cuidado para que todo encajara al final. También tuvimos dificultades implementando algunas partes del código, como la gestión de los turnos y la lógica de los tipos de Pokémon, que fue más compleja de lo que esperábamos. Además, tuvimos que aprender a organizarnos bien como equipo, especialmente para llegar a la fecha límite y asegurarnos de que todo estuviera alineado. Resolver conflictos en Git fue otro reto que enfrentamos durante el proceso.

Para esta entrega, fue importante pensar en todo el código sin enfocarnos todavía en la interacción con el usuario y la forma de mostrar los datos, lo que nos hizo replantear algunas decisiones y descartar algunas ideas y código iniciales. Investigamos recursos adicionales sobre C#, especialmente para implementar diccionarios, y mejorar nuestro entendimiento de ciertas especificaciones del juego y comentarios XML. Algunas historias de usuario eran bastante abiertas, lo que generó varias discusiones hasta que logramos ponernos de acuerdo en cómo implementarlas.

Además de los desafíos iniciales, como la dependencia entre clases y la necesidad de desarrollarlas por separado, también enfrentamos dificultades técnicas específicas. La implementación de la lógica de tipos de Pokémon y su efectividad fue un punto crítico, ya que implicó manejar múltiples casos especiales y excepciones. Esto nos llevó a investigar y utilizar estructuras más eficientes, como diccionarios, para simplificar la lógica y hacerla más clara.

El uso de principios como SRP (Single Responsibility Principle) fue fundamental para resolver estos retos. Diseñar clases independientes y modulares nos permitió asignar responsabilidades de manera efectiva, asegurando que cada clase cumpliera un propósito claro y único. Esto también facilitó el mantenimiento del código y redujo las dependencias innecesarias entre componentes.

Trabajar con estos principios nos ayudó a estructurar el proyecto de forma escalable. Por ejemplo, asignar la responsabilidad de la efectividad de los ataques a la clase `Pokemon` respetó el principio de Expert, ya que esta clase tenía toda la información necesaria para cumplir esa tarea. Este enfoque iterativo nos permitió refactorizar y priorizar funcionalidades clave mientras manteníamos la cohesión en el diseño.

Al final, logramos desarrollar un sistema coherente que respetaba estos principios, asegurando la calidad y funcionalidad del producto.



