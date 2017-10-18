--CLEAR
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
/

DROP TYPE GroupePersonne_T FORCE;
/

DROP TYPE Personne_T FORCE;
/

DROP TYPE GroupeEtudiant_T FORCE;
/

DROP TYPE Etudiant_T FORCE;
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

DROP TYPE GroupeNiveau_T FORCE;
/

DROP TYPE Niveau_T FORCE;
/

DROP TYPE GroupeFiliere_T FORCE;
/

DROP TYPE Filiere_T FORCE;
/


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

CREATE OR REPLACE TYPE Niveau_T AS OBJECT (nomNiveau VARCHAR2(80), specialites GroupeSpecialite_T);
/

CREATE OR REPLACE TYPE Inscription_T AS OBJECT  (dateInscription DATE, niveau REF Niveau_T,  specialite REF Specialite_T);
/

CREATE OR REPLACE TYPE GroupeNiveau_T AS VARRAY(5) OF  REF Niveau_T;
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

CREATE TABLE Niveau OF Niveau_T
NESTED TABLE specialites STORE AS specialites;
/

CREATE TABLE Universite OF Universite_T
NESTED TABLE filieres STORE AS filieres,
NESTED TABLE personnes STORE AS personnes;
/

--INSERTIONS
INSERT INTO UE VALUES (UE_T(1,'BDA', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(2,'Presentation des données web', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(3,'Logique des propositions', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(4,'Langages formels', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(5,'Complexite et calculabilite', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(6,'Compilation Interpretation', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(7,'Programmation linéaire', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(8,'Anglais', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(9,'Histoire', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(10,'Espagnol', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(11,'Allemand', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(12,'Graphe', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(13,'Proba. Stat.', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(14,'Science social', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(15,'Gestion de projet', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(16,'IHM', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(16,'IA', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(17,'Logique des predicats', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(18,'Musique', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(19,'Français', GroupeEtudiant_T() ));
INSERT INTO UE VALUES (UE_T(20,'Physique. Chimie.', GroupeEtudiant_T() ));

--Spécialités de Licence Info
INSERT INTO Specialite VALUES ( Specialite_T ('L1info', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('L2info', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('L3info', 100, UEObligatoire_T(), UEOptionnelle_T() ));
--Spécialités de Licence math
INSERT INTO Specialite VALUES ( Specialite_T ('L1math', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('L2math', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('L3math', 100, UEObligatoire_T(), UEOptionnelle_T() ));
--Spécialités de Licence Physique
INSERT INTO Specialite VALUES ( Specialite_T ('L1physique', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('L2physique', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('L3physique', 100, UEObligatoire_T(), UEOptionnelle_T() ));

--Spécialités de Master 1 Info
INSERT INTO Specialite VALUES ( Specialite_T ('AIGLE1', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('IMAGINA1', 50, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('DECOL1', 100, UEObligatoire_T(), UEOptionnelle_T() ));
--Spécialités de Master 1 Physique
INSERT INTO Specialite VALUES ( Specialite_T ('Newton', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('Nucleaire', 50, UEObligatoire_T(), UEOptionnelle_T() ));

--Spécialités de Master 2 Info
INSERT INTO Specialite VALUES ( Specialite_T ('AIGLE2', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('IMAGINA2', 50, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('DECOL2', 100, UEObligatoire_T(), UEOptionnelle_T() ));
--Spécialités de Master 2 Physique
INSERT INTO Specialite VALUES ( Specialite_T ('Newton', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('Nucleaire', 50, UEObligatoire_T(), UEOptionnelle_T() ));



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


INSERT INTO Niveau VALUES (Niveau_T(M1,
GroupeSpecialite_T(
(SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'DECOL'),
(SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'IMAGINA'),
(SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'AIGLE')
)
);

INSERT INTO Niveau VALUES (Niveau_T(M1,
GroupeSpecialite_T(
(SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'Newton'),
(SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'Nucleair'),
)
);

INSERT INTO Niveau VALUES (Niveau_T(M2,
GroupeSpecialite_T(
(SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'DECOL'),
(SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'IMAGINA'),
(SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'AIGLE')
)
);

INSERT INTO Niveau VALUES (Niveau_T(M2,
GroupeSpecialite_T(
(SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'Newton'),
(SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'Nucleair'),
)
);

INSERT INTO Niveau VALUES (Niveau_T(L1, GroupeSpecialite_T(( SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'L1info'));
INSERT INTO Niveau VALUES (Niveau_T(L1, GroupeSpecialite_T(( SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'L1physique'));
INSERT INTO Niveau VALUES (Niveau_T(L1, GroupeSpecialite_T(( SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'L1math'));

INSERT INTO Niveau VALUES (Niveau_T(L2, GroupeSpecialite_T(( SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'L2info'));
INSERT INTO Niveau VALUES (Niveau_T(L2, GroupeSpecialite_T(( SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'L2physique'));
INSERT INTO Niveau VALUES (Niveau_T(L1, GroupeSpecialite_T(( SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'L1math'));

INSERT INTO Niveau VALUES (Niveau_T(L3, GroupeSpecialite_T(( SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'L3info'));
INSERT INTO Niveau VALUES (Niveau_T(L3, GroupeSpecialite_T(( SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'L1physique'));
INSERT INTO Niveau VALUES (Niveau_T(L1, GroupeSpecialite_T(( SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'L1math'));

/*
Pour référence future : 
    SELECT n.nomniveau, DEREF(value(s)).nomSpecialite
    FROM Filiere f, table(f.niveaux) n, table(n.specialites) s;
    
    INSERT INTO Filiere VALUES (
    'INFORMATIQUE MONTPELLIER', GroupeNiveau_T(
        Niveau_T('M1',GroupeSpecialite_T(
                (SELECT REF(s) FROM Specialite s WHERE s.nomSpecialite = 'AIGLE1'),
                (SELECT REF(s) FROM Specialite s WHERE s.nomSpecialite = 'DECOL1'),
                (SELECT REF(s) FROM Specialite s WHERE s.nomSpecialite = 'IMAGINA1')
            )
        ),
        Niveau_T('M2',GroupeSpecialite_T(
                (SELECT REF(s) FROM Specialite s WHERE s.nomSpecialite = 'AIGLE2'),
                (SELECT REF(s) FROM Specialite s WHERE s.nomSpecialite = 'DECOL2'),
                (SELECT REF(s) FROM Specialite s WHERE s.nomSpecialite = 'IMAGINA2')
            )
        )
    )
);

INSERT INTO Filiere VALUES (
    'EEA MONTPELLIER', GroupeNiveau_T(
        Niveau_T('M1',GroupeSpecialite_T(
                (SELECT REF(s) FROM Specialite s WHERE s.nomSpecialite = 'ROB1'),
                (SELECT REF(s) FROM Specialite s WHERE s.nomSpecialite = 'SEI1'),
                (SELECT REF(s) FROM Specialite s WHERE s.nomSpecialite = 'ISS1')
            )
        ),
        Niveau_T('M2',GroupeSpecialite_T(
                (SELECT REF(s) FROM Specialite s WHERE s.nomSpecialite = 'ROB2'),
                (SELECT REF(s) FROM Specialite s WHERE s.nomSpecialite = 'SEI2'),
                (SELECT REF(s) FROM Specialite s WHERE s.nomSpecialite = 'ISS2')
            )
        )
    )
);
*/

--Filiere 
INSERT INTO Filiere VALUES('INFORMATIQUE',
GroupeNiveau_T(
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'L1'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'L2'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'L3'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'M1'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'M2')
)
);

INSERT INTO Filiere VALUES('PHYSIQUE',
GroupeNiveau_T(
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'L1'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'L2'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'L3'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'M1'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'M2')
)
);

INSERT INTO Filiere VALUES('MATHEMATIQUE',
GroupeNiveau_T(
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'L1'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'L2'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'L3'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'M1'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'M2')
)
);


INSERT INTO Universite VALUES (Universite_T('Paul Valery', Adresse_T('Montpellier', 34090, 54, 'Place Bataillon', NULL), GroupeFiliere_T(), GroupePersonne_T()));
INSERT INTO Universite VALUES (Universite_T('Universite des sciences', Adresse_T('Montpellier', 34095, 545, 'Place Bataillon', NULL), GroupeFiliere_T(), GroupePersonne_T()));
INSERT INTO Universite VALUES (Universite_T('Universite de Luminy', Adresse_T('Marseille', 13288, 163, 'Avenue de Luminy', NULL), GroupeFiliere_T(), GroupePersonne_T()));
INSERT INTO Universite VALUES (Universite_T('Universite de Picardie', Adresse_T('Amiens', 80025, 96, 'Chemin du Thil', 'CS 52501 80025 Cedex'), GroupeFiliere_T(), GroupePersonne_T()));
INSERT INTO Universite VALUES (Universite_T('Universite de Lorraine', Adresse_T('Nancy', 54000, 34, 'Cours Leopold', NULL), GroupeFiliere_T(), GroupePersonne_T()));
INSERT INTO Universite VALUES (Universite_T('Universite de Strasbourg', Adresse_T('Strasbourg', 67081, 4, 'Rue Blaise Pascal', NULL), GroupeFiliere_T(), GroupePersonne_T()));

insert into Etudiant values (Etudiant_T('Macvain', 'Marten', TO_DATE('05/06/1998','dd/mm/yyyy'), 135813631, Inscription_T(TO_DATE('02/09/2017','dd/mm/yyyy'),(SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M1') ,(SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'AIGLE'))));
insert into Etudiant values (Etudiant_T('Rodriguez', 'Eloise', TO_DATE('19/04/1996','dd/mm/yyyy'), 899421083, Inscription_T(TO_DATE('01/09/2017','dd/mm/yyyy'),(SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M2'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'AIGLE'))));
insert into Etudiant values (Etudiant_T('Hedges', 'Courtenay', TO_DATE('18/12/1998','dd/mm/yyyy'), 509383738, Inscription_T(TO_DATE('05/07/2017','dd/mm/yyyy'),(SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M1'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'AIGLE'))));
insert into Etudiant values (Etudiant_T('Angelo', 'Lane', TO_DATE('13/01/1997','dd/mm/yyyy'), 269247756, Inscription_T(TO_DATE('04/09/2017','dd/mm/yyyy'),(SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M1'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'AIGLE'))));
insert into Etudiant values (Etudiant_T('Castellet', 'Willy', TO_DATE('08/04/1995','dd/mm/yyyy'), 899816273, Inscription_T(TO_DATE('05/08/2017','dd/mm/yyyy'), (SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M2'),(SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'AIGLE'))));
insert into Etudiant values (Etudiant_T('Wrigglesworth', 'Krystyna', TO_DATE('15/08/1998','dd/mm/yyyy'), 837328578, Inscription_T(TO_DATE('05/09/2017','dd/mm/yyyy'),(SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M2'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'AIGLE'))));
insert into Etudiant values (Etudiant_T('Gynni', 'Ari', TO_DATE('06/03/1998','dd/mm/yyyy'), 795433545, Inscription_T(TO_DATE('15/08/2017','dd/mm/yyyy'),(SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M1'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'AIGLE'))));
insert into Etudiant values (Etudiant_T('Grzesiak', 'Ferdinand', TO_DATE('04/01/1994','dd/mm/yyyy'), 977930189, Inscription_T(TO_DATE('18/09/2017','dd/mm/yyyy'),(SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M2'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'AIGLE'))));
insert into Etudiant values (Etudiant_T('O''Sculley', 'Erl', TO_DATE('30/05/1998','dd/mm/yyyy'), 053529807, Inscription_T(TO_DATE('06/07/2017','dd/mm/yyyy'), (SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M1'),(SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'AIGLE'))));
insert into Etudiant values (Etudiant_T('Inde', 'Janis', TO_DATE('11/09/1995','dd/mm/yyyy'), 901633321, Inscription_T(TO_DATE('05/07/2017','dd/mm/yyyy'),(SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M1'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'IMAGINA'))));
insert into Etudiant values (Etudiant_T('Simeoni', 'Annis', TO_DATE('22/01/1995','dd/mm/yyyy'), 557998331, Inscription_T(TO_DATE('17/08/2017','dd/mm/yyyy'),(SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M2'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'IMAGINA'))));
insert into Etudiant values (Etudiant_T('Tunnick', 'Rutger', TO_DATE('19/08/1996','dd/mm/yyyy'), 387215056, Inscription_T(TO_DATE('20/09/2017','dd/mm/yyyy'),(SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M2'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'IMAGINA'))));
insert into Etudiant values (Etudiant_T('Salsbury', 'Denice', TO_DATE('18/03/1999','dd/mm/yyyy'), 893265517, Inscription_T(TO_DATE('01/09/2017','dd/mm/yyyy'),(SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M1'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'IMAGINA'))));
insert into Etudiant values (Etudiant_T('Chritchley', 'Melita', TO_DATE('16/09/1996','dd/mm/yyyy'), 026018030, Inscription_T(TO_DATE('28/08/2017','dd/mm/yyyy'),(SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M1'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'IMAGINA'))));
insert into Etudiant values (Etudiant_T('Fattorini', 'Wallis', TO_DATE('05/10/1998','dd/mm/yyyy'), 793565381, Inscription_T( TO_DATE('30/08/2017','dd/mm/yyyy'),(SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M2'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'IMAGINA'))));
insert into Etudiant values (Etudiant_T('Kendle', 'Godfree', TO_DATE('29/01/1998','dd/mm/yyyy'), 331494420, Inscription_T(TO_DATE('04/07/2017','dd/mm/yyyy'),(SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M1'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'IMAGINA'))));
insert into Etudiant values (Etudiant_T('Peealess', 'Kelli', TO_DATE('24/12/1995','dd/mm/yyyy'), 921034462, Inscription_T(TO_DATE('20/09/2017','dd/mm/yyyy'),(SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M2'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'DECOL'))));
insert into Etudiant values (Etudiant_T('O''Scanlon', 'Darn', TO_DATE('22/04/1997','dd/mm/yyyy'), 761490474, Inscription_T(TO_DATE('12/08/2017','dd/mm/yyyy'), (SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M1'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'DECOL'))));
insert into Etudiant values (Etudiant_T('Stickells', 'Jackson', TO_DATE('30/04/1995','dd/mm/yyyy'), 431810176, Inscription_T(TO_DATE('05/09/2017','dd/mm/yyyy'),(SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M1'),  (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'DECOL'))));
insert into Etudiant values (Etudiant_T('Feighney', 'Stephie', TO_DATE('17/01/1996','dd/mm/yyyy'), 762975184, Inscription_T(TO_DATE('14/07/2017','dd/mm/yyyy'),(SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M2'),  (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'DECOL'))));
insert into Etudiant values (Etudiant_T('Karpychev', 'Buddy', TO_DATE('05/01/2000','dd/mm/yyyy'), 781097472, Inscription_T(TO_DATE('15/07/2017','dd/mm/yyyy'), (SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M1'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'DECOL'))));
insert into Etudiant values (Etudiant_T('Tayloe', 'Vanni', TO_DATE('17/10/1995','dd/mm/yyyy'), 180690232, Inscription_T(TO_DATE('15/08/2017','dd/mm/yyyy'),(SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M1'),  (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'DECOL'))));
insert into Etudiant values (Etudiant_T('Emett', 'Ambrosius', TO_DATE('20/09/1999','dd/mm/yyyy'), 597076188, Inscription_T(TO_DATE('02/08/2017','dd/mm/yyyy'), (SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'M1'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'DECOL'))));
insert into Etudiant values (Etudiant_T('Hyrons', 'Alie', TO_DATE('22/06/1995','dd/mm/yyyy'), 839973451, Inscription_T(TO_DATE('09/08/2017','dd/mm/yyyy'), (SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'L1'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'L1info'))));
insert into Etudiant values (Etudiant_T('Abbett', 'Osborn', TO_DATE('03/12/1998','dd/mm/yyyy'), 399585723, Inscription_T(TO_DATE('16/07/2017','dd/mm/yyyy'), (SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'L1'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'L1math'))));
insert into Etudiant values (Etudiant_T('Caudwell', 'Flin', TO_DATE('14/07/1997','dd/mm/yyyy'), 029976274, Inscription_T(TO_DATE('22/08/2017','dd/mm/yyyy'),  (SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'L1'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'L1physique'))));
insert into Etudiant values (Etudiant_T('Ball', 'Maje', TO_DATE('26/11/1999','dd/mm/yyyy'), 631580297, Inscription_T(TO_DATE('18/09/2017','dd/mm/yyyy'),  (SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'L1'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'L1info'))));
insert into Etudiant values (Etudiant_T('Iashvili', 'Tani', TO_DATE('07/11/1995','dd/mm/yyyy'), 792779943, Inscription_T(TO_DATE('17/08/2017','dd/mm/yyyy'),  (SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'L2'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'L2info'))));
insert into Etudiant values (Etudiant_T('Spracklin', 'Rosanne', TO_DATE('18/02/1998','dd/mm/yyyy'), 437128387, Inscription_T(TO_DATE('16/07/2017','dd/mm/yyyy'),  (SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'L2'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'L2info'))));
insert into Etudiant values (Etudiant_T('Onians', 'Bancroft', TO_DATE('13/10/1999','dd/mm/yyyy'), 760333365, Inscription_T(TO_DATE('15/09/2017','dd/mm/yyyy'),  (SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'L2'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'L2math'))));
insert into Etudiant values (Etudiant_T('Kinnin', 'Kippy', TO_DATE('03/03/1994','dd/mm/yyyy'), 916700555, Inscription_T(TO_DATE('30/09/2017','dd/mm/yyyy'), (SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'L3'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'L3physique'))));
insert into Etudiant values (Etudiant_T('Hofner', 'Gabbie', TO_DATE('25/06/1997','dd/mm/yyyy'), 825481825, Inscription_T(TO_DATE('28/08/2017','dd/mm/yyyy'), (SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'L3'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'L3info'))));
insert into Etudiant values (Etudiant_T('Hasluck', 'Mallorie', TO_DATE('13/01/2000','dd/mm/yyyy'), 627649845, Inscription_T(TO_DATE('24/09/2017','dd/mm/yyyy'), (SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'L1'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'L1info'))));
insert into Etudiant values (Etudiant_T('Parfrey', 'Clemens', TO_DATE('08/10/2000','dd/mm/yyyy'), 834120468, Inscription_T(TO_DATE('21/09/2017','dd/mm/yyyy'), (SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'L1'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'L1physique'))));
insert into Etudiant values (Etudiant_T('Faldoe', 'Adam', TO_DATE('25/11/1998','dd/mm/yyyy'), 666521647, Inscription_T(TO_DATE('22/07/2017','dd/mm/yyyy'), (SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'L2'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'L2info'))));
insert into Etudiant values (Etudiant_T('Welch', 'Alphonse', TO_DATE('30/06/1994','dd/mm/yyyy'), 742695831, Inscription_T(TO_DATE('14/08/2017','dd/mm/yyyy'), (SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'L1'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'L1info'))));
insert into Etudiant values (Etudiant_T('Petrolli', 'Clarita', TO_DATE('01/07/1996','dd/mm/yyyy'), 800127196, Inscription_T(TO_DATE('29/08/2017','dd/mm/yyyy'), (SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'L2'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'L2physique'))));
insert into Etudiant values (Etudiant_T('Le Claire', 'Alex', TO_DATE('04/02/1994','dd/mm/yyyy'), 663270244, Inscription_T(TO_DATE('24/09/2017','dd/mm/yyyy'),(SELECT REF(n) FROM Niveau n WHERE n.nomNiveau = 'L1'), (SELECT REF(s) FROM  Specialite s WHERE s.nomSpecialite = 'L1physique'))));

--Université 2

--Polvalerie

--Spécialités de Licence langue
INSERT INTO Specialite VALUES ( Specialite_T ('L1langue', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('L2langue', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('L3langue', 100, UEObligatoire_T(), UEOptionnelle_T() ));
--Spécialités de Master langue
INSERT INTO Specialite VALUES ( Specialite_T ('langueEtrangere', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('langueMorte', 50, UEObligatoire_T(), UEOptionnelle_T() ));

INSERT INTO Niveau VALUES (
    Niveau_T(L1 , GroupeSpecialite_T( (SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'L1langue') )
);

INSERT INTO Niveau VALUES (Niveau_T(L2,
GroupeSpecialite_T(
(SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'L2langue')
)
);

INSERT INTO Niveau VALUES (Niveau_T(L2,
GroupeSpecialite_T(
(SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'L3langue')
)
);
INSERT INTO Niveau VALUES (Niveau_T(M1,
GroupeSpecialite_T(
(SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'langueEtrangere'),
(SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'langueMorte')
)
);

INSERT INTO Niveau VALUES (Niveau_T(M2,
GroupeSpecialite_T(
(SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'langueEtrangere'),
(SELECT REF(n) FROM Niveau n WHERE nomSpecialite = 'langueMorte')
)
);


-- filière
INSERT INTO Filiere VALUES('LANGUE',
GroupeNiveau_T(
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'L1'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'L2'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'L3'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'M1'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'M2')
)
);


--etudiants
insert into Etudiant values (Etudiant_T('Ortas', 'Carlene', TO_DATE('01/12/1998','dd/mm/yyyy'), 720388260, Inscription_T(TO_DATE('02/09/2017','dd/mm/yyyy'), NULL)));
insert into Etudiant values (Etudiant_T('Ervin', 'Nathalia', TO_DATE('21/08/1998','dd/mm/yyyy'), 165016075, Inscription_T(TO_DATE('15/09/2017','dd/mm/yyyy'), NULL)));
insert into Etudiant values (Etudiant_T('Luffman', 'Frederich', TO_DATE('19/06/2000','dd/mm/yyyy'), 733782228, Inscription_T(TO_DATE('05/07/2017','dd/mm/yyyy'), NULL)));
insert into Etudiant values (Etudiant_T('Pirkis', 'Penny', TO_DATE('19/03/1998','dd/mm/yyyy'), 717500918, Inscription_T(TO_DATE('20/09/2017','dd/mm/yyyy'), NULL)));
insert into Etudiant values (Etudiant_T('Spanswick', 'Shari', TO_DATE('11/01/2000','dd/mm/yyyy'), 922042622, Inscription_T(TO_DATE('27/08/2017','dd/mm/yyyy'), NULL)));
insert into Etudiant values (Etudiant_T('Jorg', 'Jeanette', TO_DATE('01/04/1995','dd/mm/yyyy'), 423146603, Inscription_T(TO_DATE('02/09/2017','dd/mm/yyyy'), NULL)));


--Université 3


--spécialités de licence Droit
INSERT INTO Specialite VALUES ( Specialite_T ('L1droit', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('L2droit', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('L3droit', 100, UEObligatoire_T(), UEOptionnelle_T() ));

--spécialités de master Droit
INSERT INTO Specialite VALUES ( Specialite_T ('Droit du travail', 100, UEObligatoire_T(), UEOptionnelle_T() ));
INSERT INTO Specialite VALUES ( Specialite_T ('Droit de l'informatique', 50, UEObligatoire_T(), UEOptionnelle_T() ));

--Filière 
INSERT INTO Filiere VALUES('DROIT',
GroupeNiveau_T(
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'L1'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'L2'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'L3'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'M1'),
(SELECT REF(n) FROM Niveau n WHERE nomNiveau = 'M2')
)
);

--etudiants
insert into Etudiant values (Etudiant_T('Rossin', 'Rosana', TO_DATE('11/01/1997','dd/mm/yyyy'), 040460361, Inscription_T(TO_DATE('02/09/2017','dd/mm/yyyy'), NULL)));
insert into Etudiant values (Etudiant_T('Kittel', 'Lindie', TO_DATE('20/04/1996','dd/mm/yyyy'), 644712348, Inscription_T(TO_DATE('24/09/2017','dd/mm/yyyy'), NULL)));
insert into Etudiant values (Etudiant_T('Wilkisson', 'Shelley', TO_DATE('20/06/1994','dd/mm/yyyy'), 714201197, Inscription_T(TO_DATE('29/08/2017','dd/mm/yyyy'), NULL)));
insert into Etudiant values (Etudiant_T('Temblett', 'Gav', TO_DATE('08/08/1998','dd/mm/yyyy'), 422040289, Inscription_T(TO_DATE('11/09/2017','dd/mm/yyyy'), NULL)));
insert into Etudiant values (Etudiant_T('Eddowes', 'Alyosha', TO_DATE('13/07/1997','dd/mm/yyyy'), 604495851, NULL));
insert into Etudiant values (Etudiant_T('Hadlee', 'Emmery', TO_DATE('12/08/1997','dd/mm/yyyy'), 359055729, Inscription_T(TO_DATE('06/09/2017','dd/mm/yyyy'), NULL)));
insert into Etudiant values (Etudiant_T('Gresch', 'Terrell', TO_DATE('16/07/1995','dd/mm/yyyy'), 157631489, Inscription_T(TO_DATE('02/09/2017','dd/mm/yyyy'), NULL)));





--SELECTIONS
--La date moyenne d'inscription des etudiants

--La filière qui accueil le maxilmum d'étudiant

--Les etudiants qui ne sont pas encore inscrits
Select nomPersonne, prenomPersonne From Etudiant Where inscription Is NULL;


--L'UE qui propose le plus d'UE optionnelles

--L'université qui propose le plus de specialitees Informatique

