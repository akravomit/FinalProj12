-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: game
-- ------------------------------------------------------
-- Server version	8.0.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `attack`
--

DROP TABLE IF EXISTS `attack`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `attack` (
  `id` int NOT NULL AUTO_INCREMENT,
  `FilePath` varchar(250) DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Damage` int DEFAULT NULL,
  `Decay` int DEFAULT NULL,
  `DecayFactor` double DEFAULT NULL,
  `Duration` int DEFAULT NULL,
  `ElementID` int DEFAULT NULL,
  `IsHidden` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `kyb7bbv_idx` (`ElementID`),
  CONSTRAINT `kyb7bbv` FOREIGN KEY (`ElementID`) REFERENCES `element` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attack`
--

LOCK TABLES `attack` WRITE;
/*!40000 ALTER TABLE `attack` DISABLE KEYS */;
INSERT INTO `attack` VALUES (1,'attacks/acidic_spray.png','acidic spray',15,5,0.8,3,3,0),(2,'attacks/bite.png','bite',25,0,1,1,8,0),(3,'attacks/bow.png','bow',20,0,1,1,5,0),(4,'attacks/claw.png','claw',22,0,1,1,5,0),(5,'attacks/cut.png','cut',18,0,1,1,5,0),(6,'attacks/fin_slap.png','fin slap',20,0,1,1,3,0),(7,'attacks/fireball.png','fireball',30,10,0.9,2,2,0),(8,'attacks/freeze.png','freeze',10,0,1,4,3,0),(9,'attacks/headbutt.png','headbutt',28,0,1,1,6,0),(10,'attacks/infect.png','infect',5,10,0.7,5,4,0),(11,'attacks/laser_beam.png','laser beam',35,0,1,1,2,0),(12,'attacks/peck.png','peck',15,0,1,1,7,0),(13,'attacks/petrify.png','petrify',0,0,1,5,6,0),(14,'attacks/punch.png','punch',20,0,1,1,8,0),(15,'attacks/ram.png','ram',30,0,1,1,6,0),(16,'attacks/shield.png','shield',0,0,1,3,5,0),(17,'attacks/slash.png','slash',25,0,1,1,5,0),(18,'attacks/slice.png','slice',24,0,1,1,5,0),(19,'attacks/slosh.png','slosh',12,5,0.9,2,3,0),(20,'attacks/stab.png','stab',26,0,1,1,5,0),(21,'attacks/stomp.png','stomp',32,0,1,1,6,0),(22,'attacks/throw_bone.png','throw bone',18,0,1,1,6,0),(23,'attacks/throw_feather.png','throw feather',14,0,1,1,7,0),(24,'attacks/shoot.png','shoot',15,0,1,1,5,0),(25,'attacks/bullet_spray.png','bullet spray',15,5,0.8,3,5,0),(26,'attacks/heal.png','heal',-50,0,1,1,3,0),(27,'attacks/restore_mana.png','restore mana',0,-20,1,1,1,0),(28,'attacks/strength_buff.png','strength buff',0,0,1,5,6,0),(29,'attacks/block.png','block',0,0,1,2,5,0);
/*!40000 ALTER TABLE `attack` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `element`
--

DROP TABLE IF EXISTS `element`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `element` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `StrongAgainst` int DEFAULT NULL,
  `WeakAgainst` int DEFAULT NULL,
  `StrongModifier` double DEFAULT NULL,
  `WeakModifier` double DEFAULT NULL,
  `IsHidden` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `element`
--

LOCK TABLES `element` WRITE;
/*!40000 ALTER TABLE `element` DISABLE KEYS */;
INSERT INTO `element` VALUES (1,'Testium',0,0,100,0,1),(2,'Fire',7,3,1.2,0.8,0),(3,'Water',2,4,1.2,0.8,0),(4,'Plant',3,5,1.2,0.8,0),(5,'Metal',4,6,1.2,0.8,0),(6,'Earth',5,7,1.2,0.8,0),(7,'Wind',6,2,1.2,0.8,0),(8,'None',0,0,1,1,0);
/*!40000 ALTER TABLE `element` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `entry`
--

DROP TABLE IF EXISTS `entry`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `entry` (
  `id` int NOT NULL AUTO_INCREMENT,
  `MonsterID` int DEFAULT NULL,
  `PlayerID` int DEFAULT NULL,
  `DateSlain` datetime DEFAULT NULL,
  `TimesKilled` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_MonID_idx` (`MonsterID`),
  KEY `FK_PlayerID_idx` (`PlayerID`),
  CONSTRAINT `FK_MonID` FOREIGN KEY (`MonsterID`) REFERENCES `monster` (`id`),
  CONSTRAINT `FK_PlayerID` FOREIGN KEY (`PlayerID`) REFERENCES `player` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entry`
--

LOCK TABLES `entry` WRITE;
/*!40000 ALTER TABLE `entry` DISABLE KEYS */;
INSERT INTO `entry` VALUES (1,6,1,'2026-01-29 19:06:09',15),(2,1,1,'2026-01-29 19:08:08',25),(3,15,1,'2026-01-29 19:08:18',11),(4,10,1,'2026-01-29 19:08:19',16),(5,5,1,'2026-01-29 19:08:20',16),(6,20,1,'2026-01-29 19:08:21',17),(7,2,1,'2026-01-29 19:08:23',13),(8,11,1,'2026-01-29 19:08:24',21),(9,18,1,'2026-01-29 19:08:24',16),(10,8,1,'2026-01-29 19:08:25',20),(11,13,1,'2026-01-29 19:08:25',15),(12,16,1,'2026-01-29 19:08:25',14),(13,3,1,'2026-01-29 19:08:26',16),(14,9,1,'2026-01-29 19:08:28',11),(15,7,1,'2026-01-29 19:08:30',9),(16,14,1,'2026-01-29 19:08:32',12),(17,4,1,'2026-01-29 19:08:32',14),(18,12,1,'2026-01-29 19:08:36',14),(19,7,2,'2026-01-30 14:10:48',1),(20,14,2,'2026-01-30 14:10:53',2),(21,10,2,'2026-01-30 14:10:57',2),(22,17,2,'2026-01-30 14:10:59',1),(23,4,2,'2026-01-30 14:10:59',1),(24,2,2,'2026-01-30 14:11:00',1),(25,13,9,'2026-03-05 09:01:47',1),(26,3,9,'2026-03-05 09:01:49',1),(27,2,9,'2026-03-05 09:01:50',2),(28,14,9,'2026-03-05 09:01:51',1),(29,20,9,'2026-03-05 09:01:52',1),(30,17,1,'2026-03-08 10:41:24',15),(31,19,1,'2026-03-08 10:56:36',10),(33,18,14,'2026-03-08 18:31:44',1),(34,19,14,'2026-03-08 18:31:54',2),(35,5,14,'2026-03-08 18:31:55',1),(36,12,14,'2026-03-08 18:31:59',1),(37,1,14,'2026-03-08 18:32:00',1),(38,11,14,'2026-03-08 18:32:05',1),(39,9,14,'2026-03-08 18:32:08',1);
/*!40000 ALTER TABLE `entry` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventory`
--

DROP TABLE IF EXISTS `inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inventory` (
  `id` int NOT NULL AUTO_INCREMENT,
  `PlayerID` int DEFAULT NULL,
  `ItemID` int DEFAULT NULL,
  `item_level` int DEFAULT '1',
  `IsHidden` int DEFAULT NULL,
  `Amount` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_Player_idx` (`PlayerID`),
  KEY `FK_Item_idx` (`ItemID`),
  CONSTRAINT `FK_Item` FOREIGN KEY (`ItemID`) REFERENCES `item` (`id`),
  CONSTRAINT `FK_Player` FOREIGN KEY (`PlayerID`) REFERENCES `player` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory`
--

LOCK TABLES `inventory` WRITE;
/*!40000 ALTER TABLE `inventory` DISABLE KEYS */;
INSERT INTO `inventory` VALUES (1,1,1,50,0,1),(2,1,5,3,0,1),(3,1,19,10,0,4975),(4,1,14,2,0,1),(7,16,1,1,0,1),(9,18,1,1,0,1),(10,1,11,1,0,1),(11,2,8,1,0,1),(12,1,2,20,1,1);
/*!40000 ALTER TABLE `inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `item`
--

DROP TABLE IF EXISTS `item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `item` (
  `id` int NOT NULL AUTO_INCREMENT,
  `FilePath` varchar(250) DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Description` varchar(300) DEFAULT NULL,
  `Rarity` int DEFAULT NULL,
  `Value` int DEFAULT NULL,
  `ItemType` int DEFAULT NULL,
  `ItemIncrement` int DEFAULT NULL,
  `ElementID` int DEFAULT NULL,
  `IsHidden` int DEFAULT NULL,
  `MaxStack` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Item_Element1_idx` (`ElementID`),
  CONSTRAINT `fk_Item_Element1` FOREIGN KEY (`ElementID`) REFERENCES `element` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `item`
--

LOCK TABLES `item` WRITE;
/*!40000 ALTER TABLE `item` DISABLE KEYS */;
INSERT INTO `item` VALUES (1,'items/wooden_sword.png','Wooden Sword','A basic sword made of wood. Good for beginners.',1,10,1,5,6,0,1),(2,'items/iron_sword.png','Iron Sword','A sturdy iron sword. Reliable in combat.',2,50,1,10,6,0,1),(3,'items/steel_sword.png','Steel Sword','High-quality steel blade. Cuts through enemies with ease.',3,150,1,15,6,0,1),(4,'items/mythril_sword.png','Mythril Sword','Legendary sword forged from mythril. Extremely sharp.',5,1000,1,30,6,0,1),(5,'items/pistol.png','Pistol','A simple handgun. Fires bullets quickly.',2,80,2,12,6,0,1),(6,'items/rifle.png','Rifle','Long-range rifle. High accuracy.',3,200,2,20,6,0,1),(7,'items/shotgun.png','Shotgun','Close-range powerhouse. Devastating up close.',4,400,2,25,6,0,1),(8,'items/laser_gun.png','Laser Gun','Futuristic energy weapon. Shoots laser beams.',5,1500,2,35,2,0,1),(9,'items/basic_wand.png','Basic Wand','Entry-level magic wand. Casts simple spells.',1,20,3,8,8,0,1),(10,'items/fire_wand.png','Fire Wand','Wand imbued with fire magic. Launches fireballs.',3,300,3,18,2,0,1),(11,'items/ice_wand.png','Ice Wand','Freezes enemies solid. Water-based magic.',3,300,3,18,3,0,1),(12,'items/earth_wand.png','Earth Wand','Manipulates earth and stone.',4,500,3,22,5,0,1),(13,'items/vine_wand.png','Vine Wand','Summons entangling vines. Plant magic.',4,500,3,20,4,0,1),(14,'items/cloth_armor.png','Cloth Armor','Basic clothing. Minimal protection.',1,15,4,5,8,0,1),(15,'items/leather_armor.png','Leather Armor','Flexible leather. Good balance of protection and mobility.',1,60,4,10,4,0,1),(16,'items/chainmail.png','Chainmail','Interlinked metal rings. Strong defense.',2,200,4,15,6,0,1),(17,'items/plate_armor.png','Plate Armor','Heavy metal plates. Maximum protection.',2,800,4,25,6,0,1),(18,'items/dragon_scale_armor.png','Dragon Scale Armor','Forged from dragon scales. Legendary defense.',5,2000,4,40,2,0,1),(19,'items/health_potion.png','Health Potion','Restores 50 HP.',1,25,5,10,8,0,64),(20,'items/mana_potion.png','Mana Potion','Restores 20 Mana.',1,30,5,0,8,0,64),(21,'items/strength_potion.png','Strength Potion','Temporarily boosts damage.',2,100,5,0,8,0,64),(22,'item/5deyes.webp','5d eyes','They\'re looking at me weird. I don\'t like that. Hmmmmm',5,-50,3,-20,5,0,3);
/*!40000 ALTER TABLE `item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `item_attacks`
--

DROP TABLE IF EXISTS `item_attacks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `item_attacks` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ItemID` int DEFAULT NULL,
  `AttackID` int DEFAULT NULL,
  `Attack_Increment` double DEFAULT '1',
  `IsHidden` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ItmID_idx` (`ItemID`),
  KEY `AtkID_idx` (`AttackID`),
  CONSTRAINT `AttackID` FOREIGN KEY (`AttackID`) REFERENCES `attack` (`id`),
  CONSTRAINT `ItmID` FOREIGN KEY (`ItemID`) REFERENCES `item` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `item_attacks`
--

LOCK TABLES `item_attacks` WRITE;
/*!40000 ALTER TABLE `item_attacks` DISABLE KEYS */;
INSERT INTO `item_attacks` VALUES (1,1,17,5,0),(2,1,14,5,0),(3,2,17,10,0),(4,2,20,10,0),(5,3,17,15,0),(6,3,20,15,0),(7,3,18,15,0),(8,4,17,30,0),(9,4,20,30,0),(10,4,18,30,0),(11,4,5,30,0),(12,5,24,12,0),(13,6,24,20,0),(14,7,25,25,0),(15,8,11,35,0),(16,9,15,8,0),(17,10,7,18,0),(18,11,8,18,0),(19,12,21,22,0),(20,13,10,20,0),(21,14,29,5,0),(22,15,29,10,0),(23,16,16,15,0),(24,17,16,25,0),(25,18,16,40,0),(26,18,7,40,0),(27,19,26,0,0),(28,20,27,0,0),(29,21,28,0,0);
/*!40000 ALTER TABLE `item_attacks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemtype_name`
--

DROP TABLE IF EXISTS `itemtype_name`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `itemtype_name` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Type` int DEFAULT NULL,
  `Type_Name` varchar(100) DEFAULT NULL,
  `IsHidden` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemtype_name`
--

LOCK TABLES `itemtype_name` WRITE;
/*!40000 ALTER TABLE `itemtype_name` DISABLE KEYS */;
INSERT INTO `itemtype_name` VALUES (1,1,'Melee weapon',0),(2,2,'Ranged weapon',0),(3,3,'Magic weapon',0),(4,4,'Armor',0),(5,5,'Consumable',0);
/*!40000 ALTER TABLE `itemtype_name` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `monster`
--

DROP TABLE IF EXISTS `monster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `monster` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `FilePath` varchar(250) DEFAULT NULL,
  `HP` int DEFAULT NULL,
  `Defense` int DEFAULT NULL,
  `Description` varchar(500) DEFAULT NULL,
  `Size` double DEFAULT NULL,
  `Rarity` int DEFAULT NULL,
  `IsBoss` int DEFAULT '0',
  `MonsterElement` int DEFAULT NULL,
  `IsHidden` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ulawhbaukhukb_idx` (`MonsterElement`),
  CONSTRAINT `ulawhbaukhukb` FOREIGN KEY (`MonsterElement`) REFERENCES `element` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `monster`
--

LOCK TABLES `monster` WRITE;
/*!40000 ALTER TABLE `monster` DISABLE KEYS */;
INSERT INTO `monster` VALUES (1,'Zombie','monsters/Zombie.webp',100,2,'Foul creature. Undead corpse living without a brain or a purpose. Sad.',1,1,0,5,0),(2,'Skeleton','monsters/Skeleton.webp',80,2,'Weird fella, close to a zombie, but no flesh. That means it\'s very brittle.',1,1,0,5,0),(3,'Slime','monsters/Slime.webp',50,1,'Digusting creature. As if these ASMR slime videos weren\'t enough, it appears these substances have gained conciousness!',0.75,1,0,5,0),(4,'Vulture','monsters/Vulture.webp',150,3,'Ugly bird. Stupid bird. Ugh',1.2,2,0,5,0),(5,'Demon Eye','monsters/Demon Eye.webp',50,1,'Giant flying eyeball. How does it propel itself? Is it a UFO of some sort?',0.5,1,0,5,0),(6,'Shark','monsters/Shark.webp',250,5,'How did it get on land? How is it not suffocating? Does it know Baby Shark? Many questions we do not have time to answer.',1.75,3,0,5,0),(7,'Goblin','monsters/Goblin.webp',120,3,'Backwards people. Being around them makes me feel like I\'m in London.',1,2,0,5,0),(8,'Goblin Archer','monsters/Goblin Archer.webp',100,1,'A goblin with a bow. Will probably do nothing and sit in the back while his friends die, then claim he is victorious for nailing the player\'s crotch',1,2,0,5,0),(9,'Goblin Warrior','monsters/Goblin Warrior.webp',180,5,'Tough goblin. Big goblin. Still dies to any ol\' gun. If they hadn\'t gone to war all the time, they would\'ve researched better protection against small arms.',1.25,2,0,5,0),(10,'Goblin Warlock','monsters/Goblin Warlock.webp',450,15,'Finally, something more dangerous than the idiot hordes you\'ll be fighting off every raid.',0.8,5,1,2,0),(11,'Medusa','monsters/Medusa.webp',250,7,'If she were a woman, my friend would marry her, and I will jeopardize our friendship by nailing his hot wife. She Isn\'t the most beautiful lady there is for nothing, y\'know?',0.8,5,0,5,0),(12,'Undead Miner','monsters/Undead Miner.webp',120,5,'Still a skeleton, but the hard hat somehow make him beefier and stronger. It might just be that the hard hat makes him better..? Cool nontheless.',1,4,0,5,0),(13,'Harpy','monsters/Harpy.webp',150,2,'50% bird, 50% woman, 100% Hostile. All these wings make her very brittle. She might drop chicken nuggets? Or maybe if you feed her chicken nuggets, would she get Mad... Bird? In either way I get the people who tried (and succeeded???) to romance these disease-ridden brutes. Maybe if they integrated into society I would reconsider my stance.',1.5,2,0,5,0),(14,'Gnome','monsters/Gnome.webp',50,0,'Rare little pest, one stole my wallet a while back. Not much it can do against you, maybe exceot bite you ankle or headbutt you with its long hat. Legends exist of one having a nuclear payload above his dark head.',0.5,4,0,5,0),(15,'Tim','monsters/Tim.webp',250,7,'Cool skeleton. Like the warlock, he also learned magic. Sick hat as well.',1,5,1,2,0),(16,'Derpling','monsters/Derpling.webp',300,5,'Do not be fooled by its silly appearance, it can be real deadly for new or unsuspecting players.',1.5,3,0,5,0),(17,'Gastropod','monsters/Gastropod.webp',70,1,'Similar to the slime, but mutated and flies and... shoots laser beams apparently? It might also be an abhorrent combination of slime and a demon eye. How would these even mix genetically....?',0.5,2,0,5,0),(18,'Giant Bat','monsters/Giant Bat.webp',80,1,'Words cannot convey my loathing of this creature.',0.8,2,0,5,0),(19,'Antlion Charger','monsters/Antlion Charger.webp',150,3,'With these pests, I feel like I\'m in Australia. Giant, giant, bugs that have numbers rivaling India\'s population. I know for certain though they don\'t dump their waste into their own drinking waters, and I\'m one encounter away from pursuing their extinction nonetheless.',1.2,1,0,5,0),(20,'Unicorn','monsters/Unicorn.webp',150,4,'Hold your horses. No, you cannot ride it like a little pony, it will rip your intestines out with its horn. Quit horsing around.',1.2,3,0,5,0),(21,'Shitass bitch','monsters/Shitass.webp',69420,21000,'I HATE YOU I HATE YOU I HATE YOU I HATE YOU I HATE YOU I HATE YOU I HATE YOU I HATE YOU I HATE YOU I HATE YOU I HATE YOU I HATE YOU ',0.05,22,2,1,1);
/*!40000 ALTER TABLE `monster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `monster_attacks`
--

DROP TABLE IF EXISTS `monster_attacks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `monster_attacks` (
  `id` int NOT NULL AUTO_INCREMENT,
  `MonsterID` int DEFAULT NULL,
  `AttackID` int DEFAULT NULL,
  `Attack_Increment` double DEFAULT '1',
  `IsHidden` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `MonID_idx` (`MonsterID`),
  KEY `AtkID_idx` (`AttackID`),
  CONSTRAINT `AtkID` FOREIGN KEY (`AttackID`) REFERENCES `attack` (`id`),
  CONSTRAINT `MonID` FOREIGN KEY (`MonsterID`) REFERENCES `monster` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `monster_attacks`
--

LOCK TABLES `monster_attacks` WRITE;
/*!40000 ALTER TABLE `monster_attacks` DISABLE KEYS */;
INSERT INTO `monster_attacks` VALUES (1,1,17,1,0),(2,1,14,1,0),(3,2,3,1,0),(4,2,14,1,0),(5,2,22,1,0),(6,3,19,1,0),(7,3,1,1,0),(8,4,12,1,0),(9,4,4,1,0),(10,5,15,1,0),(11,6,2,1,0),(12,6,6,1,0),(13,7,14,1,0),(14,7,20,1,0),(15,7,2,1,0),(16,8,3,1,0),(17,8,14,1,0),(18,9,14,1,0),(19,9,20,1,0),(20,9,18,1,0),(21,9,5,1,0),(22,10,7,1,0),(23,10,16,1,0),(24,10,8,1,0),(25,11,13,1,0),(26,11,4,1,0),(27,12,22,1,0),(28,12,14,1,0),(29,12,9,1,0),(30,13,23,1,0),(31,13,4,1,0),(32,13,12,1,0),(33,14,20,1,0),(34,14,9,1,0),(35,15,7,1,0),(36,16,21,1,0),(37,16,12,1,0),(38,17,11,1,0),(39,18,2,1,0),(40,18,10,1,0),(41,19,2,1,0),(42,19,15,1,0),(43,19,21,1,0),(44,20,15,1,0);
/*!40000 ALTER TABLE `monster_attacks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `player`
--

DROP TABLE IF EXISTS `player`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `player` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(25) DEFAULT NULL,
  `HP` int DEFAULT '100',
  `Mana` int DEFAULT '20',
  `Coins` int DEFAULT '10',
  `IsHidden` int DEFAULT NULL,
  `OwnerID` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_owner_id_idx` (`OwnerID`),
  CONSTRAINT `FK_owner_id` FOREIGN KEY (`OwnerID`) REFERENCES `users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `player`
--

LOCK TABLES `player` WRITE;
/*!40000 ALTER TABLE `player` DISABLE KEYS */;
INSERT INTO `player` VALUES (1,'Tinman player edition',2042,20,11680,0,1),(2,'Tinman two',100,20,1154,0,1),(8,'awdawsda',100,20,0,0,8),(9,'jimmy',100,20,371,0,9),(14,'One Pise',100,20,580,0,2),(15,'Mister shit',100,20,0,0,1),(16,'agag',100,20,0,1,1),(17,'lawlollol',100,20,0,1,1),(18,'Morbius',100,20,0,0,1);
/*!40000 ALTER TABLE `player` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `isadmin` int NOT NULL,
  `ishidden` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Tinman','Whenamechaindasama','TruthNukeTinman@gmail.com',1,0),(2,'ProjectX','Clankerdeporter9000','imstupidlalalala@gmail.com',0,0),(3,'Jungelist','The stars bleed','aaaaaaaaaa@gmail.com',1,1),(4,'h','h','h',0,0),(5,'Markus','Markmark','Thisisatest@gmail.com',0,0),(6,'Doinkius','TheDonker','Dinkdonk',0,1),(7,'Doinkidus','SirDoinksALot','DoinkerTheThird@gmail.com',0,0),(8,'Testhead','Radiohead','explode@gmail.com',0,0),(9,'john fallout','Asdf1!','at@at.com',0,0),(10,'cooki','Birdspoop','birdspoop@gmail.com',0,0),(11,'Ben Dover','IronManSucks!','orphan.boy@loser.com',0,1);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-20 20:54:30
-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: gameadapi
-- ------------------------------------------------------
-- Server version	8.0.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `advertisements`
--

DROP TABLE IF EXISTS `advertisements`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `advertisements` (
  `id` int NOT NULL AUTO_INCREMENT,
  `headline` varchar(100) DEFAULT NULL,
  `body` varchar(1500) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `advertisements`
--

LOCK TABLES `advertisements` WRITE;
/*!40000 ALTER TABLE `advertisements` DISABLE KEYS */;
INSERT INTO `advertisements` VALUES (1,'Local tweaker discovers new dimension?','Local drug addict, 27, reports overdosing on fentanyl and surviving the event by teleporting into an unrecognizable landscape called \"The Fentrooms\" - a supposed drug addict\'s dream version of the popular media sensation \"The Backrooms\", which now enters production of season 36 during the time of writing. Several eyewitness reports say he was seen screaming frantically in the woods instead of his supposed dissapearance, so we may never know.'),(2,'This woman has cheated DEATH?!','Doctors are amazed at a woman\'s overcoming of her terminal cancer, mere months before her predicted passing. The woman allegadly cast a spell of mind-break on one of the nurses during a routine x-ray scan of the infected area, conquered her with sheer willpower, then transferred her conciousness to the poor nurse before shapeshifting into her original self. Stay tuned for a later appearance by a philosopher to discuss the implications of this technique.'),(3,'EXCLUSIVE OFFER - THE PERFECT COOLING SOLUTION','Have YOU ever had an issue with how slow your \"freezer\" is working? Is -18 degrees Celsius NOT cutting it for you? Do you just feel the burning need to make scientists cry in envy at your freezing capabilities? Well, this can be fixed with our newest product: a frozen soul of a demon! Plop one of these bad boys down in your \"freezer\" and watch the temperature drop to absolute zero! Now for only 17 years of your lifespan, you too can defy the known laws of thermodynamics! Handling accidents are on the customer\'s expense'),(4,'Psycholoogical fact about farts','When a person farts three times in a row, psychology says he is releasing the oxygen from his mind while circulating his feng shui. The way to avoid farting three times in a row is to simply eat a tab of potassium totalling about 250mg or more of the material.'),(5,'African teen is an upcoming prophet?','Teen alegadly conducts ritual of predicting the future, where he said the dissaporoving father of his girlfirend will be run over, by none other than himself. Hours later, the father is surprisingly killed in a tragic car accident. Police are currently searching for a suspect, though they have no clue, and thank the teen for the prediction of his unfortunate demise.'),(6,'Fantavirus pandemic starting?','The infected ship was given permission to dock on Spanish ports, its passengers allowed to return to their home countries to recieve medical care, despite heavy objection from people around the world and some leaders. The concerns and calls to not let the infected people spread the disease have been vindicated, as the first victim of Fantavirus has been claimed, with the victim, 83, has been turned into a bottle of the fizzy drink in his apartment last night.'),(7,'Tired of sleeping badly? This product might be for you.','A new invention called the whack-you-to-sleep-o-tron uses revolutionary new technology to smack you over the head with a cartoon hammer, knocking you out instantly. Coming to stores in the following months.'),(8,'Tired of losing in chess? This chess master surprises adversaries with new move','Viral influencer Chess Baby, 2 years old, that has gone viral for beating one of the best chess masters in the world, like his own mom, has now gone up against his local heavyweight in chess, his grandma. He has surprisingly won the intense match after an unheard of checkmate, only described by witnesses as \"eating the king on the fifth turn\", in which he grabbed his opponent\'s king and started nibbling on it, immediatelly nullifying any further moves by his adversary. For the next match, he will face up against his uncle. A promising career for this young star.');
/*!40000 ALTER TABLE `advertisements` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-20 20:54:30
