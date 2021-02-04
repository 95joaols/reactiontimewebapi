## Inlämningsuppgift #1
### Fortsättningskurs C# Borås Yrkeshögskola 

Inlämning: Måndag den 15:e februari via GitHub Classroom.

Läs instruktionerna noggrant! 
Både funktionskrav samt rapport skall lämnas in. Rapporten skrivs i filen Rapport.md. Mer instruktioner angånde rapporten finns i filen i sig.

-------

## Uppgift: WebAPI och kommunikation

Uppgiften är att skapa ett WebAPI som hanterar highscores.
Apiet skall kunna ta emot data som sparar ett nytt highscore.
Du ska också kunna hämta ut alla highscores från apiet.

Apiet skall användas av det reaktionsspel vi gjorde i introkursen (en version av spelet finns med i uppgiften. Det är helt ok att använda detta projekt som utgångspunkt). Ett highscore-objekt finns att utgå från i reaktionstiddsspelet.

Flödet kan beskrivas så här:
1. När spelet startas laddas alla highscores ned via WebAPIet.
2. En spelare spelar reaktionspelet. 
3. Om spelaren får ett highscore får spelaren skriva in sitt namn.
4. Tiden och namnet skickas till WebAPI:et och lagras där på valfritt sätt.

## Funktionskrav

### **Krav för Godkänt**
* Både spel och WebApi skall gå att starta
* Spelet skall kunna hämta en lista på alla highscores via WebAPIet.
* Spelet skall kunna posta ett nytt highscore till WebAPIet.
* Spelet skall visa samtliga highscores mellan varje försök.
* JSON-formatet skall användas fö att skicka data mellan spelet och WebAPIet.
* De enpoints som skall finnas i ert API är definierade i denna tabell. Det är av yttersta vikt att ni följer denna specifikation till punkt och pricka!

| Metod | Endpoint | Beskrivning | Req. Body | Response body
| ------------ | ----------- | ---- | --------|---
| GET| /highscores | Hämta alla highscores | Ingen | Lista med highscores
| POST| /highscores |Lägg till nytt highscore |Ett highscore| Ingen


------

### **Ytterligare krav för Väl Godkänt**
* Använd LINQ där det är applicerbart
* Se till att hantera felaktig input till WebAPI
* Se till att returnera korrekt Response codes från dina endpoints
* Ytterligare endpoints som skall finnas för väl godkänt (de behöver inte vara implementerade i spelet i sig)

| Metod | Endpoint | Beskrivning | Req. Body | Response body
| ------------ | ----------- | ---- | --------|---
| GET| /highscores/{id} | Hämta highscore med ett visst ID |Ingen | Ett highscore
| GET| /highscores/{username} | Hämta alla highscores för ett visst användarnamn |Ingen | En lista med highscore
| DELETE| /highscores|Ta bort alla highscores| Ingen| Ingen

------

### Valfria strechgoal som inte betygssätts:
* Gör en enkel hemsida som via wwwroot och static files visar en lista med alla highscores med hjälp av javascript. 
