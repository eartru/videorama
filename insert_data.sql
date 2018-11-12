INSERT INTO videoramaUser VALUES('user', 'user', 'user@test.fr', 0);
INSERT INTO videoramaUser VALUES('admin', 'admin', 'admin@test.fr', 1);
INSERT INTO customer VALUES(1, 'Paul', 'Lupin', '30 rue du champs', '38120', 'Saint Egreve', 'France');

INSERT INTO productType VALUES ( 'Film');
INSERT INTO productType VALUES ( 'Série');
INSERT INTO productType VALUES ( 'Dessin Animé');
INSERT INTO product VALUES('Harry Potter', '05/12/2001', 5.99, 10, '', 1, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus. Suspendisse lectus tortor, dignissim sit amet, adipiscing nec, ultricies sed, dolor. Cras elementum ultrices diam. Maecenas ligula massa, varius a, semper congue, euismod non, mi. Proin porttitor, orci nec nonummy molestie, enim est eleifend mi, non fermentum diam nisl sit amet erat. Duis semper. Duis arcu massa, scelerisque vitae, consequat in, pretium a, enim. Pellentesque congue. Ut in risus volutpat libero pharetra tempor. Cras vestibulum bibendum augue. Praesent egestas leo in pede. Praesent blandit odio eu enim. Pellentesque sed dui ut augue blandit sodales. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aliquam nibh. Mauris ac mauris sed pede pellentesque fermentum. Maecenas adipiscing ante non diam sodales hendrerit.');
INSERT INTO product VALUES('Friends saison 1', '09/09/1994', 2.99, 10, '', 2, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus. Suspendisse lectus tortor, dignissim sit amet, adipiscing nec, ultricies sed, dolor. Cras elementum ultrices diam. Maecenas ligula massa, varius a, semper congue, euismod non, mi. Proin porttitor, orci nec nonummy molestie, enim est eleifend mi, non fermentum diam nisl sit amet erat. Duis semper. Duis arcu massa, scelerisque vitae, consequat in, pretium a, enim. Pellentesque congue. Ut in risus volutpat libero pharetra tempor. Cras vestibulum bibendum augue. Praesent egestas leo in pede. Praesent blandit odio eu enim. Pellentesque sed dui ut augue blandit sodales. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aliquam nibh. Mauris ac mauris sed pede pellentesque fermentum. Maecenas adipiscing ante non diam sodales hendrerit.');
INSERT INTO product VALUES('Friends saison 2', '05/09/1995', 2.99, 10, '', 2, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus. Suspendisse lectus tortor, dignissim sit amet, adipiscing nec, ultricies sed, dolor. Cras elementum ultrices diam. Maecenas ligula massa, varius a, semper congue, euismod non, mi. Proin porttitor, orci nec nonummy molestie, enim est eleifend mi, non fermentum diam nisl sit amet erat. Duis semper. Duis arcu massa, scelerisque vitae, consequat in, pretium a, enim. Pellentesque congue. Ut in risus volutpat libero pharetra tempor. Cras vestibulum bibendum augue. Praesent egestas leo in pede. Praesent blandit odio eu enim. Pellentesque sed dui ut augue blandit sodales. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aliquam nibh. Mauris ac mauris sed pede pellentesque fermentum. Maecenas adipiscing ante non diam sodales hendrerit.');
INSERT INTO product VALUES('Inspecteur Gadget saison 1', '04/12/1982', 2.99, 10, '', 3, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus. Suspendisse lectus tortor, dignissim sit amet, adipiscing nec, ultricies sed, dolor. Cras elementum ultrices diam. Maecenas ligula massa, varius a, semper congue, euismod non, mi. Proin porttitor, orci nec nonummy molestie, enim est eleifend mi, non fermentum diam nisl sit amet erat. Duis semper. Duis arcu massa, scelerisque vitae, consequat in, pretium a, enim. Pellentesque congue. Ut in risus volutpat libero pharetra tempor. Cras vestibulum bibendum augue. Praesent egestas leo in pede. Praesent blandit odio eu enim. Pellentesque sed dui ut augue blandit sodales. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aliquam nibh. Mauris ac mauris sed pede pellentesque fermentum. Maecenas adipiscing ante non diam sodales hendrerit.');
INSERT INTO product VALUES('Le seigneur des anneaux', '19/12/2001', 5.99, 10, '~/Content/Images/seigneur_des_anneaux.jpg', 1, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus. Suspendisse lectus tortor, dignissim sit amet, adipiscing nec, ultricies sed, dolor. Cras elementum ultrices diam. Maecenas ligula massa, varius a, semper congue, euismod non, mi. Proin porttitor, orci nec nonummy molestie, enim est eleifend mi, non fermentum diam nisl sit amet erat. Duis semper. Duis arcu massa, scelerisque vitae, consequat in, pretium a, enim. Pellentesque congue. Ut in risus volutpat libero pharetra tempor. Cras vestibulum bibendum augue. Praesent egestas leo in pede. Praesent blandit odio eu enim. Pellentesque sed dui ut augue blandit sodales. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aliquam nibh. Mauris ac mauris sed pede pellentesque fermentum. Maecenas adipiscing ante non diam sodales hendrerit.');

INSERT INTO category VALUES('Comique');
INSERT INTO category VALUES('Policier');
INSERT INTO category VALUES('Science fiction');
INSERT INTO category VALUES('Fantastique');

INSERT INTO profession VALUES('Acteur');
INSERT INTO profession VALUES('Réalisateur');
INSERT INTO profession VALUES('Producteur');
INSERT INTO profession VALUES('Auteur');

INSERT INTO person VALUES('Rupert', 'Grint', '24/08/1988', 1);
INSERT INTO person VALUES('Elijah', 'Wood', '', 1);
INSERT INTO person VALUES('Jennifer', 'Anniston', '', 1);
INSERT INTO person VALUES('Peter', 'Sauder', '', 4);

INSERT INTO casting VALUES(1, 1);
INSERT INTO casting VALUES(2, 3);
INSERT INTO casting VALUES(3, 3);
INSERT INTO casting VALUES(5, 2);
INSERT INTO casting VALUES(4, 4);

INSERT INTO productCategory VALUES(1, 4);
INSERT INTO productCategory VALUES(2, 1);
INSERT INTO productCategory VALUES(3, 1);
INSERT INTO productCategory VALUES(4, 2);
INSERT INTO productCategory VALUES(5, 3);
INSERT INTO productCategory VALUES(4, 4);

INSERT INTO bill VALUES('10/11/2018');
INSERT INTO rent VALUES('07/11/2018', 0, 1, 1);
INSERT INTO rent VALUES('18/11/2018', 1, null, 1);

INSERT INTO rentDetail VALUES(1, 1);
INSERT INTO rentDetail VALUES(1, 2);
INSERT INTO rentDetail VALUES(2, 3);
INSERT INTO rentDetail VALUES(2, 5);
