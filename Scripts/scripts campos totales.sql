ALTER TABLE compras.ordencompra
  ADD COLUMN totalbruto NUMERIC(12,2) DEFAULT 0 NOT NULL;

ALTER TABLE compras.ordencompra
  ADD COLUMN totalgravado NUMERIC(12,2) DEFAULT 0 NOT NULL;

ALTER TABLE compras.ordencompra
  ADD COLUMN totalinafecto NUMERIC(12,2) DEFAULT 0 NOT NULL;

ALTER TABLE compras.ordencompra
  ADD COLUMN totalexonerado NUMERIC(12,2) DEFAULT 0 NOT NULL;

ALTER TABLE compras.ordencompra
  ADD COLUMN totalimpuesto NUMERIC(12,2) DEFAULT 0 NOT NULL;

ALTER TABLE compras.ordencompra
  ADD COLUMN importetotal NUMERIC(12,2) DEFAULT 0 NOT NULL;

ALTER TABLE compras.ordencompra
  ADD COLUMN porcentajepercepcion NUMERIC(12,2) DEFAULT 0 NOT NULL;

ALTER TABLE compras.ordencompra
  ADD COLUMN importetotalpercepcion NUMERIC(12,2) DEFAULT 0 NOT NULL;

ALTER TABLE compras.ordencompra
  ADD COLUMN totaldocumento NUMERIC(12,2) DEFAULT 0 NOT NULL;









