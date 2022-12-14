# RogueLike_Project
 Pre entrega del proyecto final para CoderHouse

Dejo un link de google drive con el Unity Package por separado del github

[Unity Package](https://drive.google.com/drive/folders/1aQILSAPhrYFZvgouzeOo0fLmLMCyv8uu)

DESCRIPCION DEL JUEGO

El objetivo del juego es pasar las diferentes habitaciones con enemigos que te atacan hasta llegar a la habitacion del Jefe final de ese nivel.
Juego orientado a ser un roguelike, en el cual cada ronda será diferente a la anterior. 
La muerte no es el fin sino un medio para hacerse más fuerte: antes de empezar la partida se podrá mejorar las caracteristicas del personaje, arma y vestimenta.
Simple de jugar, dificil de masterizar: Mecánicas simples y fluidas que priorizan un ritmo continuo para el jugador 

JUGABILIDAD

Movimiento fluido con las teclas AWSD, junto con un dash en la tecla Shift en el cual se recarga con el tiempo.
El personaje ataca a los enemigos con un arma con el click izquierdo del mouse.
Cámara isométrica centrada en el personaje

Enemigos que atacan al personaje dependiendo de su clase: Melee enemies, color azul, los cuales te persiguen y te hacen daño si colisionas con ellos; Ranged enemies, color verde, los cuales se acercan al jugador hasta una cierta distancia de tiro y dispara. Cada uno con su respectiva barra de vida.

IMPLEMENTACIONES

Simple de subida de nivel al matar una determinada cantidad de enemigos, en la cual aparecen cartas con modificaciones de diferentes tipos: Mejora en el arma, dash o estadisticas a elegir por el personaje.

Aleatoriedad de aparición de los enemigos cada vez que se inicia el juego.
Simple de interfaz con el tiempo de juego, contador de enemigos; vida, experiencia, energia y nivel del personaje.
Se muestra tanto la vida del enemigo como el daño hecho a ese enemigo.
A su vez si se apreta la tecla ESC, se pausa el juego con la opción de continuar, volver al menú o salir del juego. 
Si la vida del personaje llega a 0, aparecerá un menú de game over en el cual te dejará reiniciar el juego, volver al menú o salir del juego.

Simple pantalla de inicio de juego.
Música de fondo mientras se juega, sacada del juego Hotline Miami, Hydrogen.(En caso de que no se escuche la música puede ser que esté muteado el audio de juego)
Luces propias del escenario

Si el enemigo es tapado por el escenario, se mostrará un sombreado que marca al enemigo.

TECLAS PARA PROBAR DIFERENTES COMPORTAMIENTOS DEL PERSONAJE/JUEGO

AWSD: Movimiento del personaje en forma isométrica.
Shift: Dash en la direccion en la que te moves.
Click Izquierdo del mouse: disparos del personaje.

F: Cura al personaja una cantidad fija de vida hasta llegar al máximo.
G: Sube el nivel del personaje, para probar el funcionamiento de las cartas
Space: Quita una cantidad de vida fija al personaje hasta llegar a 0.

ESC: Menú de pausa del juego con sus diferentes opciones.

OBSERVACIONES CON RESPECTO A LO PEDIDO EN LA ENTREGA

No quise implementar animaciones ni modelos a los enemigos y al personaje, porque no quiero caer en la fácil de hacer zombies. La temática de los enemigos está en duda, lo más probable es que sean enemigos medievales.

Temporizadores hay en la mayoría del juego como puede ser el cooldown de los disparos de los enemigos, otro también es el cooldown del dash del personaje, entre otros más.

Utilización de cálculos vectoriales como puede ser el recorrido que hacen los enemigos para atacar al personaje y la rotación de los mismos; junto con el movimiento y rotación del personaje.

No vi necesaria la implementación de un caso SWITCH por el momento.

Las colisiones dentro del juego son: las paredes, los disparos del jugador como de los enemigos, y la colisión que hacen los melee enemies al chocar con el personaje.

IMPLEMENTACIONES NUEVAS

7/11
-Añadido un level manager para facilitar la vista del nivel y de los enemigos que hay en la sala.
-Añadí mensajes de finalizacion de la sala junto con triggers de cambio de sala. 

21/11
-Añadido modelado del personaje, animaciones al personaje y orientación del personaje.
-Combos con el arma a melee.
-Sistema de magia.
-Añadido aumento de estadísticas al subir de nivel.

27/11
-Añadido animación de knockback a los enemigos.
-Correcta implementación de subida de nivel con cartas.

12/12
-Implementación de modelado para enemigos
-Añadido animaciones para el jugador como para todos los enemigos.
-Añadido Boss al final del nivel

ERRORES ENCONTRADOS 

-Al momento de aparecer las cartas cuando se sube de nivel aparece, el menú de pausa. Despues funciona correctamente.(Arreglado 5/11)
-Melee enemies no hacen daño al colisionar con el personaje.(Arreglado-21/11)
-Al reiniciar el juego, no lo reinicia correctamente si no que hay que instanciar el menú y apretar el continuar, y ahí funciona correctamente.(Arreglado    14-12)
-Cuidado con el nivel del audio de la música puede que esté un poco fuerte.
-Errores a la hora de atacar en las animaciones del personaje.
-Al aparecer la interfaz de Game Over, se puede apretar el menú de pausa(Arreglado 27/11).
-Error de los enemigos al moverse al jugador.(Arreglado 14/12)
-Errores de interfaz del personaje en la experiencia y el maná.
-Error en las animaciones de personajes y enemigos.
-Error al subir varias veces de nivel con las cartas.
-Bug al atacar con magia que el personaje se queda quieto y no te podes mover.
