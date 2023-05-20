DELETE TEMPLATE where key='MapfreMas_Solicitud';

insert into TEMPLATE (ID, COMPANYID, KEY, DESCRIPTION, SUBJECT, BODY, UPDATEUSERCODE, UPDATEDATE, EMAILTO, MASTERTEMPLATEID)
values (2001, 0, 'MapfreMas_Solicitud', 'Envío de solicitud de seguro MapfreMas', 'Notificación de solicitud de póliza', '<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8" />
    <title></title>
</head>

<body>
    <font face="tahoma" size=2>Estimado(a) Usuario(a),</font>
    <br />
    <br />
    <br />
    <font face="tahoma" size=2>Para </font>
    <font face="tahoma" size=2><b>MAPFRE Seguros Costa Rica </b></font>
    <font face="tahoma" size=2>es un placer atenderle en su Solictud de seguro y al mismo tiempo agradecemos la
        confianza y preferencia que ha depositado en nosotros.</font>
    <br />
    <br />
    <font face="tahoma" size=2>Nos permitimos remitir la solicitud de seguro correspondiente a su presupuesto número
    </font>
    <font face="tahoma" size=2><b>{Data.presupuesto}</b></font>
    <font face="tahoma" size=2></font>
    <br />
    <br />
    <font face="tahoma" size=2>Quedamos a su entera disposición para cualquier consulta. Contáctenos a través de los
        siguientes medios:</font>
    <br />
    <br />
    <ul>
        <li>
            <font face="tahoma" size=2>Linea Gratuita 800 MAPFRE(8000 627373)</font>
        </li>
        <li>
            <font face="tahoma" size=2>Central Telefónica 4104-0200</font>
        </li>
        <li>
            <font face="tahoma" size=2>servicioalcliente@mapfrecr.com</font>
        </li>
    </ul>
    <br />
    <br />
    <font face="tahoma" size=2>Estamos en la mejor disposición de brindarle el mejor servicio.</font>
    <br />
    <br />
    <center>
        <font face="tahoma" size=2><b>Atentamente,</b></font>
    </center>
    <center>
        <font face="tahoma" size=2><b>MAPFRE Seguros Costa Rica</b></font>
    </center>
</body>

</html>', 202305, to_date('31-05-2023', 'dd-mm-yyyy'), null, 0);