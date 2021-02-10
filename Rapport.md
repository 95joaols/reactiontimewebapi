##Beskrivning av mina endpoints
de endpoints som jag använder mig av är:
(get)/Highscores/		     	 => hämta en IEnumerable<Highscore>
(Post)/Highscores/		      	=> skicka in Highscore i sparande
(Delete)/Highscores/		      	=> deleta alla Highscore 
(get)/Highscores/{id:int}	      	=> hämta en Highscore med dess id
(get)/Highscores/{username}	      	=> hämta en lista med alla andvändare som inerhåller det man söket
(Delete)/Highscores/{username}	=> deleta alla Highscore av den andvändaren.

Jag har inte gjort 100 % av de som man skulle göra för i (Post)/Highscores/ skulle man inte skicka någon tillbaka men i rest standard ska man skicka tillbaka det man skapat.
och jag skapade för rolighetens skull (Delete)/Highscores/{username} för att testa.

---

##Beskrivning av dataflödet mellan reaktionsspelet och webapiet


som det är uppbyggt så att de 3 stora projektetena är api, console och blazorna.
alla är kopplade med “ReactionGame.Entety”.
Jag kommer att tar och fokusera på blazorn(core) och api.
###HighscoreDataService

i blazor har jag klassen “HighscoreDataService” som håller kontakten med api(va HttpClient). När den tar och skapa en ny Highscore så skicka jag “PostAsJsonAsync” sen tar jag och kolla om jag har en response och om jag får StatusCode Created sen tar jag får ut Highscore som jag får tillbaka.
I HighscoreDataService har jag “GetHighscore<T, T1>(T1 input)” som jag tog och skapade en generisk metod för att slå ihop alla get. Jag gjorde den till att vara generisk genom att jag inte ville har 4 metoder som nästan gör samma sak. Men man få tänka på när man gör den till att vara generisk är att den blir svårare att debugga och felsöker för att det finns flera set som kan går fel som att man får tillbaka fel returtyp.
man sätter up GetHighscore genom att T är vad man arbetar med som Highscore eller IEnumerable<Highscore>. T måste vara en klass för att jag ska kunna skicka tillbaka null. man skulle kunna göra att man kan throw en Exception det är mer av vilken stil man har.
 T1 är vad man skicka in till metoden som int eller string. jag gör det för att jag vill har mer kontroll på vad jag skicka till api. däremot görs den till en sträng i metoden. Så man skulle kunna göra att man bara har en sträng, men om jag är ute efter ett id så är ett int bättre för att inte på misstag skicka en sträng som gör att man sår tillbaka flera T om man bara skulle har en. Om man vill har alla så sätter man T1 till att vara en sträng och bara skicka i metoden “” som gör att PostAsJsonAsync inte skicka något mer en / till api.
Jag använder mig av GetFromJsonAsync för att hämta och omvandla till T. Men Det som jag inte gillar med GetFromJsonAsync är att man inte får någon StatusCode. den kraschar om det som man få tillbaka är tom eller om man inte få tag i api. 
Det gör att det är svårare att få reda på vad som inte fungera. 
Om jag skulle använda mig av “GetAsync” skulle jag på mycket enkelt sätt få tag på StatusCode men det som gör att jag inte väller det i GetHighscore är att den är jobbigare att tar ut informationen och det gör att man inte på en snabb blick titta på corden och veta vad den gör..
Sen har jag de två deliet metoderna som är strate forward de kalla på “DeleteAsync” antingen med eller utan parameter.

###api
I api “HighscoresController” kommer de in request till api som automatisk sortera in i de metoder som är definierade i api.
i “GetHighscoresAsync” skickar jag tillbaka NoContent eller Ok beror på vad jag får tillbaka från IHighscoreRepository.
alla mina metoder skicka tillbaka ActionResult. Detta gör jag för att medela den som kallade apiet vad resultaten är och om den lykedes eller inte.
de resultat som jag skicka kan vara:
*Ok
*NoContent
*BadRequest
*CreatedAtAction
Genom de så meddelar jag vad som händer i api.

Jag har två metoder som söker efter specifik info bland Highscore GetHighscoresByIdAsync och GetHighscoresByUsernameAsync genom att få olika info.
GetHighscoresByIdAsync söker efter id och skicka tillbaka en Highscore medan GetHighscoresByUsernameAsync  söker efter en lista av Highscore deras användare innehåller det som man söker.
problemet är att de har samma endpoint men de har olika input som string och int.
För att låta programmet veta vilket som skulle till vilket ställe. Satte jag ”:int” i “[HttpGet("{id:int}")] ”.
Det gör att programmet vet att om det är int så går den dit annars går den till den andra.
Det finns några andra sätt att fixa detta på.
man kan andvända olika endpoint som “/id/” och “/username/”.
i url har “?username=”
men problemen med dessa är att det skulle bryta med vad uppgiften beskrivningen skulle vara.

Allt som skickas mellan api och källaren är json(om det är någon data som skickas).

---
##Egen bedömning
Jag tyckte inte att det var så jättesvår uppgift efter att man fick all kod så var det nästan allt klart. 
så jag började gå vidare och testa nya saker.
Den första som jag testade var “Unit Test”.
så jag började skapa tester till Repository för att veta att den fungera som den är tänkt.
Sedan hakade jag på med api och testar den också.
Sedan ville jag testa att skapa blazer som använde sig av api så jag skapade 3 projekt.
Blazor.Server
Blazor.WebAssembly
Blazor.Core (som har alla filer på sig)
Jag fick ihop ett enkel html

men jag tyckte att jag lärde mig av allt testande och att det var roligt att tästa på nya saker.
