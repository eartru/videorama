use videorama;

INSERT INTO videoramaUser VALUES('user', 'user', 'user@test.fr', 0);
INSERT INTO videoramaUser VALUES('admin', 'admin', 'admin@test.fr', 1);
INSERT INTO customer VALUES(1, 'Paul', 'Lupin', '30 rue du champs', '38120', 'Saint Egreve', 'France');

INSERT INTO productType VALUES ('films');
INSERT INTO productType VALUES ('séries');
INSERT INTO productType VALUES ('dessins animés');
INSERT INTO product VALUES('Harry Potter à l''école des sorciers', 'Orphelin, le jeune Harry Potter peut enfin quitter ses tyranniques oncle et tante Dursley lorsqu''un curieux messager lui révèle qu''il est un sorcier. À 11 ans, Harry va enfin pouvoir intégrer la légendaire école de sorcellerie de Poudlard, y trouver une famille digne de ce nom et des amis, développer ses dons, et préparer son glorieux avenir.', '12/09/2001', 5.99, 10, 'harry_potter_ecole_des_sorciers.jpg', 1);
INSERT INTO product VALUES('Harry Potter et la coupe de feu', 'La quatrième année à l''école de Poudlard est marquée par le Tournoi des trois sorciers. Les participants sont choisis par la fameuse coupe de feu qui est à l''origine d''un scandale. Elle sélectionne Harry Potter alors qu''il n''a pas l''âge légal requis !', '08/11/2005', 5.99, 10, 'harry_potter_coupe_de_feu.jpg', 1);
INSERT INTO product VALUES('Harry Potter et le prince de sang-mêlé', 'L''étau démoniaque de Voldemort se resserre sur l''univers des `Moldus` et le monde de la sorcellerie. Poudlard a cessé d''être un havre de paix, le danger rode au coeur du château. Cependant, Dumbledore est plus décidé que jamais à préparer Harry à son combat final, désormais imminent.', '15/07/2009', 5.99, 10, 'harry_potter_prince_sang_mele.jpg', 1);
INSERT INTO product VALUES('Harry Potter et le prisonnier d''Azkaban', 'Sirius Black, un dangereux sorcier criminel, s''échappe de la sombre prison d''Azkaban avec un seul et unique but : se venger d''Harry Potter, entré avec ses amis Ron et Hermione en troisième année à l''école de sorcellerie de Poudlard, où ils auront aussi à faire avec les terrifiants Détraqueurs.', '02/06/2004', 5.99, 10, 'harry_potter_prisonnier_azkaban.jpg', 1);
INSERT INTO product VALUES('Friends saison 1', 'Monica Geller, jeune cuisinière new-yorkaise de 25 ans, reçoit la visite de Rachel Green, une amie d’enfance dont elle avait perdu la trace et qui vient de quitter son fiancé devant l’autel. Alors qu’elles deviennent colocataires, Rachel va intégrer le groupe d’amis de Monica composé de Phoebe Buffay, une hippie qui passe son temps libre à composer des chansons ; Ross Geller, un paléontologue qui est aussi le frère de Monica ; Chandler Bing, un jeune homme qui utilise l’humour comme arme de défense ; et Joey Tribbiani, un acteur sans véritable talent si ce n’est celui d’accumuler les conquêtes. Ensemble, ils vont partager leurs joies et leurs peines au Central Perk, leur café favori.', '09/09/1994', 2.99, 10, '', 2)
INSERT INTO product VALUES('Friends saison 2', 'Ross, qui ignore les sentiments de Rachel à son égard, débute une relation avec Julie, une paléontologue qu’il a connue au collège. Jalouse et malheureuse, Rachel tente alors de saboter leur relation par tous les moyens. Pendant ce temps, et après avoir décroché le rôle du docteur Drake Ramoray dans "Des jours et des vies", Joey décide d’emménager dans son propre appartement, tandis que Chandler a un nouveau colocataire. De son côté, Phoebe découvre qu’elle a un demi-frère, et Monica commence une relation amoureuse avec un ami de ses parents.', '05/09/1995', 2.99, 10, '', 2);
INSERT INTO product VALUES('Inspecteur Gadget saison 1', 'L''inspecteur Gadget est un cyber-policier doté de nombreux gadgets (d''où son nom) directement intégrés à son corps. Il lutte pour la police contre l''organisation MAD dirigée par le sinistre Dr Gang (Dr Claw dans la version américaine) que l''on voit toujours assis de dos dans son quartier général. Mais l''inspecteur Gadget est très stupide, n''est pas très astucieux et se trompe souvent dans ses jugements, mais il a beaucoup de chance, ce qui lui permet à chaque fois de résoudre les enquêtes presque sans le faire exprès. Néanmoins, il est systématiquement aidé par sa nièce Sophie (Penny dans la version américaine), une petite fille très débrouillarde, et son chien Finot (Brain dans la version américaine), qui est très astucieux et capable de communiquer avec Sophie.', '04/12/1982', 2.99, 10, '', 3);
INSERT INTO product VALUES('Le seigneur des anneaux : La Communauté de l''anneau', 'Un jeune et timide Hobbit, Frodon Sacquet, hérite d''un anneau magique. Bien loin d''être une simple babiole, il s''agit d''un instrument de pouvoir absolu qui permettrait à Sauron, le `Seigneur des ténèbres`, de régner sur la `Terre du Milieu` et de réduire en esclavage ses peuples. Frodon doit parvenir jusqu''à la `Crevasse du Destin` pour détruire l''anneau.', '19/12/2001', 5.99, 10, 'seigneur_des_anneaux.jpg', 1);
INSERT INTO product VALUES('Un homme d''exception', 'En 1947, étudiant les mathématiques à l''université de Princeton, John Forbes Nash Jr., un brillant élève, élabore sa théorie économique des jeux. Pour lui, les fluctuations des marchés financiers peuvent être calculées très précisément. Au début des années 50, ses travaux et son enseignement au Massachusetts Institute of Technology ne passent pas inaperçus et un représentant du département de la Défense, William Parcher, se présente à lui pour lui proposer d''aider secrètement les États-Unis.', '13/02/2002', 5.99, 12, 'homme_exception.jpg', 1);
INSERT INTO product VALUES('Une merveilleuse histoire du temps', 'En 1963, en Angleterre, Stephen, brillant étudiant en Cosmologie à l''Université de Cambridge, entend bien donner une réponse simple et efficace au mystère de la création de l''univers. De nouveaux horizons s''ouvrent quand il tombe amoureux d''une étudiante en art, Jane Wilde. Cependant, le jeune homme, alors dans la fleur de l''âge, se heurte à un diagnostic implacable : une dystrophie neuromusculaire plus connue sous le nom de maladie de Charcot.', '07/11/2014', 5.99, 16, 'merveilleuse_histoire_temps.jpg', 1);
INSERT INTO product VALUES('Pokemon', 'Sacha est un jeune garçon qui vit dans le monde des pokemon. Un pokemon est une petite créature possédant divers pouvoirs. Le but de Sacha est de devenir maitre pokemon. Entouré de ses amis il va vivre de nombreuses aventures et combattre la Team Rocket, des voleurs de pokemon.', '01/04/1997', 2.99, 20, 'pokemon.jpg', 3);
INSERT INTO product VALUES('Saint Seiya', 'Le tournoi galactique a commencé, mais plusieurs participants manquent encore à l''appel. Saori, dans sa loge de verre au-dessus de l''arène, s''inquiète de l''absence de ses chevaliers.', '11/10/1987', 2.99, 10, 'saint_seiya.jpg', 3);
INSERT INTO product VALUES('La panthère rose', 'Les aventures déjantées et décalées d''une panthère rose, qui accomplit plusieurs gags et bévues au cours de petits courts métrages animés. La panthère rose fait souvent tourner en bourrique un petit bonhomme avec une énorme tête et un gros nez, dans de nombreux cartoons aux couleurs et graphismes très sixties.', '06/09/1969', 2.99, 10, 'panthere_rose.jpg', 3);
INSERT INTO product VALUES('La casa de Papel', 'Un homme mystérieux, surnommé le Professeur1 (El Profesor), planifie le meilleur braquage jamais réalisé. Pour exécuter son plan, il recrute huit des meilleurs malfaiteurs du pays qui n''ont rien à perdre. Le but est d''infiltrer la Fabrique nationale de la monnaie et du timbre afin d''imprimer 1 milliard d''euros, en moins de onze jours et sans verser une goutte de sang – malgré la présence de 67 otages, dont la fille de l''ambassadeur du Royaume-Uni.', '02/05/2017', 5.99, 25, 'casa_de_papel.jpg', 2);
INSERT INTO product VALUES('Sherlock', 'Sherlock Holmes est détective consultant et il accueille comme colocataire le docteur Watson, un ancien médecin de l''armée britannique blessé en Afghanistan. Il aide Scotland Yard à résoudre des enquêtes ardues en utilisant ses dons d''observation et de déduction associés aux technologies actuelles comme Internet ou les téléphones portables.', '25/07/2010', 4.99, 10, 'sherlock.jpg', 2);
INSERT INTO product VALUES('Brooklyn Nine Nine', 'Brooklyn Nine-Nine raconte la vie d''un commissariat de police dans le quartier de Brooklyn à New York. À l''image du slogan de la série, « Brooklyn Nine-Nine: the Law without the Order » (« Brooklyn Nine-Nine : la loi sans l''ordre »), les divers personnages le composant sont dotés de caractères très marqués voire extravagants, mettant ainsi à mal l''harmonie dans les bureaux. L''arrivée d''un nouveau capitaine, froid et strict, ne fait que renforcer cette attitude.', '17/09/2013', 4.99, 10, 'brooklyn_nine_nine.jpg', 2);
INSERT INTO product VALUES('The 100', 'Après une apocalypse nucléaire, les 318 survivants se réfugient dans des stations spatiales et parviennent à y vivre et à se reproduire, atteignant le nombre de 4000 ; 97 ans plus tard, une centaine de jeunes délinquants redescendent sur Terre.', '19/11/2014', 3.99, 15, 'the_100.jpg', 2);
INSERT INTO product VALUES('30 rock', 'Liz Lemon est scénariste en chef pour une émission de variétés. Pour elle la vie est belle et exaltante, jusqu''au jour où le Président du Network décide d''engager une star d''Hollywood dans le show ! Désormais Liz va devoir batailler pour que son rêve continue.', '11/10/2006', 3.99, 15, '30_rock.jpg', 2);
INSERT INTO product VALUES('The sinner', 'Suite au dénouement de l''affaire Cora Tannetti, le détective Harry Ambrose est rappelé dans son village natal, loin de New York, pour enquêter sur un nouveau crime particulièrement perturbant : un double meurtre commis par un garçon de 11 ans.', '01/08/2017', 2.99, 14, 'the_sinner.jpg', 2);
INSERT INTO product VALUES('Les évadés', 'En 1947, Andy Dufresne, un jeune banquier, est condamné à la prison à vie pour le meurtre de sa femme et de son amant. Ayant beau clamer son innocence, il est emprisonné à `Shawshank`, le pénitencier le plus sévère de l''Etat du Maine. Il y fait la rencontre de Red, un homme désabusé, détenu depuis 20 ans. Commence alors une grande histoire d''amitié entre les deux hommes.', '01/03/1995', 5.99, 10, 'les_evades.jpg', 1);
INSERT INTO product VALUES('Les gardiens de la Galaxie', 'Peter Quill est un aventurier traqué par tous les chasseurs de primes pour avoir volé un mystérieux globe convoité par le puissant Ronan, dont les agissements menacent l''univers tout entier. Lorsqu''il découvre le véritable pouvoir de ce globe et la menace qui pèse sur la galaxie, il conclut une alliance fragile avec quatre extraterrestres disparates.', '13/08/2014', 6.99, 10, 'gardien_galaxie.jpg', 1);
INSERT INTO product VALUES('Deadpool', 'Wade Wilson, un ancien militaire des forces spéciales, est devenu mercenaire. Après avoir subi une expérimentation hors-norme qui va accélérer ses pouvoirs de guérison, il va devenir Deadpool. Armé de ses nouvelles capacités et d''un humour noir survolté, il va traquer l''homme qui a bien failli anéantir sa vie.', '10/12/2016', 6.99, 10, 'deadpool.jpg', 1);

INSERT INTO category VALUES('Comique');
INSERT INTO category VALUES('Policier');
INSERT INTO category VALUES('Science fiction');
INSERT INTO category VALUES('Fantasy');
INSERT INTO category VALUES('Drame');
INSERT INTO category VALUES('Romance');
INSERT INTO category VALUES('Biopic');
INSERT INTO category VALUES('Thriller');

INSERT INTO profession VALUES('Acteur');
INSERT INTO profession VALUES('Réalisateur');
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