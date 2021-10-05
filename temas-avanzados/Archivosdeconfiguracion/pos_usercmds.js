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
	var rcst;
	MainForm.SetProducto(cod);
	var codigo=MainForm.dxProducto.Value;
	
	if (!codigo)
		return;
	
	// Aquí puede validarse si el código de producto aplica para usar este método de captura
	// Tú código aquí
	////////////////////////////////////////////////////////////////////////////////////////
	
		sql="SELECT ifnull(p.UnidadB,'') unidadb,ifnull(p.UnidadC,'') unidadc, ifnull(p.Unidadd,'') unidadd,ifnull(p.Unidade,'') unidade, ifnull(factorb,0) factorb, ifnull(factorc,0) factorc, ifnull(factord,0) factord, ifnull(factore,0) factore FROM Producto p where p.codigo='"+codigo+"' limit 1;";
		rcst = pos_support.OpenRecordset(sql,Application.AdoCnn);
		
		var unidades_alternas="";
		
		if (rcst)
		{
			if (rcst("factorb").Value>0)
				unidades_alternas=rcst("unidadb").Value + ":" + rcst("factorb").Value;
		
			if (rcst("factorc").Value>0)
			{
				if (unidades_alternas!="")
					unidades_alternas=unidades_alternas+",";
				
				unidades_alternas=unidades_alternas+rcst("unidadc").Value + ":" + rcst("factorc").Value;
			}
			
			if (rcst("factord").Value>0)
			{
				if (unidades_alternas!="")
					unidades_alternas=unidades_alternas+",";
				
				unidades_alternas=unidades_alternas+rcst("unidadd").Value + ":" + rcst("factord").Value;
			}
			if (rcst("factore").Value>0)
			{
				if (unidades_alternas!="")
					unidades_alternas=unidades_alternas+",";
				
				unidades_alternas=unidades_alternas+rcst("unidade").Value + ":" + rcst("factore").Value;
			}
		}
		
		
	
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
	
	if (unidades_alternas=="")
			unidades_alternas=unidad+":1";
		
	Application.MainForm.ClearConsole();
	var command = "capturaGranel.bat "+
	"\""+codigo + "\" "+
		"\""+descripcion+"\" "+
		"\"1\" "+
		"\""+precio+"\" "+
		"\""+unidad+"\" "+
		"\""+unidades_alternas+"\" "+
		"\""+unidad+"\"";
		
	//Desactivar
	if (habilitar_bascula_aut) 
		MainForm.customTimer.Enabled=false; 
	
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
	
	//Activar
	if (habilitar_bascula_aut) 
		MainForm.customTimer.Enabled=true;
	
}