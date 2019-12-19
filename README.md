# VirtualDoctor
Implementation of ambulance organizational system like a three-layered structure using WPF and MySQL Client in .NET Core.
Tehnologies:
- MySql Database using MySqlClient provider     for .NET applications
- WPF application (.NET) using C# and XAML
- .NET Core class libraries
- Neo4
- Automapper

System purpose:
VirtualDoctor introduces new digital ways for manipulating healthcare informations, like personal health records, doctors, patients, ambulances with list of doctors who work there, possible doctor's specializations and titles. Also, each place has list of qualities. It gives support for future upgrade, with Neo4j database, that would allow user to check for symptoms and doctors to get list og all possible diseases that SATISFY specific criteria. That way patients can check if they really need to go to doctor and list of possible doctors for disease and doctors can get list of possible diseases for patient he examines. Symptom checker is not implemented in this version of system, so there is no connectiom between global and ambulance database.

Users:Depending on type of users, different features are enabled. Users are:
Doctors, Admins for places, ambulances, titles, specializations and doctors, Admins for health records, Patients

Details of implementation:
On frontend part paging is enabled on tables. Also there is option for changing language (Serbian, English). On backend, systems like EntityFramework are not used. Instead there is raw sql that MySql provider for .NET executes on db server. That way we get better performance and better control over sql commands and generally, sql language expressions. Not only that, but Command Pattern is used with System.Reflection to lower need for duplicating sql expressions in code, and that greatly improved code reusability and system agility. Just perfect. It also uses services as medium layer of three layer structure to make code even more reusable. It needs to be refactored so that each layer has its own models for inter and intra layer communication, but in this phase I choosed to decrease instead code duplication. 
As DI is not supported in WPF applications, I used tradicional Factory Methods for creating objects (for example Services). SOLID principles are followed. In backend part, in need for code maintability and reusability, I used different classes as ServiceExecutor for example and DbCommand, that are core and main classes of whole implementation, each with Single Responsability. See code for additional details or contact me on my email: marija.vanja.novakovic@gmail.com. 

Read also:
Some roles should be inserted in database before using it. That are OrganizationalAdmin, PatientAdmin, DoctorAdmin, AccountsAdmin. Also, password hashing needs to be implemented. For now, passwordhash in database is users raw password. This project was for course purposes, so some things are not properly implemented.