IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'sqldb-project-lcz-prod')
BEGIN
   CREATE DATABASE [sqldb-project-lcz-prod];
   PRINT 'Database sqldb-project-lcz-prod Criada';
END;
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='fabricante' and xtype='U')
BEGIN
    CREATE TABLE fabricante (
        id_fabricante int IDENTITY(1,1) PRIMARY KEY,
        nome varchar(100) NOT NULL
    );
    PRINT 'Table fabricante Criada';
END

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='modelo' and xtype='U')
BEGIN
    CREATE TABLE modelo (
        id_modelo int IDENTITY(1,1) PRIMARY KEY,
        id_fabricante int FOREIGN KEY REFERENCES fabricante(id_fabricante),
        nome varchar(100) NOT NULL
    );
    PRINT 'Table modelo Criada';
END

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='veiculo' and xtype='U')
BEGIN
    CREATE TABLE veiculo (
        id_veiculo int IDENTITY(1,1) PRIMARY KEY,
        placa varchar(10) NOT NULL,
        id_fabricante int FOREIGN KEY REFERENCES fabricante(id_fabricante),
        nome_fabricante varchar (100) NOT NULL,
        id_modelo int NOT NULL FOREIGN KEY REFERENCES modelo(id_modelo),
        nome_modelo varchar(100) NOT NULL
    );
    PRINT 'Table veiculo Criada';
END

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='cliente' and xtype='U')
BEGIN
    CREATE TABLE cliente (
        id_cliente int IDENTITY(1,1) PRIMARY KEY,
        nome varchar(100) NOT NULL,
        cpf varchar(11) NOT NULL,
        data_nascimento DATE NOT NULL,
        numero_cnh varchar(11) NOT NULL
    );
    PRINT 'Table cliente Criada';
END

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='endereco' and xtype='U')
BEGIN
    CREATE TABLE endereco (
        id_endereco int IDENTITY(1,1) PRIMARY KEY,
        cep varchar(8) NOT NULL,
        logradouro varchar(100) NOT NULL,
        numero varchar(10),
        complemento varchar(40),
        bairro varchar(40) NOT NULL,
        cidade varchar(40) NOT NULL,
        estado varchar(2) NOT NULL,
        tipo_endereco int NOT NULL,
        id_cliente int NOT NULL FOREIGN KEY REFERENCES cliente(id_cliente)
    );
    PRINT 'Table endereco Criada';
END

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='reserva' and xtype='U')
BEGIN
    CREATE TABLE reserva (
        id_reserva int IDENTITY(1,1) PRIMARY KEY,
        id_cliente int FOREIGN KEY REFERENCES cliente(id_cliente),
        id_veiculo int FOREIGN KEY REFERENCES veiculo(id_veiculo),
        data_criacao DATETIME NOT NULL,
        data_atualizacao DATETIME,
        data_retirada DATETIME NOT NULL,
        data_prevista_devolucao DATETIME NOT NULL,
        data_devolucao DATETIME
    );
    PRINT 'Table reserva Criada';
END

INSERT INTO fabricante (nome) VALUES ('Toyota'), ('Volkswagen'), ('Hyundai'), ('Ford'), ('Honda'), ('Nissan'), ('Chevrolet'), ('Kia'), ('Mercedes-Benz'), ('BMW');

PRINT 'Carga na tabela de fabricante realizada';

INSERT INTO modelo (nome, id_fabricante) VALUES ('SW4', 1), ('Corolla', 1), ('Bandeirante', 1), ('Etios', 1), ('RAV4', 1), ('Camry', 1), ('Supra', 1), ('Prius', 1), ('Yaris', 1), ('Corolla Cross', 1);

INSERT INTO modelo (nome, id_fabricante) VALUES ('Gol', 2), ('Voyage', 2), ('Polo', 2), ('Virtus', 2), ('Nivus', 2), ('T-Cross', 2), ('Taos', 2), ('Jetta', 2), ('Saveiro', 2), ('Amarok', 2);

INSERT INTO modelo (nome, id_fabricante) VALUES ('Creta', 3), ('HB20', 3), ('HB20S', 3), ('Azera', 3), ('IX35', 3), ('Tucson', 3), ('I30', 3), ('Elantra', 3), ('Kona', 3), ('Veloster', 3);

INSERT INTO modelo (nome, id_fabricante) VALUES ('Ecosport', 4), ('Edge', 4), ('F-150', 4), ('Fiesta', 4), ('Fusion', 4), ('Ka', 4), ('Ranger', 4), ('Focus', 4), ('F-250', 4), ('F-350', 4);

INSERT INTO modelo (nome, id_fabricante) VALUES ('Civic', 5), ('Fit', 5), ('Accord', 5), ('HR-V', 5), ('City', 5), ('WR-V', 5), ('CR-V', 5), ('New Civic', 5);

PRINT 'Carga na tabela de modelo realizada';



 