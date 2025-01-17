DELETE FROM template WHERE id=3000;
INSERT INTO TEMPLATE (ID, COMPANYID, "KEY", DESCRIPTION, SUBJECT, "BODY", UPDATEUSERCODE, UPDATEDATE, EMAILTO, MASTERTEMPLATEID) VALUES(3000, 0, 'Send_PaymentLink', 'Envio de enlace de pago', 'Enlace de Pago Mapfre Seguros Costas Rica S.A.', '<!doctype html>
<html lang=es>
<head>
<meta charset=UTF-8>
<meta name=viewport content="width=device-width,initial-scale=1">
<title>Email - Finalización de Compra</title>
</head>
<body style=font-family:Arial,sans-serif;margin:0;padding:0;background-color:#f9f9f9;color:#333>
<div style="max-width:600px;margin:0 auto;background-color:#fff;padding:20px;box-shadow:0 2px 4px rgba(0,0,0,.1)">
<div style=text-align:center;margin-bottom:20px>
<img src={app.url}/images/email/image001-min.png alt="Logo Mapfre">
</div>
<div style="padding:0 20px">
<p style=font-size:1.5em>Estimado señor/a: {Data.payinfo.FirstName} {Data.payinfo.LastName}</p>
<img src={app.url}/images/email/image_family-min.png alt=Familia style="width:100%;max-width:500px;height:auto;margin:20px 0;padding:15px 20px">
<div style=display:flex;align-items:center>
<img src={app.url}/images/email/check_icon-min.png alt="Lock Icon" style=float:left;margin-right:10px;height:50px;width:auto>
<p style=font-size:1.3em><strong>De parte de Mapfre Seguros Costa Rica le estamos enviando este enlace de pago.</strong></p>
</div>
<table style="width:100%;border-collapse:collapse;margin:20px 0">
<tr>
<th colspan=2 style=background-color:#f5f5f5;font-weight:400;padding:10px;text-align:left>
<img src={app.url}/images/email/user_icon-min.png alt="User Icon" style=width:24px;height:auto;vertical-align:middle;margin-right:5px;float:right>
Datos del Beneficiario
</th>
</tr>
<tr>
<td style=border:0;padding:10px;text-align:left>Nombre:</td>
<td style=border:0;padding:10px;text-align:left>{Data.payinfo.FirstName} {Data.payinfo.LastName}</td>
</tr>
<tr>
<td style=border:0;padding:10px;text-align:left>Documento:</td>
<td style=border:0;padding:10px;text-align:left>{Data.payinfo.DocumentType} {Data.payinfo.Document}</td>
</tr>
<tr>
<td style=border:0;padding:10px;text-align:left>Email:</td>
<td style=border:0;padding:10px;text-align:left>{Data.payinfo.Email}</td>
</tr>
<tr>
<td style=border:0;padding:10px;text-align:left>Teléfono:</td>
<td style=border:0;padding:10px;text-align:left>{Data.payinfo.Mobile}</td>
</tr>
<tr>
<th colspan=2 style=background-color:#f5f5f5;font-weight:400;padding:10px;text-align:left>
<img src={app.url}/images/email/info_icon-min.png alt="Cart Icon" style=width:24px;height:auto;vertical-align:middle;margin-right:5px;float:right>
Resumen de compra
</th>
</tr>
<tr>
<td style=border:0;padding:10px;text-align:left>Producto:</td>
<td style=border:0;padding:10px;text-align:left>{Data.payinfo.Description}</td>
</tr>
<tr>
<td style=border:0;padding:10px;text-align:left>Referencia de pago:</td>
<td style=border:0;padding:10px;text-align:left>{Data.session.Reference}</td>
</tr>
<tr>
<td style=border:0;padding:10px;text-align:left>Fecha de creación del enlace:</td>
<td style=border:0;padding:10px;text-align:left>{Hoy}</td>
</tr>
</table>
<p style=font-size:1.2em>
<img src={app.url}/images/email/info_icon-min.png alt="Info Icon" style=width:24px;height:auto;vertical-align:middle;margin-right:5px>
Si desea pagar su póliza, favor dar click en el botón Pague aquí.
</p>
<p style="text-align:center;padding:50px 0">
<a href={Data.session.ProcessUrl} style="padding:10px 20px;color:#fff;background-color:#d9534f;text-decoration:none;border-radius:5px;font-size:1em;text-align:center;display:inline-block">Pague aquí</a>
</p>
</div>
<div style=text-align:center;font-size:.9em;color:#666;margin-top:20px>
<img src={app.url}/images/email/image010-min.jpg alt="Footer Logo">
</div>
</div>
</body>
</html>', 6329, TIMESTAMP '2023-05-08 00:00:00.000000', NULL, 0);