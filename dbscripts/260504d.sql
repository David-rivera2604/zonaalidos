-- ============================================================
-- NOTIFICATION DDL — Schema ALIADOS
-- Sistema de Notificaciones Enterprise v1.1
-- ============================================================

CREATE SEQUENCE SEQ_NOTIFICATION
    START WITH 1 INCREMENT BY 1 NOCACHE NOCYCLE;

CREATE TABLE Notification (
    NotificationId  NUMBER(9)       NOT NULL,
    CompanyId       NUMBER(5)       NOT NULL,
    UserId          NUMBER(9)       NOT NULL,     -- Usuario destinatario (el asignado)
    Title           VARCHAR2(255)   NOT NULL,
    Message         VARCHAR2(2000)  NOT NULL,
    Type            VARCHAR2(50)    NOT NULL,
    Category        VARCHAR2(50)    NULL,
    EntityType      NUMBER(5)       NULL,          -- 1=Proceso 2=Poliza 3=Pago 4=Firma
    EntityId        NUMBER(18)      NULL,
    Metadata        CLOB            NULL,          -- JSON libre por modulo
    IsRead          NUMBER(1)       DEFAULT 0 NOT NULL,
    ReadAt          TIMESTAMP       NULL,
    UpdateUserCode  NUMBER(9)       NULL,
    UpdateDate      TIMESTAMP       DEFAULT SYSTIMESTAMP NOT NULL,
    CreatedAt       TIMESTAMP       DEFAULT SYSTIMESTAMP NOT NULL,
    CONSTRAINT PK_Notification       PRIMARY KEY (NotificationId),
    CONSTRAINT CK_Notification_IsRead CHECK (IsRead IN (0, 1))
);

-- Bandeja del usuario (query principal)
CREATE INDEX IDX_Notif_User
    ON Notification (CompanyId, UserId, IsRead, CreatedAt DESC);

-- Busqueda por tipo de evento
CREATE INDEX IDX_Notif_Type
    ON Notification (CompanyId, Type, CreatedAt DESC);

-- Trazabilidad por entidad origen
CREATE INDEX IDX_Notif_Entity
    ON Notification (CompanyId, EntityType, EntityId);

-- Tabla historica (misma estructura, sin constraints)
CREATE TABLE NotificationArchive AS SELECT * FROM Notification WHERE 1=0;
ALTER TABLE NotificationArchive ADD CONSTRAINT PK_NotificationArchive PRIMARY KEY (NotificationId);