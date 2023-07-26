UPDATE TEMPLATE SET COMPANYID=4, "KEY"='Notify_InclusionInMedical', DESCRIPTION='Bayer. Inclusión en Medical', SUBJECT='La solicitud #I-{Data.Id}, fue incluida en Medical ({Data.Bayer.ContractorDesc})', "BODY"='    <p>La solicitud #I-{Data.Id} del usuario {CurrentUser.FirstName} {CurrentUser.LastName}, ha sido debidamente revisada por RRHH y firmada por el solicitante, en consecuencia la misma fue registrada en medical.</p>
    <h4>Datos de la póliza</h4>
    <p style=''padding-left: 30px;''>
        Tipo: {Data.LineOfBusinessDesc}<br>
    </p>
    <h4>Datos del asegurado</h4>
    <p style=''padding-left: 30px;''>
        Nombre: {Data.PrimaryInsured.FirstName} {Data.PrimaryInsured.MiddleName} {Data.PrimaryInsured.LastName} {Data.PrimaryInsured.SecondLastName}<br>
    </p>', UPDATEUSERCODE=6329, UPDATEDATE=TIMESTAMP '1970-02-07 00:00:00.000000', EMAILTO='{UserRoleList.Mapfre},{UserRoleList.Asprose}', MASTERTEMPLATEID=NULL WHERE ID=406;
