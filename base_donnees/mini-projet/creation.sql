--------------------------------------------------------------------------------------------------CLEAR------------------------------------------------------------------------------------------------
DROP TABLE Etudiant;
/

DROP TABLE Filiere;
/

DROP TABLE UE;
/

DROP TABLE Specialite;
/

DROP TABLE Universite;
/

DROP TYPE Universite_T FORCE;
/

DROP TYPE Adresse_T FORCE;
/color

DROP TYPE GroupePersonne_T FORCE;
/

DROP TYPE Personne_T FORCE;
/

DROP TYPE UEObligatoire_T FORCE;
/

DROP TYPE UEOptionnelle_T FORCE;
/

DROP TYPE UE_T FORCE;
/

DROP TYPE GroupeSpecialite_T FORCE;
/

DROP TYPE Specialite_T FORCE;
/

DROP TYPE Inscription_T FORCE;
/

DROP TYPE GroupeFiliere_T FORCE;
/

DROP TYPE Filiere_T FORCE;
/


--------------------------------------------------------------------------------------------------CREATIONS------------------------------------------------------------------------------------------------

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



CREATE OR REPLACE TYPE Specialite_T AS OBJECT (nomSpecialite VARCHAR2(80), annee VARCHAR(5), nbEtuMax NUMBER, ueObligatoires UEObligatoire_T, ueOptionnelles UEOptionnelle_T);
/

CREATE OR REPLACE TYPE GroupeSpecialite_T AS TABLE of REF Specialite_T;
/

CREATE OR REPLACE TYPE Inscription_T AS OBJECT  (dateInscription DATE,  specialite REF Specialite_T);
/

CREATE OR REPLACE TYPE Filiere_T AS OBJECT (nomFiliere VARCHAR2(80),  specialites GroupeSpecialite_T);
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

CREATE TABLE Filiere OF Filiere_T
NESTED TABLE specialites STORE AS specialites;
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

----------------------------------------------------------------------------------------------------INSERTIONS--------------------------------------------------------------------------------------------------

------------------------------------------------------------------------------------------------Debut Universite------------------------------------------------------------------------------------------------

--Spécialités de Licence Info
INSERT INTO Specialite VALUES ( Specialite_T ('informatique', 'L1', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('informatique', 'L2', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('informatique', 'L3', 100, UEObligatoire_T(), UEOptionnelle_T() ));
--Spécialités de Licence math
INSERT INTO Specialite VALUES ( Specialite_T ('math', 'L1', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('math', 'L2', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('math', 'L3', 100, UEObligatoire_T(), UEOptionnelle_T() ));
--Spécialités de Licence Physique
INSERT INTO Specialite VALUES ( Specialite_T ('physique', 'L1', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('physique', 'L2', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('physique', 'L3', 100, UEObligatoire_T(), UEOptionnelle_T() ));

--Spécialités de Master 1 Info
INSERT INTO Specialite VALUES ( Specialite_T ('aigle', 'M1', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('imagina', 'M1', 50, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('decol', 'M1', 100, UEObligatoire_T(), UEOptionnelle_T() ));
--Spécialités de Master 1 Physique
INSERT INTO Specialite VALUES ( Specialite_T ('newton', 'M1', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('nucleaire', 'M1', 50, UEObligatoire_T(), UEOptionnelle_T() ));

--Spécialités de Master 2 Info
INSERT INTO Specialite VALUES ( Specialite_T ('aigle', 'M2', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('imagina', 'M2', 50, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('decol', 'M2', 100, UEObligatoire_T(), UEOptionnelle_T() ));
--Spécialités de Master 2 Physique
INSERT INTO Specialite VALUES ( Specialite_T ('newton', 'M2', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('nucleaire', 'M2', 50, UEObligatoire_T(), UEOptionnelle_T() ));

--Filiere 
INSERT INTO Filiere VALUES('informatique',
    GroupeSpecialite_T(
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'informatique' and annee = 'L1'),
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'informatique' and annee = 'L2'),
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'informatique' and annee = 'L3'),
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'aigle' and annee = 'M1'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'imagina' and annee = 'M1'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'decol' and annee = 'M1'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'aigle' and annee = 'M2'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'imagina' and annee = 'M2'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'decol' and annee = 'M2')
    )
);

INSERT INTO Filiere VALUES('physique',
    GroupeSpecialite_T(
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'physique' and annee = 'L1'),
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'physique' and annee = 'L2'),
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'physique' and annee = 'L3'),
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'newton' and annee = 'M1'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'nucleaire' and annee = 'M1'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'newton' and annee = 'M2'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'nucleaire' and annee = 'M2')
    )
);

INSERT INTO Filiere VALUES('mathematique',
    GroupeSpecialite_T(
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'math' and annee = 'L1'),
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'math' and annee = 'L2'),
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'math' and annee = 'L3')
    )
);


INSERT INTO UE VALUES (UE_T(1,'BDA', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(2,'Presentation des données web', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(3,'Logique des propositions', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(4,'Langages formels', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(5,'Complexite et calculabilite', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(6,'Compilation Interpretation', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(7,'Programmation linéaire', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(8,'Anglais', GroupeEtudiant_T() ));

--modifier les UEObligatoires
call dbms_output.put_line('modification des UEs obligatoires'); 
UPDATE Specialite SET ueObligatoires = UEObligatoire_T(
(SELECT REF(U) FROM UE U WHERE U.codeUE = '1'),
(SELECT REF(U) FROM UE U WHERE U.codeUE = '2'),
(SELECT REF(U) FROM UE U WHERE U.codeUE = '3'),
(SELECT REF(U) FROM UE U WHERE U.codeUE = '8'))
WHERE nomSpecialite = 'aigle' and annee = 'M1';

call dbms_output.put_line('modification des UEs obligatoires'); 
UPDATE Specialite SET ueObligatoires = UEObligatoire_T(
(SELECT REF(U) FROM UE U WHERE U.codeUE = '1'),
(SELECT REF(U) FROM UE U WHERE U.codeUE = '2'),
(SELECT REF(U) FROM UE U WHERE U.codeUE = '5'),
(SELECT REF(U) FROM UE U WHERE U.codeUE = '4'))
WHERE nomSpecialite = 'decol' and annee = 'M1';

call dbms_output.put_line('modification des UEs obligatoires'); 
UPDATE Specialite SET ueObligatoires = UEObligatoire_T(
(SELECT REF(U) FROM UE U WHERE U.codeUE = '1'),
(SELECT REF(U) FROM UE U WHERE U.codeUE = '2'),
(SELECT REF(U) FROM UE U WHERE U.codeUE = '3'),
(SELECT REF(U) FROM UE U WHERE U.codeUE = '6'))
WHERE nomSpecialite = 'imagina' and annee = 'M1';

UPDATE Specialite SET ueOptionnelles = UEOptionnelle_T(
(SELECT REF(U) FROM UE U WHERE U.codeUE = '5'),
(SELECT REF(U) FROM UE U WHERE U.codeUE = '6'),
(SELECT REF(U) FROM UE U WHERE U.codeUE = '7'),
(SELECT REF(U) FROM UE U WHERE U.codeUE = '4'))
WHERE nomSpecialite = 'aigle' and annee = 'M1';

insert into Etudiant values (Etudiant_T('Macvain', 'Marten', TO_DATE('05/06/1998','dd/mm/yyyy'), 135813631, Inscription_T(TO_DATE('02/09/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'aigle' and annee = 'M1'))));
insert into Etudiant values (Etudiant_T('Rodriguez', 'Eloise', TO_DATE('19/04/1996','dd/mm/yyyy'), 899421083, Inscription_T(TO_DATE('01/09/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'aigle' and annee = 'M2'))));
insert into Etudiant values (Etudiant_T('Hedges', 'Courtenay', TO_DATE('18/12/1998','dd/mm/yyyy'), 509383738, Inscription_T(TO_DATE('05/07/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'aigle' and annee = 'M1'))));
insert into Etudiant values (Etudiant_T('Angelo', 'Lane', TO_DATE('13/01/1997','dd/mm/yyyy'), 269247756, Inscription_T(TO_DATE('04/09/2017','dd/mm/yyyy'),(SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'aigle' and annee = 'M2'))));
insert into Etudiant values (Etudiant_T('Castellet', 'Willy', TO_DATE('08/04/1995','dd/mm/yyyy'), 899816273, Inscription_T(TO_DATE('05/08/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'aigle' and annee = 'M1'))));
insert into Etudiant values (Etudiant_T('Wrigglesworth', 'Krystyna', TO_DATE('15/08/1998','dd/mm/yyyy'), 837328578, Inscription_T(TO_DATE('05/09/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'aigle' and annee = 'M2'))));
insert into Etudiant values (Etudiant_T('Gynni', 'Ari', TO_DATE('06/03/1998','dd/mm/yyyy'), 795433545, Inscription_T(TO_DATE('15/08/2017','dd/mm/yyyy'),(SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'aigle' and annee = 'M1'))));
insert into Etudiant values (Etudiant_T('Grzesiak', 'Ferdinand', TO_DATE('04/01/1994','dd/mm/yyyy'), 977930189, Inscription_T(TO_DATE('18/09/2017','dd/mm/yyyy'),(SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'aigle' and annee = 'M2'))));
insert into Etudiant values (Etudiant_T('O''Sculley', 'Erl', TO_DATE('30/05/1998','dd/mm/yyyy'), 053529807, Inscription_T(TO_DATE('06/07/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'aigle' and annee = 'M1'))));
insert into Etudiant values (Etudiant_T('Inde', 'Janis', TO_DATE('11/09/1995','dd/mm/yyyy'), 901633321, Inscription_T(TO_DATE('05/07/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'imagina' and annee = 'M2'))));
insert into Etudiant values (Etudiant_T('Simeoni', 'Annis', TO_DATE('22/01/1995','dd/mm/yyyy'), 557998331, Inscription_T(TO_DATE('17/08/2017','dd/mm/yyyy'),(SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'imagina' and annee = 'M1'))));
insert into Etudiant values (Etudiant_T('Tunnick', 'Rutger', TO_DATE('19/08/1996','dd/mm/yyyy'), 387215056, Inscription_T(TO_DATE('20/09/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'imagina' and annee = 'M2'))));
insert into Etudiant values (Etudiant_T('Salsbury', 'Denice', TO_DATE('18/03/1999','dd/mm/yyyy'), 893265517, Inscription_T(TO_DATE('01/09/2017','dd/mm/yyyy'),(SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'imagina' and annee = 'M1'))));
insert into Etudiant values (Etudiant_T('Chritchley', 'Melita', TO_DATE('16/09/1996','dd/mm/yyyy'), 026018030, Inscription_T(TO_DATE('28/08/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'imagina' and annee = 'M2'))));
insert into Etudiant values (Etudiant_T('Fattorini', 'Wallis', TO_DATE('05/10/1998','dd/mm/yyyy'), 793565381, Inscription_T( TO_DATE('30/08/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'imagina' and annee = 'M1'))));
insert into Etudiant values (Etudiant_T('Kendle', 'Godfree', TO_DATE('29/01/1998','dd/mm/yyyy'), 331494420, Inscription_T(TO_DATE('04/07/2017','dd/mm/yyyy'),(SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'imagina' and annee = 'M1'))));
insert into Etudiant values (Etudiant_T('Peealess', 'Kelli', TO_DATE('24/12/1995','dd/mm/yyyy'), 921034462, Inscription_T(TO_DATE('20/09/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'decol' and annee = 'M2'))));
insert into Etudiant values (Etudiant_T('O''Scanlon', 'Darn', TO_DATE('22/04/1997','dd/mm/yyyy'), 761490474, Inscription_T(TO_DATE('12/08/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'decol' and annee = 'M2'))));
insert into Etudiant values (Etudiant_T('Stickells', 'Jackson', TO_DATE('30/04/1995','dd/mm/yyyy'), 431810176, Inscription_T(TO_DATE('05/09/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'decol' and annee = 'M1'))));
insert into Etudiant values (Etudiant_T('Feighney', 'Stephie', TO_DATE('17/01/1996','dd/mm/yyyy'), 762975184, Inscription_T(TO_DATE('14/07/2017','dd/mm/yyyy'),  (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'decol' and annee = 'M1'))));
insert into Etudiant values (Etudiant_T('Karpychev', 'Buddy', TO_DATE('05/01/2000','dd/mm/yyyy'), 781097472, Inscription_T(TO_DATE('15/07/2017','dd/mm/yyyy'),(SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'decol' and annee = 'M2'))));
insert into Etudiant values (Etudiant_T('Tayloe', 'Vanni', TO_DATE('17/10/1995','dd/mm/yyyy'), 180690232, Inscription_T(TO_DATE('15/08/2017','dd/mm/yyyy'),  (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'decol' and annee = 'M1'))));
insert into Etudiant values (Etudiant_T('Emett', 'Ambrosius', TO_DATE('20/09/1999','dd/mm/yyyy'), 597076188, Inscription_T(TO_DATE('02/08/2017','dd/mm/yyyy'),  (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'decol' and annee = 'M2'))));
insert into Etudiant values (Etudiant_T('Hyrons', 'Alie', TO_DATE('22/06/1995','dd/mm/yyyy'), 839973451, Inscription_T(TO_DATE('09/08/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'informatique' and annee = 'L1'))));
insert into Etudiant values (Etudiant_T('Abbett', 'Osborn', TO_DATE('03/12/1998','dd/mm/yyyy'), 399585723, Inscription_T(TO_DATE('16/07/2017','dd/mm/yyyy'),  (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'mathematique'  and annee = 'L1'))));
insert into Etudiant values (Etudiant_T('Caudwell', 'Flin', TO_DATE('14/07/1997','dd/mm/yyyy'), 029976274, Inscription_T(TO_DATE('22/08/2017','dd/mm/yyyy'),  (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite  = 'physique' and annee = 'L1'))));
insert into Etudiant values (Etudiant_T('Ball', 'Maje', TO_DATE('26/11/1999','dd/mm/yyyy'), 631580297, Inscription_T(TO_DATE('18/09/2017','dd/mm/yyyy'),  (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'informatique' and annee = 'L1'))));
insert into Etudiant values (Etudiant_T('Iashvili', 'Tani', TO_DATE('07/11/1995','dd/mm/yyyy'), 792779943, Inscription_T(TO_DATE('17/08/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'informatique' and annee = 'L2'))));
insert into Etudiant values (Etudiant_T('Spracklin', 'Rosanne', TO_DATE('18/02/1998','dd/mm/yyyy'), 437128387, Inscription_T(TO_DATE('16/07/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'informatique' and annee = 'L2'))));
insert into Etudiant values (Etudiant_T('Onians', 'Bancroft', TO_DATE('13/10/1999','dd/mm/yyyy'), 760333365, Inscription_T(TO_DATE('15/09/2017','dd/mm/yyyy'),  (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite  = 'mathematique' and annee = 'L2'))));
insert into Etudiant values (Etudiant_T('Kinnin', 'Kippy', TO_DATE('03/03/1994','dd/mm/yyyy'), 916700555, Inscription_T(TO_DATE('30/09/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite   = 'mathematique' and annee = 'L3'))));
insert into Etudiant values (Etudiant_T('Hofner', 'Gabbie', TO_DATE('25/06/1997','dd/mm/yyyy'), 825481825, Inscription_T(TO_DATE('28/08/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'informatique' and annee = 'L3'))));
insert into Etudiant values (Etudiant_T('Hasluck', 'Mallorie', TO_DATE('13/01/2000','dd/mm/yyyy'), 627649845, Inscription_T(TO_DATE('24/09/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'informatique' and annee = 'L1'))));
insert into Etudiant values (Etudiant_T('Parfrey', 'Clemens', TO_DATE('08/10/2000','dd/mm/yyyy'), 834120468, Inscription_T(TO_DATE('21/09/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite  = 'physique' and annee = 'L1'))));
insert into Etudiant values (Etudiant_T('Faldoe', 'Adam', TO_DATE('25/11/1998','dd/mm/yyyy'), 666521647, Inscription_T(TO_DATE('22/07/2017','dd/mm/yyyy'),  (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'informatique' and annee = 'L2'))));
insert into Etudiant values (Etudiant_T('Welch', 'Alphonse', TO_DATE('30/06/1994','dd/mm/yyyy'), 742695831, Inscription_T(TO_DATE('14/08/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite= 'informatique' and annee = 'L1'))));
insert into Etudiant values (Etudiant_T('Petrolli', 'Clarita', TO_DATE('01/07/1996','dd/mm/yyyy'), 800127196, Inscription_T(TO_DATE('29/08/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite  = 'physique' and annee = 'L2'))));
insert into Etudiant values (Etudiant_T('Le Claire', 'Alex', TO_DATE('04/02/1994','dd/mm/yyyy'), 663270244, Inscription_T(TO_DATE('24/09/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite  = 'physique' and annee = 'L1'))));

INSERT INTO Universite VALUES (Universite_T('Universite de Montpellier', Adresse_T('Montpellier', 34095, 545, 'Place Bataillon', NULL), GroupeFiliere_T(), GroupePersonne_T()));

UPDATE Universite u SET filieres = GroupeFiliere_T(
    (SELECT REF(f) FROM Filiere f WHERE nomFiliere = 'informatique'),
    (SELECT REF(f) FROM Filiere f WHERE nomFiliere = 'physique'),
    (SELECT REF(f) FROM Filiere f WHERE nomFiliere = 'mathematique')
) WHERE u.nomUniversite = 'Universite de Montpellier';

------------------------------------------------------------------------------------------------Fin Université 2------------------------------------------------------------------------------------------------

------------------------------------------------------------------------------------------------debut Polvaleri------------------------------------------------------------------------------------------------


--Spécialités de Licence langue
INSERT INTO Specialite VALUES ( Specialite_T ('langue', 'L1', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('langue', 'L2', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('langue', 'L3', 100, UEObligatoire_T(), UEOptionnelle_T() ));
--Spécialités de Licence art
INSERT INTO Specialite VALUES ( Specialite_T ('art', 'L1', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('art', 'L2', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('art', 'L3', 100, UEObligatoire_T(), UEOptionnelle_T() ));

--Spécialités de Master 1 langue
INSERT INTO Specialite VALUES ( Specialite_T ('anglais', 'M1', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('espagnol', 'M1', 50, UEObligatoire_T(), UEOptionnelle_T() ));
--Spécialités de Master 1 art
INSERT INTO Specialite VALUES ( Specialite_T ('cinema', 'M1', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('painture', 'M1', 50, UEObligatoire_T(), UEOptionnelle_T() ));

--Spécialités de Master 2 langue
INSERT INTO Specialite VALUES ( Specialite_T ('anglais', 'M2', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('espagnol', 'M2', 50, UEObligatoire_T(), UEOptionnelle_T() ));
--Spécialités de Master 2 art
INSERT INTO Specialite VALUES ( Specialite_T ('cinema', 'M2', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('painture', 'M2', 50, UEObligatoire_T(), UEOptionnelle_T() ));

--Filiere 
INSERT INTO Filiere VALUES('langue',
    GroupeSpecialite_T(
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'langue' and annee = 'L1'),
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'langue' and annee = 'L2'),
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'langue' and annee = 'L3'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'anglais' and annee = 'M1'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'espagnol' and annee = 'M1'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'anglais' and annee = 'M2'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'espagnol' and annee = 'M2')
    )
);

INSERT INTO Filiere VALUES('art',
    GroupeSpecialite_T(
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'art' and annee = 'L1'),
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'art' and annee = 'L2'),
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'art' and annee = 'L3'),
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'cinema' and annee = 'M1'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'painture' and annee = 'M1'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'cinema' and annee = 'M2'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'painture' and annee = 'M2')
    )
);

--etudiants
insert into Etudiant values (Etudiant_T('Ortas', 'Carlene', TO_DATE('01/12/1998','dd/mm/yyyy'), 720388260, Inscription_T(TO_DATE('02/09/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'langue' and annee = 'L1'))));
insert into Etudiant values (Etudiant_T('Ervin', 'Nathalia', TO_DATE('21/08/1998','dd/mm/yyyy'), 165016075, Inscription_T(TO_DATE('15/09/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'langue' and annee = 'L2'))));
insert into Etudiant values (Etudiant_T('Luffman', 'Frederich', TO_DATE('19/06/2000','dd/mm/yyyy'), 733782228, Inscription_T(TO_DATE('05/07/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'langue' and annee = 'L3'))));
insert into Etudiant values (Etudiant_T('Pirkis', 'Penny', TO_DATE('19/03/1998','dd/mm/yyyy'), 717500918, Inscription_T(TO_DATE('20/09/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'anglais' and annee = 'M1'))));
insert into Etudiant values (Etudiant_T('Spanswick', 'Shari', TO_DATE('11/01/2000','dd/mm/yyyy'), 922042622, Inscription_T(TO_DATE('27/08/2017','dd/mm/yyyy'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'anglais' and annee = 'M2'))));
insert into Etudiant values (Etudiant_T('Jorg', 'Jeanette', TO_DATE('11/01/2000','dd/mm/yyyy'), 423146603, Inscription_T(NULL, (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'espagnol' and annee = 'M1'))));

INSERT INTO Universite VALUES (Universite_T('Universite des sciences', Adresse_T('Montpellier', 34095, 545, 'Place Bataillon', NULL), GroupeFiliere_T(), GroupePersonne_T()));

UPDATE Universite u SET filieres = GroupeFiliere_T(
    (SELECT REF(f) FROM Filiere f WHERE nomFiliere = 'langue'),
    (SELECT REF(f) FROM Filiere f WHERE nomFiliere = 'art')
) WHERE u.nomUniversite = 'Paul Valery';

------------------------------------------------------------------------------------------------------Fin polvaleri---------------------------------------------------------------------------------------------------

------------------------------------------------------------------------------------------------Debut Université 3-------------------------------------------------------------------------------------------------

--INSERTIONS

--Spécialités de Licence Droit
INSERT INTO Specialite VALUES ( Specialite_T ('droit', 'L1', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('droit', 'L2', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('droit', 'L3', 100, UEObligatoire_T(), UEOptionnelle_T() ));
--Spécialités de Licence Commerce
INSERT INTO Specialite VALUES ( Specialite_T ('commerce', 'L1', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('commerce', 'L2', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('commerce', 'L3', 100, UEObligatoire_T(), UEOptionnelle_T() ));

--Spécialités de Master 1 Droit
INSERT INTO Specialite VALUES ( Specialite_T ('droit public', 'M1', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('droit fiscal', 'M1', 50, UEObligatoire_T(), UEOptionnelle_T() ));
--Spécialités de Master 1 Commerce
INSERT INTO Specialite VALUES ( Specialite_T ('finance', 'M1', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('marketing', 'M1', 50, UEObligatoire_T(), UEOptionnelle_T() ));

--Spécialités de Master 2 Droit
INSERT INTO Specialite VALUES ( Specialite_T ('droit public', 'M2', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('droit fiscal', 'M2', 50, UEObligatoire_T(), UEOptionnelle_T() ));
--Spécialités de Master 2 Commerce
INSERT INTO Specialite VALUES ( Specialite_T ('finance', 'M2', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('marketing', 'M2', 50, UEObligatoire_T(), UEOptionnelle_T() ));

--Filiere 
INSERT INTO Filiere VALUES('droit',
    GroupeSpecialite_T(
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'droit' and annee = 'L1'),
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'droit' and annee = 'L2'),
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'droit' and annee = 'L3'),
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'droit public' and annee = 'M1'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'droit fiscal' and annee = 'M1'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'droit public' and annee = 'M2'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'droit fiscal' and annee = 'M2')
    )
);

INSERT INTO Filiere VALUES('commerce',
    GroupeSpecialite_T(
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'commerce' and annee = 'L1'),
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'commerce' and annee = 'L2'),
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'commerce' and annee = 'L3'),
          (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'finance' and annee = 'M1'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'marketing' and annee = 'M1'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'finance' and annee = 'M2'),
            (SELECT REF(s) FROM Specialite s WHERE nomSpecialite = 'marketing' and annee = 'M2')
    )
);



--etudiants
insert into Etudiant values (Etudiant_T('Rossin', 'Rosana', TO_DATE('11/01/1997','dd/mm/yyyy'), 040460361, Inscription_T(TO_DATE('02/09/2017','dd/mm/yyyy'),(SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'droit' and annee = 'L1'))));
insert into Etudiant values (Etudiant_T('Kittel', 'Lindie', TO_DATE('20/04/1996','dd/mm/yyyy'), 644712348, Inscription_T(TO_DATE('24/09/2017','dd/mm/yyyy'),(SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'droit' and annee = 'L3'))));
insert into Etudiant values (Etudiant_T('Wilkisson', 'Shelley', TO_DATE('20/06/1994','dd/mm/yyyy'), 714201197, Inscription_T(TO_DATE('29/08/2017','dd/mm/yyyy'),(SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'droit public' and annee = 'M1'))));
insert into Etudiant values (Etudiant_T('Temblett', 'Gav', TO_DATE('08/08/1998','dd/mm/yyyy'), 422040289, Inscription_T(TO_DATE('11/09/2017','dd/mm/yyyy'),(SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'marketing' and annee = 'M1'))));
insert into Etudiant values (Etudiant_T('Eddowes', 'Alyosha', TO_DATE('13/07/1997','dd/mm/yyyy'), 604495851, Inscription_T(TO_DATE('18/08/2017','dd/mm/yyyy'),(SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'commerce' and annee = 'L2'))));
insert into Etudiant values (Etudiant_T('Hadlee', 'Emmery', TO_DATE('13/07/1997','dd/mm/yyyy'), 359055729, Inscription_T(NULL,(SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'finance' and annee = 'M2'))));
insert into Etudiant values (Etudiant_T('Gresch', 'Terrell', TO_DATE('13/07/1997','dd/mm/yyyy'), 157631489, Inscription_T(NULL,(SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'commerce' and annee = 'L3'))));


INSERT INTO Universite VALUES (Universite_T('Universite de Strasbourg', Adresse_T('Strasbourg', 67081, 4, 'Rue Blaise Pascal', NULL), GroupeFiliere_T(), GroupePersonne_T()));

UPDATE Universite u SET filieres = GroupeFiliere_T(
    (SELECT  REF(f) FROM Filiere f WHERE nomFiliere = 'droit'),
    (SELECT REF(f) FROM Filiere f WHERE nomFiliere = 'commerce') 
) WHERE u.nomUniversite = 'Universite de Strasbourg';

------------------------------------------------------------------------------------------------Fin Insertion Université 3------------------------------------------------------------------------------------------------



--------------------------------------------------------------------------------------------------------REQUETES----------------------------------------------------------------------------------------------------------

--recupere le nombre d'etudiant inscrit dans les specialites (pour verifier la requete suivante)
select e.inscription.specialite.nomSpecialite as nomSpec, e.inscription.specialite.annee as nivSpec, count(e.inscription.specialite.nomSpecialite) as nbInscrit
from etudiant e
group by (e.inscription.specialite.nomSpecialite, e.inscription.specialite.annee) ;

--Filiere qui accueille le plus d'étudiant
select e1.inscription.specialite.nomSpecialite , e1.inscription.specialite.annee
from etudiant e1
group by (e1.inscription.specialite.nomSpecialite, e1.inscription.specialite.annee)
having count (*) =
(select max(count(*))
from etudiant e2
group by (e2.inscription.specialite.nomSpecialite, e2.inscription.specialite.annee)
);


--Les etudiants qui ne sont pas encore inscrits
Select nomPersonne, prenomPersonne 
From Etudiant e 
Where e.inscription.dateInscription Is NULL;

--Specialite qui propose le plus d'UE Optionnelles
SELECT s.nomSpecialite
FROM Specialite s, TABLE(s.ueOptionnelles) ueOpt
GROUP BY s.nomSpecialite
HAVING COUNT (*) =
(
    SELECT MAX(COUNT(*))
    FROM Specialite s2, TABLE(s2.ueOptionnelles) ueOpt2
    WHERE s.nomSpecialite = s2.nomSpecialite
    GROUP BY s2.nomSpecialite
)

--L'université qui propose le plus de specialites Informatique
SELECT nomUniversite FROM (
    SELECT u.nomUniversite, COUNT(u.nomUniversite) as cpt FROM Universite u, TABLE(u.filieres) f, TABLE(DEREF(VALUE(f)).specialites) s WHERE DEREF(VALUE(f)).nomFiliere = 'informatique' GROUP BY u.nomUniversite 
) WHERE cpt = (SELECT MAX(COUNT(u.nomUniversite)) as cpt FROM Universite u, TABLE(u.filieres) f, TABLE(DEREF(VALUE(f)).specialites) s WHERE DEREF(VALUE(f)).nomFiliere = 'informatique' GROUP BY u.nomUniversite);

--Le nombre d'étudiant inscrit en 'M1' dans "Université de Montpellier'
SELECT count(DISTINCT e.nomPersonne)
FROM Etudiant e, Universite u, table(u.filieres) f, table(deref(value(f)).specialites) s
WHERE e.inscription.specialite.annee = 'M1'
AND u.nomUniversite = 'Universite de Montpellier'
AND DEREF(value(s)).nomSpecialite = e.inscription.specialite.nomSpecialite;

--Quelles est l'UE Obligatoire disponible dans le plus de spécialitées
SELECT ue.nomUE
FROM UE ue
GROUP BY ue.nomUE
HAVING COUNT(*) = (
    SELECT MAX(COUNT(*))
    FROM Specialite s, table(s.ueObligatoires) ueObl
    WHERE DEREF(value(ueObl)).nomUE = ue.nomUe
    GROUP BY DEREF(value(ueObl)).nomUE

-- Les 7 jours ou il y a eu le plus d'inscription 
SELECT * FROM
(SELECT e.inscription.dateInscription as dateInscription, count(*) as nbInscriptions
        FROM Etudiant e
        GROUP BY e.inscription.dateInscription
        ORDER BY count(*) DESC
 ) WHERE dateInscription IS NOT NULL
   AND ROWNUM < 7;
