NOTE:
TuBo has been registered on botframework.com and the url is https://dev.botframework.com/bots?id=TuBo
TuBo version 1.0.0 10/10/2016


ABOUT-

TuBo is an artificially intelligent Tutor Bot that helps school kids solve simple math problems by guiding them in a step by step manner and thus aiding them reach till the answer without actully spoonfeeding the answer.This intelligent tutor even facilitates the student to check her obtained answer for correctness.


CONFIGURATION INSTRUCTIONS-

The user need to connect the bot accross the microsoft bot framework emulator or can even connect through multiple client services like skype, facebook messenger, slack, email, etc. 


SMART FEARTUES-

a)TuBo is a very smart bot and can teach a student how to solve operation problems with each step explained explicitly.
b)It also accepts multiple operator queries and teaches the user as per the BODMAS rules.

c)The user may even ask her problems in natural language and the bot will understand english statements quite well.

d)It even solves linear equations in 1 variable.

e)It teaches the student to solve mensuration problems of finding area of square , rectangle and perimeter of square, rectangle and triangle.


EXAMPLE USAGE-
The user can directly ask her query to get the detailed explanation, or can even greet the tutor in the beginning to start a conversation.



POTENTIAL BUGS-

				 		    MAJOR LUIS BUGS
 
a)-LUIS does not identify 3 and higher digit numbers as an entity (even though number is a builtin entity.) so if the user gives a query such as 356+854, these numbers will just not be recognised by LUIS ,but the same query will work for 2 digit numbers and even for  combination of 2 and 3 digit numbers.

 b)-Another major bug is that LUIS does not give different entities to repeated numbers. For example, if one gives 5+5, it will not read the second 5. Because of this bug, ifthe user wants to find the area of a square, she must write dimensions as (side*side) instead of just (side).
	
					           OUR LIMITATIONS

a) we consider operations only on whole numbers.

b)linear equations have to be given in the form of a*x+b=c or a*x-b=c.


TRUBLESHOOTING-
a)Most of these bugs are actually beyond our control,and are inbuilt to LUIS.

b)we can increase the domain of our bot by including more mathematical features and even allow for float point values. We plan to include these features in future versions of TuBo.
 


CONTACT-

mail:
   ritveeka@outlook.com , ritveeka@iitg.ernet.in

	kotharipurva@outlook.com , p.kothari@iitg.ernet.in

	surabhi1947@outlook.com , surabhi.gupta@iitg.ernet.in




