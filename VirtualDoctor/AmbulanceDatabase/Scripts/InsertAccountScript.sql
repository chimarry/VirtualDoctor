use ambulance;
delete from local_account_role;
delete from role;
delete from local_account;
insert into role (idrole,rolename) values (1,"Doctor");
insert into role (idrole,rolename) values (2,"AccountAdmin");
insert into role (idrole,rolename) values (3,"PatientAdmin");
insert into role (idrole,rolename) values (4,"OrganizationalAdmin");

insert into local_account (idlocalaccount,email,fullname,passwordhash,deleted) values (1,"user@gmail.com","User User","user",0);

insert into local_account_role (idlocalaccount,idrole) values (1,1);
insert into local_account_role (idlocalaccount,idrole) values (1,2);
insert into local_account_role (idlocalaccount,idrole) values (1,3);
insert into local_account_role (idlocalaccount,idrole) values (1,4);