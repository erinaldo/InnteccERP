ALTER TABLE compras.requerimiento
  ADD COLUMN createdby INTEGER;
  
ALTER TABLE compras.requerimiento
  ADD COLUMN creationdate TIMESTAMP(0) WITHOUT TIME ZONE;

ALTER TABLE compras.requerimiento
  ADD COLUMN modifiedby INTEGER;

ALTER TABLE compras.requerimiento
  ADD COLUMN lastmodified TIMESTAMP(0) WITHOUT TIME ZONE;  