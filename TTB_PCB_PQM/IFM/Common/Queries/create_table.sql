CREATE TABLE m_user_roles (
  ID SERIAL NOT NULL,
  user_cd varchar(20) NOT NULL,
  assign_code varchar(32) NOT NULL,
  priority int NOT NULL DEFAULT '1',
  status bit NOT NULL DEFAULT '0',
  comments varchar(100) DEFAULT NULL,
  updater varchar(32) DEFAULT NULL,
  update_time timestamp  DEFAULT CURRENT_TIMESTAMP,
  creator varchar(32) DEFAULT NULL,
  create_time timestamp  DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (ID)
) 

CREATE TABLE m_user (
  ID SERIAL NOT NULL,
  user_cd varchar(20),
  user_name varchar(128),
  user_pass varchar(32) NOT NULL,
  user_status bit NOT NULL DEFAULT '1',
  user_comments varchar(100) NOT NULL,
  user_role int NOT NULL,
  user_email varchar(521) DEFAULT NULL,
  user_permision varchar(100) DEFAULT NULL,
  user_lang varchar(2) DEFAULT 'en',
  PRIMARY KEY (ID)
)

CREATE TABLE m_assignments (
  ID SERIAL NOT NULL,
  assign_code varchar(32) NOT NULL,
  assign_name varchar(32) NOT NULL,
  assign_name_vn varchar(32) DEFAULT NULL,
  assign_view varchar(64) DEFAULT NULL,
  parent_code varchar(32) DEFAULT NULL,
  priority int NOT NULL DEFAULT '1',
  status bit NOT NULL DEFAULT '0',
  comments varchar(100) DEFAULT NULL,
  updater varchar(32) DEFAULT NULL,
  update_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  creator varchar(32) DEFAULT NULL,
  create_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (ID)
)