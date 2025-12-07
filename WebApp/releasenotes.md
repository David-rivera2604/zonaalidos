# Release Notes - Aliados

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

