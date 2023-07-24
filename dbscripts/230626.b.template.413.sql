INSERT INTO TEMPLATE (ID, COMPANYID, "KEY", DESCRIPTION, SUBJECT, "BODY", UPDATEUSERCODE, UPDATEDATE, EMAILTO, MASTERTEMPLATEID) VALUES(413, 4, 'Notify_RequestOnReviewMapfre', 'Bayer. La solicitud requiere ser revisada (emisión mayor a 90 días)', 'La solicitud #I-{Data.Id}, requiere ser revisada ({Data.Bayer.ContractorDesc} - Emisión mayor a 90 días)', '    <p>El usuario {CurrentUser.FirstName} {CurrentUser.LastName}, ha registrado la solictud #I-{Data.Id}, es necesario su revision.</p>
    <h4>Datos de la poliza</h4>
    <p style=''padding-left: 30px;''>
        Tipo: {Data.LineOfBusinessDesc}<br>
    </p>
    <h4>Datos del asegurado</h4>
    <p style=''padding-left: 30px;''>
        Nombre: {Data.PrimaryInsured.FirstName} {Data.PrimaryInsured.MiddleName} {Data.PrimaryInsured.LastName} {Data.PrimaryInsured.SecondLastName}<br>
    </p>', 6329, TIMESTAMP '1970-02-07 00:00:00.000000', '{UserRoleList.Mapfre}', NULL);
