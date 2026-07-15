# Teacher_Management_System-Using-CSharp


Project Detail
1. Create a console application.
2. Use this connection string: "Data Source=.\\SQLEXPRESS;Initial
Catalog=CSharpB21;User ID=csharpb21;
Password=123456;TrustServerCertificate=True;"
3. You must include migration files otherwise you will get zero.
4. If your project does not compile and run, you will get zero. So make sure you commit
all necessary files and the project has no errors.
5. There will be two types of users, Admin and Teacher. Both can login using their
username and password. No user type will be provided. No prefix should be added in
username. Keep column for user type in database. Use the same user table. From
their username, the system should understand what type of user it is. They can also
logout. Here we are considering school teachers, not training centers. So no batches,
instead classes will be considered and no courses rather subjects will be considered.
6. Admin will assign a teacher to a class and a subject. One teacher can be assigned to
multiple classes and multiple subjects. Classes and subjects will be created before
assigning teachers to that class and subject. So the admin has to also maintain
(create/edit/delete/list) classes and subjects for each class.
7. Admin can create a teacher, edit, delete or see a list of teachers.
8. Teachers can create/edit/delete/view students for a particular class and subject (only
for the classes and subjects that the teacher is assigned to).
9. Teachers can give grades to a student for a particular subject for a particular class.
10. There will be 1st term, mid term and final term exams for each class. So the teacher
will be assigning grades for each term.
11. Teachers can see the term grades for each student and final grade for the whole
class at the end of final term. Imagine how it was done in schools when you studied
to understand the system. Our goal is to give this software to help school teachers to
manage grades.
12. Add data will be stored in the database so that school can later use it in future.
