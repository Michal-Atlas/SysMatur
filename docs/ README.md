# No Name Given

## Design Concept

Webová stránka, kde si člověk může shrnout všechny své Feedy do jednoho.
Člověk by si nalinkoval všechny své ostatní sociální sítě, jako FB, IG, Reddit, Twitter,
a měl by z nich, jeden hezký feed.
Hodně stránek má vlastní API, ale mám iluzi toho,
že by možná bylo možné aby si člověk mohl vytvořit "post model" pro libovolnou stránku,
auth_token a sledovat tím jakoukoli část internetu.
Samozřejmně začnu pouze tím, že umožním použít pár základních API,
samozřejmě chci auth_tokeny uživatelům synchronizovat,
aby se uživatel pouze přihlásil svým účtem pro tuto stránku a měl všechny ostatní už připravené.
Pokud to jenom bude možné, měli by tu fungovat kvalitní RSS feedy.
Určitě bych to použil, a bezpochyby vidím stále lidi nejdříve otevřit Twitter a pak Instagram,
já bych alespoň nepřišel o to pokud by mi někdo psal na stránce kterou už nechci kontrolovat,
mimo jiné bych si spojil asi 8 různých míst, mohl bych mít jednu appku místo 5ti appek a 3 stránek.
Samozřejmě je to i lepší co do soukromý.
Pravděpodobně zde půjde použít klasicky Angular a ASP.NET, třeba Xamarin na aplikaci,
ale kdyby nebylo třeba žádné offline funkcionality tak by se dali použít i levné způsoby jako Cordova.

## Functional and Non-functional specification

### Functional

- Goals - Retrieve feeds from various sources and display them on one page
- The system will allow users to login and register
- A user has:
  - Feeds - a link to an external source of posts, with authentication
    - Depending on time constraints the feeds added will be
      - RSS
      - External API (Twitter and Reddit)
      - HTML Parser
  - Views - A user has views to which they can add feeds which they want to see on one page, basically acting as Feed Groups
- When viewing a post, depending on the feed type, the user should be able to interact with it, I.E.
  - Up/Downvote
  - View and Make Comments

### Non-Functional

- Log-in using third-party Auth0 provider
- ASP.NET WebAPI - for API
- Microsoft MS SQL database - for Database
- React.js - for frontend Website and API calls

## Functional Use Case Scripts

- **AuthenticateUser:**
  - If no authentication token is detected, an existing user will have to navigate to the login page, where they are presented with a form including a username, password and a submit button, and enter their username and password, to recieve a new one
  - **Exception:** If the username is not found in the database, the user will be informed of this fact and a suggestion will be made to register.
  - **Exception:** The password is incorrect, an invalid password warning is presented to the user.
- **RegisterUser:**
  - The user visits the register screen, where they are prompted essentially with an identical form to the login form, where the user enrolls a new user entry
  - **Exception:** If the username already exists the user is informed and the usercase restarts.
  - **Exception:** If the password does not meet the password policy, the user is informed, the password policy is displayed and the usercase restarts.
- **RemoveAuthentication:**
  - By clicking the Logout button the page will attempt to remove any and all locally stored authentication information.
- **ModifyFeeds:**
  - After navigating to the Feed management screen the user is presented with a list of their feeds each having an edit and delete button, as well as all the kept information about them, and a button to add a new feed.
  - If the user clicks add new, they are taken to a form where they enter information based on the type of feed and enroll it by clicking save, if the user clicked edit this form is pre-filled with that feed's information and changes it instead of adding a new one.
  - Deleting requires a secondary acceptance in a pop-up box
  - **Exception:** If the user wishes to cancel an edit, they click the cancel button in the edit form and the usecase restarts.
- **ShowView:**
  - On the main page, the user is greeted by a chronological post stream from their feeds
  - The user may use the sidebar to show and hide different feeds
  - **Exception:** No connectivity or unexpected response from one or more servers, will result in that feed being marked so
- **ReactToPost:**
  - Posts from feeds that support reactions, have reaction buttons and a comment entry field
  - **Exception:** The API call fails for some reason, An alert is displayed to the user, with a button that displays the entire JSON answer recieved.

## Conceptual Model

![Conceptual Model image](./model.png)
