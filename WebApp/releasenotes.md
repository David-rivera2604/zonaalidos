# Release Notes - Aliados

## Versión 1.6.167 - 29/01/2026

### Aliados - Trazabilidad: Mejoras varias en la trazabilidad de la aplicación.	

#### Funcionalidades implementadas:

- ✅ Descarga masiva de documentos desde la pestaña de adjuntos.
- ✅ Eliminar carga de un solo documento de la pestaña de adjuntos.
- ✅ Carga de documentos con arrastre hacia la ventana de la plataforma.
- ✅ Se requiere una alerta o una señal para identificar los nuevos casos cargados o movimientos recientes en la plataforma cada vez que cambie de etapa. Se habilita el agente como persona de contacto del caso de esta forma se pueden configurar las notificaciones.
- ✅ Revisión de 84 procesos para determinar fallas de diseño, solo se encontraron 2 errores y 2 casos para mejora.
- ✅ Apertura de rol para corredurías. Para cualquier tenant diferente al de mapfre se pasa los roles del usuario conectado de forma que la lista de procesos permitido se filtre usando lo roles del usuario, el nombre del rol debe exitir en el tenant mapfre para pode filtrarlo.
- ✅ Ocultar la visualización de casos finalizados posterior a los 30 días para ver solo los pendientes o más recientes para Rol de Purdy /Agentes / Intermediarios, pero dejar en los reportes.
- ✅ Colocar botón opcional en notas que permita decidir si el sistema debe enviar notificación al dejar mensajes nuevos al contacto que apertura el caso.
- ✅ Habilitar para Rol de agentes y Rol de Purdy en la pestaña de seguimiento la vista de los comentarios colocados en seguimiento de etapas, fechas de la gestión y realizado por. Vista desde tenant aliados y purdy.
- ✅ Abrir casilla para que los casos seleccionados con prioridad "reprocesos" se deba colocar de forma obligatoria el número de caso anterior. Se agrega la capacidad de poder hacer visible o no los campos de referencia con lo cual se puede agregar un par de campos y manejarlo por visibilidad.

- #### Dependencias:

1. 20251215a.process.alter.sql
2. 20260106a.lookupmaster.69.sql
3. 20260107a.process.alter.sql
4. 20260112a.process.insight.sql

---

## Versión 1.6.166 - 14/01/2026

### Aliados - Monge: Incidentes Reportados Noviembre - Diciembre.

#### Funcionalidades implementadas:

- ✅ Se ajusta la creación de registros en las tablas AuthenticationTrace y ChangeSet por medio de sequence propios de Oracle.
- ✅ Se habilita validaciones para las cotizaciones de viajero.
- ✅ Se agrega manejo de dos reintentos en caso de existir algun error en la emisión con una pausa de 0.5 segundos entre intento.

- #### Dependencias:

1. 260112a.AuthenticationTrace.ChangeSet.alter.sql
---
## Versión 1.6.165 - 30/12/2025

### Aliados - SICOP : Se habilita traza en el llamado a los servicios de SICOP.

#### Funcionalidades implementadas:

- ✅ Se habilita traza por medio de la tabla TRACKREQUEST en el llamado a los servicios de SICOP.

---
## Versión 1.6.164 - 17/12/2025

### Aliados - Security : Optimización del Control de Inactividad de Usuarios.

#### Funcionalidades implementadas:

- ✅ El sistema detecta la inactividad del usuario y envía una notificación emergente como aviso preventivo.
- ✅ Si la inactividad persiste, el sistema cierra automáticamente la sesión para reforzar el control y la seguridad.
- ✅ Cuando el usuario muestra actividad después de recibir la advertencia, el sistema extiende automáticamente la sesión sin intervención manual.

#### Nuevos Settings

Implementación de nuevos parámetros de configuración (tabla `settings`) para el control de inactividad de usuarios y la mejora de la usabilidad del sistema:

| Setting | Default | Descripción |
|---------|---------|-------------|
| `Session.WarningTime` | 9 | Minutos antes de expirar la sesión en los que se muestra la notificación emergente de advertencia al usuario. Si la sesión total es de 30 minutos y este valor es 2, el aviso aparecerá a los 28 minutos de inactividad. |
| `Session.InactiveTime` | 10 | Minutos que se extiende automáticamente la sesión cuando el usuario muestra actividad (movimiento del mouse, clic, scroll, etc.) después de haber recibido la advertencia de inactividad. Esto permite que usuarios activos no tengan que hacer clic manualmente en la notificación de advertencia. |

#### Flujo de funcionamiento:

1. **Usuario inactivo**: El sistema comienza a contar el tiempo de inactividad
2. **Advertencia**: A los (ExpiresIn - WarningTime) minutos, se muestra la notificación emergente
3. **Reactivación automática**: Si el usuario mueve el mouse o interactúa con el sistema, la sesión se extiende automáticamente por InactiveTime minutos
4. **Expiración**: Si no hay actividad, la sesión expira y redirige al login

#### Dependencias:

1. 251218a.settings.new.sql
---

## Versión 1.6.163 - 07/12/2025

### Aliados - SUGESE: Se migra desde medical la funcionalidad de creación de archivo xml para la SUEGSE.

#### Funcionalidades implementadas:

- ✅ Se crear nueva vista sugese/generador la cual se encarga de procesar archivos excel y convertilos  en el formato de monitoreo XML de la SUGESE.
- ✅ Se crear nueva vista sugese/envio la cual realiza el envio del XML al servicio de la SUGESE.

Nuevos settings (tabla `settings`) para controlar la autenticación 2FA:

| Setting | Default | Descripción |
|---------|-------------|-------------|
| `app.path` | C:\Aliados\WebApp | Ruta fisica de la aplicación |
| `sugese.codigoaseguradora` | A03 | Código de la entidad aseguradora |
| `sugese.entidadaseguradora` | Mapfre Seguros Costa Rica S.A. | nombre de la entidad aseguradora |

---
## Versión 1.6.162 - 07/12/2025

### Aliados - Seguridad: Cambios para poder usar el cookie en el request de apis, desde la aplicación la aplicacion web.

#### Funcionalidades implementadas:

- ✅ Se hacen cambios necesario para no necesitar almacenar el token en el localstore del browser.

---
## Versión 1.6.161 - 04/12/2025

### Aliados - Seguridad: 2FA, manejo de claves de acceso

#### Funcionalidades implementadas:

- ✅ Se habilita el manejo de cuentas de servicio en modo 2FA. Las cuentas de servicio solo pueden ser usadas en el API.
- ✅ Se cambia el mantenimiento de usuario para habilitar la configuración de cuentas de servicio.
- ✅ La clave de acceso no se almacena; en su lugar se obtiene un hash, lo cual es la forma correcta de manejarlas.
- ✅ Se hacen mejoras en el manejo de autenticación en modo 2FA.

#### Nuevos Settings

Nuevos settings (tabla `settings`) para controlar la autenticación 2FA:

| Setting | Descripción |
|---------|-------------|
| `Security.2FA.Mode` | Modo de uso de 2FA. none=deshabilitado, full=habilitado, user=según nuevo indicador de los usuarios |
| `Security.2FA.Enable` | Debe ser eliminado ya que no se utiliza |

---
## Versión 1.6.160 - 03/12/2025

### Aliados - Viajero: Envío de facturas electrónicas

#### Funcionalidades implementadas:

- ✅ Se envía una factura electrónica cuando se hace la emisión y el usuario tiene entre sus roles el rol 'Scotiabank'
- ✅ En la tabla `changeset` con `entitytype = 3000` se agrega traza del envío de la factura electrónica
- ✅ En la tabla `changeset` con `entitytype = 3000` se agrega traza si hubo falla al momento de la emisión

#### Nuevos Settings

Nuevos settings (tabla `settings`) para controlar el envío de la factura electrónica:

| Setting | Descripción |
|---------|-------------|
| `Integration.GTI.ApiCargaFactura.BaseURL` | URL base del servicio de GTI para el envío de facturas electrónicas |
| `Integration.GTI.ApiCargaFactura.NumCuenta` | Número de cuenta para el servicio de GTI |
| `Integration.GTI.ApiCargaFactura.Usuario` | Usuario para el servicio de GTI |
| `Integration.GTI.ApiCargaFactura.Clave` | Clave para el servicio de GTI |

---

