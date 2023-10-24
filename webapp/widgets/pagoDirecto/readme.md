# Proceso de Instalación del widget de pasarela de pagos
A continuación, te proporciono un detallado manual de instalación para el Widget en tu aplicación. Sigue estos pasos para una correcta implementación:
Recibirás un archivo comprimido (zip) que contiene los archivos necesarios para el Chat Widget. Asegúrate de descomprimirlo y obtener los siguientes archivos:
1. index.html
2. widget-pago-directo-element.js
3. widget-pago-directo.css
4. Una carpeta llamada assets

Abre el archivo "index.html" y revisa su contenido. Debería tener una estructura similar a la siguiente:

```html
<!doctype html>
<html lang="en">

<head>
  <meta charset="utf-8">
  <title>WidgetPagoDirecto</title>
  <base href="/">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="icon" type="image/x-icon" href="favicon.ico">
  <link rel="stylesheet" href="styles.css">
</head>

<body>

  <button id="button"> abrir modal</button>
  <widget-pagos style="width: 410px;
  max-height: 50%;
  position: fixed;
  left: 20%;
  top: 20%;
  right: auto;"></widget-pagos>

  <script>
    const button = document.querySelector("button")
    const widgetPagos = document.querySelector("widget-pagos")
    widgetPagos.setAttribute("login", "")
    const recibo = JSON.stringify({
      documentoCliente: "",            //requerido
      total: "",                           //requerido
      nombreCliente: "",
      emailCliente: "",
      telefonoCliente: "",
      subtotal: "",
      impuestos: "",
      concepto: "",
      urlWebhook: "",
      countryCode: "",
      contratoFrontal: false,
      items: []
    })

    button.addEventListener("click", () => {
      widgetPagos.setAttribute('show-modal', recibo)
    })
  </script>
</body>

</html>


```


1. En el archivo "index.html", encontrarás partes importantes:
    1.  La etiqueta `<widget-pagos></widget-pagos>`, que representa el Widget en sí.
    2.	Al final del archivo, encontrarás una etiquetas `<script>` que se encargan de la funcionalidad del Widget.
    3. en la etiqueta header encontrarás una etiqueta `<link>` que se encarga de los estilos del widget
2. Dependiendo del tipo de pagina puedes realizar la instalación de dos formas
    1.	Si estás utilizando una aplicación de página única ("single page application"), simplemente pon las etiquetas en el archivo html dónde deseas utilizar el widget.
    2.	Si estás utilizando una aplicación de varias páginas ("multiple page application") coloca la etiqueta `<widget-pagos></widget-pagos>` en la ubicación deseada de cada página junto con los scripts y estilos.


## Aclaracion
como se ve en el ejemplo del "index.html" el widget tiene unos estilos en linea, esto es por que dependiendo de las necesidades de visualización, se puede modificar este contenedor para poder ajustar los estilos a los requeridos. 

¡Eso es todo! Siguiendo estos pasos, podrás instalar el Widget en tu aplicación de manera adecuada. Si tienes alguna pregunta o enfrentas algún problema durante la instalación, no dudes en contactarnos para brindarte asistencia.
¡Gracias y que tengas un gran día!
Atentamente, Equipo técnico de Silice.

# Inputs

## login()
Evento de entrada, se encarga de hacer el login de la aplicación. Para poder hacer login el dominio desde el cual se lanza la petición debe estar configurado en dsp.

## showModal() 
Se encarga de abrir el widget, ese necesario primero hacer login antes de abrir el modal,

### parametros de entrada : 
```javascript

{
  total: string,              // Valor total de la transacción (obligatorio)
  documentoCliente: string,   // DNI del cliente  (obligatorio)
  nombreCliente?: string,     // Nombre del cliente
  emailCliente?: string,      // Correo electrónico del cliente
  telefonoCliente?: string,   // Teléfono del cliente
  subtotal?: string,          // Subtotal del recibo
  impuestos?: string,         // Impuestos del recibo
  concepto?: string,          // Concepto de venta
  urlWebhook?: string,        // url De Webhook
  countryCode?: string,       // Código de llamadas del país
  items?: Array<item>,        // arreglo con productos comprados
  dataExtra?: object          // Información adicinal a enviar
}

interface item {       
  cantidad: number,  // numero de items comprados
  producto: string,  // nombre del producto comprado
  precio: number,    // precio del producto comprado
  moneda: string     // moneda en la que fue comprado el producto
      
}

```



# Outputs

## loginComplete()
Este evento avisa cuando el login se completó, el parametro detail dentro de la respuesta define si el login fue exitoso o fallido con un booleano, si el login no es exitoso el widget no se mostrará.
