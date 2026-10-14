
INSERT INTO NAVIGATION
 (
 NAVIGATIONID,
 COMPANYID,
 CODE,
 PARENTCODE,
 "TYPE",
 TITLE,
 MENUTITLE,
 DESCRIPTION,
 URLPATH,
 URLHELP,
 SMALLIMAGE,
 BIGIMAGE,
 "SEQUENCE",
 RECORDSTATUS,
 UPDATEUSERCODE,
 UPDATEDATE
 ) 
VALUES (
(SELECT NVL(MAX(NAVIGATIONID),0)+1 FROM NAVIGATION ),
2,
'QUOTE010',
'QUOTEMN',
2,
'Masivos',
NULL,
NULL,
'Masivos/Index',
NULL,
'fa fa-upload',
NULL,
110,
1,
254,
SYSDATE);




insert into rolemembernavigation  (
    ID ,
     COMPANYID,
      ROLEID,
        CODE ,
         ALLOW,
          SECURITYLEVEL,
           CREATEACTION,
             READACTION,
               UPDATEACTION,
                 DELETEACTION,
                   LISTACTION,
                     PRINTACTION,
                      UPDATEUSERCODE,
                        UPDATEDATE
)

values

(

(SELECT NVL(MAX(ID),0)+1 FROM rolemembernavigation ),
2,
(select ROLEID from rolemember where rolename='Empleado' AND companyid=2 ),
'QUOTE010',
0,
0,
0,
0,
0,
0,
0,
0,
254,
SYSDATE
)
