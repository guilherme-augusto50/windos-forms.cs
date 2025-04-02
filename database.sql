CREATE DATABASE Usuarios;
use Usuarios;
CREATE TABLE IF NOT EXISTS usuarios (
id int auto_increment primary key,
nome varchar(100) not null,
senha varchar(255) not null
);
