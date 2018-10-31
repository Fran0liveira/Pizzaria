CREATE DATABASE Pizzaria;
GO
USE Pizzaria;
GO
CREATE TABLE cliente(
    id_cli INTEGER PRIMARY KEY NOT NULL IDENTITY(1,1),
    nome_cli VARCHAR(60) NOT NULL,
    tel_cli VARCHAR(13),
    cel_cli VARCHAR(14)
);
GO
CREATE TABLE funcionario(
    id_func INTEGER PRIMARY KEY NOT NULL IDENTITY(1,1),
    nome_func VARCHAR(60) NOT NULL,
    tel_func VARCHAR(13),
    cel_func VARCHAR(14),
	car_traba_func VARCHAR(30) NOT NULL,
	end_func VARCHAR(30) NOT NULL
);
GO
CREATE TABLE pedido(
    id_pedido INTEGER PRIMARY KEY NOT NULL IDENTITY(1,1),
    nome_pedido VARCHAR(50) NOT NULL,
    desc_pedido VARCHAR(100) NOT NULL,
    --status_pedido VARCHAR(15) NOT NULL,
    id_cli INTEGER FOREIGN KEY REFERENCES cliente(id_cli),
	id_func INTEGER FOREIGN KEY REFERENCES funcionario(id_func)
);
GO
INSERT INTO cliente(nome_cli, tel_cli, cel_cli) 
VALUES('Ronaldo', '(11)0000-0000', '(11)00000-0000');
GO
SELECT * FROM cliente;
SELECT * FROM cliente WHERE nome_cli LIKE 'R%';


INSERT INTO pedido(nome_pedido,desc_pedido,id_cli) 
VALUES('Calabresa', 'Sem cebola.',1);

SELECT * FROM cliente;
SELECT * FROM pedido WHERE id_cli = 1;
SELECT * FROM pedido WHERE nome_pedido LIKE 'C'  AND id_cli = 1;