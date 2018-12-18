# videorama

## Prérequis

* Base de données SQL Server
* Visual Studio 

## Configuration
Lancer Microsoft SQL Server Management et éxécutez les scripts SQL dans l'ordre suivant :
* create_table.sql : crée la base de données ainsi que toutes les tables
* insert_data.sql : insère des données dans la base précédemment créée
* procedure_stockees.sql : crée les procédures stockées

Ensuite, lancez Visual Studio et ouvrez le fichier Web.Config à la racine et modifiez le en fonction de vos paramètres de connexion à votre base de données.

Pour cela vous devez modifier les lignes suivantes : 
```
<connectionStrings>
    <add name="VideoramaDb" connectionString="Data Source=MY_DATABASE;Initial Catalog=videorama;user id=my_user;password=my_password;Pooling=False;MultipleActiveResultSets=True" />
  </connectionStrings>
```
name="VideoramaDb" est le nom de la chaine de connexion, il est déconseillé de le modifier sinon il faudrait impacter ce nom dans les fichiers .cs qui crée une connexion vers la base de données.

Data Source correspond au nom de votre serveur de base de données (ex: localhost\SQLEXPRESS par défaut sur SQL Server).

user id est le nom d'utilisateur et password, le mot de passe, que vous utilisez pour vous connectez à la base de données.

Initial Catalog correspond au nom de la base de données, vous pouvez le laisser tel quel, c'est à dire videorama, car le script crée une base de données avec ce nom.

