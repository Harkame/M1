--CLEAR
DROP TABLE Etudiant;
DROP TABLE Filiere;
DROP TABLE UE;
DROP TABLE Specialite;
DROP TABLE Universite;

DROP TYPE Universite_T FORCE;
DROP TYPE Adresse_T FORCE;
DROP TYPE GroupePersonne_T FORCE;
DROP TYPE Personne_T FORCE;
DROP TYPE GroupeEtudiant_T FORCE;
DROP TYPE Etudiant_T FORCE;
DROP TYPE UEObligatoire_T FORCE;
DROP TYPE UEOptionnelle_T FORCE;
DROP TYPE UE_T FORCE;
DROP TYPE GroupeSpecialite_T FORCE;
DROP TYPE Specialite_T FORCE;
DROP TYPE Inscription_T FORCE;
DROP TYPE GroupeNiveau_T FORCE;
DROP TYPE Niveau_T FORCE;
DROP TYPE GroupeFiliere_T FORCE;
DROP TYPE Filiere_T FORCE;


--CREATIONS

--TYPES
CREATE OR REPLACE TYPE Adresse_T AS OBJECT(ville VARCHAR2(50), codePostal NUMBER, numero NUMBER, voie VARCHAR2(50), complement VARCHAR2(100));
/

CREATE OR REPLACE TYPE Personne_T AS OBJECT(nomPersonne VARCHAR2(50), prenomPersonne VARCHAR2(50), date_naissance DATE) NOT FINAL NOT INSTANTIABLE;
/

CREATE OR REPLACE TYPE GroupePersonne_T AS TABLE OF REF Personne_T;
/

CREATE OR REPLACE TYPE Etudiant_T UNDER Personne_T(ine NUMBER);
/

CREATE OR REPLACE TYPE GroupeEtudiant_T AS TABLE OF REF Etudiant_T;
/

CREATE OR REPLACE TYPE UE_T AS OBJECT(codeUE NUMBER, nomUE VARCHAR2(80), etudiants GroupeEtudiant_T);
/

CREATE OR REPLACE TYPE UEObligatoire_T AS TABLE  OF REF UE_T;
/

CREATE OR REPLACE TYPE UEOptionnelle_T AS TABLE OF REF UE_T;
/

CREATE OR REPLACE TYPE Specialite_T AS OBJECT (nomSpecialite VARCHAR2(80), nbEtuMax NUMBER, ueObligatoires UEObligatoire_T, ueOptionnelles UEOptionnelle_T);
/

CREATE OR REPLACE TYPE GroupeSpecialite_T AS TABLE of REF Specialite_T;
/

CREATE OR REPLACE TYPE Inscription_T AS OBJECT  (dateInscription DATE, specialite REF Specialite_T);
/

CREATE OR REPLACE TYPE Niveau_T AS OBJECT (nomNiveau VARCHAR2(80), specialites GroupeSpecialite_T);
/

CREATE OR REPLACE TYPE GroupeNiveau_T AS VARRAY(5) OF  Niveau_T;
/

CREATE OR REPLACE TYPE Filiere_T AS OBJECT (nomFiliere VARCHAR2(80),  Niveaux GroupeNiveau_T);
/

CREATE OR REPLACE TYPE GroupeFiliere_T AS TABLE OF REF Filiere_T;
/

CREATE OR REPLACE TYPE Universite_T AS OBJECT (nomUniversite VARCHAR2(80), adresse Adresse_T, filieres GroupeFiliere_T, personnes GroupePersonne_T);
/

ALTER TYPE Etudiant_T
ADD ATTRIBUTE(inscription Inscription_T) CASCADE;
/

--TABLES
CREATE TABLE Etudiant OF Etudiant_T;
/

CREATE TABLE Filiere OF Filiere_T;
/

CREATE TABLE UE OF UE_T
NESTED TABLE etudiants STORE AS etudiants;
/

CREATE TABLE Specialite OF Specialite_T
NESTED TABLE ueObligatoires STORE AS ueObligatoires,
NESTED TABLE ueOptionnelles STORE AS ueOptionnelles;
/

CREATE TABLE Universite OF Universite_T
NESTED TABLE filieres STORE AS filieres,
NESTED TABLE personnes STORE AS personnes;
/

--INSERTIONS
INSERT INTO UE VALUES (UE_T(1,'BDA', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(2,'Presentation des données web', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(3,'Logique', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(4,'Langages formels', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(5,'Complexite et calculabilite', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(6,'Compilation Interpretation', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(7,'Programmation linéaire', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(8,'Anglais', GroupeEtudiant_T() ));

--Spécialités de Licence Info
INSERT INTO Specialite VALUES ( Specialite_T ('L1info', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('L2info', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('L3info', 100, UEObligatoire_T(), UEOptionnelle_T() ));

--Spécialités de Master 1 Info
INSERT INTO Specialite VALUES ( Specialite_T ('AIGLE1', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('IMAGINA1', 50, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('DECOL1', 100, UEObligatoire_T(), UEOptionnelle_T() ));

--Spécialités de Master 2 Info
INSERT INTO Specialite VALUES ( Specialite_T ('AIGLE2', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('IMAGINA2', 50, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('DECOL2', 100, UEObligatoire_T(), UEOptionnelle_T() ));

--modifier les UEObligatoires
UPDATE Specialite SET ueObligatoires = UEObligatoire_T(
(SELECT REF(U) FROM UE U WHERE U.codeUE = '1'),
(SELECT REF(U) FROM UE U WHERE U.codeUE = '2'),
(SELECT REF(U) FROM UE U WHERE U.codeUE = '3'),
(SELECT REF(U) FROM UE U WHERE U.codeUE = '8'))
WHERE nomSpecialite = 'AIGLE1';

UPDATE Specialite SET ueOptionnelles = UEOptionnelle_T(
(SELECT REF(U) FROM UE U WHERE U.codeUE = '5'),
(SELECT REF(U) FROM UE U WHERE U.codeUE = '6'),
(SELECT REF(U) FROM UE U WHERE U.codeUE = '7'),
(SELECT REF(U) FROM UE U WHERE U.codeUE = '4'))
WHERE nomSpecialite = 'AIGLE1';

INSERT INTO Filiere VALUES ('INFORMATIQUE', GroupeNiveau_T(
Niveau_T('L1',GroupeSpecialite_T()),
Niveau_T('L2',GroupeSpecialite_T()),
Niveau_T('L3',GroupeSpecialite_T()),
Niveau_T('M1',GroupeSpecialite_T()),
Niveau_T('M2',GroupeSpecialite_T())
));

INSERT INTO Universite VALUES (Universite_T('Paul Valery', Adresse_T('Montpellier', 34090, 54, 'Place Bataillon', NULL), GroupeFiliere_T(), GroupePersonne_T()));
INSERT INTO Universite VALUES (Universite_T('Universite des sciences', Adresse_T('Montpellier', 34095, 545, 'Place Bataillon', NULL), GroupeFiliere_T(), GroupePersonne_T()));
INSERT INTO Universite VALUES (Universite_T('Universite de Luminy', Adresse_T('Marseille', 13288, 163, 'Avenue de Luminy', NULL), GroupeFiliere_T(), GroupePersonne_T()));
INSERT INTO Universite VALUES (Universite_T('Universite de Picardie', Adresse_T('Amiens', 80025, 96, 'Chemin du Thil', 'CS 52501 80025 Cedex'), GroupeFiliere_T(), GroupePersonne_T()));
INSERT INTO Universite VALUES (Universite_T('Universite de Lorraine', Adresse_T('Nancy', 54000, 34, 'Cours Leopold', NULL), GroupeFiliere_T(), GroupePersonne_T()));
INSERT INTO Universite VALUES (Universite_T('Universite de Strasbourg', Adresse_T('Strasbourg', 67081, 4, 'Rue Blaise Pascal', NULL), GroupeFiliere_T(), GroupePersonne_T()));
