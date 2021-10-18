use CMSDB
go

INSERT INTO Banners VALUES('Banana','http://www.some-banana.com',0,'634050218905156250_5.jpg',NULL);
INSERT INTO MenuAndPages VALUES('Home',1,1,5,'Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?page.','null');
INSERT INTO MenuAndPages VALUES('Servicies',1,1,10,'At vero eos et accusamus et iusto odio dignissimos ducimus qui
blanditiis praesentium voluptatum deleniti atque corrupti quos dolores
et quas molestias excepturi sint occaecati cupiditate non provident,
similique sunt in culpa qui officia deserunt mollitia animi, id est
laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita
distinctio. Nam libero tempore, cum soluta nobis est eligendi optio
cumque nihil impedit quo minus id quod maxime placeat facere possimus,
omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem
quibusdam et aut officiis debitis aut rerum necessitatibus saepe
eveniet ut et voluptates repudiandae sint et molestiae non recusandae.
Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis
voluptatibus maiores alias consequatur aut perferendis doloribus
asperiores repellat.','null');
INSERT INTO MenuAndPages VALUES('About us',2,1,30,'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do
eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad
minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip
ex ea commodo consequat. Duis aute irure dolor in reprehenderit in
voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur
sint occaecat cupidatat non proident, sunt in culpa qui officia
deserunt mollit anim id est laborum.','null');
INSERT INTO MenuAndPages VALUES('News',1,1,20,'','controller=News;action=Index');
INSERT INTO MenuAndPages VALUES('Feedback',1,1,40,NULL,'controller=Home;action=Feedback');
INSERT INTO NewsCategories VALUES('Announcement');
INSERT INTO NewsCategories VALUES('Event');
INSERT INTO News VALUES('New Year Discount','2009-10-12',1,'Handbags and other fashion accessories on <em>discount</em> prices with high class quality &amp; original leather materials.');
INSERT INTO News VALUES('Thanksgiving Special ','2009-10-28 00:00:00',2,'Thanksgiving Special ');
INSERT INTO News VALUES('Christmas Gift ','2009-11-26 00:00:00',2,'Christmas Gift ');
INSERT INTO zzz_RelationsIDs VALUES('MenuAndPages','Banners',0);
INSERT INTO zzz_SiteFiles(TableName, ColumnName) VALUES('Banners', 'Picture')