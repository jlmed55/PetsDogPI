-- Script de criação do banco de dados PetsDog em MySQL
-- Estrutura refletida a partir da migração inicial (20251201233032_Inicial)

CREATE DATABASE IF NOT EXISTS `PetsDog` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `PetsDog`;

-- Remoção opcional das tabelas para recriação limpa
DROP TABLE IF EXISTS `Agendamento`;
DROP TABLE IF EXISTS `Animals`;
DROP TABLE IF EXISTS `Servicos`;
DROP TABLE IF EXISTS `Profissionais`;
DROP TABLE IF EXISTS `Clientes`;

CREATE TABLE `Clientes` (
  `Idcliente` int NOT NULL AUTO_INCREMENT,
  `Nome` longtext NULL,
  `Email` longtext NULL,
  `Senha` longtext NULL,
  `Telefone` longtext NULL,
  `Datacadastro` datetime(6) NOT NULL,
  PRIMARY KEY (`Idcliente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `Profissionais` (
  `id_profissional` int NOT NULL AUTO_INCREMENT,
  `nome` longtext NULL,
  `especialidade` longtext NULL,
  `DisponibilidadeInicio` longtext NULL,
  `DiponibilidadeFim` longtext NULL,
  PRIMARY KEY (`id_profissional`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `Servicos` (
  `Idservico` int NOT NULL AUTO_INCREMENT,
  `nome` longtext NULL,
  `duracao_min` int NOT NULL,
  `preco` decimal(65,30) NOT NULL,
  PRIMARY KEY (`Idservico`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `Animals` (
  `id_animal` int NOT NULL AUTO_INCREMENT,
  `Nome` longtext NULL,
  `Especie` longtext NULL,
  `Porte` longtext NULL,
  `Idade` int NOT NULL,
  `Id_cliente` int NOT NULL,
  PRIMARY KEY (`id_animal`),
  KEY `IX_Animals_Id_cliente` (`Id_cliente`),
  CONSTRAINT `FK_Animals_Clientes_Id_cliente` FOREIGN KEY (`Id_cliente`) REFERENCES `Clientes`(`Idcliente`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `Agendamento` (
  `id_agendamento` int NOT NULL AUTO_INCREMENT,
  `data_hora` datetime(6) NOT NULL,
  `status` longtext NULL,
  `id_animal` int NOT NULL,
  `id_servico` int NOT NULL,
  `id_profissional` int NOT NULL,
  `Profissionalid_profissional` int NULL,
  `ServicoIdservico` int NULL,
  PRIMARY KEY (`id_agendamento`),
  KEY `IX_Agendamento_id_animal` (`id_animal`),
  KEY `IX_Agendamento_id_profissional` (`id_profissional`),
  KEY `IX_Agendamento_id_servico` (`id_servico`),
  KEY `IX_Agendamento_Profissionalid_profissional` (`Profissionalid_profissional`),
  KEY `IX_Agendamento_ServicoIdservico` (`ServicoIdservico`),
  CONSTRAINT `FK_Agendamento_Animals_id_animal` FOREIGN KEY (`id_animal`) REFERENCES `Animals`(`id_animal`) ON DELETE CASCADE,
  CONSTRAINT `FK_Agendamento_Profissionais_id_profissional` FOREIGN KEY (`id_profissional`) REFERENCES `Profissionais`(`id_profissional`) ON DELETE CASCADE,
  CONSTRAINT `FK_Agendamento_Profissionais_Profissionalid_profissional` FOREIGN KEY (`Profissionalid_profissional`) REFERENCES `Profissionais`(`id_profissional`),
  CONSTRAINT `FK_Agendamento_Servicos_id_servico` FOREIGN KEY (`id_servico`) REFERENCES `Servicos`(`Idservico`) ON DELETE CASCADE,
  CONSTRAINT `FK_Agendamento_Servicos_ServicoIdservico` FOREIGN KEY (`ServicoIdservico`) REFERENCES `Servicos`(`Idservico`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
