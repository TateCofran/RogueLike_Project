# RogueLike_Project
 Pre entrega del proyecto final para CoderHouse

DESCRIPCION DEL JUEGO

El objetivo del juego es pasar las diferentes habitaciones con enemigos que te atacan hasta llegar a la habitacion del Jefe final de ese nivel.
Juego orientado a ser un roguelike, en el cual cada ronda será diferente a la anterior. 
La muerte no es el fin sino un medio para hacerse más fuerte: antes de empezar la partida se podrá mejorar caracteristicas del personaje, arma y vestimenta.
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


TECLAS PARA PROBAR DIFERENTES COMPORTAMIENTOS DEL PERSONAJE/JUEGO

AWSD: Movimiento del personaje en forma isométrica.
Shift: Dash en la direccion en la que te moves.
Click Izquierdo del mouse: disparos del personaje.

F: Cura al personaja una cantidad fija de vida hasta llegar al máximo.
G: Sube el nivel del personaje, para probar el funcionamiento de las cartas
Space: Quita una cantidad de vida fija al personaje hasta llegar a 0.

ESC: Menú de pausa del juego con sus diferentes opciones.
