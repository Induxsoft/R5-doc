## Captura a granel rápida

Este programa presenta una ventana (diálogo) para introducir fácilmente cantidad y precio según los requerimientos de velocidad en la captura 
en negocios que venden frutas, verduras, semillas, chiles y productos a granel en general con un alto volumen de operaciones.

El programa puede leer automáticamente los datos de una báscula conectada al puerto serie.

### Línea de comando
```
capturaGranel.exe "MA0001" "Piña" "1" "45.5" "Kg" "Reja:25,Costal:35.5, Tara:150,Tonelada:1000" "Kg"
```
Donde los argumentos por orden son:
 1. Código del producto
 2. Descripción del producto
 3. Cantidad
 4. Precio en unidad estándar
 5. Unidad estándar
 6. Unidades alternas y sus factores de conversión respecto a la unidad estándar (opcional)
 7. Unidad que al estar seleccionada activa la entrada automática de la báscula (opcional)
 
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

Si confirma la venta de 2 Caja, la cantidad devuelta será 50 y el total $ 200

### Implementación

1. Compile el proyecto capturaGranel.sln para obtener capturaGranel.exe
2. Copie el archivo capturaGranel.exe a una ubicación en el equipo que ejecuta el POS
3. Cree un archivo .bat que ejecute a capturaGranel.exe como se muestra más adelante.
4. Modifique el script pos_usercmds.js como se muestra más adelante para habilitar un comando de usuario.

#### capturagranel.bat
Para capturar la salida de consola de aplicaciones .Net de Windows Forms se requiere un archivo de proceso por lotes en el POS de MaxiComercio R5.


``` bacth
@capturagranel.exe %1 %2 %3 %4 %5 %6 %7
```

#### pos_usercmds.js
Aquí se habilita el comando +f para desplegar la ventana de captura (capturagranel.exe)
``` javascript
function main()
{

	//Este código debe ir en el script pos_usrcmd.js
	//MainForm.AddUserCommand("Comando", "Accion", "Descripcion", "function", Negritas t/f,Color fuente);
	//Comandos definibles por el usuario: +12 ... +98
	//MainForm.AddUserCommand("+12", "Accion", "Descripcion", "mifuncion", false,0xC000);
	
	MainForm.AddUserCommand("+12", "Catálogo de documentos de flujo", "Muestra el catálogo de documentos de flujo", "pos_requisiciones.dlgbrowser",false,0xC000);
	MainForm.AddUserCommand("+13", "Configuración de envío de correo", "Permite al usuario configurar envío del corte de caja por correo", "config_email_arqueo.configLoad",false,0xC000);
	
	// ************ GRANEL *************
	MainForm.AddUserCommand("+f", "Captura de productos a granel", "Despliega la ventana de captura de productos a granel", "pos_usercmds.cmd_granel",false,0xC000);
	// *********************************

	
}

function cmd_granel()
{
	pos_usercmds.granel("");
}

function granel(cod)
{
	
	MainForm.SetProducto(cod);
	var codigo=MainForm.dxProducto.Value;
	
	if (!codigo)
		return;
	
	// Aquí puede validarse si el código de producto aplica para usar este método de captura
	// Tú código aquí
	////////////////////////////////////////////////////////////////////////////////////////
	
	
	var idxp=MainForm.BuscarProductoEnPantalla_PorCodigo(codigo);
	var cantidad_actual=0;
	var importe_actual=0;
	var descripcion="";
	var precio=0;
	var unidad="";
	
	if (idxp>0)
	{
		MainForm.SeleccionaProductoEnPantalla(idxp);
		cantidad_actual=eBasic.RoundVal(MainForm.lvwProductos.ListItems(idxp).SubItems(2),4);
		importe_actual=eBasic.RoundVal(MainForm.lvwProductos.ListItems(idxp).SubItems(5),4);
		descripcion=MainForm.lvwProductos.ListItems(idxp).SubItems(1);
		precio=eBasic.RoundVal(MainForm.lvwProductos.ListItems(idxp).SubItems(4),2);
		unidad=MainForm.lvwProductos.ListItems(idxp).SubItems(3);
	}
	else
	{
		precio=MainForm.PrecioProdActualConImpuestos;
		descripcion=MainForm.ProductoActual.Descripcion;
		unidad=MainForm.ProductoActual.Unidad;
	}
	
	
	Application.MainForm.ClearConsole();
	var command = "capturaGranel.bat "+
		"\""+codigo + "\" "+
		"\""+descripcion+"\" "+
		"\"1\" "+
		"\""+precio+"\" "+
		"\""+unidad+"\"";		
		
	Application.MainForm.ExecInConsole(command);
	
	var response = eBasic.ClearStrBorders(Application.MainForm.txtConsole.Text);

	if (response.indexOf("*CANCEL*")<0)
	{
		try
		{
			var ultMayorQue = response.lastIndexOf("*");
			response = response.substr(ultMayorQue+1, response.length-ultMayorQue);		
			var datos=response.split('|');
			
			importe_actual=importe_actual+eBasic.RoundVal(datos[1],4);
			cantidad_actual=cantidad_actual+eBasic.RoundVal(datos[2],4);
			
			if (idxp>0)
				MainForm.Execute("--");
			
			var c1=codigo+"*"+cantidad_actual; 	// Agregar el producto con su cantidad
			var c2="/"+importe_actual;			// Establecer el importe total por todas las unidades
			
			MainForm.Execute(c1);
			MainForm.Execute(c2);
		}
		catch(e)
		{
			eBasic.eMsgbox("Error");
		}
	}	
	
}
```
