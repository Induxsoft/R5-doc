## Sondeo periódico en el punto de venta de MaxiComercio R5

El sondeo periódico consiste en que el POS ejecuta código Javascript con una frecuencia configurada de tiempo, es decir un temporizador.

Esta característica resulta de gran utilidad para realizar actividades como monitorear la entrada de una báscula u otro dispositivo, despliegue de avisos, etc.

Para poner en marcha el sondeo deberá realizar las siguientes acciones:

1.	Escribir el código que se ejecutará en una función que debe llamarse 'evCustomTimer' sin argumentos:

```Javascript
function evCustomTimer()
{
  // Código que se ejecutará periódicamente
}
```

2.	Indicar al POS en el código de inicio que establezca la propiedad Interval del temporizador personalizable como en el ejemplo:

```Javascript
// Se ejecuta cada segundo (el valor de interval está expresado en milisegundos)
MainForm.customTimer.Interval=1000; 
```
Puede incluir el código en los archivos pos.js, pos_usercmd.js, pos_events.js o en alguno que configure para que se cargue en el evento evAlIniciar() (en pos.js)
