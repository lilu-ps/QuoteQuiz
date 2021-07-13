1) The first page that opens when you run the project is Log In page.
You log in using username (email) and password. Below the login button is sign up link which directs you to the sign up page.
User signs up with email, first name, last name and password. Password is encrypted and then saved to database. If user already
exists with give email, then instead of registering a new user, the user stays at the same page.
(When user registers, their default setting (quote type) is set to binary).

2) When user signs up or logs in into their account, the first page displayed is the quiz page. On this page we see a quote and possible answers
(depending on the last question they answered and the quote type that they have at the given time). 
If user's setting is set to binary quotes, then below the quote we see the name of the possible author of the quote and yes and no options.
If user's setting is set to multiple choice, then we see multiple choice answers for the quote. After answering the question, result
of the users choice appears. Also appears the next button that displays next quote on the screen.

3) Second tab we have is the settings tab. It is pretty self-explanatory. In this tab there are to radio buttons with values - binary and multiple choice.
One of them is checked according to what quote type user has at the moment. User can switch quiz mode by clicking on the radio button.
In this case QuizController method ChangeMode is called with parameters - newModeId and userId and mode switch is saved in the database (user info is edited).

4) Third tab is review other users.
This tab calls reviewOtherUsers method which itself calls UserController action ReviewOthers which returns partial view of with list of other users. In this view we have a grid. Every row has username and link that 
transfers us to their game history (with quote and whether their chosen answer was correct or not displayed (chosen answer is not shown)).
If the user is Admin then in grid row next to "View User Games", we have disable and delete as well. They allow the admin to either disable
the user or delete them.

5) Manage Account tab calls goToUserManagement method which calls UserController action UserManagement which returns partial view. In this partial view
we have 4 fields (email, first name, last name and password). If the user whats to change any of them, then they write in the fields
and then click "Save Changes" button which calls modifyUser js method. this method calls UserController action ModifyUser which saves 
every modified information in the database. 
In account management view we also see three options - disable user,  delete user, and log out. They call DisableUser, DeleteUser and LogOut actions from UserController
accordingly.In all these three cases, we are redirected to the log in page.

6) Review My History tab calls js method reviewMyHistory which calls UserController action getUserGames which displays the view 
similar to the one that would open by clicking one of the users from the "Review Other Users" tab grid. But in this case we see out own
history.

There are two projects in the solution - QuoteQuizAPI and QuoteQuizEntity.
QuoteQuizEntity consists of database models (in the Entities folder), Migrations and scrips.
In scripts folder we have DataBaseBackup - the script that I used originally to add information to the database.

QuoteQuizAPI consists of Models, Controllers, Services, Views, Constants.

In Models view folder there are all the models  that I used(few that are direct match to the database models
and also additional ones that I needed).

In Controllers folder there are four controllers - Home, Quiz, Quote, User.

In Services folder I have interfaces for the services and the services themselves. I call these
service methods from controllers so the controllers are not directly modifying the database.
css and js files are in wwwroot.

In Controllers folder there are to files - ModeConstants and UserConstants. I created these files
to compare modes and user types easily and to not over use constants in the code.

In Views folder there is another folder Home in which we have Index.cshtml. In this view we have two divs - tab-bar and quiz view.
tab-bar stays the same through all the account operations whilst quiz view changes according
to in which tab we are in.

The first view that is shown when we run the program is Login.cshtml.
I use models in these views to access all the information I need in it.
