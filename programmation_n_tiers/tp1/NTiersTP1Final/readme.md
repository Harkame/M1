#Parties

##TP1Share.jar

Contient les fichiers (sources + interfaces) utilisé par le client et le serveur.

Breed (espece) n'herite pas de UnicastREmoteObject pour etre passe par copie

##TP1Server

Projet serveur, cree un cabinet (ajoute 1 animal a la construction pour les tests) et le depose dans un registre.

Contient src + bin

##TP1Client

Projet  client,  recupere le cabinet, par default y ajoute un veterinaire et un animal pour le test des alertes.

Des portions de code commenté (+ intitule) sont la pour des tests. (enlever un animal, modifier dossier, recuperer animal 
avec le nom)

Normalement le codebase est implemente mais ne fonctionne pas (envoye un objet qui n'existe pas sur le serveur)

/!\ eviter de lancer plusieurs client dans la meme seconde, la date est utilise pour generer un identifiant pour stocker
les veterinaires et les animaux dans le cabinet.

A chaque connexion d'un client, un nouveau message d'alerte apparais pour chaqu'un des clients deja connectes (alerte)
car on ajoute un animal.

Contient src + bin

#Instruction

Pour le serveur et le client, aller dans le repertoire bin.

java -cp .:../../TP1Share.jar <Server|Client>
