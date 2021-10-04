## Captura a granel rápida

Este programa presenta una ventana (diálogo) para introducir fácilmente cantidad y precio según los requerimientos de velocidad en la captura 
en negocios que venden frutas, verduras, semillas, chiles y productos a granel en general con un alto volumen de operaciones.

El programa puede leer automáticamente los datos de una báscula conectada al puerto serie.

### Línea de comando
```
capturaGranel.exe "MA0001" "Piña" "1" "45.5" "Kg" "Reja:25,Costal:35.5, Tara:150,Tonelada:1000" "Kg"
```
Donde los argumentos por orden son:
 1- Código del producto
 2- Descripción del producto
 3- Cantidad
 4- Unidad estándar
 5- Unidades alternas y sus factores de conversión respecto a la unidad estándar (opcional)
 6- Unidad que al estar seleccionada activa la entrada automática de la báscula (opcional)
 
#### Nota sobre la especificación de unidades alternas
 
Observe que la notación es: ```Unidad_alterna:Factor_conversión, ...```

El caracter dos puntos (:) sirve como delimitador entre la unidad y su factor, mientras que el caracter coma (,) delimita los pares unidad-factor 

### Uso de teclado

Se ha habilitado el uso de las teclas (flecha) arriba y abajo para desplazarse entre los campos unidad, cantidad, precio y total.

El campo unidad, que es un ComboBox puede desplegarse y contraerse con F4 (no admite las flechas arriba y abajo porque son para elegir de la lista).

En todos los campos, al presionar ENTER se avanza al siguiente.

ESC cierra la ventana.

### Salida de consola

Si la operación se cancela, se imprime en la consola: ```**CANCEL***```
Si la operación se confirma, la salida es: ```***codigo|total|cantidad```

- codigo Es el código del producto
- total es el importe total a cobrar por la cantidad de unidades (estándar) vendidas 
- cantidad es la cantidad expresada en la unidad estándar (no importa si se eligió otra unidad, la cantidad será convertida a lo correspondiente)

Suponga que la unidad estándar es Kg y tiene una unidad alterna Caja con un factor de 25, es decir 25Kg=1Caja con un precio por caja de $100. 

Si confirma la venta de 2 Caja, la cantidad devuelta será 50 y el importe $ 200


