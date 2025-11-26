<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
   xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
   xmlns:msxsl="urn:schemas-microsoft-com:xslt"
   xmlns="http://www.w3.org/1999/xhtml"
   exclude-result-prefixes="msxsl"
   xmlns:user="urn:my-scripts">


  <xsl:output method="text"/>
  <msxsl:script implements-prefix='user' language='CSharp'>
    <msxsl:assembly name="System.Web" />
    <msxsl:using namespace="System.Web" />

    <![CDATA[

    public bool cedulaNacional(string id)

    {

     return Regex.Match(id, @"(^(0[1-9]\-\d{4}-\d{4})$)").Success;

    }
    
    public bool cedulaJuridica(string id)

    {

     return Regex.Match(id, @"(^3-\d{3}-\d{6}$)").Success;

    }
    public bool cedulaResidencia(string id)

    {

     return Regex.Match(id, @"(^1\d{3}-\d+-\d+$)").Success;

    }
    
     public bool cedulaDimex(string id)

    {

     return Regex.Match(id, @"(^(1\d{11})$)").Success;

    } 
      public bool cedulaDidi(string id)

    {

     return Regex.Match(id, @"(^5[0-9]{11}$)").Success;

    } 
    
    public bool cedulaNoResidente(string id)

    {

     return Regex.Match(id, @"(^[^@^!^<^>^&^=^{^}^\(^\)^""^;^']{1}[^@^!^<^>^&^=^{^}^\(^\)^""^;^']{1,49}$)").Success;

    } 
     public bool cedulaGobiernoCentral(string id)

    {

     return Regex.Match(id, @"(^2-\d00-\d{6}$)").Success;

    } 
    
     public bool cedulaInstitucionAutonoma(string id)

    {

     return Regex.Match(id, @"(^4-000-\d{6}$)").Success;

    } 

    ]]>

  </msxsl:script>
  <xsl:template name="VerificarAsegurados" match="/">
    <xsl:variable name="FechaActual" select="ModeloPolizas/Parametros/FechaActual"/>

    <!--Verifica que no existan asegurados repetidos --><!--
    <xsl:for-each select="ModeloPolizas/Datos/Modelo/Poliza">

      <xsl:variable name="NumeroPoliza" select="NumPoliza"/>
      <xsl:variable name="ListaRevisados"/>

      <xsl:call-template name="ValidarAsegurados">
        <xsl:with-param name="NumPoliza" select="$NumeroPoliza"/>
        <xsl:with-param name="ListaElementos" select=".//IdAsegurado[not(.=IdAsegurado)]"/>
      </xsl:call-template>
    </xsl:for-each>-->
    
    <!--Verifica que la informacion del tomador este completa-->
    <xsl:for-each select="ModeloPolizas/Datos/Modelo/Poliza">
      <xsl:variable name="CodEntidad" select="/ModeloPolizas/Datos/Modelo/@EntidadFuente"/>
      <xsl:variable name="NumeroPoliza" select="NumPoliza"/>
      <xsl:variable name="FecSuscripcion" select="FecSuscripcion"/>
      <xsl:variable name="CodProducto" select="CodProducto"/>
      <xsl:variable name="TipoIdentificacion" select="Tomador/TipoIdentificacionTomador"/>
      <xsl:variable name="NombreTomador" select='count(Tomador/NombreTomador)'/>
      <xsl:variable name="PrimerApellido" select='count(Tomador/PrimerApellidoTomador)'/>
      <xsl:variable name="SegundoApellido" select='count(Tomador/SegundoApellidoTomador)'/>
      <xsl:variable name="IdTomador" select="Tomador/IdTomador"/>
      <xsl:variable name="TamanoNombreTomador" select="string-length(normalize-space(Tomador/NombreTomador))" />
      <xsl:variable name="TamanoPrimerApellido" select="string-length(normalize-space(Tomador/PrimerApellidoTomador))" />


      <xsl:variable name="FechaSusc" select="concat(substring($FecSuscripcion, 0, 5),substring($FecSuscripcion, 6, 2),substring($FecSuscripcion, 9, 2))" />

      <xsl:if test="$FechaSusc > $FechaActual">
        <xsl:value-of select="concat('La fecha de suscripción no puede ser mayor a la fecha actual, póliza #: ',$NumeroPoliza,'|&#10;')"/>
      </xsl:if>


      

      <!--Verifica que el número de identificación del tomador coincida con el tipo indicado-->
      <xsl:if test="$TipoIdentificacion = 1">
        <xsl:choose>
          <xsl:when  test="not(user:cedulaNacional($IdTomador))">
            <xsl:value-of select="concat('El número de identificación del tomador con cédula: ',$IdTomador,' no corresponde con el tipo de identificación: 1, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
          </xsl:when >

          <xsl:when  test="format-number(translate(translate(normalize-space($IdTomador),'\-',''),'\0','\9'), '#,####,####') != substring(translate(translate(normalize-space($IdTomador),'\-','\,'),'\0','\9'), 1, 12 )">
            <xsl:value-of select="concat('El número de identificación del tomador con cédula: ',$IdTomador,' no corresponde con el tipo de identificación: 1, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
          </xsl:when >

        </xsl:choose>
      </xsl:if>

      <xsl:if test="$TipoIdentificacion = 2">
        <xsl:choose>

          <xsl:when  test="not(user:cedulaResidencia($IdTomador))">
            <xsl:value-of select="concat('El número de identificación del tomador con cédula: ',$IdTomador,' no corresponde con el tipo de identificación: 2, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
          </xsl:when >

          <xsl:when test="not(starts-with(normalize-space($IdTomador),'1'))">
            <xsl:value-of select="concat('El número de identificación del tomador con cédula: ',$IdTomador,' no corresponde con el tipo de identificación: 2, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
          </xsl:when>
        </xsl:choose>

      </xsl:if>

      <xsl:if test="$TipoIdentificacion = 4">
        <xsl:choose>

          <xsl:when  test="not(user:cedulaJuridica($IdTomador))">
            <xsl:value-of select="concat('El número de identificación del tomador con cédula: ',$IdTomador,' no corresponde con el tipo de identificación: 4, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
          </xsl:when >

          <xsl:when  test="format-number(translate(translate(normalize-space($IdTomador), '\-', ''), '\0', '\9'), '##########') != substring(translate(translate(normalize-space($IdTomador),'\-', ''),'\0', '\9'), 1, 10 )">
            <xsl:value-of select="concat('El número de identificación del tomador con cédula: ',$IdTomador,' no corresponde con el tipo de identificación: 4, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
          </xsl:when >

        </xsl:choose>
      </xsl:if>

      <xsl:if test="$TipoIdentificacion = 5">
        <xsl:choose>

          <xsl:when  test="not(user:cedulaGobiernoCentral($IdTomador))">
            <xsl:value-of select="concat('El número de identificación del tomador con cédula: ',$IdTomador,' no corresponde con el tipo de identificación: 5, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
          </xsl:when >

          <xsl:when  test="format-number(translate(translate(normalize-space($IdTomador), '\-', ''), '\0', '\9'), '##########') != substring(translate(translate(normalize-space($IdTomador),'\-', ''),'\0', '\9'), 1, 10 )">
            <xsl:value-of select="concat('El número de identificación del tomador con cédula: ',$IdTomador,' no corresponde con el tipo de identificación: 5, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
          </xsl:when >

        </xsl:choose>

      </xsl:if>

      <xsl:if test="$TipoIdentificacion = 6">
        <xsl:choose>

          <xsl:when  test="not(user:cedulaInstitucionAutonoma($IdTomador))">
            <xsl:value-of select="concat('El número de identificación del tomador con cédula: ',$IdTomador,' no corresponde con el tipo de identificación: 6, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
          </xsl:when >


          <xsl:when  test="format-number(translate(translate(normalize-space($IdTomador), '\-', ''), '\0', '\9'), '##########') != substring(translate(translate(normalize-space($IdTomador),'\-', ''),'\0', '\9'), 1, 10 )">
            <xsl:value-of select="concat('El número de identificación del tomador con cédula: ',$IdTomador,' no corresponde con el tipo de identificación: 6, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
          </xsl:when >

        </xsl:choose>
      </xsl:if>

      <xsl:if test="$TipoIdentificacion = 7">
        <xsl:if test="not(user:cedulaNoResidente($IdTomador))">
          <xsl:value-of select="concat('El número de identificación del tomador con cédula: ',$IdTomador,' no corresponde a al tipo de identificación: 7, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
        </xsl:if>
      </xsl:if>


      <xsl:if test="$TipoIdentificacion = 8">
        <xsl:choose>

          <xsl:when  test="not(user:cedulaDimex($IdTomador))">
            <xsl:value-of select="concat('El número de identificación del tomador con cédula: ',$IdTomador,' no corresponde con el tipo de identificación: 8, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
          </xsl:when >

          <xsl:when  test="format-number(translate(normalize-space($IdTomador), '\0', '\9'), '############') != format-number(substring(translate(normalize-space($IdTomador),'\0', '\9'), 2, 12 ), '1###########')">
            <xsl:value-of select="concat('El número de identificación del tomador con cédula: ',$IdTomador,' no corresponde con el tipo de identificación: 8, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
          </xsl:when >

        </xsl:choose>
      </xsl:if>

      <xsl:if test="$TipoIdentificacion = 10">
        <xsl:choose>

          <xsl:when  test="not(user:cedulaDidi($IdTomador))">
            <xsl:value-of select="concat('El número de identificación del tomador con cédula: ',$IdTomador,' no corresponde con el tipo de identificación: 10, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
          </xsl:when >


          <xsl:when  test="format-number(translate(normalize-space($IdTomador), '\0', '\9'), '############') != format-number(substring(translate(normalize-space($IdTomador),'\0', '\9'), 2, 12 ), '5###########')">
            <xsl:value-of select="concat('El número de identificación del tomador con cédula: ',$IdTomador,' no corresponde con el tipo de identificación: 10, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
          </xsl:when >

        </xsl:choose>
      </xsl:if>

      <xsl:if test="$TipoIdentificacion != 1">
        <xsl:if test="$NombreTomador = 0 or $TamanoNombreTomador = 0">
          <xsl:value-of select="concat('Debe indicar el nombre para el tomador con cédula: ',$IdTomador,' de la póliza número: ',$NumeroPoliza,'|&#10;')"/>
        </xsl:if>
      </xsl:if>

      <!--Verifica que los apellidos del tomador esten presentes o ausentes según el tipo de identificación-->
      <xsl:if test="$TipoIdentificacion != 4">
        <xsl:if test="$TipoIdentificacion != 5">
          <xsl:if test="$TipoIdentificacion != 6">
            <xsl:if test="$TipoIdentificacion != 1">
              <xsl:if test="$PrimerApellido = 0 or $TamanoPrimerApellido = 0">
                <xsl:value-of select="concat('Debe indicar el primer apellido para el tomador Físico con cédula: ',$IdTomador,' (Tipo Identificación DIMEX, DIDI, Cédula de residencia ó Extranjero no residente), Póliza número: ',$NumeroPoliza,'|&#10;')"/>
              </xsl:if>
            </xsl:if>
          </xsl:if>
        </xsl:if>
      </xsl:if>


    </xsl:for-each>

    <!--Verifica que la informacion del beneficiario este completa-->
    <xsl:for-each select="ModeloPolizas/Datos/Modelo/Poliza">
      <xsl:variable name="NumeroPoliza" select="NumPoliza"/>

      <xsl:for-each select="Asegurados/Asegurado">
        <xsl:variable name="NombreAsegurado" select='count(NombreAsegurado)'/>
        <xsl:variable name="PrimerApellidoAsegurado" select='count(PrimerApellidoAsegurado)'/>
        <xsl:variable name="SegundoApellidoAsegurado" select='count(SegundoApellidoAsegurado)'/>
        <xsl:variable name="TipoIdentificacionAsegurado" select="TipoIdentificacionAsegurado"/>
        <xsl:variable name="IdAsegurado" select="IdAsegurado"/>
        <xsl:variable name="FecInclusion" select="FecInclusion"/>
        <xsl:variable name="TamanoNombreAsegurado" select="string-length(normalize-space(NombreAsegurado))"/>
        <xsl:variable name="TamanoPrimerApellidoAsegurado" select="string-length(normalize-space(PrimerApellidoAsegurado))"/>

        <xsl:variable name="FecInclu" select="concat(substring($FecInclusion, 0, 5),substring($FecInclusion, 6, 2),substring($FecInclusion, 9, 2))" />

        <xsl:if test="$FecInclu > $FechaActual">
          <xsl:value-of select="concat('La fecha de inclusión del asegurado con cédula: ',$IdAsegurado,', no puede ser mayor a la fecha actual, póliza #: ',$NumeroPoliza,'|&#10;')"/>
        </xsl:if>

        <!--Verifica que el número de identificación del asegurado coincida con el tipo indicado-->
        <xsl:if test="$TipoIdentificacionAsegurado = 1">
          <xsl:choose>

            <xsl:when  test="not(user:cedulaNacional($IdAsegurado))">
              <xsl:value-of select="concat('El número de identificación del Asegurado con cédula: ',$IdAsegurado,' no corresponde con el tipo de identificación: 1, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
            </xsl:when >

            <xsl:when  test="format-number(translate(translate(normalize-space($IdAsegurado),'\-',''),'\0','\9'), '#,####,####') != substring(translate(translate(normalize-space($IdAsegurado),'\-','\,'),'\0','\9'), 1, 12 )">
              <xsl:value-of select="concat('El número de identificación del Asegurado con cédula: ',$IdAsegurado,' no corresponde con el tipo de identificación: 1, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
            </xsl:when >

          </xsl:choose>
        </xsl:if>

        <xsl:if test="$TipoIdentificacionAsegurado = 2">
          <xsl:choose>
            <xsl:when  test="not(user:cedulaResidencia($IdAsegurado))">
              <xsl:value-of select="concat('El número de identificación del Asegurado con cédula: ',$IdAsegurado,' no corresponde con el tipo de identificación: 2, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
            </xsl:when >
            <xsl:when test="not(starts-with(normalize-space($IdAsegurado),'1'))">
              <xsl:value-of select="concat('El número de identificación del Asegurado  con cédula: ',$IdAsegurado,' no corresponde con el tipo de identificación: 2, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
            </xsl:when>
          </xsl:choose>
        </xsl:if>


        <xsl:if test="$TipoIdentificacionAsegurado = 7">
          <xsl:if test="not(user:cedulaNoResidente($IdAsegurado))">
            <xsl:value-of select="concat('El número de identificación del Asegurado con cédula: ',$IdAsegurado,' no corresponde a al tipo de identificación: 7, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
          </xsl:if>
        </xsl:if>

        <xsl:if test="$TipoIdentificacionAsegurado = 8">
          <xsl:choose>

            <xsl:when  test="not(user:cedulaDimex($IdAsegurado))">
              <xsl:value-of select="concat('El número de identificación del Asegurado con cédula: ',$IdAsegurado,' no corresponde con el tipo de identificación:8, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
            </xsl:when >

            <xsl:when  test="format-number(translate(normalize-space($IdAsegurado), '\0', '\9'), '############') != format-number(substring(translate(normalize-space($IdAsegurado),'\0', '\9'), 2, 12 ), '1###########')">
              <xsl:value-of select="concat('El número de identificación del Asegurado con cédula: ',$IdAsegurado,' no corresponde con el tipo de identificación: 8, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
            </xsl:when >

          </xsl:choose>
        </xsl:if>

        <xsl:if test="$TipoIdentificacionAsegurado = 10">
          <xsl:choose>

            <xsl:when  test="not(user:cedulaDidi($IdAsegurado))">
              <xsl:value-of select="concat('El número de identificación del Asegurado con cédula: ',$IdAsegurado,' no corresponde con el tipo de identificación: 10, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
            </xsl:when >

            <xsl:when  test="format-number(translate(normalize-space($IdAsegurado), '\0', '\9'), '############') != format-number(substring(translate(normalize-space($IdAsegurado),'\0', '\9'), 2, 12 ), '5###########')">
              <xsl:value-of select="concat('El número de identificación del Asegurado  con cédula: ',$IdAsegurado,' no corresponde con el tipo de identificación: 10, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
            </xsl:when >

          </xsl:choose>
        </xsl:if>


        <!--Verifica que los apellidos del asegurado esten presentes o ausentes según el tipo de identificación-->
        <xsl:if test="$TipoIdentificacionAsegurado != 1">
          <xsl:if test="$NombreAsegurado = 0 or $TamanoNombreAsegurado = 0">
            <xsl:value-of select="concat('Debe indicar el nombre para el Asegurado con cédula: ',$IdAsegurado,' de la póliza número: ',$NumeroPoliza,'|&#10;')"/>
          </xsl:if>
          <xsl:if test="$PrimerApellidoAsegurado = 0 or $TamanoPrimerApellidoAsegurado = 0">
            <xsl:value-of select="concat('Debe indicar el primer apellido para un asegurado Físico  con cédula: ',$IdAsegurado,' (Tipo Identificacion 8 ó 10), Póliza número: ',$NumeroPoliza,'|&#10;')"/>
          </xsl:if>
        </xsl:if>


        <xsl:for-each select="Beneficiarios/Beneficiario">
          <xsl:variable name="TipoDesignacion" select="TipoDesignacion"/>
          <xsl:variable name="CountTipoIdentificacion" select="count(TipoIdentificacionBeneficiario)"/>
          <xsl:variable name="CIdBeneficiario" select='count(IdBeneficiario)'/>
          <xsl:variable name="Nombre" select='count(NombreBeneficiario)'/>
          <xsl:variable name="PrimerApellido" select='count(PrimerApellidoBeneficiario)'/>
          <xsl:variable name="SegundoApellido" select='count(SegundoApellidoBeneficiario)'/>
          <xsl:variable name="Descripcion" select='count(Descripcion)'/>
          <xsl:variable name="TipoIdentificacion" select="TipoIdentificacionBeneficiario"/>
          <xsl:variable name="IdBeneficiario" select='IdBeneficiario'/>
          <xsl:variable name="TamanoNombre" select="string-length(normalize-space(NombreBeneficiario))"/>
          <xsl:variable name="TamanoPrimerApellido" select="string-length(normalize-space(PrimerApellidoBeneficiario))"/>
          <xsl:variable name="TamanoDescripcion" select="string-length(normalize-space(Descripcion))"/>

          <xsl:if test="$TipoDesignacion = 1">
            <xsl:if test="$CountTipoIdentificacion = 0">
              <xsl:value-of select="concat('Debe indicar el tipo de identificación para una asignación específica, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
            </xsl:if>
            <xsl:if test="$CIdBeneficiario = 0">
              <xsl:value-of select="concat('Debe indicar la identificación del beneficiario para una asignación específica, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
            </xsl:if>

            <xsl:if test="$TipoIdentificacion != 1">
              <xsl:if test="$Nombre = 0 or $TamanoNombre = 0">
                <xsl:value-of select="concat('Debe indicar el nombre del beneficiario para una asignación específica, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
              </xsl:if>
            </xsl:if>

            <xsl:if test="$CountTipoIdentificacion = 1">

              <!--Verifica que el número de identificación del beneficiario coincida con el tipo indicado-->
              <xsl:if test="$TipoIdentificacion = 1">
                <xsl:choose>

                  <xsl:when  test="not(user:cedulaNacional($IdBeneficiario))">
                    <xsl:value-of select="concat('El número de identificación del beneficiario con cédula: ',$IdBeneficiario,' no corresponde con el tipo de identificación: 1, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
                  </xsl:when >

                  <xsl:when  test="format-number(translate(translate(normalize-space($IdBeneficiario),'\-',''),'\0','\9'), '#,####,####') != substring(translate(translate(normalize-space($IdBeneficiario),'\-','\,'),'\0','\9'), 1, 12 )">
                    <xsl:value-of select="concat('El número de identificación del beneficiario con cédula: ',$IdBeneficiario,'  no corresponde con el tipo de identificación: 1, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
                  </xsl:when >

                </xsl:choose>
              </xsl:if>

              <xsl:if test="$TipoIdentificacion = 2">
                <xsl:choose>
                  <xsl:when  test="not(user:cedulaResidencia($IdBeneficiario))">
                    <xsl:value-of select="concat('El número de identificación del beneficiario con cédula: ',$IdBeneficiario,' no corresponde con el tipo de identificación: 2, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
                  </xsl:when >

                  <xsl:when test="not(starts-with(normalize-space($IdBeneficiario),'1'))">
                    <xsl:value-of select="concat('El número de identificación del beneficiario con cédula: ',$IdBeneficiario,'  no corresponde con el tipo de identificación: 2, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
                  </xsl:when>

                </xsl:choose>
              </xsl:if>

              <xsl:if test="$TipoIdentificacion = 4">
                <xsl:choose>

                  <xsl:when  test="not(user:cedulaJuridica($IdBeneficiario))">
                    <xsl:value-of select="concat('El número de identificación del beneficiario con cédula: ',$IdBeneficiario,' no corresponde con el tipo de identificación: 4, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
                  </xsl:when >

                  <xsl:when  test="format-number(translate(translate(normalize-space($IdBeneficiario), '\-', ''), '\0', '\9'), '##########') != substring(translate(translate(normalize-space($IdBeneficiario),'\-', ''),'\0', '\9'), 1, 10 )">
                    <xsl:value-of select="concat('El número de identificación del beneficiario con cédula: ',$IdBeneficiario,'  no corresponde con el tipo de identificación: 4, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
                  </xsl:when >

                </xsl:choose>
              </xsl:if>

              <xsl:if test="$TipoIdentificacion = 5">
                <xsl:choose>

                  <xsl:when  test="not(user:cedulaGobiernoCentral($IdBeneficiario))">
                    <xsl:value-of select="concat('El número de identificación del beneficiario con cédula: ',$IdBeneficiario,' no corresponde con el tipo de identificación: 5, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
                  </xsl:when >


                  <xsl:when  test="format-number(translate(translate(normalize-space($IdBeneficiario), '\-', ''), '\0', '\9'), '##########') != substring(translate(translate(normalize-space($IdBeneficiario),'\-', ''),'\0', '\9'), 1, 10 )">
                    <xsl:value-of select="concat('El número de identificación del beneficiario con cédula: ',$IdBeneficiario,'  no corresponde con el tipo de identificación: 5, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
                  </xsl:when >

                </xsl:choose>
              </xsl:if>

              <xsl:if test="$TipoIdentificacion = 6">
                <xsl:choose>

                  <xsl:when  test="not(user:cedulaInstitucionAutonoma($IdBeneficiario))">
                    <xsl:value-of select="concat('El número de identificación del beneficiario con cédula: ',$IdBeneficiario,' no corresponde con el tipo de identificación: 6, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
                  </xsl:when >


                  <xsl:when  test="format-number(translate(translate(normalize-space($IdBeneficiario), '\-', ''), '\0', '\9'), '##########') != substring(translate(translate(normalize-space($IdBeneficiario),'\-', ''),'\0', '\9'), 1, 10 )">
                    <xsl:value-of select="concat('El número de identificación del beneficiario con cédula: ',$IdBeneficiario,'  no corresponde con el tipo de identificación: 2, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
                  </xsl:when >

                </xsl:choose>
              </xsl:if>

              <xsl:if test="$TipoIdentificacion = 7">
                <xsl:if test="not(user:cedulaNoResidente($IdBeneficiario))">
                  <xsl:value-of select="concat('El número de identificación del beneficiario con cédula: ',$IdBeneficiario,' no corresponde a al tipo de identificación: 7, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
                </xsl:if>
              </xsl:if>

              <xsl:if test="$TipoIdentificacion = 8">
                <xsl:choose>

                  <xsl:when  test="not(user:cedulaDimex($IdBeneficiario))">
                    <xsl:value-of select="concat('El número de identificación del beneficiario con cédula: ',$IdBeneficiario,' no corresponde con el tipo de identificación: 8, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
                  </xsl:when >

                  <xsl:when  test="format-number(translate(normalize-space($IdBeneficiario), '\0', '\9'), '############') != format-number(substring(translate(normalize-space($IdBeneficiario),'\0', '\9'), 2, 12 ), '1###########')">
                    <xsl:value-of select="concat('El número de identificación del beneficiario con cédula: ',$IdBeneficiario,'  no corresponde con el tipo de identificación: 8, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
                  </xsl:when >

                </xsl:choose>
              </xsl:if>

              <xsl:if test="$TipoIdentificacion = 10">
                <xsl:choose>

                  <xsl:when  test="not(user:cedulaDidi($IdBeneficiario))">
                    <xsl:value-of select="concat('El número de identificación del beneficiario con cédula: ',$IdBeneficiario,' no corresponde con el tipo de identificación: 10, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
                  </xsl:when >

                  <xsl:when  test="format-number(translate(normalize-space($IdBeneficiario), '\0', '\9'), '############') != format-number(substring(translate(normalize-space($IdBeneficiario),'\0', '\9'), 2, 12 ), '5###########')">
                    <xsl:value-of select="concat('El número de identificación del beneficiario con cédula: ',$IdBeneficiario,'  no corresponde con el tipo de identificación: 10, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
                  </xsl:when >

                </xsl:choose>
              </xsl:if>

              <!--Verifica que los apellidos del beneficiario esten presentes o ausentes según el tipo de identificación-->

              <xsl:if test="$TipoIdentificacion != 4">
                <xsl:if test="$TipoIdentificacion != 5">
                  <xsl:if test="$TipoIdentificacion != 6">
                    <xsl:if test="$TipoIdentificacion != 1">
                      <xsl:if test="$PrimerApellido = 0 or $TamanoPrimerApellido = 0">
                        <xsl:value-of select="concat('Debe indicar el primer apellido para el beneficiario Físico con cédula: ',$IdBeneficiario,' (Tipo Identificación DIMEX, DIDI, Cédula de residencia ó Extranjero no residente), Póliza número: ',$NumeroPoliza,'|&#10;')"/>
                      </xsl:if>
                    </xsl:if>
                  </xsl:if>
                </xsl:if>
              </xsl:if>
            </xsl:if>

          </xsl:if>

          <xsl:if test="$TipoDesignacion = 2">
            <xsl:if test="$Descripcion = 0 or $TamanoDescripcion = 0">
              <xsl:value-of select="concat('Debe indicar el beneficiario en el espacio descripción, Póliza número: ',$NumeroPoliza,'|&#10;')"/>
            </xsl:if>
          </xsl:if>
        </xsl:for-each>
      </xsl:for-each>
      
    </xsl:for-each>

  </xsl:template>

  <!--<xsl:template name="ValidarAsegurados">
    <xsl:param name="ListaElementos"/>
    <xsl:param name="ListaRevisados"/>
    <xsl:param name="NumPoliza"/>

    <xsl:variable name="Elemento" select="$ListaElementos[1]"/>
    
    <xsl:if test="$Elemento">
      <xsl:if test="contains($ListaRevisados, concat('[',$Elemento,']'))">
        <xsl:value-of select="concat('El asegurado con la identificación: ', $Elemento,' aparece mas de una vez en la póliza: ', $NumPoliza, '|&#10;')"/>
      </xsl:if>
      <xsl:call-template name="ValidarAsegurados">
        <xsl:with-param name="ListaElementos" select="$ListaElementos[position() &gt; 1]"/>
        <xsl:with-param name="ListaRevisados" select="concat($ListaRevisados, '[', $Elemento, ']')"/>
        <xsl:with-param name="NumPoliza" select='$NumPoliza'/>
      </xsl:call-template>

    </xsl:if>
  </xsl:template>-->


</xsl:stylesheet>

