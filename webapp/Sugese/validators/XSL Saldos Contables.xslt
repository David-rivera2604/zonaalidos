<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:myObj="urn:bccrfunciones" version="1.0">
  <xsl:output method="text"/>
  <xsl:variable name="Tab" select="'&#9;'"/>
  <xsl:variable name="Nl" select="'&#10;'"/>
  <xsl:template name="EncabezadoArchivoTrimestral" match="*/Encabezado"/>
  <!--Obtiene el path del nodo-->
  <xsl:template name="ObtenerFullPath">
    <xsl:param name="Nodo" select="."/>
    <xsl:param name="Path"/>
    <xsl:param name="Ancestros"/>
    <xsl:param name="Inicio"/>
    <xsl:choose>
      <xsl:when test="not($Path)">
        <xsl:for-each select="$Nodo">
          <xsl:call-template name="ObtenerFullPath">
            <xsl:with-param name="Nodo" select="$Nodo"/>
            <xsl:with-param name="Path" select="'.'"/>
            <xsl:with-param name="Ancestros" select="ancestor::*"/>
            <xsl:with-param name="Inicio" select="$Inicio"/>
          </xsl:call-template>
        </xsl:for-each>
      </xsl:when>
      <xsl:otherwise>
        <xsl:variable name="Padre" select="$Ancestros[1]"/>
        <xsl:choose>
          <xsl:when test="$Padre">
            <xsl:call-template name="ObtenerFullPath">
              <xsl:with-param name="Nodo" select="$Nodo"/>
              <xsl:with-param name="Path" select="concat($Path, '&lt;', local-name($Padre), '&gt;')"/>
              <xsl:with-param name="Ancestros" select="$Ancestros[position() &gt; 1]"/>
              <xsl:with-param name="Inicio" select="$Inicio"/>
            </xsl:call-template>
          </xsl:when>
          <xsl:otherwise>
            <xsl:variable name="InfoAncestro">
              <xsl:choose>
                <xsl:when test="$Inicio">
                  <xsl:value-of select="concat('En el nodo &lt;', local-name($Inicio), '&gt;', '@', local-name($Inicio/@*[1]), '=',$Inicio/@*[1],'. ')"/>
                </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="''"/>
                </xsl:otherwise>
              </xsl:choose>
            </xsl:variable>
            <xsl:value-of select="concat($Tab, $InfoAncestro, $Path,'&lt;',local-name($Nodo), '&gt;', $Nl)"/>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--Reemplaza caracteres-->
  <xsl:template name="replaceCharsInString">
    <xsl:param name="stringIn"/>
    <xsl:param name="charsIn"/>
    <xsl:param name="charsOut"/>
    <xsl:choose>
      <xsl:when test="contains($stringIn,$charsIn)">
        <xsl:value-of select="concat(substring-before($stringIn,$charsIn),$charsOut)"/>
        <xsl:call-template name="replaceCharsInString">
          <xsl:with-param name="stringIn" select="substring-after($stringIn,$charsIn)"/>
          <xsl:with-param name="charsIn" select="$charsIn"/>
          <xsl:with-param name="charsOut" select="$charsOut"/>
        </xsl:call-template>
      </xsl:when>
      <xsl:otherwise>
        <xsl:value-of select="$stringIn"/>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--retorna la suma de los elmentos y atributos de un nodo-->
  <xsl:template name="SumarAtributosYElementos">
    <!--captura los valores de los atributos e hijos del nodo-->
    <xsl:variable name="valores">
      <xsl:for-each select="./*">
        <xsl:choose>
          <xsl:when test="count(./@*) &gt; 0">
            <!--Si tiene atributos-->
            <xsl:value-of select="concat(./@*[1], '|')"/>
          </xsl:when>
          <xsl:otherwise>
            <xsl:value-of select="concat(., '|')"/>
            <!--Si tiene elementos-->
          </xsl:otherwise>
        </xsl:choose>
      </xsl:for-each>
    </xsl:variable>
    <!--Suma-->
    <xsl:value-of select="myObj:BccrSum($valores)"/>
  </xsl:template>
  <!--    Valida una cuenta madre    1. Si tiene un total comprueba que tenga cuentas hijas    2. Si tiene un total comprueba que la suma de las cuentas hijas sumen el total      -->
  <xsl:template name="ValidarCuentaMadre">
    <xsl:choose>
      <xsl:when test="count(./@*) &gt; 0 and count(./*) = 0">
        <xsl:value-of select="concat('La [', local-name(.), '] ', ' debe indicar al menos una de sus cuentas hijas ', $Nl)"/>
      </xsl:when>
      <xsl:otherwise>
        <xsl:if test="count(./*) &gt; 0">
          <xsl:variable name="suma">
            <xsl:call-template name="SumarAtributosYElementos"/>
          </xsl:variable>
          <xsl:if test="(myObj:BccrDecimal(./@*[1]) - myObj:BccrDecimal($suma) != 0) and (not(contains(',cta_80000000000000,cta_60000000000000,', concat(',',local-name(.),',')))) ">
            <xsl:value-of select="concat('El atributo @',local-name(./@*[1]), ' de la [', local-name(.), '] ', ' no coincide con la sumatoria de sus cuentas hijas.', $Nl)"/>
          </xsl:if>
          <xsl:for-each select="./*">
            <xsl:call-template name="ValidarCuentaMadre"/>
          </xsl:for-each>
        </xsl:if>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--Valida la cuenta 80000000000000-->
  <xsl:template name="Totalcta_80000000000000">
    <xsl:param name="Nodo"/>
    <xsl:variable name="Suman">
      <xsl:value-of select="myObj:BccrSum(concat($Nodo/cta_80100000000000/@*,'|',$Nodo/cta_80300000000000/@*))"/>
    </xsl:variable>
    <xsl:variable name="Restan">
      <xsl:value-of select="myObj:BccrSum(concat($Nodo/cta_80200000000000,'|',$Nodo/cta_80400000000000))"/>
    </xsl:variable>
    <xsl:if test="((myObj:BccrDecimal(myObj:BccrDecimal($Nodo/@*)) != myObj:BccrResta($Suman, $Restan)))">
      <xsl:value-of select="concat('El valor del atributo @', local-name ($Nodo/@*),' del nodo &lt;', local-name ($Nodo), '&gt; es ', ($Nodo/@*), ', y no coincide con la suma de los elementos &lt;',local-name($Nodo/cta_80100000000000), '&gt;&lt;',local-name($Nodo/cta_80300000000000),'&gt; menos &lt;',local-name($Nodo/cta_80200000000000),'&gt;&lt;',local-name($Nodo/cta_80400000000000),$Nl)"/>
    </xsl:if>
    <xsl:if test="($Nodo/@*!=0.00)">
      <xsl:value-of select="concat('El valor del atributo @', local-name ($Nodo/@*),' del nodo &lt;', local-name ($Nodo), '&gt; es ', ($Nodo/@*),' el cual debe ser cero.',$Nl)"/>
    </xsl:if>
  </xsl:template>
  <!--Valida la cuenta 60000000000000-->
  <xsl:template name="Totalcta_60000000000000">
    <xsl:param name="Nodo"/>
    <xsl:variable name="Suman">
      <xsl:value-of select="myObj:BccrSum(concat($Nodo/cta_60100000000000/@*,'|',$Nodo/cta_60300000000000/@*))"/>
    </xsl:variable>
    <xsl:variable name="Restan">
      <xsl:value-of select="myObj:BccrSum(concat($Nodo/cta_60200000000000/@*,'|',$Nodo/cta_60400000000000/@*))"/>
    </xsl:variable>
    <xsl:if test="((myObj:BccrDecimal(myObj:BccrDecimal($Nodo/@*)) != myObj:BccrResta($Suman, $Restan)))">
      <xsl:value-of select="concat('El valor del atributo @', local-name ($Nodo/@*),' del nodo &lt;', local-name ($Nodo), '&gt; es ', ($Nodo/@*), ', y no coincide con la suma de los elementos &lt;',local-name($Nodo/cta_60100000000000), '&gt;&lt;',local-name($Nodo/cta_60300000000000),'&gt; menos &lt;',local-name($Nodo/cta_60200000000000),'&gt;&lt;',local-name($Nodo/cta_60400000000000),$Nl)"/>
    </xsl:if>
    <xsl:if test="($Nodo/@*!=0.00)">
      <xsl:value-of select="concat('El valor del atributo @', local-name ($Nodo/@*),' del nodo &lt;', local-name ($Nodo), '&gt; es ', ($Nodo/@*), ' el cual debe ser cero' ,$Nl)"/>
    </xsl:if>
  </xsl:template>
  <!--Adecuacion contable-->
  <xsl:template name="Totalcuentas">
    <xsl:param name="Nodo"/>
    <xsl:variable name="Suman">
      <xsl:value-of select="myObj:BccrSum(concat($Nodo/cta_10000000000000/@*,'|',$Nodo/cta_40000000000000/@*))"/>
    </xsl:variable>
    <xsl:variable name="Restan">
      <xsl:value-of select="myObj:BccrSum(concat($Nodo/cta_20000000000000/@*,'|',$Nodo/cta_30000000000000/@*,'|',$Nodo/cta_50000000000000/@*))"/>
    </xsl:variable>
    <xsl:variable name="Resultado">
      <xsl:value-of select="myObj:BccrDecimal(myObj:BccrResta($Suman, $Restan))"/>
    </xsl:variable>
    <xsl:if test="not($Resultado= 0.00 or (myObj:BccrDecimal($Resultado) &lt; 1.00 and myObj:BccrDecimal($Resultado) &gt; -1.00))">
      <xsl:value-of select="concat('El valor de la operación &lt;',local-name($Nodo/cta_10000000000000/@*) ,'&gt; + &lt;',local-name($Nodo/cta_40000000000000/@*),'&gt; - &lt;',local-name($Nodo/cta_20000000000000/@*),'&gt; - &lt;',local-name($Nodo/cta_30000000000000/@*),'&gt; - &lt;',local-name($Nodo/cta_50000000000000/@*),'&gt;, es ',$Resultado,' y la misma debe ser cero.',$Nl)"/>
    </xsl:if>
  </xsl:template>
  <!--[X]ValidacionModeloSaldosContables-->
  <xsl:template name="ValidacionModeloSaldosContables" match="ModeloSaldosContables/Datos/Modelo">
    <xsl:for-each select="./*">
      <xsl:call-template name="ValidarCuentaMadre"/>
    </xsl:for-each>
    <xsl:call-template name="Totalcta_60000000000000">
      <xsl:with-param name="Nodo" select="cta_60000000000000"/>
    </xsl:call-template>
    <xsl:call-template name="Totalcta_80000000000000">
      <xsl:with-param name="Nodo" select="cta_80000000000000"/>
    </xsl:call-template>
    <xsl:call-template name="Totalcuentas">
      <xsl:with-param name="Nodo" select="."/>
    </xsl:call-template>
  </xsl:template>
</xsl:stylesheet>
