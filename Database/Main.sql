-- Database: "Main"

-- DROP DATABASE "Main";

CREATE DATABASE "Main"
  WITH OWNER = postgres
       ENCODING = 'UTF8'
       TABLESPACE = pg_default
       LC_COLLATE = 'Polish_Poland.1250'
       LC_CTYPE = 'Polish_Poland.1250'
       CONNECTION LIMIT = -1;


-- Schema: wano_main

-- DROP SCHEMA wano_main;

CREATE SCHEMA wano_main
  AUTHORIZATION postgres;


-- Table: wano_main.w_cards

-- DROP TABLE wano_main.w_cards;

CREATE TABLE wano_main.w_cards
(
  c_id serial NOT NULL,
  "c_cardId" integer,
  c_deleted boolean,
  "c_password" integer,
  c_end date,
  c_start date,
  CONSTRAINT w_cards_pkey PRIMARY KEY (c_id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE wano_main.w_cards
  OWNER TO postgres;
  
-- Table: wano_main.w_activity

-- DROP TABLE wano_main.w_activity;

CREATE TABLE wano_main.w_activity
(
  w_id serial NOT NULL,
  w_username text,
  w_time date,
  w_activitytext text,
  w_isvip boolean,
  CONSTRAINT w_activity_pkey PRIMARY KEY (w_id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE wano_main.w_activity
  OWNER TO postgres;
  
-- Table: wano_main.w_srdata

-- DROP TABLE wano_main.w_srdata;

CREATE TABLE wano_main.w_srdata
(
  s_id serial NOT NULL,
  "s_deviceId" integer,
  s_freguency decimal,
  s_send_data decimal,
  "s_status" integer,
  s_error_text text,
  CONSTRAINT w_srdata_pkey PRIMARY KEY (s_id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE wano_main.w_srdata
  OWNER TO postgres;
