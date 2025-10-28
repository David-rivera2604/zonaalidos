# Aliados - Documento de Requisitos del Producto (PRD)

## 1. Resumen Ejecutivo

### 1.1 Descripción del Producto
Aliados es una plataforma de seguros y servicios financieros construida sobre .NET Framework 4.8. El sistema proporciona gestión integral de pólizas de seguro, servicios de tarificación, integración con sistemas externos (Tron, SICOP, Monge), y funcionalidad de negocio central para la gestión de operaciones de seguros.

### 1.2 Objetivos de Negocio
- Optimizar la gestión del ciclo de vida de las pólizas de seguro
- Proporcionar tarificación y precios precisos de seguros
- Habilitar integración fluida con sistemas asociados
- Soportar distribución multicanal a través de la alianza con Monge
- Asegurar cumplimiento normativo y procesamiento seguro de pagos
- Facilitar la gestión de documentos y firmas electrónicas

---

## 2. Arquitectura del Producto

### 2.1 Componentes del Sistema

#### Capa Central (Core)
- **Architect.API.Core**: Servicios y endpoints de API central
- **Architect.API.Core.Contracts**: Contratos de servicios y DTOs centrales
- **Architect.API.Core.Business**: Capa de lógica de negocio central
- **Architect.API.Core.DataAccess**: Capa de acceso a datos central
- **Architect.API.Core.Security**: Servicios de autenticación y autorización

#### Dominio de Pólizas de Seguro
- **Architect.API.Insurance**: Servicios de API de seguros
- **Architect.API.Insurance.Contracts**: Contratos de servicios de seguros
- **Architect.API.Insurance.Business**: Lógica de negocio de seguros
- **Architect.API.Insurance.DataAccess**: Persistencia de datos de seguros

#### Motor de Tarificación de Seguros
- **Architect.Insurance.Services**: Servicios de cálculo de tarifas
- **Architect.Insurance.Contracts**: Contratos de servicios de tarificación

#### Capa de Integración Tron
- **Architect.API.Tron**: Fachada de API del sistema Tron
- **Architect.API.Tron.Contracts**: Contratos de servicios Tron
- **Architect.API.Tron.Business**: Lógica de negocio Tron
- **Architect.API.Tron.DataAccess**: Capa de acceso a datos Tron
- **Architect.WS.Integrations**: Integraciones de servicios web Tron

#### Módulo de Alianza Monge
- **Aliados.Monge.WebApi**: API REST para integración con Monge
- **Aliados.Monge.Domain**: Modelos de dominio Monge
- **Aliados.Monge.Application**: Servicios de aplicación Monge
- **Aliados.Monge.Infrastructure.Data**: Infraestructura de datos Monge
- **Aliados.Monge**: Lógica de negocio Monge

#### Integraciones Externas
- **Architect.Extend.Integrations**: Integraciones extendidas de seguros
- **Architect.Payment.Integrations**: Integraciones de pasarelas de pago
- **Architect.DocuSign.Integrations**: Servicios de firma electrónica
- **Architect.Compliance.Integrations**: Servicios de cumplimiento normativo y regulatorio
- **Architect.PDF.Integrations**: Generación y manipulación de PDF
- **Architect.SICOP.Integrations**: Integración con sistema SICOP
- **Architect.SICOP.WcfService**: Servicios WCF de SICOP

#### Kernel/Utilidades
- **Architect.Utilities**: Utilidades y helpers comunes
- **Architect.Utilities.Excel**: Manejo de documentos Excel
- **Architect.DataFactory**: Factory de acceso a datos y helpers de ORM

#### Aplicación Web
- **aliados**: Aplicación web principal (webapp)

### 2.2 Patrones Arquitectónicos
- **Arquitectura por Capas**: Separación de responsabilidades con capas de Contratos, Negocio y Acceso a Datos
- **Arquitectura Orientada a Servicios (SOA)**: Múltiples puntos de integración con sistemas externos
- **Diseño Dirigido por Dominio**: Especialmente evidente en el módulo Monge
- **Patrón Repository**: Abstracción de acceso a datos
- **Inyección de Dependencias**: Resolución de servicios basada en contratos

---

## 3. Requisitos Funcionales

### 3.1 Gestión de Pólizas de Seguro

#### 3.1.1 Creación de Pólizas
- **FR-POL-001**: El sistema debe permitir la creación de nuevas pólizas de seguro con información completa del cliente y coberturas
- **FR-POL-002**: El sistema debe validar los datos de la póliza contra las reglas de negocio antes de la creación
- **FR-POL-003**: El sistema debe generar números de póliza únicos
- **FR-POL-004**: El sistema debe soportar múltiples tipos de productos de seguro

#### 3.1.2 Ciclo de Vida de Pólizas
- **FR-POL-005**: El sistema debe gestionar estados de pólizas (Borrador, Cotizada, Emitida, Activa, Suspendida, Cancelada, Expirada)
- **FR-POL-006**: El sistema debe rastrear modificaciones y enmiendas de pólizas
- **FR-POL-007**: El sistema debe soportar flujos de trabajo de renovación de pólizas
- **FR-POL-008**: El sistema debe permitir la cancelación de pólizas con reglas de negocio apropiadas

#### 3.1.3 Búsqueda y Recuperación de Pólizas
- **FR-POL-009**: El sistema debe proporcionar búsqueda integral de pólizas por múltiples criterios (número de póliza, cliente, rango de fechas, estado)
- **FR-POL-010**: El sistema debe mostrar vistas resumidas y detalladas de pólizas
- **FR-POL-011**: El sistema debe mantener un historial completo de pólizas y pista de auditoría

### 3.2 Motor de Tarificación de Seguros

#### 3.2.1 Cálculo de Primas
- **FR-RATE-001**: El sistema debe calcular primas de seguro basadas en factores de tarificación configurables
- **FR-RATE-002**: El sistema debe soportar múltiples metodologías de tarificación por producto
- **FR-RATE-003**: El sistema debe aplicar descuentos y recargos basados en reglas de negocio
- **FR-RATE-004**: El sistema debe soportar versionado de tablas de tarificación

#### 3.2.2 Generación de Cotizaciones
- **FR-RATE-005**: El sistema debe generar cotizaciones con desglose detallado de primas
- **FR-RATE-006**: El sistema debe soportar comparación de cotizaciones para diferentes opciones de cobertura
- **FR-RATE-007**: El sistema debe hacer cumplir períodos de validez de cotizaciones
- **FR-RATE-008**: El sistema debe convertir cotizaciones a pólizas al ser aceptadas

### 3.3 Gestión de Clientes

#### 3.3.1 Datos de Clientes
- **FR-CUST-001**: El sistema debe mantener perfiles integrales de clientes (personal, empresarial)
- **FR-CUST-002**: El sistema debe validar documentos de identificación de clientes
- **FR-CUST-003**: El sistema debe soportar segmentación y clasificación de clientes
- **FR-CUST-004**: El sistema debe rastrear relaciones y jerarquías de clientes

#### 3.3.2 Portal de Clientes
- **FR-CUST-005**: El sistema debe proporcionar capacidades de autoservicio para clientes
- **FR-CUST-006**: El sistema debe permitir a los clientes ver sus pólizas y documentos
- **FR-CUST-007**: El sistema debe habilitar a los clientes para solicitar cambios en pólizas
- **FR-CUST-008**: El sistema debe soportar preferencias de comunicación de clientes

### 3.4 Integración con Sistema Tron

#### 3.4.1 Sincronización de Datos
- **FR-TRON-001**: El sistema debe sincronizar datos de pólizas con el sistema Tron
- **FR-TRON-002**: El sistema debe recuperar información de clientes desde Tron
- **FR-TRON-003**: El sistema debe actualizar cambios de estado de pólizas a Tron
- **FR-TRON-004**: El sistema debe manejar errores de integración con Tron de manera elegante

#### 3.4.2 Procesamiento de Transacciones
- **FR-TRON-005**: El sistema debe enviar transacciones de nuevos negocios a Tron
- **FR-TRON-006**: El sistema debe procesar endosos a través de Tron
- **FR-TRON-007**: El sistema debe reconciliar transacciones entre sistemas

### 3.5 Alianza Monge

#### 3.5.1 Integración con Punto de Venta
- **FR-MONGE-001**: El sistema debe proporcionar APIs para sistemas de punto de venta de Monge
- **FR-MONGE-002**: El sistema debe soportar generación de cotizaciones en tiempo real en ubicaciones Monge
- **FR-MONGE-003**: El sistema debe habilitar emisión de pólizas a través de canales Monge
- **FR-MONGE-004**: El sistema debe rastrear atribución de ventas a agentes/ubicaciones Monge

#### 3.5.2 Gestión de Comisiones
- **FR-MONGE-005**: El sistema debe calcular comisiones para ventas de Monge
- **FR-MONGE-006**: El sistema debe generar reportes de comisiones
- **FR-MONGE-007**: El sistema debe soportar ajustes y reconciliación de comisiones

### 3.6 Procesamiento de Pagos

#### 3.6.1 Recaudación de Pagos
- **FR-PAY-001**: El sistema debe integrarse con pasarelas de pago para procesamiento de tarjetas de crédito
- **FR-PAY-002**: El sistema debe soportar múltiples métodos de pago (tarjeta, transferencia bancaria, efectivo)
- **FR-PAY-003**: El sistema debe generar recibos y confirmaciones de pago
- **FR-PAY-004**: El sistema debe rastrear estado de pagos y aplicarlos a pólizas

#### 3.6.2 Facturación y Emisión de Facturas
- **FR-PAY-005**: El sistema debe generar facturas para primas pendientes
- **FR-PAY-006**: El sistema debe soportar planes de pago a plazos
- **FR-PAY-007**: El sistema debe enviar recordatorios y avisos de pago
- **FR-PAY-008**: El sistema debe manejar fallos de pago y reintentos

### 3.7 Gestión de Documentos

#### 3.7.1 Generación de Documentos
- **FR-DOC-001**: El sistema debe generar documentos de pólizas (declaraciones, certificados)
- **FR-DOC-002**: El sistema debe crear documentos PDF desde plantillas
- **FR-DOC-003**: El sistema debe soportar versionado y archivo de documentos
- **FR-DOC-004**: El sistema debe generar correspondencia con clientes

#### 3.7.2 Firmas Electrónicas
- **FR-DOC-005**: El sistema debe integrarse con DocuSign para firmas electrónicas
- **FR-DOC-006**: El sistema debe rastrear el flujo de trabajo de firma de documentos
- **FR-DOC-007**: El sistema debe almacenar documentos firmados de manera segura
- **FR-DOC-008**: El sistema debe validar la autenticidad de firmas

### 3.8 Cumplimiento Normativo y Regulatorio

#### 3.8.1 Cumplimiento Regulatorio
- **FR-COMP-001**: El sistema debe hacer cumplir requisitos regulatorios para transacciones de seguros
- **FR-COMP-002**: El sistema debe realizar validación KYC (Conozca a su Cliente)
- **FR-COMP-003**: El sistema debe soportar verificaciones AML (Anti-Lavado de Dinero)
- **FR-COMP-004**: El sistema debe mantener registros de auditoría para reportes regulatorios

#### 3.8.2 Privacidad de Datos
- **FR-COMP-005**: El sistema debe cumplir con regulaciones de protección de datos
- **FR-COMP-006**: El sistema debe soportar gestión de consentimiento de clientes
- **FR-COMP-007**: El sistema debe habilitar solicitudes de acceso de datos de sujetos
- **FR-COMP-008**: El sistema debe implementar políticas de retención de datos

### 3.9 Integración SICOP

#### 3.9.1 Integración del Sistema
- **FR-SICOP-001**: El sistema debe integrarse con SICOP para productos de seguro específicos
- **FR-SICOP-002**: El sistema debe intercambiar datos de pólizas con SICOP
- **FR-SICOP-003**: El sistema debe soportar reglas de negocio específicas de SICOP
- **FR-SICOP-004**: El sistema debe proporcionar servicios WCF para comunicación con SICOP

### 3.10 Reportes y Analítica

#### 3.10.1 Reportes Operacionales
- **FR-REP-001**: El sistema debe generar reportes de ventas por producto, agente, canal
- **FR-REP-002**: El sistema debe proporcionar reportes de estado e inventario de pólizas
- **FR-REP-003**: El sistema debe crear reportes financieros y contables
- **FR-REP-004**: El sistema debe soportar generación de reportes personalizados

#### 3.10.2 Integración con Excel
- **FR-REP-005**: El sistema debe exportar datos a formato Excel
- **FR-REP-006**: El sistema debe importar datos desde plantillas de Excel
- **FR-REP-007**: El sistema debe soportar validación de datos basada en Excel

---

## 4. Requisitos No Funcionales

### 4.1 Rendimiento

#### 4.1.1 Tiempo de Respuesta
- **NFR-PERF-001**: Los endpoints de API deben responder en menos de 2 segundos para el 95% de las solicitudes
- **NFR-PERF-002**: Las consultas de base de datos deben ejecutarse en menos de 1 segundo para operaciones estándar
- **NFR-PERF-003**: Los cálculos de tarificación deben completarse en menos de 3 segundos
- **NFR-PERF-004**: La generación de documentos debe completarse en menos de 5 segundos

#### 4.1.2 Capacidad de Procesamiento
- **NFR-PERF-005**: El sistema debe soportar 100 usuarios concurrentes sin degradación del rendimiento
- **NFR-PERF-006**: El sistema debe procesar 1000 cotizaciones por hora
- **NFR-PERF-007**: El sistema debe manejar 500 transacciones de pólizas por hora

### 4.2 Escalabilidad

- **NFR-SCALE-001**: La arquitectura del sistema debe soportar escalamiento horizontal de servicios API
- **NFR-SCALE-002**: La base de datos debe soportar particionamiento para grandes volúmenes de datos
- **NFR-SCALE-003**: El sistema debe manejar 10 veces el volumen de transacciones actual con escalamiento de infraestructura

### 4.3 Seguridad

#### 4.3.1 Autenticación y Autorización
- **NFR-SEC-001**: El sistema debe implementar mecanismos de autenticación seguros
- **NFR-SEC-002**: El sistema debe soportar control de acceso basado en roles (RBAC)
- **NFR-SEC-003**: El sistema debe hacer cumplir requisitos de complejidad de contraseñas
- **NFR-SEC-004**: El sistema debe implementar gestión de sesiones y tiempo de espera

#### 4.3.2 Protección de Datos
- **NFR-SEC-005**: El sistema debe encriptar datos sensibles en reposo
- **NFR-SEC-006**: El sistema debe usar HTTPS/TLS para todas las comunicaciones
- **NFR-SEC-007**: El sistema debe proteger contra vulnerabilidades comunes (OWASP Top 10)
- **NFR-SEC-008**: El sistema debe implementar validación y sanitización de entradas

#### 4.3.3 Auditoría y Registro
- **NFR-SEC-009**: El sistema debe registrar todos los eventos relevantes de seguridad
- **NFR-SEC-010**: El sistema debe mantener pistas de auditoría a prueba de manipulación
- **NFR-SEC-011**: El sistema debe rastrear acciones de usuarios para rendición de cuentas

### 4.4 Confiabilidad y Disponibilidad

- **NFR-REL-001**: El sistema debe mantener 99.5% de tiempo de actividad durante horas de negocio
- **NFR-REL-002**: El sistema debe implementar manejo de errores y degradación elegante
- **NFR-REL-003**: El sistema debe soportar respaldo y recuperación de base de datos
- **NFR-REL-004**: El sistema debe proporcionar capacidades de failover para servicios críticos

### 4.5 Mantenibilidad

- **NFR-MAINT-001**: El código debe seguir estándares y convenciones de codificación establecidos
- **NFR-MAINT-002**: El sistema debe mantener documentación completa de API
- **NFR-MAINT-003**: El sistema debe soportar cambios de configuración sin despliegue de código
- **NFR-MAINT-004**: El sistema debe implementar registro exhaustivo para resolución de problemas

### 4.6 Usabilidad

- **NFR-USE-001**: La interfaz web debe ser responsiva y soportar navegadores modernos
- **NFR-USE-002**: El sistema debe proporcionar mensajes de error claros y retroalimentación de validación
- **NFR-USE-003**: Las APIs deben seguir convenciones RESTful cuando sea aplicable
- **NFR-USE-004**: El sistema debe soportar internacionalización (español primario)

### 4.7 Integración

- **NFR-INT-001**: El sistema debe proporcionar contratos de API bien definidos
- **NFR-INT-002**: El sistema debe implementar lógica de reintento para llamadas a servicios externos
- **NFR-INT-003**: El sistema debe manejar tiempos de espera de servicios externos de manera elegante
- **NFR-INT-004**: El sistema debe soportar procesamiento asíncrono para operaciones de larga duración

### 4.8 Gestión de Datos

- **NFR-DATA-001**: El sistema debe mantener integridad de datos a través de transacciones
- **NFR-DATA-002**: El sistema debe soportar archivo de datos para registros históricos
- **NFR-DATA-003**: El sistema debe implementar validación de datos en todas las capas
- **NFR-DATA-004**: El sistema debe soportar migración y versionado de datos

---

## 5. Especificaciones Técnicas

### 5.1 Stack Tecnológico

#### 5.1.1 Framework y Plataforma
- **.NET Framework**: 4.8
- **Lenguaje**: C# (primario), potencialmente F#
- **Framework Web**: ASP.NET Web API, ASP.NET MVC
- **Comunicación de Servicios**: WCF (para integraciones legacy), APIs REST

#### 5.1.2 Acceso a Datos
- **ORM/Acceso a Datos**: Entity Framework o ADO.NET (vía DataFactory)
- **Base de Datos**: SQL Server (inferido de la estructura del proyecto)

#### 5.1.3 Librerías y Servicios Externos
- **API DocuSign**: Integración de firma electrónica
- **Pasarelas de Pago**: Varios procesadores de pago
- **Procesamiento de Excel**: Office Interop o librerías de terceros
- **Generación de PDF**: Librerías PDF para creación de documentos

### 5.2 Estándares de Desarrollo

#### 5.2.1 Organización del Código
- Separación de responsabilidades con capas distintas (Contratos, Negocio, Acceso a Datos)
- Inyección de dependencias para acoplamiento flexible
- Diseño contract-first para interfaces de servicios
- Principios de diseño dirigido por dominio donde sea aplicable

#### 5.2.2 Convenciones de Nomenclatura
- Nomenclatura de proyectos: `<Producto>.<Capa>.<Módulo>`
- Alineación de namespace con estructura del proyecto
- Clara separación entre API, Lógica de Negocio y Acceso a Datos

#### 5.2.3 Manejo de Errores
- Manejo centralizado de excepciones
- Registro apropiado en todas las capas
- Mensajes de error amigables para el usuario
- Información detallada de errores para depuración

### 5.3 Diseño de API

#### 5.3.1 Principios de API REST
- URLs basadas en recursos
- Verbos HTTP para operaciones (GET, POST, PUT, DELETE)
- JSON para payloads de petición/respuesta
- Estrategia de versionado para evolución de API

#### 5.3.2 Gestión de Contratos
- DTOs (Objetos de Transferencia de Datos) en proyectos de Contratos
- Interfaces de servicios definiendo operaciones
- Clara separación entre contratos internos y externos

### 5.4 Diseño de Base de Datos

#### 5.4.1 Arquitectura de Datos
- Estructura de base de datos relacional normalizada
- Indexación apropiada para rendimiento
- Restricciones de clave foránea para integridad referencial
- Columnas de auditoría (fechas y usuarios de Creación, Modificación)

#### 5.4.2 Patrones de Acceso a Datos
- Patrón Repository para abstracción de acceso a datos
- Unit of Work para gestión de transacciones
- Procedimientos almacenados para operaciones complejas (donde sea apropiado)

---

## 6. Historias de Usuario y Casos de Uso

### 6.1 Gestión de Pólizas

#### Historia de Usuario: Crear Nueva Póliza de Seguro
**Como** agente de seguros  
**Quiero** crear una nueva póliza de seguro para un cliente  
**Para que** el cliente esté cubierto y la póliza quede registrada en el sistema

**Criterios de Aceptación:**
- El agente puede ingresar información del cliente
- El agente puede seleccionar producto de seguro y opciones de cobertura
- El sistema calcula la prima automáticamente
- El sistema valida toda la información requerida
- El sistema genera número de póliza al momento de la creación
- Los documentos de póliza se generan automáticamente

#### Historia de Usuario: Cotizar Prima de Seguro
**Como** agente de seguros  
**Quiero** generar una cotización para un cliente  
**Para que** el cliente pueda ver el costo antes de comprar

**Criterios de Aceptación:**
- El agente puede ingresar requisitos de cobertura
- El sistema calcula la prima basada en reglas de tarificación
- El sistema muestra desglose detallado de prima
- La cotización puede ser guardada y recuperada después
- La cotización puede ser convertida a póliza

### 6.2 Integración Monge

#### Historia de Usuario: Vender Seguro en Punto de Venta Monge
**Como** representante de ventas de Monge  
**Quiero** vender pólizas de seguro en el punto de venta  
**Para que** los clientes puedan comprar seguro con sus productos

**Criterios de Aceptación:**
- El representante de ventas puede acceder al sistema desde POS Monge
- El sistema proporciona cotizaciones en tiempo real
- La póliza puede ser emitida inmediatamente
- El pago es procesado a través de la pasarela integrada
- Los documentos se generan para el cliente
- La comisión se rastrea para Monge

### 6.3 Autoservicio de Clientes

#### Historia de Usuario: Ver Mis Pólizas en Línea
**Como** cliente  
**Quiero** ver mis pólizas de seguro en línea  
**Para** poder acceder a mi información de pólizas en cualquier momento

**Criterios de Aceptación:**
- El cliente puede iniciar sesión de manera segura
- El cliente ve lista de todas sus pólizas
- El cliente puede ver detalles de pólizas
- El cliente puede descargar documentos de pólizas
- El cliente puede ver historial de pagos

### 6.4 Procesamiento de Pagos

#### Historia de Usuario: Pagar Prima en Línea
**Como** cliente  
**Quiero** pagar mi prima de seguro en línea  
**Para** mantener mi cobertura de manera conveniente

**Criterios de Aceptación:**
- El cliente puede seleccionar método de pago
- El sistema procesa el pago de manera segura
- El cliente recibe confirmación de pago
- El pago se aplica a la póliza correcta
- El recibo se genera y se envía por correo electrónico

### 6.5 Gestión de Documentos

#### Historia de Usuario: Firmar Documentos de Póliza Electrónicamente
**Como** cliente  
**Quiero** firmar documentos de póliza electrónicamente  
**Para** no necesitar visitar una oficina

**Criterios de Aceptación:**
- El sistema envía el documento a DocuSign
- El cliente recibe notificación por correo electrónico
- El cliente puede firmar en cualquier dispositivo
- El documento firmado se almacena en el sistema
- El estado de la póliza se actualiza al firmar

---

## 7. Puntos de Integración

### 7.1 Integración con Sistema Tron

**Propósito**: Integración con sistema de seguros legacy  
**Tipo**: Servicios Web (SOAP/WCF)  
**Flujo de Datos**: Bidireccional

**Operaciones Clave:**
- Sincronización de pólizas
- Recuperación de datos de clientes
- Envío de transacciones
- Actualizaciones de estado

### 7.2 Integración SICOP

**Propósito**: Procesamiento de productos de seguro específicos  
**Tipo**: Servicios WCF  
**Flujo de Datos**: Bidireccional

**Operaciones Clave:**
- Procesamiento de pólizas específicas del producto
- Intercambio de datos
- Validación de reglas de negocio

### 7.3 Integración Monge

**Propósito**: Canal de distribución de socios  
**Tipo**: API REST  
**Flujo de Datos**: Bidireccional

**Operaciones Clave:**
- Generación de cotizaciones
- Emisión de pólizas
- Rastreo de comisiones
- Reportes de ventas

### 7.4 Integración de Pasarela de Pagos

**Propósito**: Procesamiento de pagos en línea  
**Tipo**: API REST / SDK  
**Flujo de Datos**: Saliente (solicitudes de pago), Entrante (callbacks)

**Operaciones Clave:**
- Autorización de pagos
- Captura de pagos
- Procesamiento de reembolsos
- Actualizaciones de estado de pago

### 7.5 Integración DocuSign

**Propósito**: Servicios de firma electrónica  
**Tipo**: API REST  
**Flujo de Datos**: Saliente (envío de documentos), Entrante (webhooks)

**Operaciones Clave:**
- Enviar documentos para firma
- Rastrear estado de firma
- Recuperar documentos firmados
- Notificaciones webhook

### 7.6 Integración de Servicios de Cumplimiento

**Propósito**: Verificaciones de cumplimiento regulatorio  
**Tipo**: API REST  
**Flujo de Datos**: Solicitud/Respuesta

**Operaciones Clave:**
- Verificación KYC
- Screening AML
- Verificación de listas de sanciones
- Validación de identidad

---

## 8. Modelo de Datos (Alto Nivel)

### 8.1 Entidades Principales

#### Póliza (Policy)
- PolicyId (PK)
- PolicyNumber
- CustomerId (FK)
- ProductId (FK)
- StatusId (FK)
- EffectiveDate
- ExpirationDate
- PremiumAmount
- CreatedDate
- ModifiedDate

#### Cliente (Customer)
- CustomerId (PK)
- CustomerType (Individual/Empresa)
- FirstName, LastName
- IdentificationNumber
- Email, Phone
- Address
- CreatedDate
- ModifiedDate

#### Producto (Product)
- ProductId (PK)
- ProductCode
- ProductName
- ProductType
- IsActive
- EffectiveDate
- ExpirationDate

#### Cobertura (Coverage)
- CoverageId (PK)
- PolicyId (FK)
- CoverageType
- Limit
- Deductible
- Premium

#### Pago (Payment)
- PaymentId (PK)
- PolicyId (FK)
- PaymentAmount
- PaymentDate
- PaymentMethod
- PaymentStatus
- TransactionId

#### Documento (Document)
- DocumentId (PK)
- PolicyId (FK)
- DocumentType
- DocumentPath
- SignatureStatus
- CreatedDate

### 8.2 Entidades de Soporte

#### Factores de Tarificación
- Tablas de tarificación específicas del producto
- Reglas de descuentos y recargos
- Datos de territorio y clasificación

#### Estructura de Comisiones
- Tasas de comisión de agentes
- Reglas de comisión de socios (Monge)
- Reglas de cálculo de comisiones

#### Pista de Auditoría
- Rastreo integral de cambios
- Registro de acciones de usuarios
- Registro de eventos del sistema

---

## 9. Consideraciones de Seguridad

### 9.1 Autenticación
- Gestión de credenciales de usuarios
- Autenticación multifactor (donde se requiera)
- Gestión de sesiones
- Políticas de contraseñas

### 9.2 Autorización
- Control de acceso basado en roles
- Permisos a nivel de función
- Seguridad a nivel de datos (nivel de fila)
- Seguridad de endpoints de API

### 9.3 Protección de Datos
- Encriptación en reposo (datos sensibles)
- Encriptación en tránsito (HTTPS/TLS)
- Protección de PII (Información de Identificación Personal)
- Cumplimiento de datos de tarjetas de pago (PCI DSS)

### 9.4 Cumplimiento Normativo
- Regulaciones de privacidad de datos
- Requisitos regulatorios de seguros
- Cumplimiento de servicios financieros
- Requisitos de auditoría y reportes

---

## 10. Despliegue y Operaciones

### 10.1 Modelo de Despliegue
- Hosting on-premises o en la nube
- Despliegue de arquitectura multi-nivel
- Servidor(es) de base de datos
- Servidor(es) de aplicación
- Servidor(es) web

### 10.2 Monitoreo
- Monitoreo de rendimiento de aplicación
- Registro de errores y alertas
- Monitoreo de transacciones
- Verificaciones de salud de integraciones

### 10.3 Respaldo y Recuperación
- Estrategia de respaldo de base de datos
- Respaldo de almacenamiento de documentos
- Plan de recuperación ante desastres
- Planificación de continuidad del negocio

### 10.4 Mantenimiento
- Ventanas de mantenimiento programadas
- Procedimientos de actualización de versiones
- Mantenimiento de base de datos
- Rotación y archivo de logs

---

## 11. Métricas de Éxito

### 11.1 Métricas de Negocio
- Volumen de emisión de pólizas
- Tasa de conversión de cotizaciones
- Tiempo promedio para emitir póliza
- Puntaje de satisfacción del cliente
- Atribución de ventas de socios (Monge)

### 11.2 Métricas Técnicas
- Porcentaje de tiempo de actividad del sistema
- Tiempos de respuesta de API
- Tasas de error
- Tasas de éxito de integraciones
- Métricas de rendimiento de base de datos

### 11.3 Adopción de Usuarios
- Usuarios activos (agentes, clientes)
- Uso del portal de autoservicio
- Uso móvil vs escritorio
- Tasas de utilización de características

---

## 12. Mejoras Futuras

### 12.1 Características Planificadas
- Aplicaciones móviles (iOS, Android)
- Analítica y reportes mejorados
- Suscripción potenciada por IA
- Chatbot para servicio al cliente
- Integración con socios adicionales

### 12.2 Evolución Tecnológica
- Migración a .NET Core/.NET 6+
- Arquitectura de microservicios
- Despliegue cloud-native (Azure, AWS)
- Containerización (Docker, Kubernetes)
- Implementación de API Gateway

---

## 13. Apéndices

### 13.1 Glosario

- **Póliza**: Contrato de seguro entre asegurador y asegurado
- **Prima**: Monto pagado por la cobertura de seguro
- **Cobertura**: Protección específica provista por el seguro
- **Cotización**: Prima estimada antes de emisión de póliza
- **Endoso**: Modificación/enmienda de póliza
- **Tarificación**: Proceso de cálculo de prima de seguro
- **Suscripción**: Evaluación de riesgo y aprobación de póliza
- **Tron**: Sistema legacy de gestión de seguros
- **SICOP**: Sistema de productos de seguros especializados
- **Monge**: Socio minorista para distribución de seguros

### 13.2 Referencias

- Repositorio del proyecto: https://bitbucket.org/mapmcr-web/aliados
- Documentación de .NET Framework 4.8
- Estándares de la industria de seguros
- Requisitos de cumplimiento regulatorio

### 13.3 Control del Documento

- **Versión**: 1.0
- **Creado**: Basado en análisis del workspace
- **Estado**: Borrador
- **Propietario**: Gestión de Producto
- **Revisores**: Equipo de Desarrollo, Stakeholders de Negocio

---

## 14. Contacto y Soporte

### 14.1 Equipo de Desarrollo
- Repositorio primario de desarrollo: Bitbucket (aliados)
- Rama: feature/login (desarrollo activo)

### 14.2 Stakeholders
- Product Owner: [Por definir]
- Líder Técnico: [Por definir]
- Analista de Negocio: [Por definir]

---

*Este Documento de Requisitos del Producto es un documento vivo y debe ser actualizado a medida que el producto evoluciona y se identifican nuevos requisitos.*
