# Pokémon Battle Simulator Chatbot 🤖

Este proyecto consiste en el desarrollo de un chatbot multijugador por turnos que simula batallas de Pokémon, desarrollado como parte del segundo semestre de 2024 en el curso de programación. El chatbot permitirá a los jugadores seleccionar sus Pokémon, atacar, cambiar de Pokémon y realizar todas las acciones típicas de una batalla de Pokémon mediante mensajes, sin necesidad de una interfaz gráfica.

## Descripción

El objetivo del proyecto es crear un chatbot que permita a dos o más jugadores simular una batalla de Pokémon en una plataforma de mensajería, como WhatsApp. El juego se desarrollará por turnos, y los jugadores podrán elegir movimientos, cambiar Pokémon y recibir actualizaciones sobre el estado de la batalla.

### Características:

- Selección de 6 Pokémon de un catálogo disponible.
- Ataques por turnos con visualización de los movimientos disponibles.
- Los ataques especiales solo pueden usarse cada dos turnos.
- Visualización del HP (puntos de vida) de los Pokémon en combate.
- Sistema de efectividad de ataques según los tipos de Pokémon (fuego, agua, planta, etc.).
- Cambio de Pokémon que implica la pérdida del turno.
- La batalla termina cuando los Pokémon del oponente llegan a 0 HP.

## Requisitos Técnicos

### Lenguajes y Herramientas:

- **Lenguaje**: C#
- **Plataforma de Mensajería**: WhatsApp (mediante la API de WhatsApp)
- **Diagrama de Clases**: DrawIO
- **Repositorio de Código**: https://github.com/ucudal/pii_2024_2_equipo27.git 

### API Utilizada:

- **API de WhatsApp**: Para enviar y recibir mensajes en el bot.

## Estructura del Proyecto
- `src`: Contiene el código fuente del proyecto, con las clases de dominio como `Pokemon`, `Move`, y `Battle y proóximamente la integración con la API de WhatsApp.
- `tests`: Contiene las pruebas unitarias para verificar la lógica del juego.
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

## Notas de Reflexión

Uno de los mayores desafíos que enfrentamos fue avanzar en el proyecto cuando todas las clases dependían entre sí, pero debíamos desarrollarlas por separado. Esto nos obligó a planificar con mucho cuidado para que todo encajara al final. También tuvimos dificultades implementando algunas partes del código, como la gestión de los turnos y la lógica de los tipos de Pokémon, que fue más compleja de lo que esperábamos.

Además, tuvimos que aprender a organizarnos bien como equipo, especialmente para llegar a la fecha límite y asegurarnos de que todo estuviera alineado. Resolver conflictos en Git fue otro reto que enfrentamos durante el proceso.

Para esta entrega, fue importante pensar en todo el código sin enfocarnos todavía en la interacción con el usuario, lo que nos hizo replantear algunas decisiones y descartar algunas ideas y código iniciales. Investigamos recursos adicionales sobre C#, especialmente para implementar diccionarios, y mejorar nuestro entendimiento de ciertas especificaciones del juego y comentarios XML. Algunas historias de usuario eran bastante abiertas, lo que generó varias discusiones hasta que logramos ponernos de acuerdo en cómo implementarlas.

