CREATE DATABASE  IF NOT EXISTS `bdrpg` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `bdrpg`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: bdrpg
-- ------------------------------------------------------
-- Server version	5.7.20-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `classe`
--

DROP TABLE IF EXISTS `classe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `classe` (
  `idClasse` int(11) NOT NULL,
  `Vida` int(11) NOT NULL,
  `Mana` int(11) NOT NULL,
  `Dano` int(11) NOT NULL,
  `NomeClasse` varchar(45) NOT NULL,
  `Defesa` int(11) NOT NULL,
  `DefesaMagica` int(11) NOT NULL,
  `Agilidade` int(11) NOT NULL,
  `DescClasse` varchar(500) NOT NULL,
  PRIMARY KEY (`idClasse`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classe`
--

LOCK TABLES `classe` WRITE;
/*!40000 ALTER TABLE `classe` DISABLE KEYS */;
INSERT INTO `classe` VALUES (1,15,0,6,'Arqueiro',5,5,23,'Exímios atiradores no uso do arco. Sua afinidade e dedicação a um único tipo de arma, torna possível que realizem verdadeiras proezas quando disparam suas flechas.'),(2,18,0,10,'Cavaleiro',8,1,5,'Cavaleiros são bem resistentes possuindo na maioria das vezes armaduras pesadas e também armas longas e com mais poder destrutivo.'),(3,20,20,3,'Clérigo',1,10,5,'Um clérigo age como um agente intermediário, controlando poderes divinos, também possuindo o poder de curar ferimentos apenas com sua fé, da mesma forma que pode causar ferimentos e doenças com o mesmo método.'),(4,15,20,8,'Mago',1,10,5,'Os Magos são capazes de utilizar poderes naturais e elementais como terra, fogo, água e ar. Mas o seu maior poder é conjurar a magia Branca, como fortes raios de luzes e poderes de cura.'),(5,15,10,7,'Paladino',5,6,5,'Possuem habilidades de combate como a de um guerreiro juntamente com a força de um Berserker, e prestam a devoção aos deuses, obtendo assim o poder necessário para conjurar suas magias.');
/*!40000 ALTER TABLE `classe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dadospartida`
--

DROP TABLE IF EXISTS `dadospartida`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dadospartida` (
  `idPartida` int(11) NOT NULL,
  `TotalJogadores` int(11) NOT NULL,
  PRIMARY KEY (`idPartida`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dadospartida`
--

LOCK TABLES `dadospartida` WRITE;
/*!40000 ALTER TABLE `dadospartida` DISABLE KEYS */;
/*!40000 ALTER TABLE `dadospartida` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `habilidade`
--

DROP TABLE IF EXISTS `habilidade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `habilidade` (
  `idHabilidade` int(11) NOT NULL,
  `NomeHabilidade` varchar(50) NOT NULL,
  `DescHabilidade` varchar(200) NOT NULL,
  `idClasse` int(11) NOT NULL,
  PRIMARY KEY (`idHabilidade`),
  KEY `fk_Poder_Classe1_idx` (`idClasse`),
  CONSTRAINT `fk_Poder_Classe1` FOREIGN KEY (`idClasse`) REFERENCES `classe` (`idClasse`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `habilidade`
--

LOCK TABLES `habilidade` WRITE;
/*!40000 ALTER TABLE `habilidade` DISABLE KEYS */;
INSERT INTO `habilidade` VALUES (1,'Agilidade','Aumenta a Chance de Esquiva em 15%',1),(2,'Dupla Flecha','Aumenta a Cadência por 1 Turno(mas reduz o dano pela metade)',1),(3,'Precisão','Aumenta o dano em 5%(mas leva 1 turno para mirar)',1),(4,'Deus Vult','Aumenta o ataque em 20%',2),(5,'Escudo','Levanta o escudo ou guarda(reduz o dano recebido em 25%)',2),(6,'Fúria','Aumenta o ataque em 50%',2),(7,'Cura Nível I','Regenera a vida em 30%',3),(8,'Cura Nível II','Regenera a vida em 50%',3),(9,'Cura Nível III','Regenera a vida de todos os aliados em 70%',3),(10,'Concentração','Aumenta o dano mágico em 30%',4),(11,'Escudo Mágico','Aumenta a defesa mágica em 50%',4),(12,'Onda de Choque','Chance de atordoar todos os inimigos em 50%(Chefes não são atordoados)',4),(13,'Arma Mágica','Encanta a arma utilizada aumentando o dano em 30%',5),(14,'Arma Mágica Nível II','Encanta a arma utilizada aumentando o dano em 40%',5),(15,'Arma Mágica de Grau','Encanta a arma utilizada aumentando o dano em 45%(Causa sangramento)',5);
/*!40000 ALTER TABLE `habilidade` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inimigo`
--

DROP TABLE IF EXISTS `inimigo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inimigo` (
  `idInimigo` int(11) NOT NULL,
  `NomeInimigo` varchar(50) NOT NULL,
  `VidaInimigo` int(11) NOT NULL,
  `DescInimigo` varchar(50) NOT NULL,
  `DanoInimigo` int(11) NOT NULL,
  `DefesaInimigo` int(11) DEFAULT NULL,
  `idPartida` int(11) NOT NULL,
  PRIMARY KEY (`idInimigo`),
  KEY `fk_Inimigo_DadosPartida1_idx` (`idPartida`),
  CONSTRAINT `fk_Inimigo_DadosPartida1` FOREIGN KEY (`idPartida`) REFERENCES `dadospartida` (`idPartida`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inimigo`
--

LOCK TABLES `inimigo` WRITE;
/*!40000 ALTER TABLE `inimigo` DISABLE KEYS */;
/*!40000 ALTER TABLE `inimigo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventario`
--

DROP TABLE IF EXISTS `inventario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inventario` (
  `idInventario` int(11) NOT NULL,
  `LimiteInventario` int(11) NOT NULL,
  PRIMARY KEY (`idInventario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventario`
--

LOCK TABLES `inventario` WRITE;
/*!40000 ALTER TABLE `inventario` DISABLE KEYS */;
INSERT INTO `inventario` VALUES (1,5),(2,5),(3,5),(4,5),(5,5);
/*!40000 ALTER TABLE `inventario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `item`
--

DROP TABLE IF EXISTS `item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `item` (
  `idItem` int(11) NOT NULL,
  `NomeItem` varchar(50) NOT NULL,
  `DescItem` varchar(50) NOT NULL,
  `DanoItem` int(11) DEFAULT NULL,
  `DefesaItem` int(11) DEFAULT NULL,
  PRIMARY KEY (`idItem`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `item`
--

LOCK TABLES `item` WRITE;
/*!40000 ALTER TABLE `item` DISABLE KEYS */;
/*!40000 ALTER TABLE `item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `iteminventario`
--

DROP TABLE IF EXISTS `iteminventario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `iteminventario` (
  `idInventario` int(11) NOT NULL,
  `idItem` int(11) NOT NULL,
  PRIMARY KEY (`idInventario`,`idItem`),
  KEY `fk_inventario_has_item_item1_idx` (`idItem`),
  KEY `fk_inventario_has_item_inventario1_idx` (`idInventario`),
  CONSTRAINT `fk_inventario_has_item_inventario1` FOREIGN KEY (`idInventario`) REFERENCES `inventario` (`idInventario`),
  CONSTRAINT `fk_inventario_has_item_item1` FOREIGN KEY (`idItem`) REFERENCES `item` (`idItem`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `iteminventario`
--

LOCK TABLES `iteminventario` WRITE;
/*!40000 ALTER TABLE `iteminventario` DISABLE KEYS */;
/*!40000 ALTER TABLE `iteminventario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jogador`
--

DROP TABLE IF EXISTS `jogador`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `jogador` (
  `idJogador` int(11) NOT NULL,
  `NomeJogador` varchar(50) NOT NULL,
  `idInventario` int(11) NOT NULL,
  `idClasse` int(11) NOT NULL,
  `idPartida` int(11) NOT NULL,
  PRIMARY KEY (`idJogador`),
  KEY `fk_Jogador_Inventario1_idx` (`idInventario`),
  KEY `fk_Jogador_Classe1_idx` (`idClasse`),
  KEY `fk_Jogador_DadosPartida1_idx` (`idPartida`),
  CONSTRAINT `fk_Jogador_Classe1` FOREIGN KEY (`idClasse`) REFERENCES `classe` (`idClasse`),
  CONSTRAINT `fk_Jogador_DadosPartida1` FOREIGN KEY (`idPartida`) REFERENCES `dadospartida` (`idPartida`),
  CONSTRAINT `fk_Jogador_Inventario1` FOREIGN KEY (`idInventario`) REFERENCES `inventario` (`idInventario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jogador`
--

LOCK TABLES `jogador` WRITE;
/*!40000 ALTER TABLE `jogador` DISABLE KEYS */;
/*!40000 ALTER TABLE `jogador` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-11-06 13:12:36
