# Release Notes - Aliados

## Versión 1.6.172 - 10/02/2026

### Aliados - Pasarela: Tokenización de tarjeta duplicadas.	

#### Funcionalidades implementadas:

- Cuando se hage el pago on line con suscripción se crear una nueva tokenizacion pero queda activa la tokenizacion anterior.

---

## Versión 1.6.171 - 09/02/2026

### Aliados - Trazabilidad: Reporte de Casos creados por Purdy.	

#### Funcionalidades implementadas:

- Reporte de casoso descargable para Rol agente / Purdy / Corredurías que contenga los siguientes campos: #caso / fecha ingreso  / asunto / Estado - Urgente / Usuario de creación (contacto).

#### Dependencias:

1. 20260209a.visualizations.422.sql

---

## Versión 1.6.170 - 09/02/2026

### Aliados - Trazabilidad: Validación de casos duplicado.	

#### Funcionalidades implementadas:

- Alerta de posible caso duplicado por asunto/datos obligatorios. Se varifica el proceso, asunto y referencias requeridas.

---

## Versión 1.6.169 - 03/02/2026

### Aliados - Bump NuGet packages and disable auth DB write.

#### Funcionalidades implementadas:

- Bulk upgrade of NuGet packages across multiple projects: updated Microsoft.IdentityModel packages (to 8.15.0), System.Text.Json (to 8.0.5), Newtonsoft.Json (to 13.0.4) and many System.* packages, plus Microsoft.Bcl.AsyncInterfaces (to 9.0.10) and added Microsoft.Bcl.TimeProvider, Microsoft.Extensions.Logging.Abstractions and System.Diagnostics.DiagnosticSource. Corresponding csproj HintPath changes and bindingRedirect updates in app.configs were applied. A new update-nuget-packages.ps1 script was added. Also commented out the DataAccess.Security.AuthenticationTrace.Create call in AuthenticationTrace.cs to disable persisting the authentication trace Id (likely temporary for testing). After this change run NuGet restore and full test pass to verify no runtime or binding issues.

---

## Versión 1.6.168 - 01/02/2026

### Aliados - Procesos: Refactorización y Migración a Proyecto Independiente.

#### Funcionalidades implementadas:

- Se migra toda la funcionalidad de procesos desde el módulo Core hacia un nuevo proyecto independiente Process.
- Se crea nueva estructura de proyectos para el manejo de procesos:
  - Architect.API.Process.Business - Lógica de negocio
  - Architect.API.Process.Contracts - Contratos y DTOs
  - Architect.API.Process.DataAccess - Acceso a datos
  - Architect.API.Process.WebApi - API Web independiente
- Se eliminan del módulo Core todas las clases y controladores relacionados con procesos para mejorar la separación de responsabilidades.
- Se actualiza la solución principal para incluir los nuevos proyectos de Process.
- Se ajustan las referencias y dependencias entre proyectos para mantener la funcionalidad existente.

#### Archivos migrados:

- **Controladores migrados**: ProcessCaseController, ProcessController, ProcessSpecFlowController, ProcessSpecLinkController, ProcessSpecSLAController, ProcessSpecStepController, ProcessSpecTaskController
- **Clases de acceso a datos migradas**: ProcessCase, ProcessHelpers, ProcessInstance, ProcessSpecFlow, ProcessSpecFlowRole, ProcessSpecLink, ProcessSpecSLALevel, ProcessSpecStep, ProcessSpecStepRole, ProcessSpecTask
- **Contratos migrados**: Todos los contratos relacionados con procesos del módulo Core.Contracts

#### Beneficios de la refactorización:

1. **Separación de responsabilidades**: Los procesos ahora tienen su propio dominio independiente
2. **Escalabilidad**: Facilita el mantenimiento y evolución independiente del módulo de procesos
3. **Arquitectura modular**: Mejora la organización del código y reduce el acoplamiento
4. **Despliegue independiente**: Permite desplegar cambios en procesos sin afectar el Core

---

## Versión 1.6.167 - 29/01/2026

### Aliados - Trazabilidad: Mejoras varias en la trazabilidad de la aplicación.	

#### Funcionalidades implementadas:

- Descarga masiva de documentos desde la pestaña de adjuntos.
- Eliminar carga de un solo documento de la pestaña de adjuntos.
- Carga de documentos con arrastre hacia la ventana de la plataforma.
- Se requiere una alerta o una señal para identificar los nuevos casos cargados o movimientos recientes en la plataforma cada vez que cambie de etapa. Se habilita el agente como persona de contacto del caso de esta forma se pueden configurar las notificaciones.
- Revisión de 84 procesos para determinar fallas de diseño, solo se encontraron 2 errores y 2 casos para mejora.
- Apertura de rol para corredurías. Para cualquier tenant diferente al de mapfre se pasa los roles del usuario conectado de forma que la lista de procesos permitido se filtre usando lo roles del usuario, el nombre del rol debe exitir en el tenant mapfre para pode filtrarlo.
- Ocultar la visualización de casos finalizados posterior a los 30 días para ver solo los pendientes o más recientes para Rol de Purdy /Agentes / Intermediarios, pero dejar en los reportes.
- Colocar botón opcional en notas que permita decidir si el sistema debe enviar notificación al dejar mensajes nuevos al contacto que apertura el caso.
- Habilitar para Rol de agentes y Rol de Purdy en la pestaña de seguimiento la vista de los comentarios colocados en seguimiento de etapas, fechas de la gestión y realizado por. Vista desde tenant aliados y purdy.
- Abrir casilla para que los casos seleccionados con prioridad "reprocesos" se deba colocar de forma obligatoria el número de caso anterior. Se agrega la capacidad de poder hacer visible o no los campos de referencia con lo cual se puede agregar un par de campos y manejarlo por visibilidad.

#### Dependencias:

1. 20251215a.process.alter.sql
2. 20260106a.lookupmaster.69.sql
3. 20260107a.process.alter.sql
4. 20260112a.process.insight.sql

---

## Versión 1.6.166 - 14/01/2026

### Aliados - Monge: Incidentes Reportados Noviembre - Diciembre.

#### Funcionalidades implementadas:

- Se ajusta la creación de registros en las tablas AuthenticationTrace y ChangeSet por medio de sequence propios de Oracle.
- Se habilita validaciones para las cotizaciones de viajero.
- Se agrega manejo de dos reintentos en caso de existir algun error en la emisión con una pausa de 0.5 segundos entre intento.

- #### Dependencias:

1. 260112a.AuthenticationTrace.ChangeSet.alter.sql
---
## Versión 1.6.165 - 30/12/2025

### Aliados - SICOP : Se habilita traza en el llamado a los servicios de SICOP.

#### Funcionalidades implementadas:

- Se habilita traza por medio de la tabla TRACKREQUEST en el llamado a los servicios de SICOP.

---
## Versión 1.6.164 - 17/12/2025

### Aliados - Security : Optimización del Control de Inactividad de Usuarios.

#### Funcionalidades implementadas:

- El sistema detecta la inactividad del usuario y envía una notificación emergente como aviso preventivo.
- Si la inactividad persiste, el sistema cierra automáticamente la sesión para reforzar el control y la seguridad.
- Cuando el usuario muestra actividad después de recibir la advertencia, el sistema extiende automáticamente la sesión sin intervención manual.

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

- Se crear nueva vista sugese/generador la cual se encarga de procesar archivos excel y convertilos  en el formato de monitoreo XML de la SUGESE.
- Se crear nueva vista sugese/envio la cual realiza el envio del XML al servicio de la SUGESE.

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

- Se hacen cambios necesario para no necesitar almacenar el token en el localstore del browser.

---
## Versión 1.6.161 - 04/12/2025

### Aliados - Seguridad: 2FA, manejo de claves de acceso

#### Funcionalidades implementadas:

- Se habilita el manejo de cuentas de servicio en modo 2FA. Las cuentas de servicio solo pueden ser usadas en el API.
- Se cambia el mantenimiento de usuario para habilitar la configuración de cuentas de servicio.
- La clave de acceso no se almacena; en su lugar se obtiene un hash, lo cual es la forma correcta de manejarlas.
- Se hacen mejoras en el manejo de autenticación en modo 2FA.

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

- Se envía una factura electrónica cuando se hace la emisión y el usuario tiene entre sus roles el rol 'Scotiabank'
- En la tabla `changeset` con `entitytype = 3000` se agrega traza del envío de la factura electrónica
- En la tabla `changeset` con `entitytype = 3000` se agrega traza si hubo falla al momento de la emisión

#### Nuevos Settings

Nuevos settings (tabla `settings`) para controlar el envío de la factura electrónica:

| Setting | Descripción |
|---------|-------------|
| `Integration.GTI.ApiCargaFactura.BaseURL` | URL base del servicio de GTI para el envío de facturas electrónicas |
| `Integration.GTI.ApiCargaFactura.NumCuenta` | Número de cuenta para el servicio de GTI |
| `Integration.GTI.ApiCargaFactura.Usuario` | Usuario para el servicio de GTI |
| `Integration.GTI.ApiCargaFactura.Clave` | Clave para el servicio de GTI |

---

