# Release Notes - Aliados

## Versión 1.6.193

### Aliados : Cuando se suscribe una tarjeta, reemplazar la anterior en boveda.

#### Funcionalidades implementadas:

- Cuando se hacen nuevas suscripciones de tarjetas, la tarjeta anterior en boveda queda con estado igual a nueve.
- Se ajustaron los proceso que controlan los reintentos para recurrencia ya que no estaban conciderando el estado nueve y procedian a cambiarlo a 1.

---
## Versión 1.6.192

### Aliados : Cambio de Contraseña desde el Login.

#### Funcionalidades implementadas:

- Se ajusta los llamados del servicio para poder recuperar la contraseña desde el login.

---
## Versión 1.6.191

### Aliados : Boton de agregar usuarios no se habilita en Aliados DES-QA.

#### Funcionalidades implementadas:

- Al agregar la opcion del menejo de lenguaje se bloque la zona del click para los botones de agregar de los mantenimientos.

---
## Versión 1.6.190

### Aliados : Zona Clientes, consulta de recibos pendientes.

#### Funcionalidades implementadas:

- Se habilita la posibilidad de pagar solo el primer recibo pendiente.

---

## Versión 1.6.189

### Aliados : Eliminación de presupuestos en Zona de Aliados.

#### Funcionalidades implementadas:

- Se habilita por medio de un icono rojo al lado del número de presupuesto, la posibilidad de eliminar el presupuesto.

---
## Versión 1.6.188 - Autenticación Okta - OAuth 2.0 (OIDC) con sincronización de usuarios.

### Aliados - Integración de inicio de sesión federado con Okta mediante el flujo Authorization Code de OAuth 2.0.

#### Cambios implementados:

- Nuevo controlador `OktaController` para gestionar el flujo de autorización OAuth 2.0 con Okta: inicio de sesión (`Login`), callback de autorización (`Callback`), intercambio de código por tokens y consulta del endpoint `userinfo`.
- Nueva clase `OktaUserManagement` en Core para sincronizar usuarios con la Users API de Okta: crear, actualizar (perfil y contraseña) y eliminar usuarios, con autenticación vía `private_key_jwt` (RFC 7523).
- Nuevo método `AuthenticationByOkta` en `Accounts.cs` para autenticar usuarios cuya identidad fue verificada por Okta sin requerir validación de contraseña local.
- Se habilita la gestión de grupos en Okta: los usuarios creados o actualizados son asignados automáticamente al grupo configurado (`Okta.ServiceApp.AssignGroupName`).
- Se sincroniza el password en Okta cuando el usuario lo modifica desde la UI de Aliados.
- Nuevas vistas de login para tenants `Clientes` y `Bayer` con botón de inicio de sesión con Okta.

#### Nuevos puntos de acceso:

- Clientes: `{webapp}/acceso/clientes` → inicia flujo Okta para el tenant de clientes.
- Bayer: `{webapp}/acceso/bayer` → inicia flujo Okta para el tenant de Bayer.

#### Nuevos settings de configuración requeridos (`Web.config`):

| Setting | Descripción |
|---|---|
| `Okta.Domain` | URL base del tenant Okta (ej. `https://loginpre.mapfrecr.com`). |
| `Okta.ClientId` | Client ID de la aplicación Okta. |
| `Okta.RedirectUri` | URI de redirección registrada en Okta. Debe coincidir exactamente con la configurada en el portal. |
| `Okta.AuthorizationServerId` | ID del servidor de autorización de Okta (usa `default` si aplica). |
| `Okta.ServiceApp.ClientId` | Client ID de la Service App utilizada para sincronización de usuarios. |
| `Okta.ServiceApp.PrivateKeyJwk` | Clave privada en formato JWK (Base64) para firmar el `client_assertion`. |
| `Okta.ServiceApp.Scopes` | Scopes solicitados (ej. `okta.users.manage okta.groups.read okta.groups.manage`). |
| `Okta.ServiceApp.AssignGroupName` | Nombre del grupo en Okta al que se asignan los usuarios (opcional). |
| `Okta.SyncUsers.Tenants` | Lista de `CompanyId` (separados por `;`) cuyos usuarios se sincronizan con Okta. |

> ⚠️ Ajustar `Okta.RedirectUri` según el ambiente (desarrollo, QA, producción). El valor debe coincidir exactamente con la URI registrada en el portal de Okta.

#### Dependencias:

- Registro de la aplicación en el portal de Okta.
- Service App en Okta con permiso de gestión de usuarios (`okta.users.manage`) y grupos.
- Clave privada JWK generada y configurada en `Okta.ServiceApp.PrivateKeyJwk`.

---

## Versión 1.6.187 - Compliance: Se habilita el reporte de la trazabilidad para Compliance (SNAP).

### Aliados - Scheduler: Manejo de ejecuciones recurrentes, se habilita el manejo de la tabla `ScheduledJob` y la persistencia del resultado de ejecución.

#### Cambios implementados:

- Por medio de la tabla `ScheduledJob` y el tipo `REPORT_EMAIL` se determina la tarea a ejecutar.
- Se ejecutar la generación del reporte en forma excel según la columna `resultado_snap`.
- Se envía por correo por medio de la plantilla indicada en la columna `mail_template` y se anexa el excel generado con el nombre según  `output_file_name`.

#### Dependencias:

1. 261107a.BO_SCHEDULED_JOB.sql
2. 260518a.visualization.resultado_snap.sql
3. 260518b.template.resultado_snap.sql
4. 260518c.scheduledjob.resultado_snap.sql

---

## Versión 1.6.186 - MAPFRE Más: Restricción de ajuste comercial para planes Trébol Basic y Trébol Premium.

### Aliados - MAPFRE Más (Ramo 302): Se bloquea el ajuste comercial para planes específicos.

#### Cambios implementados:

- Se restringe la modificación del campo "Porcentaje de ajuste comercial" (PCT_AJUSTE_GEN) en la sección de datos del vehículo para los planes Trébol Basic y Trébol Premium.
- El campo es deshabilitado y forzado a 0% cuando se selecciona alguno de estos planes, tanto en cotización como en emisión.

#### Alcance:
- Aplica únicamente al ramo 302 (MAPFRE Más).
- Afecta exclusivamente los planes Trébol Basic y Trébol Premium.

#### Dependencias:
- No aplica.

---

## Versión 1.6.185 - Compliance: Se habilita la trazabilidad para Compliance (SNAP).

### Compliance - Se actualiza el flujo de integración de Compliance (SNAP) para registrar trazabilidad completa.

#### Cambios implementados:

- Se agregan nuevos campos opcionales en la traza de solicitudes para mejorar el contexto de negocio: `PolicyId`, `InsuredId` e `InsuredName`.
- Se actualiza el flujo de integración de Compliance para registrar trazabilidad completa de request/response en `TrackRequest`.
- Se consolida la lógica de trazabilidad para usar una única implementación central en Core.
- Se migran los consumidores de Tron y Monge para usar la implementación de trazas de Core.

#### Actualizaciones de interfaz de usuario:

- **Vistas CSHTML mejoradas**: Se actualiza el sistema de traducción multilenguaje en vistas, incluyendo:
  - Vistas de seguridad: `Login`, `Register`, `ChangePassword`, `Integrate`, `RoleMember`, `UserMember`, etc.
  - Vistas de Variaciones: `HogarTotal`, `HogarTotalPlus`, `MapfreMas`, `Multirriesgo`, etc.
  - Nuevas vistas en Viewer: `Dashboard`, `Formio`, `crud`.
- **Scripts y estilos**: Se actualiza `core.js`, `core.ui.js`, `core.frm.js` y estilos CSS para soporte de traducción dinámica.
- **Componentes de terceros**: Se agregan dependencias para Dropzone y Animate.css; se actualiza Formio.js a versión más reciente.
- **Configuración del proyecto**: Se actualiza `aliados.csproj` y `packages.config` con nuevas dependencias.

#### Cambios menores:

- Limpieza de `Web.config` y `connectionstring`.
- Se corriges el logging para traducciones.
- Actualización de reglas de productos MapfreMas y MapfreMasPlus.
- Limpieza de archivos temporales y sesiones de prueba.

#### Dependencias:

1. 260504a.TrackRequest.alter.sql

#### Archivos principales modificados: 
- 45+ vistas CSHTML con traducción multilenguaje
- Scripts de interfaz (`core.js`, `core.ui.js`, `core.frm.js`)
- Librerías de terceros (Formio.js, Dropzone, Animate.css)
- Configuración del proyecto (`aliados.csproj`, `packages.config`)

---

## Versión 1.6.184 - Viajero: Validaciones de beneficiarios y mejoras de captura.

### Aliados - Viajero: Se fortalecen validaciones y experiencia de ingreso de datos para beneficiarios.

#### Cambios implementados:

- Se agrega validación para asegurar que el porcentaje de participación de beneficiarios sume 100% por riesgo.
- Se muestran mejoras visuales en la tabla de beneficiarios, incluyendo la columna de porcentaje.
- Se ajusta el comportamiento del tipo y número de identificación para una captura más consistente.
- Se mejoran validaciones y mensajes en pantalla durante el registro/edición de beneficiarios.
- Se incorporan ajustes menores de interfaz para una experiencia más clara en el flujo de Viajero.

#### Dependencias:

- No aplica.

---

## Versión 1.6.183 - Autenticación Microsoft Entra ID (Azure AD) - OAuth 2.0.

### Aliados - Integración de inicio de sesión federado con Microsoft Entra ID mediante el flujo Authorization Code de OAuth 2.0.

#### Cambios implementados:

- Nuevo controlador EntraID para controla el flujo de autorización.
- Nuevo controlador Acceso para definir punto de entrada especificos para tres tenant `aliados`, `purdy` y `mapfre`.
- Nuevas paginas de login para cada tenant, con botón de inicio de sesión con Microsoft Entra ID.

#### Nuevos puntos de access por tenant:

	- Aliados: {webapp}/acceso/aliados, ejemplo: https://appqa.mapfrecr.com/aliados/acceso/aliados
	- Purdy: {webapp}/acceso/purdy, ejemplo: https://appqa.mapfrecr.com/aliados/acceso/purdy
	- Mapfre: {webapp}/acceso/mapfre, ejemplo: https://appqa.mapfrecr.com/aliados/acceso/mapfre

#### Nuevos settings de configuración requeridos (`Web.config`):


| Setting | Descripción |
|---|---|
| `EntraId.ClientId` | ID de la aplicación registrada en el portal de Microsoft Entra ID (Azure AD). |
| `EntraId.TenantId` | ID del directorio (tenant) de Microsoft Entra ID donde está registrada la aplicación. |
| `EntraId.ClientSecret` | Secreto de cliente generado en el portal de Entra ID. Debe rotarse periódicamente y no exponerse en repositorios públicos. |
| `EntraId.RedirectUri` | URI de redirección a la que Microsoft devuelve el código de autorización tras la autenticación. Debe coincidir exactamente con la registrada en el portal de Entra ID. |

> ⚠️ Ajustar `EntraId.RedirectUri` según el ambiente (desarrollo, QA, producción). El valor debe coincidir exactamente con la URI registrada en el portal de Entra ID.

#### Dependencias:
- Registro de la aplicación en Microsoft Entra ID.

---

## Versión 1.6.182 - Altas/Bajas: Se agregar los campos teléfono, ocupación y sección repetitiva para beneficiarios.

### Aliados - Altas/Bajas: Se agregar los campos teléfono, ocupación y sección repetitiva para beneficiarios.

#### Cambios implementados:

- Se agrega el mapeo de la colección `Beneficiarios` en `AltasBajasPoliza.cs` hacia `SPCall.BENEFICIARIOS`.
- Se incorpora el mapeo completo de propiedades de beneficiario para el request del procedimiento almacenado.
- Se aplica conversión de `FEC_NAC_BENEF` al formato requerido `ddMMyyyy` para `SPCallBeneficiario`.
- Se documentan clases y propiedades con comentarios XML en el namespace `Architect.API.Tron.Contracts.AltasBajas.Request`.
- Archivos documentados: `Base.cs`, `BeneficiarioBase.cs`, `Beneficiario.cs`, `Poliza.cs`, `SPCall.cs`, `SPCallBeneficiario.cs`.
- Se ajusta definición de forma EmitirPoliza de la tabla visualization.
- Ajustes al javascript de soporte Form.Ext.Altas.js.

#### Dependencias:
1. 260421a.visualization.emitirpoliza.sql

---

## Versión 1.6.181 - Multilenguaje: Refinamientos avanzados y soporte de Bootstrap Table (Fase III).

### Aliados - Multilenguaje: Refinamientos avanzados y soporte de Bootstrap Table (Fase III).

#### Cambios implementados:

**Motor de Multilenguaje - `core.language.js`:**
- ✅ **Nuevo soporte para Bootstrap Table:** Función `applyBootstrapTableTranslations()` que extiende opciones de traducción dinámicamente.
- ✅ **Refrescado de traducciones en tablas:** Nueva función `refreshBootstrapTableTranslations()` para actualizar traducciones en tiempo de ejecución en grillas Bootstrap.
- ✅ **Mejora de filtros de labels:** Control mejorado para evitar traducción duplicada en etiquetas con ID definido.
- ✅ **Sincronización automática:** Las tablas Bootstrap se actualizan automáticamente cuando se cargan nuevas traducciones.

#### Dependencias:
1. 260416a.visualization.upd.des.57c14536.sql
2. 260416b.navigation.fix.75db2a1c.sql
3. 260416c.translations.038ca66a.sql 
4. 260416d.translations.data.7805eced.sql
5. 20260419a.lookupmaster.alter.3021530b.sql
6. 20260419b.translations.tron_a1002090.aa95c583.sql
7. 20260419c.G1010031.42edd036.sql.

---

## Versión 1.6.180 - 02/04/2026

### Aliados - Multilenguaje: Implementación de librería propia de traducción y localización (Fase I y II).

#### Funcionalidades implementadas:

- Librería propia de multilenguaje con soporte para múltiples idiomas (ES/EN).
- Mejora de `core.language.js` (módulo propietario) con control dinámico de caché mediante query string (`?cache=false`).
- Localización de 64 archivos JSON en 10 módulos (Avisos, Cases, Cotizacion, Common, Emision, General, Inicio, Security, Variaciones, Viewer).
- Integración de librería en 30+ controladores backend y actualización de 25+ scripts JavaScript.
- Localización de 42+ vistas Razor con atributos `data-i18n`.
- Refactorización de `Database.cs` y `aliados.csproj`.

---

## Versión 1.6.179 - 07/04/2026

### Aliados - MapfreMasPlus: Al seleccionar el contrato 10700, el campo 'RC alcohol' se marca como 'si' y se bloquea.

#### Funcionalidades implementadas:

- Al seleccionar el contrato 10700, el campo 'RC alcohol' se marca como 'si' y se bloquee.
- La visibilidad del campo 'RC alcohol' se condiciona a los roles Intermediario y Empleado.

---

## Versión 1.6.178 - 27/03/2026

### Aliados - MapfreMas: Se habilita la carga dinámica de las marcas de vehículos.

#### Funcionalidades implementadas:

- Se habilita la carga dinámica de las marcas de vehículos.

---

## Versión 1.6.177 - 27/03/2026

### Aliados - Panel Purdy: Se establece en los campos fecha que el valo minimo es `1900-01-01`.

#### Funcionalidades implementadas:

- Se establece en los campos fecha que el valo minimo es `1900-01-01`.

---

## Versión 1.6.176 - 22/03/2026

### Aliados - Trazabilidad: Tablero de estadisticas de casos.	

#### Funcionalidades implementadas:

- Se agregar tablero con multiples estaditicas de casos registrados.

#### Rutas de acceso:

- https://appqa.mapfrecr.com/aliados/viewer/dashboard?id=process

---

## Versión 1.6.175 - 16/03/2026

### Aliados - syscorpla: Se agregar acceso syscorpla de forma embebida en un iframe a página completa 

#### Funcionalidades implementadas:

- Se agregar acceso syscorpla de forma embebida en un iframe a página completa.

#### Rutas de acceso:

- https://appqa.mapfrecr.com/aliados/viewer/dashboard?id=syscorpla

---

## Versión 1.6.174 - 14/03/2026

### Aliados - TRON: Ajuste para obtener el nombre del programa encargado de generar el certificado según el ramo.	

#### Funcionalidades implementadas:

- Se cambia la lógica para obtener el nombre del programa que genera el certificado por ramo, de forma que no esté fija en código y que dicho nombre se obtenga de la tabla `settings` usando como clave la siguiente interpolación (`tron.prog.certificado.{ramo}`).

#### Dependencias:

1. 260314a.settings.tron.prog.certificado.sql

---

## Versión 1.6.173 - 11/03/2026

### Aliados - Funerario: Implementación del ramo 196.	

#### Funcionalidades implementadas:

- Implementación del ramo 196 para el producto funerario.
- Se agregan las funcionalidades necesarias para la cotización y emisión de pólizas autoexpedibles funerarias.

#### Rutas de acceso:

- Cotización: /funerario/cotizacion
---

## Versión 1.6.172 - 10/02/2026

### Aliados - Pasarela: Tokenización de tarjetas duplicadas.	

#### Funcionalidades implementadas:

- Cuando se hace el pago en línea con suscripción, se crea una nueva tokenización, pero queda activa la tokenización anterior.

---

## Versión 1.6.171 - 09/02/2026

### Aliados - Trazabilidad: Reporte de Casos creados por Purdy.	

#### Funcionalidades implementadas:

- Reporte de casos descargable para rol agente / Purdy / corredurías que contenga los siguientes campos: #caso / fecha ingreso / asunto / estado - urgente / usuario de creación (contacto).

#### Dependencias:

1. 20260209a.visualizations.422.sql

---

## Versión 1.6.170 - 09/02/2026

### Aliados - Trazabilidad: Validación de casos duplicados.	

#### Funcionalidades implementadas:

- Alerta de posible caso duplicado por asunto/datos obligatorios. Se verifica el proceso, asunto y referencias requeridas.

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
- Se requiere una alerta o una señal para identificar los nuevos casos cargados o movimientos recientes en la plataforma cada vez que cambie de etapa. Se habilita el agente como persona de contacto del caso; de esta forma se pueden configurar las notificaciones.
- Revisión de 84 procesos para determinar fallas de diseño; solo se encontraron 2 errores y 2 casos para mejora.
- Apertura de rol para corredurías. Para cualquier tenant diferente al de Mapfre, se pasan los roles del usuario conectado, de forma que la lista de procesos permitidos se filtre usando los roles del usuario; el nombre del rol debe existir en el tenant Mapfre para poder filtrarlo.
- Ocultar la visualización de casos finalizados posterior a los 30 días para ver solo los pendientes o más recientes para rol de Purdy / agentes / intermediarios, pero dejarlos en los reportes.
- Colocar botón opcional en notas que permita decidir si el sistema debe enviar notificación al dejar mensajes nuevos al contacto que apertura el caso.
- Habilitar para rol de agentes y rol de Purdy, en la pestaña de seguimiento, la vista de los comentarios colocados en seguimiento de etapas, fechas de la gestión y realizado por. Vista desde tenant Aliados y Purdy.
- Abrir casilla para que los casos seleccionados con prioridad "reprocesos" deban colocar de forma obligatoria el número de caso anterior. Se agrega la capacidad de poder hacer visibles o no los campos de referencia, con lo cual se puede agregar un par de campos y manejarlo por visibilidad.

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
- Se habilitan validaciones para las cotizaciones de viajero.
- Se agrega manejo de dos reintentos en caso de existir algún error en la emisión, con una pausa de 0.5 segundos entre intentos.

#### Dependencias:

1. 260112a.AuthenticationTrace.ChangeSet.alter.sql
---
## Versión 1.6.165 - 30/12/2025

### Aliados - SICOP: Se habilita traza en el llamado a los servicios de SICOP.

#### Funcionalidades implementadas:

- Se habilita traza por medio de la tabla TRACKREQUEST en el llamado a los servicios de SICOP.

---
## Versión 1.6.164 - 17/12/2025

### Aliados - Security: Optimización del Control de Inactividad de Usuarios.

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

### Aliados - SUGESE: Se migra desde Medical la funcionalidad de creación de archivo XML para la SUGESE.

#### Funcionalidades implementadas:

- Se crea nueva vista `sugese/generador`, la cual se encarga de procesar archivos Excel y convertirlos en el formato de monitoreo XML de la SUGESE.
- Se crea nueva vista `sugese/envio`, la cual realiza el envío del XML al servicio de la SUGESE.

Nuevos settings (tabla `settings`) para controlar la autenticación 2FA:

| Setting | Default | Descripción |
|---------|-------------|-------------|
| `app.path` | C:\Aliados\WebApp | Ruta física de la aplicación |
| `sugese.codigoaseguradora` | A03 | Código de la entidad aseguradora |
| `sugese.entidadaseguradora` | Mapfre Seguros Costa Rica S.A. | Nombre de la entidad aseguradora |

---
## Versión 1.6.162 - 07/12/2025

### Aliados - Seguridad: Cambios para poder usar la cookie en el request de APIs, desde la aplicación web.

#### Funcionalidades implementadas:

- Se hacen cambios necesarios para no tener que almacenar el token en el local storage del browser.

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

- Se envía una factura electrónica cuando se hace la emisión y el usuario tiene entre sus roles el rol 'Scotiabank'.
- En la tabla `changeset` con `entitytype = 3000` se agrega traza del envío de la factura electrónica.
- En la tabla `changeset` con `entitytype = 3000` se agrega traza si hubo falla al momento de la emisión.

#### Nuevos Settings

Nuevos settings (tabla `settings`) para controlar el envío de la factura electrónica:

| Setting | Descripción |
|---------|-------------|
| `Integration.GTI.ApiCargaFactura.BaseURL` | URL base del servicio de GTI para el envío de facturas electrónicas |
| `Integration.GTI.ApiCargaFactura.NumCuenta` | Número de cuenta para el servicio de GTI |
| `Integration.GTI.ApiCargaFactura.Usuario` | Usuario para el servicio de GTI |
| `Integration.GTI.ApiCargaFactura.Clave` | Clave para el servicio de GTI |

---

## Notas:

### Flujo de entregas a DES

- Se hace merge de DES a rama del feature
- Se prepara releasenotes.md con la información del feature
- Se hace el commit para dejara la rama feature actualizada con DES
- Se cambia a rama DES y se hace el pull de la misma
- Se hace el merge de la rama feature a DES (git merge --squash feature/{nombre})
- Se hace commit y push usando el título de la versión liberada del release notes