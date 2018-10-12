USE master;
GO

CREATE DATABASE [ControlWork]
ON PRIMARY
( 
NAME = 'ControlWork',
FILENAME = 'C:ControlWork\ControlWork.mdf',
 SIZE =150MB,
 MAXSIZE = 250MB,
 FILEGROWTH =50MB
 ),
 FILEGROUP [CW]
 (
 NAME = 'CW1',
 FILENAME = 'C:ControlWork\CW1',
 SIZE = 200MB
 ),
 (
 NAME = 'CW2',
 FILENAME = 'C:ControlWork\CW1',
 MAXSIZE = UNLIMITED,
 FILEGROWTH = 60MB
 )
 LOG ON 
 (
 NAME = 'ControlWork_log1',
 FILENAME = 'C:ControlWork\CotrolWork_log1.ldf',
 SIZE = 50MB,
 MAXSIZE = 200MB,
 FILEGROWTH = 10%
 ),
 (
 NAME = 'ControlWork_log2',
 FILENAME = 'C:ControlWork\ControlWork_log2.ldf',
 SIZE = 50MB,
 MAXSIZE = 150MB,
 FILEGROWTH = 10MB
 );
 GO

