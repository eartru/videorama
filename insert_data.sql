use videorama;

INSERT INTO videoramaUser VALUES('user', 'user', 'user@test.fr', 0);
INSERT INTO videoramaUser VALUES('admin', 'admin', 'admin@test.fr', 1);
INSERT INTO customer VALUES(1, 'Paul', 'Lupin', '30 rue du champs', '38120', 'Saint Egreve', 'France');

INSERT INTO productType VALUES ('films');
INSERT INTO productType VALUES ('s�ries');
INSERT INTO productType VALUES ('dessins anim�s');
INSERT INTO product VALUES('Harry Potter � l''�cole des sorciers', 'Orphelin, le jeune Harry Potter peut enfin quitter ses tyranniques oncle et tante Dursley lorsqu''un curieux messager lui r�v�le qu''il est un sorcier. � 11 ans, Harry va enfin pouvoir int�grer la l�gendaire �cole de sorcellerie de Poudlard, y trouver une famille digne de ce nom et des amis, d�velopper ses dons, et pr�parer son glorieux avenir.', '12/09/2001', 5.99, 10, 'harry_potter_ecole_des_sorciers.jpg', 1);
INSERT INTO product VALUES('Harry Potter et la coupe de feu', 'La quatri�me ann�e � l''�cole de Poudlard est marqu�e par le Tournoi des trois sorciers. Les participants sont choisis par la fameuse coupe de feu qui est � l''origine d''un scandale. Elle s�lectionne Harry Potter alors qu''il n''a pas l''�ge l�gal requis !', '08/11/2005', 5.99, 10, 'harry_potter_coupe_de_feu.jpg', 1);
INSERT INTO product VALUES('Harry Potter et le prince de sang-m�l�', 'L''�tau d�moniaque de Voldemort se resserre sur l''univers des `Moldus` et le monde de la sorcellerie. Poudlard a cess� d''�tre un havre de paix, le danger rode au coeur du ch�teau. Cependant, Dumbledore est plus d�cid� que jamais � pr�parer Harry � son combat final, d�sormais imminent.', '15/07/2009', 5.99, 10, 'harry_potter_prince_sang_mele.jpg', 1);
INSERT INTO product VALUES('Harry Potter et le prisonnier d''Azkaban', 'Sirius Black, un dangereux sorcier criminel, s''�chappe de la sombre prison d''Azkaban avec un seul et unique but : se venger d''Harry Potter, entr� avec ses amis Ron et Hermione en troisi�me ann�e � l''�cole de sorcellerie de Poudlard, o� ils auront aussi � faire avec les terrifiants D�traqueurs.', '02/06/2004', 5.99, 10, 'harry_potter_prisonnier_azkaban.jpg', 1);
INSERT INTO product VALUES('Friends saison 1', 'Monica Geller, jeune cuisini�re new-yorkaise de 25 ans, re�oit la visite de Rachel Green, une amie d�enfance dont elle avait perdu la trace et qui vient de quitter son fianc� devant l�autel. Alors qu�elles deviennent colocataires, Rachel va int�grer le groupe d�amis de Monica compos� de Phoebe Buffay, une hippie qui passe son temps libre � composer des chansons ; Ross Geller, un pal�ontologue qui est aussi le fr�re de Monica ; Chandler Bing, un jeune homme qui utilise l�humour comme arme de d�fense ; et Joey Tribbiani, un acteur sans v�ritable talent si ce n�est celui d�accumuler les conqu�tes. Ensemble, ils vont partager leurs joies et leurs peines au Central Perk, leur caf� favori.', '09/09/1994', 2.99, 10, '', 2)
INSERT INTO product VALUES('Friends saison 2', 'Ross, qui ignore les sentiments de Rachel � son �gard, d�bute une relation avec Julie, une pal�ontologue qu�il a connue au coll�ge. Jalouse et malheureuse, Rachel tente alors de saboter leur relation par tous les moyens. Pendant ce temps, et apr�s avoir d�croch� le r�le du docteur Drake Ramoray dans "Des jours et des vies", Joey d�cide d�emm�nager dans son propre appartement, tandis que Chandler a un nouveau colocataire. De son c�t�, Phoebe d�couvre qu�elle a un demi-fr�re, et Monica commence une relation amoureuse avec un ami de ses parents.', '05/09/1995', 2.99, 10, '', 2);
INSERT INTO product VALUES('Inspecteur Gadget saison 1', 'L''inspecteur Gadget est un cyber-policier dot� de nombreux gadgets (d''o� son nom) directement int�gr�s � son corps. Il lutte pour la police contre l''organisation MAD dirig�e par le sinistre Dr Gang (Dr Claw dans la version am�ricaine) que l''on voit toujours assis de dos dans son quartier g�n�ral. Mais l''inspecteur Gadget est tr�s stupide, n''est pas tr�s astucieux et se trompe souvent dans ses jugements, mais il a beaucoup de chance, ce qui lui permet � chaque fois de r�soudre les enqu�tes presque sans le faire expr�s. N�anmoins, il est syst�matiquement aid� par sa ni�ce Sophie (Penny dans la version am�ricaine), une petite fille tr�s d�brouillarde, et son chien Finot (Brain dans la version am�ricaine), qui est tr�s astucieux et capable de communiquer avec Sophie.', '04/12/1982', 2.99, 10, '', 3);
INSERT INTO product VALUES('Le seigneur des anneaux : La Communaut� de l''anneau', 'Un jeune et timide Hobbit, Frodon Sacquet, h�rite d''un anneau magique. Bien loin d''�tre une simple babiole, il s''agit d''un instrument de pouvoir absolu qui permettrait � Sauron, le `Seigneur des t�n�bres`, de r�gner sur la `Terre du Milieu` et de r�duire en esclavage ses peuples. Frodon doit parvenir jusqu''� la `Crevasse du Destin` pour d�truire l''anneau.', '19/12/2001', 5.99, 10, 'seigneur_des_anneaux.jpg', 1);
INSERT INTO product VALUES('Un homme d''exception', 'En 1947, �tudiant les math�matiques � l''universit� de Princeton, John Forbes Nash Jr., un brillant �l�ve, �labore sa th�orie �conomique des jeux. Pour lui, les fluctuations des march�s financiers peuvent �tre calcul�es tr�s pr�cis�ment. Au d�but des ann�es 50, ses travaux et son enseignement au Massachusetts Institute of Technology ne passent pas inaper�us et un repr�sentant du d�partement de la D�fense, William Parcher, se pr�sente � lui pour lui proposer d''aider secr�tement les �tats-Unis.', '13/02/2002', 5.99, 12, 'homme_exception.jpg', 1);
INSERT INTO product VALUES('Une merveilleuse histoire du temps', 'En 1963, en Angleterre, Stephen, brillant �tudiant en Cosmologie � l''Universit� de Cambridge, entend bien donner une r�ponse simple et efficace au myst�re de la cr�ation de l''univers. De nouveaux horizons s''ouvrent quand il tombe amoureux d''une �tudiante en art, Jane Wilde. Cependant, le jeune homme, alors dans la fleur de l''�ge, se heurte � un diagnostic implacable : une dystrophie neuromusculaire plus connue sous le nom de maladie de Charcot.', '07/11/2014', 5.99, 16, 'merveilleuse_histoire_temps.jpg', 1);
INSERT INTO product VALUES('Pokemon', 'Sacha est un jeune gar�on qui vit dans le monde des pokemon. Un pokemon est une petite cr�ature poss�dant divers pouvoirs. Le but de Sacha est de devenir maitre pokemon. Entour� de ses amis il va vivre de nombreuses aventures et combattre la Team Rocket, des voleurs de pokemon.', '01/04/1997', 2.99, 20, 'pokemon.jpg', 3);
INSERT INTO product VALUES('Saint Seiya', 'Le tournoi galactique a commenc�, mais plusieurs participants manquent encore � l''appel. Saori, dans sa loge de verre au-dessus de l''ar�ne, s''inqui�te de l''absence de ses chevaliers.', '11/10/1987', 2.99, 10, 'saint_seiya.jpg', 3);
INSERT INTO product VALUES('La panth�re rose', 'Les aventures d�jant�es et d�cal�es d''une panth�re rose, qui accomplit plusieurs gags et b�vues au cours de petits courts m�trages anim�s. La panth�re rose fait souvent tourner en bourrique un petit bonhomme avec une �norme t�te et un gros nez, dans de nombreux cartoons aux couleurs et graphismes tr�s sixties.', '06/09/1969', 2.99, 10, 'panthere_rose.jpg', 3);
INSERT INTO product VALUES('La casa de Papel', 'Un homme myst�rieux, surnomm� le Professeur1 (El Profesor), planifie le meilleur braquage jamais r�alis�. Pour ex�cuter son plan, il recrute huit des meilleurs malfaiteurs du pays qui n''ont rien � perdre. Le but est d''infiltrer la Fabrique nationale de la monnaie et du timbre afin d''imprimer 1 milliard d''euros, en moins de onze jours et sans verser une goutte de sang � malgr� la pr�sence de 67 otages, dont la fille de l''ambassadeur du Royaume-Uni.', '02/05/2017', 5.99, 25, 'casa_de_papel.jpg', 2);
INSERT INTO product VALUES('Sherlock', 'Sherlock Holmes est d�tective consultant et il accueille comme colocataire le docteur Watson, un ancien m�decin de l''arm�e britannique bless� en Afghanistan. Il aide Scotland Yard � r�soudre des enqu�tes ardues en utilisant ses dons d''observation et de d�duction associ�s aux technologies actuelles comme Internet ou les t�l�phones portables.', '25/07/2010', 4.99, 10, 'sherlock.jpg', 2);
INSERT INTO product VALUES('Brooklyn Nine Nine', 'Brooklyn Nine-Nine raconte la vie d''un commissariat de police dans le quartier de Brooklyn � New York. � l''image du slogan de la s�rie, � Brooklyn Nine-Nine: the Law without the Order � (� Brooklyn Nine-Nine : la loi sans l''ordre �), les divers personnages le composant sont dot�s de caract�res tr�s marqu�s voire extravagants, mettant ainsi � mal l''harmonie dans les bureaux. L''arriv�e d''un nouveau capitaine, froid et strict, ne fait que renforcer cette attitude.', '17/09/2013', 4.99, 10, 'brooklyn_nine_nine.jpg', 2);
INSERT INTO product VALUES('The 100', 'Apr�s une apocalypse nucl�aire, les 318 survivants se r�fugient dans des stations spatiales et parviennent � y vivre et � se reproduire, atteignant le nombre de 4000 ; 97 ans plus tard, une centaine de jeunes d�linquants redescendent sur Terre.', '19/11/2014', 3.99, 15, 'the_100.jpg', 2);
INSERT INTO product VALUES('30 rock', 'Liz Lemon est sc�nariste en chef pour une �mission de vari�t�s. Pour elle la vie est belle et exaltante, jusqu''au jour o� le Pr�sident du Network d�cide d''engager une star d''Hollywood dans le show ! D�sormais Liz va devoir batailler pour que son r�ve continue.', '11/10/2006', 3.99, 15, '30_rock.jpg', 2);
INSERT INTO product VALUES('The sinner', 'Suite au d�nouement de l''affaire Cora Tannetti, le d�tective Harry Ambrose est rappel� dans son village natal, loin de New York, pour enqu�ter sur un nouveau crime particuli�rement perturbant : un double meurtre commis par un gar�on de 11 ans.', '01/08/2017', 2.99, 14, 'the_sinner.jpg', 2);
INSERT INTO product VALUES('Les �vad�s', 'En 1947, Andy Dufresne, un jeune banquier, est condamn� � la prison � vie pour le meurtre de sa femme et de son amant. Ayant beau clamer son innocence, il est emprisonn� � `Shawshank`, le p�nitencier le plus s�v�re de l''Etat du Maine. Il y fait la rencontre de Red, un homme d�sabus�, d�tenu depuis 20 ans. Commence alors une grande histoire d''amiti� entre les deux hommes.', '01/03/1995', 5.99, 10, 'les_evades.jpg', 1);
INSERT INTO product VALUES('Les gardiens de la Galaxie', 'Peter Quill est un aventurier traqu� par tous les chasseurs de primes pour avoir vol� un myst�rieux globe convoit� par le puissant Ronan, dont les agissements menacent l''univers tout entier. Lorsqu''il d�couvre le v�ritable pouvoir de ce globe et la menace qui p�se sur la galaxie, il conclut une alliance fragile avec quatre extraterrestres disparates.', '13/08/2014', 6.99, 10, 'gardien_galaxie.jpg', 1);
INSERT INTO product VALUES('Deadpool', 'Wade Wilson, un ancien militaire des forces sp�ciales, est devenu mercenaire. Apr�s avoir subi une exp�rimentation hors-norme qui va acc�l�rer ses pouvoirs de gu�rison, il va devenir Deadpool. Arm� de ses nouvelles capacit�s et d''un humour noir survolt�, il va traquer l''homme qui a bien failli an�antir sa vie.', '10/12/2016', 6.99, 10, 'deadpool.jpg', 1);

INSERT INTO category VALUES('Comique');
INSERT INTO category VALUES('Policier');
INSERT INTO category VALUES('Science fiction');
INSERT INTO category VALUES('Fantasy');
INSERT INTO category VALUES('Drame');
INSERT INTO category VALUES('Romance');
INSERT INTO category VALUES('Biopic');
INSERT INTO category VALUES('Thriller');

INSERT INTO profession VALUES('Acteur');
INSERT INTO profession VALUES('R�alisateur');
INSERT INTO profession VALUES('Producteur');
INSERT INTO profession VALUES('Auteur');

INSERT INTO person VALUES('Rupert', 'Grint', '24/08/1988', 1);
INSERT INTO person VALUES('Daniel', 'Radcliffe', '23/07/1989', 1); 
INSERT INTO person VALUES('J. K.', 'Rowling', '', 4);
INSERT INTO person VALUES('Elijah', 'Wood', '', 1);
INSERT INTO person VALUES('Jennifer', 'Anniston', '', 1);
INSERT INTO person VALUES('Matthew', 'Perry', '', 1);
INSERT INTO person VALUES('David', 'Crane', '', 3);
INSERT INTO person VALUES('Peter', 'Sauder', '', 4);

INSERT INTO casting VALUES(1, 1);
INSERT INTO casting VALUES(1, 2);
INSERT INTO casting VALUES(1, 3);
INSERT INTO casting VALUES(2, 1);
INSERT INTO casting VALUES(2, 2);
INSERT INTO casting VALUES(2, 3);
INSERT INTO casting VALUES(3, 1);
INSERT INTO casting VALUES(3, 2);
INSERT INTO casting VALUES(3, 3);
INSERT INTO casting VALUES(4, 1);
INSERT INTO casting VALUES(4, 2);
INSERT INTO casting VALUES(4, 3);
INSERT INTO casting VALUES(8, 4);
INSERT INTO casting VALUES(5, 5);
INSERT INTO casting VALUES(5, 6);
INSERT INTO casting VALUES(5, 7);
INSERT INTO casting VALUES(7, 8);

INSERT INTO productCategory VALUES(1, 4);
INSERT INTO productCategory VALUES(2, 4);
INSERT INTO productCategory VALUES(3, 4);
INSERT INTO productCategory VALUES(4, 4);
INSERT INTO productCategory VALUES(5, 1);
INSERT INTO productCategory VALUES(6, 1);
INSERT INTO productCategory VALUES(7, 2);
INSERT INTO productCategory VALUES(8, 4);
INSERT INTO productCategory VALUES(9, 5);
INSERT INTO productCategory VALUES(9, 7);
INSERT INTO productCategory VALUES(10, 5);
INSERT INTO productCategory VALUES(10, 7);

INSERT INTO rent VALUES('07/11/2018', '25/11/2018', '27/11/2018', 0, 1);
INSERT INTO rent VALUES('27/11/2018', '17/11/2018', '29/11/2018', 1, 1);
INSERT INTO rent VALUES('18/11/2018', '08/12/2018', '10/12/2018', 1, 1);

INSERT INTO rentDetail VALUES(1, 1);
INSERT INTO rentDetail VALUES(1, 2);
INSERT INTO rentDetail VALUES(2, 3);
INSERT INTO rentDetail VALUES(2, 5);
INSERT INTO rentDetail VALUES(3, 8);